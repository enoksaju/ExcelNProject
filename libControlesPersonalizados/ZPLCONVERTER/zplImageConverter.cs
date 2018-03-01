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

namespace libControlesPersonalizados.ZPLCONVERTER
{
    public class zplImageConverter : Component, IBindableComponent
    {
        private int blackLimit=125;
        private int total;
        private int widthBytes;
        private bool compressHex= true;
        private int lengToSplit=40;

        public int BlacknessLimitPercentage
        {
            get
            {
                return (blackLimit * 100 / 255);
            }
            set
            {
                blackLimit = (value * 255 / 100);
            }
        }

        public bool CompressHex
        {
            get { return compressHex; }
            set { compressHex = value; }
        }

        private Image _image = null;

        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
            }
        }

        public string zplValue
        {
            get
            {
                return this._image != null ? FromImage( (Bitmap)this._image ) : "^A0,10,8^FDError!";
            }
        }

        public Image ImageResult
        {
            get
            {
                try
                {
                    return ZPLtoImage( zplValue );
                }
                catch
                {
                    return null;
                }
            }
        }
        public int LengToSplit
        {
            get
            {
                return lengToSplit;
            }

            set
            {
                lengToSplit = value;
            }
        }


        #region IBindableComponent Members
        private BindingContext bindingContext;
        private ControlBindingsCollection dataBindings;
        [Browsable( false )]
        public BindingContext BindingContext
        {
            get
            {
                if (bindingContext == null)
                {
                    bindingContext = new BindingContext();
                }
                return bindingContext;
            }
            set
            {
                bindingContext = value;
            }
        }
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Content )]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (dataBindings == null)
                {
                    dataBindings = new ControlBindingsCollection( this );
                }
                return dataBindings;
            }
        }


        #endregion

        private static Dictionary<int, string> mapCode= new Dictionary<int, string>() {
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


        public string FromImage( Bitmap image )
        {
            string cuerpo= createBody(image);

            if (compressHex) cuerpo = HexToAscii( cuerpo );
            return headDoc() + cuerpo + "\n^FS";
        }
        private string createBody( Bitmap OriginalImage )
        {
            StringBuilder sb = new StringBuilder();
            // Graphics graphics = Graphics.FromImage( orginalImage);
            // graphics.DrawImage( orginalImage, 0, 0 );

            Bitmap clonedImage =(Bitmap)OriginalImage.Clone();


            int height = clonedImage.Height;
            int width = clonedImage.Width;
            int index = 0;
            // int rgb;
            int red;
            int green;
            int blue;
            char[] auxBinaryChar = new char[] { '0', '0', '0', '0', '0', '0', '0', '0' };

            widthBytes = (width / 8);

            if (((width % 8) > 0))
            {
                widthBytes = (((int)((width / 8))) + 1);
            }
            else
            {
                widthBytes = (width / 8);
            }

            this.total = (widthBytes * height);


            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    var  rgb = clonedImage.GetPixel( w, h );
                    red = rgb.R;
                    green = rgb.G;
                    blue = rgb.B;

                    char auxChar = '1';


                    int totalColor = (red + green + blue)/3;


                    if ((totalColor > blackLimit || rgb.A <= blackLimit)) auxChar = '0';


                    auxBinaryChar[index] = auxChar;
                    index++;

                    if (((index == 8) || (w == (width - 1))))
                    {
                        sb.Append( ByteBinary( new string( auxBinaryChar ) ) );

                        auxBinaryChar = new char[] { '0', '0', '0', '0', '0', '0', '0', '0' };
                        index = 0;
                    }
                }

                sb.Append( "\n" );
            }

            clonedImage.Dispose();
            return sb.ToString();
        }



        private string ByteBinary( string binary )
        {
            int dec = Convert.ToInt32(binary, 2);//int.Parse(binaryStr);//Integer.parseInt(binaryStr,2);
            if (dec > 15)
            {
                return dec.ToString( "X" ).ToUpper();//int.toString( dec, 16 ).toUpperCase();
            }
            else
            {
                return "0" + dec.ToString( "X" ).ToUpper();//Integer.toString( dec, 16 ).toUpperCase();
            }
        }
        private string HexToAscii( string code )
        {
            int maxlinea =  widthBytes * 2;

            StringBuilder sbCode = new StringBuilder();
            StringBuilder sbLinea = new StringBuilder();
            String previousLine = null;
            int counter = 1;

            char aux = code[0];

            bool firstChar = false;

            for (int i = 1; i < code.Length; i++)
            {
                var d=code[i];

                if (firstChar)
                {
                    aux = code[i];
                    firstChar = false;
                    continue;
                }
                if (code[i] == '\n')
                {
                    if (counter >= maxlinea && aux == '0')
                    {
                        sbLinea.Append( "," );
                    }
                    else if (counter >= maxlinea && aux == 'F')
                    {
                        sbLinea.Append( "!" );
                    }
                    else if (counter > 20)
                    {
                        int multi20 = (counter/20)*20;
                        int resto20 = (counter%20);

                        sbLinea.Append( mapCode[multi20] );

                        if (resto20 != 0)
                        {
                            sbLinea.Append( mapCode[resto20] + aux );
                        }
                        else
                        {
                            sbLinea.Append( aux );
                        }
                    }
                    else
                    {
                        sbLinea.Append( mapCode[counter] + aux );
                        if (mapCode[counter] == null) { }
                    }
                    counter = 1;
                    firstChar = true;
                    if (sbLinea.ToString().Equals( previousLine ))
                    {
                        sbCode.Append( ":" );
                    }
                    else
                    {
                        sbCode.Append( sbLinea.ToString() );
                    }

                     //sbCode.Append( "\n" );
                    previousLine = sbLinea.ToString();
                    sbLinea.Clear();//.setLength( 0 );
                    continue;
                }
                if (aux == code[i])
                {
                    counter++;
                }
                else
                {
                    if (counter > 20)
                    {
                        int multi20 = (counter/20)*20;
                        int resto20 = (counter%20);
                        sbLinea.Append( mapCode[multi20] );
                        if (resto20 != 0)
                        {
                            sbLinea.Append( mapCode[resto20] + aux );
                        }
                        else
                        {
                            sbLinea.Append( aux );
                        }
                    }
                    else
                    {
                        sbLinea.Append( mapCode[counter] + aux );
                    }
                    counter = 1;
                    aux = code[i];
                }
            }

            
            StringBuilder strBldRes= new StringBuilder();

            for (int i = 0; i < sbCode.Length; i+= LengToSplit)
            {
                strBldRes.AppendFormat( "\t{0}\n", sbCode.ToString().Substring( i, i + LengToSplit <= sbCode.Length ? LengToSplit : sbCode.Length-i ) );
            }

            var y= strBldRes.ToString();

            return y;
        }


        public string AsciiToHex( string code )
        {
            string TempValue="";


            StringBuilder stb= new StringBuilder();
            string previewValue="";


            Regex t = new Regex("[0-9A-Yg-z,:!]{25,}");
            var y= t.Match( code, 0 );

            Regex valuesRegex = new Regex("(GFA,)[0-9]+(,)[0-9]+(,){1}[0-9]+");

            var values=valuesRegex.Match( code, 0 )?.Value.Split(',');
            int widthBytesLocal= ( int.Parse(values[3]) *2);

            if (y != null)
            {
                //string CodeImage= y.Value;
                Regex regx = new Regex("(GFA,)[0-9]+(,){1}[0-9]+(,){1}[0-9]+(,){1}");
                string CodeImage= regx.Replace(y.Value,"");

                for (int i = 0; i < CodeImage.Length; i++)
                {
                    if (CodeImage[i] == ',')
                    {
                        previewValue = new string( '0', widthBytesLocal );
                        stb.AppendFormat( "{0}\n", previewValue );
                    }
                    else if(CodeImage[i] == '!')
                    {
                        previewValue = new string( 'F', widthBytesLocal );
                        stb.AppendFormat( "{0}\n", previewValue );
                    }
                    else if (CodeImage[i] == ':')
                    {
                        stb.AppendFormat( "{0}\n", previewValue );
                    }
                    else
                    {
                        var val= CodeImage[i].ToString();
                        var val2= CodeImage[i+1>=CodeImage.Length?i: i+1].ToString();
                        var val3= CodeImage[i+2>=CodeImage.Length?(i+1>=CodeImage.Length?i: i+1): i+2].ToString();

                        int key1= mapCode.FirstOrDefault(x=> x.Value== CodeImage[i].ToString()).Key;
                        int key2;
                        char keyVal;

                        if (key1 > 19)
                        {
                            key2 = mapCode.FirstOrDefault( x => x.Value == CodeImage[i + 1].ToString() ).Key;

                            if (key2 == 0)
                            {
                                TempValue += new string( CodeImage[i + 1], key1 );
                                i += 1;
                            }
                            else
                            {
                                TempValue += new string( CodeImage[i + 2], key1 + key2 );
                                i += 2;
                            }
                        }
                        else if (key1 < 20)
                        {
                            TempValue += new string( CodeImage[i + 1], key1 );
                            i += 1;
                        }

                        if (TempValue.Length == widthBytesLocal)
                        {
                      
                                previewValue = TempValue;
                                stb.AppendFormat( "{0}\n", previewValue );
                                TempValue = "";
                           
                            
                        }

                    }
                }


            }
            return stb.ToString();
        }
        
        public Image ZPLtoImage( string code )
        {
            string[] t;
            try
            {
                var y= code.Replace( "\n", "").Replace("\t","");
                t = AsciiToHex( y ).Split( '\n' );
            }
            catch (Exception ex)
            {
                Debug.WriteLine( ex);
                throw;
            }
           
            StringBuilder stbld= new StringBuilder();

            Regex valuesRegex = new Regex("(GFA,)[0-9]+(,)[0-9]+(,){1}[0-9]+");
            var values=valuesRegex.Match( code, 0 )?.Value.Split(',');

            int widthBytes= ( int.Parse(values[3]));
            int height = int.Parse(values[2])/ widthBytes;
            int Realwidth= widthBytes * 8;


            var ToRet= new Bitmap(Realwidth , height);
            Graphics gp= Graphics.FromImage(ToRet);

            foreach (string s in t)
            {
                foreach (char c in s)
                {
                    stbld.Append( Convert.ToString( Convert.ToInt32( c.ToString(), 16 ), 2 ).PadLeft( 4, '0' ) );
                }
            }


            var valuesImgPx = stbld.ToString();

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < Realwidth; w++)
                {
                    var val= valuesImgPx[w + (h* (Realwidth))];
                    Color col= val == '1' ? Color.Black: Color.White;

                    

                    ToRet.SetPixel( w, h,col );
                }
            }

           

            return ToRet;
        }
        private String headDoc()
        {
            String str = "\n^FO10,10^GFA,"+ total + ","+ total + "," + widthBytes +",\n";
            return str;
        }
    }
}
