using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace libControlesPersonalizados.ZPLCONVERTER {
	public class zplImageConverter : Component, IBindableComponent {
		private int blackLimit = 125;
		private int total;
		private int widthBytes;
		private bool compressHex = true;
		private int lengToSplit = 40;

		public int BlacknessLimitPercentage {
			get {
				return ( blackLimit * 100 / 255 );
			}
			set {
				blackLimit = ( value * 255 / 100 );
			}
		}

		public bool CompressHex {
			get { return compressHex; }
			set { compressHex = value; }
		}

		private Image _image = null;

		public Image Image {
			get { return _image; }
			set {
				_image = value;
			}
		}

		public string zplValue {
			get {
				return this._image != null ? FromImage ( ( Bitmap ) this._image ) : "^A0,10,8^FDError!";
			}
		}

		public Image ImageResult {
			get {
				try {
					return ZPLtoImage ( zplValue );
				} catch {
					return null;
				}
			}
		}
		public int LengToSplit {
			get {
				return lengToSplit;
			}

			set {
				lengToSplit = value;
			}
		}


		#region IBindableComponent Members
		private BindingContext bindingContext;
		private ControlBindingsCollection dataBindings;
		[Browsable ( false )]
		public BindingContext BindingContext {
			get {
				if ( bindingContext == null ) {
					bindingContext = new BindingContext ( );
				}
				return bindingContext;
			}
			set {
				bindingContext = value;
			}
		}
		[DesignerSerializationVisibility ( DesignerSerializationVisibility.Content )]
		public ControlBindingsCollection DataBindings {
			get {
				if ( dataBindings == null ) {
					dataBindings = new ControlBindingsCollection ( this );
				}
				return dataBindings;
			}
		}


		#endregion

		private static Dictionary<int , string> mapCode = new Dictionary<int , string> ( ) {
			{ 1,"G"},
			{ 2,"H"},
			{ 3,"I"},
			{ 4,"J"},
			{ 5,"K"},
			{ 6,"L"},
			{ 7,"M"},
			{ 8,"N"},
			{ 9,"O"},
			{ 10, "P"},
			{ 11, "Q"},
			{ 12, "R"},
			{ 13, "S"},
			{ 14, "T"},
			{ 15, "U"},
			{ 16, "V"},
			{ 17, "W"},
			{ 18, "X"},
			{ 19, "Y"},
			{ 20, "g"},
			{ 40, "h"},
			{ 60, "i"},
			{ 80, "j"},
			{ 100, "k"},
			{ 120, "l"},
			{ 140, "m"},
			{ 160, "n"},
			{ 180, "o"},
			{ 200, "p"},
			{ 220, "q"},
			{ 240, "r"},
			{ 260, "s"},
			{ 280, "t"},
			{ 300, "u"},
			{ 320, "v"},
			{ 340, "w"},
			{ 360, "x"},
			{ 380, "y"},
			{ 400, "z"},
		};


		public string FromImage ( Bitmap image ) {
			string cuerpo = createBody ( image );

			if ( compressHex )
				cuerpo = HexToAscii ( cuerpo );
			return headDoc ( ) + cuerpo + "\n^FS";
		}
		private string createBody ( Bitmap OriginalImage ) {
			StringBuilder sb = new StringBuilder ( );
			// Graphics graphics = Graphics.FromImage( orginalImage);
			// graphics.DrawImage( orginalImage, 0, 0 );

			Bitmap clonedImage = ( Bitmap ) OriginalImage.Clone ( );


			int height = clonedImage.Height;
			int width = clonedImage.Width;
			int index = 0;
			// int rgb;
			int red;
			int green;
			int blue;
			char [ ] auxBinaryChar = new char [ ] { '0' , '0' , '0' , '0' , '0' , '0' , '0' , '0' };

			widthBytes = ( width / 8 );

			if ( ( ( width % 8 ) > 0 ) ) {
				widthBytes = ( ( ( int ) ( ( width / 8 ) ) ) + 1 );
			} else {
				widthBytes = ( width / 8 );
			}

			this.total = ( widthBytes * height );


			for ( int h = 0; h < height; h++ ) {
				for ( int w = 0; w < width; w++ ) {
					var rgb = clonedImage.GetPixel ( w , h );
					red = rgb.R;
					green = rgb.G;
					blue = rgb.B;

					char auxChar = '1';


					int totalColor = ( red + green + blue ) / 3;


					if ( ( totalColor > blackLimit || rgb.A <= blackLimit ) )
						auxChar = '0';


					auxBinaryChar [ index ] = auxChar;
					index++;

					if ( ( ( index == 8 ) || ( w == ( width - 1 ) ) ) ) {
						sb.Append ( ByteBinary ( new string ( auxBinaryChar ) ) );

						auxBinaryChar = new char [ ] { '0' , '0' , '0' , '0' , '0' , '0' , '0' , '0' };
						index = 0;
					}
				}

				sb.Append ( "\n" );
			}

			clonedImage.Dispose ( );
			return sb.ToString ( );
		}



		private string ByteBinary ( string binary ) {
			int dec = Convert.ToInt32 ( binary , 2 );//int.Parse(binaryStr);//Integer.parseInt(binaryStr,2);
			if ( dec > 15 ) {
				return dec.ToString ( "X" ).ToUpper ( );//int.toString( dec, 16 ).toUpperCase();
			} else {
				return "0" + dec.ToString ( "X" ).ToUpper ( );//Integer.toString( dec, 16 ).toUpperCase();
			}
		}
		private string HexToAscii ( string code ) {
			int maxlinea = widthBytes * 2;

			StringBuilder sbCode = new StringBuilder ( );
			StringBuilder sbLinea = new StringBuilder ( );
			String previousLine = null;
			int counter = 1;

			char aux = code [ 0 ];

			bool firstChar = false;

			for ( int i = 1; i < code.Length; i++ ) {
				var d = code [ i ];

				if ( firstChar ) {
					aux = code [ i ];
					firstChar = false;
					continue;
				}
				if ( code [ i ] == '\n' ) {
					if ( counter >= maxlinea && aux == '0' ) {
						sbLinea.Append ( "," );
					} else if ( counter >= maxlinea && aux == 'F' ) {
						sbLinea.Append ( "!" );
					} else if ( counter > 20 ) {
						int multi20 = ( counter / 20 ) * 20;
						int resto20 = ( counter % 20 );

						sbLinea.Append ( mapCode [ multi20 ] );

						if ( resto20 != 0 ) {
							sbLinea.Append ( mapCode [ resto20 ] + aux );
						} else {
							sbLinea.Append ( aux );
						}
					} else {
						sbLinea.Append ( mapCode [ counter ] + aux );
						if ( mapCode [ counter ] == null ) { }
					}
					counter = 1;
					firstChar = true;
					if ( sbLinea.ToString ( ).Equals ( previousLine ) ) {
						sbCode.Append ( ":" );
					} else {
						sbCode.Append ( sbLinea.ToString ( ) );
					}

					//sbCode.Append( "\n" );
					previousLine = sbLinea.ToString ( );
					sbLinea.Clear ( );//.setLength( 0 );
					continue;
				}
				if ( aux == code [ i ] ) {
					counter++;
				} else {
					if ( counter > 20 ) {
						int multi20 = ( counter / 20 ) * 20;
						int resto20 = ( counter % 20 );
						sbLinea.Append ( mapCode [ multi20 ] );
						if ( resto20 != 0 ) {
							sbLinea.Append ( mapCode [ resto20 ] + aux );
						} else {
							sbLinea.Append ( aux );
						}
					} else {
						sbLinea.Append ( mapCode [ counter ] + aux );
					}
					counter = 1;
					aux = code [ i ];
				}
			}


			StringBuilder strBldRes = new StringBuilder ( );

			for ( int i = 0; i < sbCode.Length; i += LengToSplit ) {
				strBldRes.AppendFormat ( "\t{0}\n" , sbCode.ToString ( ).Substring ( i , i + LengToSplit <= sbCode.Length ? LengToSplit : sbCode.Length - i ) );
			}

			var y = strBldRes.ToString ( );

			return y;
		}


		public string AsciiToHex ( string code ) {
			string TempValue = "";


			StringBuilder stb = new StringBuilder ( );
			string previewValue = "";


			Regex t = new Regex ( "[0-9A-Yg-z,:!]{25,}" );
			var y = t.Match ( code , 0 );

			Regex valuesRegex = new Regex ( "(GFA,)[0-9]+(,)[0-9]+(,){1}[0-9]+" );

			var values = valuesRegex.Match ( code , 0 )?.Value.Split ( ',' );
			int widthBytesLocal = ( int.Parse ( values [ 3 ] ) * 2 );

			if ( y != null ) {
				//string CodeImage= y.Value;
				Regex regx = new Regex ( "(GFA,)[0-9]+(,){1}[0-9]+(,){1}[0-9]+(,){1}" );
				string CodeImage = regx.Replace ( y.Value , "" );

				for ( int i = 0; i < CodeImage.Length; i++ ) {
					if ( CodeImage [ i ] == ',' ) {
						previewValue = new string ( '0' , widthBytesLocal );
						stb.AppendFormat ( "{0}\n" , previewValue );
					} else if ( CodeImage [ i ] == '!' ) {
						previewValue = new string ( 'F' , widthBytesLocal );
						stb.AppendFormat ( "{0}\n" , previewValue );
					} else if ( CodeImage [ i ] == ':' ) {
						stb.AppendFormat ( "{0}\n" , previewValue );
					} else {
						var val = CodeImage [ i ].ToString ( );
						var val2 = CodeImage [ i + 1 >= CodeImage.Length ? i : i + 1 ].ToString ( );
						var val3 = CodeImage [ i + 2 >= CodeImage.Length ? ( i + 1 >= CodeImage.Length ? i : i + 1 ) : i + 2 ].ToString ( );

						int key1 = mapCode.FirstOrDefault ( x => x.Value == CodeImage [ i ].ToString ( ) ).Key;
						int key2;

						if ( key1 > 19 ) {
							key2 = mapCode.FirstOrDefault ( x => x.Value == CodeImage [ i + 1 ].ToString ( ) ).Key;

							if ( key2 == 0 ) {
								TempValue += new string ( CodeImage [ i + 1 ] , key1 );
								i += 1;
							} else {
								TempValue += new string ( CodeImage [ i + 2 ] , key1 + key2 );
								i += 2;
							}
						} else if ( key1 < 20 ) {
							TempValue += new string ( CodeImage [ i + 1 ] , key1 );
							i += 1;
						}

						if ( TempValue.Length == widthBytesLocal ) {

							previewValue = TempValue;
							stb.AppendFormat ( "{0}\n" , previewValue );
							TempValue = "";


						}

					}
				}


			}
			return stb.ToString ( );
		}

		private ZXing.BarcodeWriter BarcodeWriter = new ZXing.BarcodeWriter ( );
		private ZXing.BarcodeWriterSvg BCsvg = new ZXing.BarcodeWriterSvg ( );

		/// <summary>
		/// Convierte un <c>string</c> con Codigo ZPL a un objeto tipo <c>Image</c>.
		/// </summary>
		/// <param name="Code"><c>string</c> del codigo ZPL</param>
		/// <returns>Una imagen generada con el codigo ZPL</returns>
		/// <example>
		/// <code>
		/// 
		/// Image Img= previewLabel("^XA ^FO50,50^A0N,20,20^FDHola Mundo^FS^XZ");
		/// 
		/// PictureBox1.Image= Img;
		/// 
		/// </code>
		/// </example>
		public Image previewLabel ( string Code , double _ScaleLabel = 0.5 , int widthLabel = 4 , int heightLabel = 2 ) {

			string [ ] ToAnalize = Regex
				.Split ( Code.Replace ( "\r\n" , "" ) , @"(?=\^XA)" )
				.Where ( x => x.Contains ( "^XZ" ) )
				.ToArray ( );

			var Resolution = ( int ) ( 203 * _ScaleLabel );


			var totalWidth = Resolution * widthLabel;
			var totalHeight = ( Resolution * heightLabel ) * ToAnalize.Count ( );

			Bitmap toRet = new Bitmap ( ( int ) totalWidth + 5 , ( int ) totalHeight + 5 );
			Graphics gp = Graphics.FromImage ( toRet );

			var cnt = 0;

			try {
				foreach ( var lbl in ToAnalize ) {

					var indexy = cnt;
					var offsetY = ( int ) ( Resolution * heightLabel ) * indexy;
					gp.ResetTransform ( );
					gp.TranslateTransform ( 0 , offsetY );

					var rect = new Rectangle ( 0 , 0 , ( int ) ( Resolution * widthLabel ) - 2 , ( int ) ( Resolution * heightLabel ) - 2 );
					gp.FillRectangle ( Brushes.White , rect );
					gp.DrawRectangle ( Pens.Red , rect );

					cnt++;

					var Fields = Regex.Split ( lbl
					.Replace ( "^XA" , "" )
					.Replace ( "^XZ" , "" )
					, @"(?=\^FO)" ).ToList ( );

					Fields.Sort ( ( a , b ) => {

						var one = Regex.Match ( a , "(GFA)|(A0)|(GB)|(B[3AQ])" ).Value;
						var two = Regex.Match ( b , "(GFA)|(A0)|(GB)|(B[3AQ])" ).Value;

						int oneI = one == "GBA" ? 1 : ( one == "A0" ? 3 : ( one == "GB" ? 2 : 0 ) );
						int twoI = two == "GBA" ? 1 : ( two == "A0" ? 3 : ( two == "GB" ? 2 : 0 ) );

						return oneI.CompareTo ( twoI );

					} );

					foreach ( var fld in Fields ) {
						if ( fld.Contains ( "^GFA" ) ) {
							var splData = Regex.Split ( fld.Replace ( "^FS" , "" ) , @"\^" );
							var _point = splData.FirstOrDefault ( t => t.Contains ( "FO" ) ).Remove ( 0 , 2 ).Split ( ',' );
							Point imgPoint = new Point ( ( int ) ( int.Parse ( _point [ 0 ] ) * _ScaleLabel ) , ( int ) ( int.Parse ( _point [ 1 ] ) * _ScaleLabel ) );

							var code = Regex.Split ( fld.Replace ( " " , "" ) , @"(\^GFA,[0-9]+,[0-9]+,[0-9]+,)" );

							using ( var img = this.ZPLtoImage ( code [ 0 ] + '\n' + code [ 1 ] + '\n' + code [ 2 ] ) ) {
								gp.DrawImage ( img , imgPoint.X , imgPoint.Y , ( float ) ( img.Width * _ScaleLabel ) , ( float ) ( img.Height * _ScaleLabel ) );
							}
						} else if ( fld.Contains ( "^A" ) && fld.Contains ( "^FD" ) && fld.Contains ( "^FB" ) ) {
							var splData = Regex.Split ( fld , @"\^" );
							var _point = splData.FirstOrDefault ( t => t.Contains ( "FO" ) ).Remove ( 0 , 2 ).Split ( ',' );
							var _fieldData = splData.FirstOrDefault ( t => t.Contains ( "FD" ) ).Remove ( 0 , 2 ).TrimEnd ( ) ?? "";
							var _sizeFont = splData.FirstOrDefault ( t => t.Contains ( "A0" ) ).Split ( ',' );
							var _BlockData = splData.FirstOrDefault ( t => t.Contains ( "FB" ) ).Remove ( 0 , 2 ).Split ( ',' );

							var angle = 0;
							var isRotated = Regex.IsMatch ( _sizeFont [ 0 ] , @"(A0)[NRIB]{1}" );
							if ( isRotated ) {
								angle = _sizeFont [ 0 ].Contains ( "N" ) ? 0 : _sizeFont [ 0 ].Contains ( "R" ) ? 90 : _sizeFont [ 0 ].Contains ( "I" ) ? 180 : _sizeFont [ 0 ].Contains ( "B" ) ? 270 : 0;
							}

							Point lblPoint = new Point ( ( int ) ( int.Parse ( _point [ 0 ] ) * _ScaleLabel ) , ( int ) ( int.Parse ( _point [ 1 ] ) * _ScaleLabel ) );


							double heightFont = int.Parse ( _sizeFont [ 1 ] );
							double widthFont = int.Parse ( _sizeFont [ 2 ] );

							Font fnt = new Font ( "Arial"
								, ( int ) ( heightFont * 9.5 )
								, FontStyle.Regular
								, GraphicsUnit.Pixel
								);


							var y = gp.MeasureString ( _fieldData , fnt );


							double widthRectangle = int.Parse ( _BlockData [ 0 ] ) * 10;
							double heightRectangle = ( y.Height + 2 ) * ( int.Parse ( _BlockData [ 1 ] ) );

							Rectangle rectangle = new Rectangle ( new Point ( 0 , 0 ) , new Size ( ( int ) widthRectangle , ( int ) heightRectangle ) );

							StringAlignment stA = StringAlignment.Near;
							switch ( _BlockData [ 3 ].Trim ( ).First ( ) ) {
								case 'L':
									stA = StringAlignment.Near;
									break;
								case 'C':
									stA = StringAlignment.Center;
									break;
								case 'R':
									stA = StringAlignment.Far;
									break;
								case 'J':
									stA = StringAlignment.Near;
									break;
							}

							using ( Bitmap bpStr = new Bitmap (
								angle == 0 || angle == 180 ? ( int ) widthRectangle : ( int ) heightRectangle ,
								angle == 0 || angle == 180 ? ( int ) heightRectangle : ( int ) widthRectangle )
								) {
								using ( Graphics gpD = Graphics.FromImage ( bpStr ) ) {
									switch ( angle ) {
										case 0:
											gpD.TranslateTransform ( 0 , 0 );
											break;
										case 90:
											gpD.TranslateTransform ( ( float ) bpStr.Width , 0 );
											break;
										case 180:
											gpD.TranslateTransform ( ( float ) bpStr.Width , ( float ) bpStr.Height );
											break;
										case 270:
											gpD.TranslateTransform ( 0 , ( float ) bpStr.Height );
											break;
									}

									gpD.RotateTransform ( angle );
									gpD.DrawString ( _fieldData , fnt , Brushes.Black , rectangle , new StringFormat { Alignment = stA } );
								}

								gp.DrawImage (
									bpStr
									, lblPoint.X
									, lblPoint.Y
									, ( float ) ( angle == 0 || angle == 180 ? ( rectangle.Width / 10.5 * _ScaleLabel ) : ( rectangle.Height / 10.5 * _ScaleLabel ) )
									, ( float ) ( angle == 0 || angle == 180 ? ( rectangle.Height / 10.5 * _ScaleLabel ) : ( rectangle.Width / 10.5 * _ScaleLabel ) )
									);
							}

						} else if ( fld.Contains ( "^A" ) && fld.Contains ( "^FD" ) && !fld.Contains ( "^FB" ) ) {
							var splData = Regex.Split ( fld.Replace ( "^FS" , "" ) , @"\^" );
							var _point = splData.FirstOrDefault ( t => t.Contains ( "FO" ) ).Remove ( 0 , 2 ).Split ( ',' );
							var _fieldData = splData.FirstOrDefault ( t => t.Contains ( "FD" ) ).Remove ( 0 , 2 ).TrimEnd ( ) ?? " ";
							var _sizeFont = splData.FirstOrDefault ( t => t.Contains ( "A0" ) ).Split ( ',' );

							var angle = 0;
							var isRotated = Regex.IsMatch ( _sizeFont [ 0 ] , @"(A0)[NRIB]{1}" );
							if ( isRotated ) {
								angle = _sizeFont [ 0 ].Contains ( "N" ) ? 0 : _sizeFont [ 0 ].Contains ( "R" ) ? 90 : _sizeFont [ 0 ].Contains ( "I" ) ? 180 : _sizeFont [ 0 ].Contains ( "B" ) ? 270 : 0;
							}

							Point lblPoint = new Point ( ( int ) ( int.Parse ( _point [ 0 ] ) * _ScaleLabel ) , ( int ) ( int.Parse ( _point [ 1 ] ) * _ScaleLabel ) );

							double heightData = int.Parse ( _sizeFont [ 1 ] );
							var y = gp.MeasureString ( _fieldData , new Font ( "Arial" , ( int ) heightData * 10 ) );

							double widthData = y.Width / 14.5;

							using ( Bitmap bpStr = new Bitmap (
								angle == 0 || angle == 180 ?
								( int ) ( _fieldData.Trim ( ) != string.Empty ? y.Width : 10 ) :
								( int ) ( _fieldData.Trim ( ) != string.Empty ? y.Height : 10 )
								,
								angle == 0 || angle == 180 ?
								( int ) ( _fieldData.Trim ( ) != string.Empty ? y.Height : 10 ) :
								( int ) ( _fieldData.Trim ( ) != string.Empty ? y.Width : 10 )

								) ) {

								using ( Graphics gpD = Graphics.FromImage ( bpStr ) ) {

									switch ( angle ) {
										case 0:
											gpD.TranslateTransform ( 0 , 0 );
											break;
										case 90:
											gpD.TranslateTransform ( ( float ) bpStr.Width , 0 );
											break;
										case 180:
											gpD.TranslateTransform ( ( float ) bpStr.Width , ( float ) bpStr.Height );
											break;
										case 270:
											gpD.TranslateTransform ( 0 , ( float ) bpStr.Height );
											break;
									}

									gpD.RotateTransform ( angle );
									gpD.DrawString ( _fieldData , new Font ( "Arial" , ( int ) heightData * 10 ) , Brushes.Black , 0 , 0 );
								}

								gp.DrawImage ( bpStr ,
									lblPoint.X ,
									lblPoint.Y ,
									( float ) ( ( angle == 0 || angle == 180 ? ( ( float ) widthData * int.Parse ( _sizeFont [ 2 ] ) ) / int.Parse ( _sizeFont [ 1 ] ) : ( float ) heightData ) * _ScaleLabel ) ,
									( float ) ( ( angle == 0 || angle == 180 ? ( float ) heightData : ( ( float ) widthData * int.Parse ( _sizeFont [ 2 ] ) ) / int.Parse ( _sizeFont [ 1 ] ) ) * _ScaleLabel ) );

							}
						} else if ( fld.Contains ( "^GB" ) ) {
							var splData = Regex.Split ( fld.Replace ( "^FS" , "" ) , @"\^" );
							var _point = splData.FirstOrDefault ( t => t.Contains ( "FO" ) ).Remove ( 0 , 2 ).Split ( ',' );
							Point rectPoint = new Point ( ( int ) ( int.Parse ( _point [ 0 ] ) * _ScaleLabel ) , ( int ) ( int.Parse ( _point [ 1 ] ) * _ScaleLabel ) );

							var _sizeRect = splData.FirstOrDefault ( t => t.Contains ( "GB" ) ).Remove ( 0 , 2 ).Split ( ',' );
							Size rectSize = new Size ( ( int ) ( int.Parse ( _sizeRect [ 0 ] ) * _ScaleLabel ) , ( int ) ( int.Parse ( _sizeRect [ 1 ] ) * _ScaleLabel ) );
							Rectangle rec = new Rectangle ( rectPoint , rectSize );

							using ( Pen pn = new Pen ( Brushes.Black , ( int ) ( int.Parse ( _sizeRect [ 2 ] ) * _ScaleLabel ) ) ) {
								gp.DrawRectangle ( pn , rec );
							}

						} else if ( fld.Contains ( "^B3" ) ) {

							var splData = Regex.Split ( fld.Replace ( "^FS" , "" ) , @"\^" );
							var _point = splData.FirstOrDefault ( t => t.Contains ( "FO" ) ).Remove ( 0 , 2 ).Split ( ',' );
							var _fieldData = splData.FirstOrDefault ( t => t.Contains ( "FD" ) ).Remove ( 0 , 2 ).TrimEnd ( ) ?? "000000";
							var _BcodeD = splData.FirstOrDefault ( t => t.Contains ( "B3" ) ).Split ( ',' );
							Point imgPoint = new Point ( ( int ) ( int.Parse ( _point [ 0 ] ) * _ScaleLabel ) , ( int ) ( int.Parse ( _point [ 1 ] ) * _ScaleLabel ) );

							var angle = 0;
							var isRotated = Regex.IsMatch ( _BcodeD [ 0 ] , @"(B3)[NRIB]{1}" );
							if ( isRotated ) {
								angle = _BcodeD [ 0 ].Contains ( "N" ) ? 0 : _BcodeD [ 0 ].Contains ( "R" ) ? 90 : _BcodeD [ 0 ].Contains ( "I" ) ? 180 : _BcodeD [ 0 ].Contains ( "B" ) ? 270 : 0;
							}

							BarcodeWriter.Format = ZXing.BarcodeFormat.CODE_39;
							BarcodeWriter.Options.Height = int.Parse ( _BcodeD [ 2 ] ) + ( ( _BcodeD [ 3 ].ToUpper ( ) == "Y" ) ? 15 : 0 );
							BarcodeWriter.Options.Margin = 0;
							BarcodeWriter.Options.PureBarcode = ( !( _BcodeD [ 3 ].ToUpper ( ) == "Y" ) ? true : false );

							var imgCodeBar = BarcodeWriter.Write ( "*" + _fieldData + ( _BcodeD [ 1 ] == "Y" ? MOD43CheckChar ( _fieldData ).ToString ( ) : "" ) + "*" );

							using ( Bitmap bpStr = new Bitmap (

							   angle == 0 || angle == 180 ?
							   ( int ) imgCodeBar.Width :
							   ( int ) imgCodeBar.Height
							   ,
							   angle == 0 || angle == 180 ?
							   ( int ) imgCodeBar.Height :
							   ( int ) imgCodeBar.Width

							   ) ) {
								using ( Graphics gpD = Graphics.FromImage ( bpStr ) ) {

									switch ( angle ) {
										case 0:
											gpD.TranslateTransform ( 0 , 0 );
											break;
										case 90:
											gpD.TranslateTransform ( ( float ) bpStr.Width , 0 );
											break;
										case 180:
											gpD.TranslateTransform ( ( float ) bpStr.Width , ( float ) bpStr.Height );
											break;
										case 270:
											gpD.TranslateTransform ( 0 , ( float ) bpStr.Height );
											break;
									}
									gpD.RotateTransform ( angle );
									gpD.DrawImage ( imgCodeBar , 0 , 0 );//, (float)(imgCodeBar.Width * ScaleLabel * 2.14), (float)(imgCodeBar.Height * ScaleLabel) );
																		 // gpD.DrawString( _fieldData, new Font( "Arial", (int)heightData * 10 ), Brushes.Black, 0, 0 );
								}

								gp.DrawImage ( bpStr ,
									imgPoint.X ,
									imgPoint.Y ,
									angle == 0 || angle == 180 ? ( float ) ( imgCodeBar.Width * _ScaleLabel * 2 ) : ( float ) ( imgCodeBar.Height * _ScaleLabel ) ,
									angle == 0 || angle == 180 ? ( float ) ( imgCodeBar.Height * _ScaleLabel ) : ( float ) ( imgCodeBar.Width * _ScaleLabel * 2 )
									);
							}
						} else if ( fld.Contains ( "^BA" ) ) {
							var splData = Regex.Split ( fld.Replace ( "^FS" , "" ) , @"\^" );
							var _point = splData.FirstOrDefault ( t => t.Contains ( "FO" ) ).Remove ( 0 , 2 ).Split ( ',' );
							var _fieldData = splData.FirstOrDefault ( t => t.Contains ( "FD" ) ).Remove ( 0 , 2 ).TrimEnd ( ) ?? "";
							var _BcodeD = splData.FirstOrDefault ( t => t.Contains ( "BA" ) ).Split ( ',' );

							Point imgPoint = new Point ( ( int ) ( int.Parse ( _point [ 0 ] ) * _ScaleLabel ) , ( int ) ( int.Parse ( _point [ 1 ] ) * _ScaleLabel ) );
							var angle = 0;
							var isRotated = Regex.IsMatch ( _BcodeD [ 0 ] , @"(BA)[NRIB]{1}" );
							if ( isRotated ) {
								angle = _BcodeD [ 0 ].Contains ( "N" ) ? 0 : _BcodeD [ 0 ].Contains ( "R" ) ? 90 : _BcodeD [ 0 ].Contains ( "I" ) ? 180 : _BcodeD [ 0 ].Contains ( "B" ) ? 270 : 0;
							}

							BarcodeWriter.Format = ZXing.BarcodeFormat.CODE_93;
							BarcodeWriter.Options.Height = int.Parse ( _BcodeD [ 1 ] ) + ( ( _BcodeD [ 2 ].ToUpper ( ) == "Y" ) ? 15 : 0 );
							BarcodeWriter.Options.Margin = 0;
							BarcodeWriter.Options.PureBarcode = ( !( _BcodeD [ 2 ].ToUpper ( ) == "Y" ) ? true : false );

							var imgCodeBar = BarcodeWriter.Write ( "*" + _fieldData + ( _BcodeD [ 4 ] == "Y" ? MOD43CheckChar ( _fieldData ).ToString ( ) : "" ) + "*" );

							using ( Bitmap bpStr = new Bitmap (

							   angle == 0 || angle == 180 ?
							   ( int ) imgCodeBar.Width :
							   ( int ) imgCodeBar.Height
							   ,
							   angle == 0 || angle == 180 ?
							   ( int ) imgCodeBar.Height :
							   ( int ) imgCodeBar.Width

							   ) ) {
								using ( Graphics gpD = Graphics.FromImage ( bpStr ) ) {

									switch ( angle ) {
										case 0:
											gpD.TranslateTransform ( 0 , 0 );
											break;
										case 90:
											gpD.TranslateTransform ( ( float ) bpStr.Width , 0 );
											break;
										case 180:
											gpD.TranslateTransform ( ( float ) bpStr.Width , ( float ) bpStr.Height );
											break;
										case 270:
											gpD.TranslateTransform ( 0 , ( float ) bpStr.Height );
											break;
									}
									gpD.RotateTransform ( angle );
									gpD.DrawImage ( imgCodeBar , 0 , 0 );//, (float)(imgCodeBar.Width * ScaleLabel * 2.14), (float)(imgCodeBar.Height * ScaleLabel) );
																		 // gpD.DrawString( _fieldData, new Font( "Arial", (int)heightData * 10 ), Brushes.Black, 0, 0 );
								}

								gp.DrawImage ( bpStr ,
									imgPoint.X ,
									imgPoint.Y ,
									angle == 0 || angle == 180 ? ( float ) ( imgCodeBar.Width * _ScaleLabel * 2 ) : ( float ) ( imgCodeBar.Height * _ScaleLabel ) ,
									angle == 0 || angle == 180 ? ( float ) ( imgCodeBar.Height * _ScaleLabel ) : ( float ) ( imgCodeBar.Width * _ScaleLabel * 2 )
									);
							}
						} else if ( fld.Contains ( "^BQ" ) ) {
							var splData = Regex.Split ( fld.Replace ( "^FS" , "" ) , @"\^" );
							var _point = splData.FirstOrDefault ( t => t.Contains ( "FO" ) ).Remove ( 0 , 2 ).Split ( ',' );
							var _fieldData = Regex.Split ( splData.FirstOrDefault ( t => t.Contains ( "FD" ) ) , @"(?<=FD[QHLM]{1}[AM]{1},)" );//splData.FirstOrDefault(t=>t.Contains("FD")).Split(',');
							var _BcodeD = splData.FirstOrDefault ( t => t.Contains ( "BQ" ) ).Split ( ',' );

							Point imgPoint = new Point ( ( int ) ( int.Parse ( _point [ 0 ] ) * _ScaleLabel ) , ( int ) ( int.Parse ( _point [ 1 ] ) * _ScaleLabel ) );
							BarcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;

							Func<ZXing.QrCode.Internal.ErrorCorrectionLevel> y = ( ) => {
								switch ( _fieldData [ 0 ] [ 2 ] ) {
									case 'H':
										return ZXing.QrCode.Internal.ErrorCorrectionLevel.H;
									case 'L':
										return ZXing.QrCode.Internal.ErrorCorrectionLevel.L;
									case 'Q':
										return ZXing.QrCode.Internal.ErrorCorrectionLevel.Q;
									default:
										return ZXing.QrCode.Internal.ErrorCorrectionLevel.M;

								}
							};

							QrCodeEncodingOptions options = new QrCodeEncodingOptions {
								DisableECI = _BcodeD [ 1 ].Trim ( ) == "1" ? false : true ,
								CharacterSet = "UTF-8" ,
								ErrorCorrection = y ( ) ,
								Margin = 0
							};
							BarcodeWriter.Options = options;
							BCsvg.Format = ZXing.BarcodeFormat.QR_CODE;
							BCsvg.Options = options;
							var bcSVG = BCsvg.Write ( ( _fieldData [ 1 ] ?? "" ).TrimStart ( ).TrimEnd ( ) );

							var svgDocument = Svg.SvgDocument.FromSvg<Svg.SvgDocument> ( bcSVG.Content );
							svgDocument.Width = bcSVG.Width * int.Parse ( _BcodeD [ 2 ] );
							svgDocument.Height = bcSVG.Height * int.Parse ( _BcodeD [ 2 ] );
							var bitmap = svgDocument.Draw ( bcSVG.Width * int.Parse ( _BcodeD [ 2 ] ) , bcSVG.Height * int.Parse ( _BcodeD [ 2 ] ) );

							gp.DrawImage ( bitmap ,
									   imgPoint.X ,
									   imgPoint.Y ,
									   ( float ) ( bitmap.Width * _ScaleLabel ) ,
									   ( float ) ( bitmap.Height * _ScaleLabel )
									   );
						}
					}

				}
			} catch ( Exception ) {

				return null;
			}

			return toRet;
		}

		private char MOD43CheckChar ( string sValue ) {
			const string charSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%";
			int T = 0;
			int intRemainder = 0;

			foreach ( var v in sValue ) {
				T += Array.IndexOf ( charSet.ToArray ( ) , v );
			}
			intRemainder = T % 43;

			return charSet [ intRemainder ];
		}

		public Image ZPLtoImage ( string code ) {
			string [ ] t;
			try {
				var y = code.Replace ( "\n" , "" ).Replace ( "\t" , "" );
				t = AsciiToHex ( y ).Split ( '\n' );
			} catch ( Exception ex ) {
				Debug.WriteLine ( ex );
				throw;
			}

			StringBuilder stbld = new StringBuilder ( );

			Regex valuesRegex = new Regex ( "(GFA,)[0-9]+(,)[0-9]+(,){1}[0-9]+" );
			var values = valuesRegex.Match ( code , 0 )?.Value.Split ( ',' );

			int widthBytes = ( int.Parse ( values [ 3 ] ) );
			int height = int.Parse ( values [ 2 ] ) / widthBytes;
			int Realwidth = widthBytes * 8;


			var ToRet = new Bitmap ( Realwidth , height );
			Graphics gp = Graphics.FromImage ( ToRet );

			foreach ( string s in t ) {
				foreach ( char c in s ) {
					stbld.Append ( Convert.ToString ( Convert.ToInt32 ( c.ToString ( ) , 16 ) , 2 ).PadLeft ( 4 , '0' ) );
				}
			}


			var valuesImgPx = stbld.ToString ( );

			for ( int h = 0; h < height; h++ ) {
				for ( int w = 0; w < Realwidth; w++ ) {
					var val = valuesImgPx [ w + ( h * ( Realwidth ) ) ];
					Color col = val == '1' ? Color.Black : Color.White;



					ToRet.SetPixel ( w , h , col );
				}
			}



			return ToRet;
		}
		private String headDoc ( ) {
			String str = "\n^FO10,10^GFA," + total + "," + total + "," + widthBytes + ",\n";
			return str;
		}
	}
}
