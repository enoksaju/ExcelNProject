using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace libProduccionDataBase {
	public class Auxiliares {
		/// <summary>
		/// Transforma un string en un valor de enumeracion y lo asigna a una propiedad del tipo de la enumeracion
		/// </summary>
		/// <typeparam name="t">Tipo de la Enumeracion</typeparam>
		/// <param name="Property">Propiedad del objecto al que se le asignara el valor(Debe ser del tipo de la enumeración)</param>
		/// <param name="value">string con el valor a asiganr</param>
		public static void SetEnumProp<t> ( t Property , string value ) {
			try {
				Property = ( t ) Enum.Parse ( typeof ( t ) , value );
			} catch ( Exception ) {
				throw new Exception ( "No se puede asignar el valor: " + value + " a la propiedad " + typeof ( t ).Name );
				;
			}
		}

		/// <summary>
		/// Devuelve la Excepcion mas profunda.
		/// </summary>
		/// <param name="Ex">Excepcion a analizar</param>
		/// <returns></returns>
		public static string GetInnerException ( Exception Ex ) {
			if ( Ex.InnerException != null ) {
				return GetInnerException ( Ex.InnerException );
			} else {
				return Ex.Message;
			}
		}

		/// <summary>
		/// Devuelve una lista con los errores del entity.
		/// </summary>
		/// <param name="DB">Contexto que se analizara</param>
		/// <returns></returns>
		public static List<System.Data.Entity.Validation.DbValidationError> GetErrors ( Contexto.DataBaseContexto DB ) {
			List<System.Data.Entity.Validation.DbValidationError> Returned = new List<System.Data.Entity.Validation.DbValidationError> ( );
			DB.GetValidationErrors ( ).ToList ( ).ForEach ( o => { Returned.AddRange ( o.ValidationErrors ); } );
			return Returned;
		}
		public static string ValidationAndErrorMessages ( Contexto.DataBaseContexto DB , Exception Ex ) {
			var errors = GetErrors ( DB );
			var strBld = new StringBuilder ( );
			if ( errors.Count > 0 ) {
				errors.ForEach ( err => {
					strBld.AppendFormat ( "• {0}.\n" , err.ErrorMessage );
				} );
				return strBld.ToString ( );
			} else {
				return GetInnerException ( Ex );
			}
		}

		public static ValidateEntryResult ValidateEntry ( Contexto.DataBaseContexto DB , object Entry ) => new ValidateEntryResult ( DB.Entry ( Entry ).GetValidationResult ( ) );

		public class ValidateEntryResult {
			
			public bool IsValid { get; set; }
			public string ValidationErrorsString {
				get {
					var strBld = new StringBuilder ( );
					foreach ( var err in this.ValidationErrors ) {
						strBld.AppendFormat ( "• {0}.\n" , err.ErrorMessage );
					}
					return strBld.ToString ( );
				}
			}

			public EntityState State { get; }
			public ICollection<System.Data.Entity.Validation.DbValidationError> ValidationErrors { get; set; }
			public ValidateEntryResult ( System.Data.Entity.Validation.DbEntityValidationResult Result ) {
				this.IsValid = Result.IsValid;
				this.ValidationErrors = Result.ValidationErrors;
				this.State = Result.Entry.State;
			}

		}

		public static CustomModelState Validate ( object Entity ) => CustomModelState.Validate ( Entity );

		public static bool IsInRol ( Identity.ApplicationUserManager UserManager , Identity.ApplicationUser User , params string [ ] roles ) {
			foreach ( var rol in roles.ToList ( ) ) {
				if ( UserManager.IsInRole ( User.Id , rol ) ) {
					return true;
				}
			}
			return false;
		}

		public class CustomModelState {
			public ICollection<ValidationResult> Result;
			public bool isValid;
			public CustomModelState ( object Entity ) {
				ValidationContext vc = new ValidationContext ( Entity );
				Result = new List<ValidationResult> ( );
				isValid = Validator.TryValidateObject ( Entity , vc , Result );
			}

			public string ValidationErrorsString {
				get {
					var strBld = new StringBuilder ( );
					foreach ( var err in Result  ) {
						strBld.AppendFormat ( "• {0}.\n" , err.ErrorMessage );
					}
					return strBld.ToString ( );
				}
			}
			public static CustomModelState Validate ( object Entity ) => new CustomModelState ( Entity );
		}

		public static class StringKript {
			// This constant is used to determine the keysize of the encryption algorithm in bits.
			// We divide this by 8 within the code below to get the equivalent number of bytes.
			private const int Keysize = 256;

			// This constant determines the number of iterations for the password bytes generation function.
			private const int DerivationIterations = 1000;

			public static string Encrypt ( string plainText , string passPhrase ) {
				// Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
				// so that the same Salt and IV values can be used when decrypting.  
				var saltStringBytes = Generate256BitsOfRandomEntropy ( );
				var ivStringBytes = Generate256BitsOfRandomEntropy ( );
				var plainTextBytes = Encoding.UTF8.GetBytes ( plainText );
				using ( var password = new Rfc2898DeriveBytes ( passPhrase , saltStringBytes , DerivationIterations ) ) {
					var keyBytes = password.GetBytes ( Keysize / 8 );
					using ( var symmetricKey = new RijndaelManaged ( ) ) {
						symmetricKey.BlockSize = 256;
						symmetricKey.Mode = CipherMode.CBC;
						symmetricKey.Padding = PaddingMode.PKCS7;
						using ( var encryptor = symmetricKey.CreateEncryptor ( keyBytes , ivStringBytes ) ) {
							using ( var memoryStream = new MemoryStream ( ) ) {
								using ( var cryptoStream = new CryptoStream ( memoryStream , encryptor , CryptoStreamMode.Write ) ) {
									cryptoStream.Write ( plainTextBytes , 0 , plainTextBytes.Length );
									cryptoStream.FlushFinalBlock ( );
									// Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
									var cipherTextBytes = saltStringBytes;
									cipherTextBytes = cipherTextBytes.Concat ( ivStringBytes ).ToArray ( );
									cipherTextBytes = cipherTextBytes.Concat ( memoryStream.ToArray ( ) ).ToArray ( );
									memoryStream.Close ( );
									cryptoStream.Close ( );
									return Convert.ToBase64String ( cipherTextBytes );
								}
							}
						}
					}
				}
			}

			public static string Decrypt ( string cipherText , string passPhrase ) {
				// Get the complete stream of bytes that represent:
				// [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
				var cipherTextBytesWithSaltAndIv = Convert.FromBase64String ( cipherText );
				// Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
				var saltStringBytes = cipherTextBytesWithSaltAndIv.Take ( Keysize / 8 ).ToArray ( );
				// Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
				var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip ( Keysize / 8 ).Take ( Keysize / 8 ).ToArray ( );
				// Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
				var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip ( ( Keysize / 8 ) * 2 ).Take ( cipherTextBytesWithSaltAndIv.Length - ( ( Keysize / 8 ) * 2 ) ).ToArray ( );

				try {
					using ( var password = new Rfc2898DeriveBytes ( passPhrase , saltStringBytes , DerivationIterations ) ) {
						var keyBytes = password.GetBytes ( Keysize / 8 );
						using ( var symmetricKey = new RijndaelManaged ( ) ) {
							symmetricKey.BlockSize = 256;
							symmetricKey.Mode = CipherMode.CBC;
							symmetricKey.Padding = PaddingMode.PKCS7;
							using ( var decryptor = symmetricKey.CreateDecryptor ( keyBytes , ivStringBytes ) ) {
								using ( var memoryStream = new MemoryStream ( cipherTextBytes ) ) {
									using ( var cryptoStream = new CryptoStream ( memoryStream , decryptor , CryptoStreamMode.Read ) ) {
										var plainTextBytes = new byte [ cipherTextBytes.Length ];
										var decryptedByteCount = cryptoStream.Read ( plainTextBytes , 0 , plainTextBytes.Length );
										memoryStream.Close ( );
										cryptoStream.Close ( );
										return Encoding.UTF8.GetString ( plainTextBytes , 0 , decryptedByteCount );
									}
								}
							}
						}
					}
				} catch ( Exception ) {
					return "";
				}


			}

			private static byte [ ] Generate256BitsOfRandomEntropy ( ) {
				var randomBytes = new byte [ 32 ]; // 32 Bytes will give us 256 bits.
				using ( var rngCsp = new RNGCryptoServiceProvider ( ) ) {
					// Fill the array with cryptographically secure random bytes.
					rngCsp.GetBytes ( randomBytes );
				}
				return randomBytes;
			}
		}

	}

	namespace Tablas {
		public class ObservableListSource<T> : ObservableCollection<T>, IListSource where T : class {

			private IBindingList _bindingList;


			bool IListSource.ContainsListCollection => false;


			IList IListSource.GetList ( ) => _bindingList ?? ( _bindingList = this.ToBindingList ( ) );

		}
	}
}
