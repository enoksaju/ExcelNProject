using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libControlesPersonalizados.ZPLCONVERTER;

namespace ConsoleApplication1
{
    class Program
    {
        private static zplImageConverter cvt= new zplImageConverter();
        static void Main( string[] args )
        {

PreguntarOtraVez:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( "Que funcion desea?" );
            Console.ForegroundColor = ConsoleColor.White;
            string p= Console.ReadLine();
            int function;
            bool IsInt= int.TryParse(p,out function);
            if (!IsInt) goto PreguntarOtraVez;

            switch (function)
            {
                case 1:
                    convertImage();
                    break;
            }

            goto PreguntarOtraVez;

        }

        public static void getBWImage(string Code)
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            using (var frm = new Form())
            {
                using (var pb= new PictureBox() { Dock = DockStyle.Fill, Location= new Point(0,0), SizeMode= PictureBoxSizeMode.AutoSize })
                {
                    frm.Controls.Add( pb );

                    pb.Image = cvt.ZPLtoImage( Code );
                    frm.ClientSize = new Size( pb.Image.Width + 20, pb.Image.Height + 20 );
                    frm.MinimumSize = new Size( 100, 100 );
                    frm.ShowDialog();
                }

            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void convertImage()
        {
            Image y;
OtraVez:

            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine( "\nCual es el nombre de la imagen?" );
                Console.ForegroundColor = ConsoleColor.White;

                var name= Console.ReadLine();
                y = (Image)Properties.Resources.ResourceManager.GetObject( name );
            }
            catch (Exception)
            {
                goto OtraVez;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine( "\nSe usara el compresor?[1:Si, 2:No]" );
            Console.ForegroundColor = ConsoleColor.White;

            var t= Console.ReadKey();
            cvt.CompressHex = t.KeyChar == '1' ? true : false;

PreguntarOtraVez:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine( "\nIngrese el % de iluminacion:" );
            Console.ForegroundColor = ConsoleColor.White;

            string p= Console.ReadLine();
            int porcent;
            bool IsInt= int.TryParse(p,out porcent);
            if (!IsInt || porcent > 100) goto PreguntarOtraVez;

            cvt.BlacknessLimitPercentage = porcent;

            var x= cvt.FromImage((Bitmap)y);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine( new string('*',20) + "Resultado " + new string('*',20));
            Console.WriteLine( x );
            Console.WriteLine( new string( '*', 50 ) );
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine( "\nQuiere ver la imagen resultante?[y:si, any:no]" );
            var bImagen= Console.ReadKey();
            if(bImagen.KeyChar == 'y')
            {
                getBWImage( x );
            }

            // goto OtraVez;
        }
    }
}
