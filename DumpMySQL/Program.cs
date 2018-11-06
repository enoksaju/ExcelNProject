using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Mail;
using System.Text;

namespace DumpMySQL
{
	class Program
	{

		static void Main ( string[] args )
		{
			string dbUser = "", dbPass = "", databases = "";
			string prevCommand = "";
			StringBuilder BodyMail = new StringBuilder ( );
			DateTime ahora = DateTime.Now;


			Console.Clear ( );
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write ( @"
     ___                       __    ____  __   __           _       _   
    /   \_   _ _ __ ___  _ __ / _\  /___ \/ /  / _\ ___ _ __(_)_ __ | |_ 
   / /\ / | | | '_ ` _ \| '_ \\ \  //  / / /   \ \ / __| '__| | '_ \| __|
  / /_//| |_| | | | | | | |_) |\ \/ \_/ / /___ _\ \ (__| |  | | |_) | |_ 
 /___,'  \__,_|_| |_| |_| .__/\__/\___,_\____/ \__/\___|_|  |_| .__/ \__|
                        |_|           EnokSaJu                |_|    v1.0 

" );
			Console.ForegroundColor = ConsoleColor.White;


			List<string> listArgs = new List<string> ( args ), listDatabases = new List<string> ( );

			try
			{
				if ( args.Length <= 0 | !listArgs.Contains ( "-u" ) | !listArgs.Contains ( "-p" ) | !listArgs.Contains ( "-d" ) )
				{
					if ( listArgs.Contains ( "--setProp" ) | listArgs.Contains ( "-s" ) )
					{
						listArgs.ForEach ( ( v ) =>
						  {
							  if ( v.Contains ( "--portEmail" ) )
							  {
								  int p;
								  int.TryParse ( v.Split ( '=' )[ 1 ], out p );
								  Properties.Settings.Default.portEmail = p;
							  }
							  else if ( v.Contains ( "--sendEmail" ) )
							  {
								  bool e;
								  bool.TryParse ( v.Split ( '=' )[ 1 ], out e );
								  Properties.Settings.Default.sendEmail = e;
							  }
							  else if (
							  v.Contains ( "--errorLogPath" ) |
							  v.Contains ( "--mysqldumpPath" ) |
							  v.Contains ( "--retaindays" ) |
							  v.Contains ( "--backupDir" ) |
							  v.Contains ( "--serverEmail" ) |
							  v.Contains ( "--pEmail" ) |
							  v.Contains ( "--Email" )
							  )
							  {
								  Properties.Settings.Default[ v.Split ( '=' )[ 0 ].Replace ( "-", "" ) ] = v.Split ( '=' )[ 1 ];
							  }
							  else if ( v.Contains ( "--list" ) )
							  {
								  Console.ForegroundColor = ConsoleColor.DarkGreen;
								  Console.WriteLine ( $"Lista de Configuraciones:\n" );
								  Console.ForegroundColor = ConsoleColor.Gray;
								  foreach ( SettingsProperty prop in Properties.Settings.Default.Properties )
								  {
									  if ( prop.Name != "pEmail" )
									  {
										  Console.WriteLine ( $"{prop.Name,25 }: {Properties.Settings.Default[ prop.Name ]}" );
									  }
									  else
									  {
										  Console.WriteLine ( $"{prop.Name,25 }: *********************" );
									  }
								  }
								  Console.WriteLine ( $"\n" );
								  Console.ForegroundColor = ConsoleColor.White;
							  }
						  } );

						Properties.Settings.Default.Save ( );
						Console.WriteLine ( "Presione una Enter para continuar..." );
						Console.Read ( );
						Environment.Exit ( 0 );
					}
					else
					{
						throw new Exception ( "No se indicaron algunos parametros requeridos" );
					}
				}


				// Reviso parametros y asigno valores a variables
				listArgs.ForEach ( ( v ) =>
				  {
					  switch ( v )
					  {
						  case "-u":
							  dbUser = listArgs[ listArgs.IndexOf ( v ) + 1 ];
							  prevCommand = v;
							  break;
						  case "-p":
							  dbPass = listArgs[ listArgs.IndexOf ( v ) + 1 ];
							  prevCommand = v;
							  break;
						  case "-d":
							  prevCommand = v;
							  break;
						  case "-e":
							  Properties.Settings.Default.sendEmail = false;
							  break;
						  default:
							  switch ( prevCommand )
							  {
								  case "-d":
									  listDatabases.Add ( v );
									  databases += $"{v} ";
									  break;
							  }
							  break;
					  }

				  } );

				File.CreateText ( Properties.Settings.Default.errorLogPath ).Close ( );

				Console.Write ( $"Conectando como: " );
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.Write ( $"{dbUser}\n" );
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write ( "  Path de Salida: " );
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.Write ( $"{Properties.Settings.Default.backupDir}\n" );
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write ( "  Bases de Datos: " );
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				listDatabases.ForEach ( i =>
				  {
					  Console.Write ( i + ( listDatabases.IndexOf ( i ) < listDatabases.Count - 1 ? ", " : "" ) );
				  } );
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write ( $"\n{new string ( '*', 75 )}\n\n" );

				BodyMail.Append ( $"Conectando como: <b style=\"color: blue\">{dbUser}</b><br />" );
				BodyMail.Append ( $"Path de Salida: <b style=\"color: blue\">{Properties.Settings.Default.backupDir}</b><br />" );
				BodyMail.Append ( $"Bases de Datos: <b style=\"color: blue\">{databases}</b><br />" );



				foreach ( var itm in listDatabases )
				{
					try
					{
						Console.Write ( $"Generando el archivo SQL de la BD: " );
						Console.ForegroundColor = ConsoleColor.DarkGreen;
						Console.Write ( $"{itm}\n" );
						BodyMail.Append ( $"\n{new string ( '*', 75 )}<br /><br />" );
						BodyMail.Append ( $"Generando el archivo SQL de la BD: <b style=\"color: blue\">{itm}</b>  -> <i color=\"gray\">{DateTime.Now.ToString ( "dd MM yyyy HH:mm" )}<i><br />" );


						ProcessStartInfo p = new ProcessStartInfo ( );
						p.WindowStyle = ProcessWindowStyle.Hidden;
						p.FileName = Path.Combine ( Properties.Settings.Default.mysqldumpPath, "mysqldump.exe" );
						p.Arguments = $"--user={dbUser} --password={dbPass} --databases {itm} --log-error={Properties.Settings.Default.errorLogPath} --result-file={( Path.Combine ( Properties.Settings.Default.backupDir, $"{ahora.ToString ( "yyyy_MM_dd_HH_mm" )}_{itm}.sql" ) )}";
						var process = Process.Start ( p );

						while ( !process.HasExited ) { }

						switch ( process.ExitCode )
						{
							case 0:
								Console.ForegroundColor = ConsoleColor.DarkGreen;
								Console.WriteLine ( $"Se genero correctamente el archivo {ahora.ToString ( "yyyy_MM_dd_HH_mm" )}_{itm}.sql" );
								break;
							default:
								Console.ForegroundColor = ConsoleColor.DarkRed;
								Console.WriteLine ( $"El proceso termino en codigo {process.ExitCode}" );
								break;
						}

						BodyMail.Append ( $"El proceso termino en codigo <b color=\"orange\">{process.ExitCode}</b> -> {DateTime.Now.ToString ( "dd MM yyyy HH:mm" )}<br />" );

					}
					catch ( Exception ex )
					{
						HandleErrors ( ex, BodyMail );
					}
					finally
					{
						HandleFinally ( BodyMail );
					}
				}
				Console.WriteLine ( $"\nComprimiendo Archivos SQL...\n" );

				try
				{
					using ( ZipArchive fileZip = ZipFile.Open ( Path.Combine ( Properties.Settings.Default.backupDir, $"{ahora.ToString ( "yyyy_MM_dd_HH_mm" )}.zip" ).ToString ( ), ZipArchiveMode.Create ) )
					{
						var files = Directory.GetFiles ( Properties.Settings.Default.backupDir, "*.sql", SearchOption.TopDirectoryOnly );
						foreach ( var file in files )
						{
							Console.WriteLine ( $"Agregando: {Path.GetFileName ( file )}\n" );
							BodyMail.Append ( $"Agregando: <b color=\"orange\">{Path.GetFileName ( file )}</b> -> <i color=\"gray\">{DateTime.Now.ToString ( "dd MM yyyy HH:mm" )}<i> <br />" );
							fileZip.CreateEntryFromFile ( file, Path.GetFileName ( file ) );
							Console.WriteLine ( $"Borrando: {Path.GetFileName ( file )}\n" );
							BodyMail.Append ( $"Borrando: <b color=\"orange\">{Path.GetFileName ( file )}</b> -> <i color=\"gray\">{DateTime.Now.ToString ( "dd MM yyyy HH:mm" )}<i> <br />" );
							File.Delete ( file );
						}
					}

				}
				catch ( Exception ex )
				{
					HandleErrors ( ex, BodyMail );
				}
				finally
				{
					HandleFinally ( BodyMail );
				}


				Console.WriteLine ( $"\nEliminando Archivos Antiguos...\n" );

				try
				{
					var files = Directory.GetFiles ( Properties.Settings.Default.backupDir, "*.zip", SearchOption.TopDirectoryOnly );
					foreach ( var file in files )
					{
						DateTime creation = File.GetCreationTime ( file );
						if ( ( DateTime.Today - creation.Date ).TotalDays > Properties.Settings.Default.retaindays )
						{
							Console.WriteLine ( $"Borrando: {Path.GetFileName ( file )}\n" );
							File.Delete ( file );
						}
					}
				}
				catch ( Exception ex )
				{
					HandleErrors ( ex, BodyMail );
				}
				finally
				{
					HandleFinally ( BodyMail );
				}


				if ( Properties.Settings.Default.sendEmail )
				{
					using ( var email = new System.Net.Mail.MailMessage ( "noreply@gmail.com", Properties.Settings.Default.Email )
					{
						IsBodyHtml = true,
						Body = BodyMail.ToString ( ),
						Subject = $"Reporte de respaldo BD {ahora.ToString ( "yyyy_MM_dd_HH_mm" )}"
					} )
					{

						using ( var mailClient = new SmtpClient ( Properties.Settings.Default.serverEmail, Properties.Settings.Default.portEmail ) )
						{
							var credentials = new System.Net.NetworkCredential ( Properties.Settings.Default.Email, Properties.Settings.Default.pEmail );
							mailClient.UseDefaultCredentials = false;
							mailClient.EnableSsl = true;
							mailClient.Credentials = credentials;
							mailClient.Send ( email );
						}
					}
				}

			}
			catch ( Exception ex )
			{
				HandleErrors ( ex, BodyMail );
			}
			finally
			{
				Console.ForegroundColor = ConsoleColor.White;
			}


		}

		public static void HandleErrors ( Exception ex, StringBuilder st )
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine ( $"Error: {ex.Message}\nUsage: -u [user] -p [password] -d \"[database1, database2, ..., databaseN]\"  [options]" );
			Console.WriteLine ( $"Options:\n\t-e\tEnvia el correo Electronico" );
			File.AppendAllText ( Properties.Settings.Default.errorLogPath, $"Error: {ex.Message } -> {DateTime.Now.ToString ( "dd MM yyyy HH:mm" )}\n" );
			st.Append ( $"Error: <b color=\"red\">{ex.Message}</b> -> {DateTime.Now.ToString ( "dd MM yyyy HH:mm" )}<br />" );
		}
		public static void HandleFinally ( StringBuilder st )
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write ( $"\n{new string ( '*', 75 )}\n" );
			st.Append ( $"\n{new string ( '*', 75 )}<br />" );
		}

		public static void BackupMysql ()
		{
			using ( var cnn = new MySql.Data.MySqlClient.MySqlConnection ( Properties.Settings.Default.PrincipalDatabase ) )
			{
				using ( var cmd = new MySql.Data.MySqlClient.MySqlCommand ( ) )
				{
				
				}
			}
		}
	}
}
