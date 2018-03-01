using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using FastColoredTextBoxNS;
using ComponentFactory.Krypton.Toolkit;
using ZXing.QrCode;

namespace libControlesPersonalizados
{
    /// <summary>
    /// Editos de Codigo ZPL con un cuadro de viata previa.
    /// </summary>
    public partial class ZPLCodeEditor : UserControl
    {
        /// <summary>
        /// Texto por defecto del editor de codigo.
        /// </summary>
        const string DEFAULT_TEXT =
@"
^FX
              Autor: Excel Nobleza
        Descripción: Etiqueta ***
            Cliente:
 Nombre del Archivo:
^FS

^XA

    ^FX Ingrese el codigo de la etiqueta aqui ^FS

^XZ";
        /// <summary>
        /// Crea una instancia del editor de codigo
        /// </summary>
        public ZPLCodeEditor()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            popupMenu = new AutocompleteMenu(fastColoredTextBox1);
            popupMenu.SearchPattern = @"[\\^FSXAZDOGB]+";
            popupMenu.AllowTabKey = true;
            BuildAutocompleteMenu();

            this.fastColoredTextBox1.Text = DEFAULT_TEXT;
            this.kryptonSplitContainer1.Panel2Collapsed = true;

            fastColoredTextBox1.OnTextChangedDelayed(fastColoredTextBox1.Range);
        }
        #region events
        public event EventHandler ChangedFileName;
        #endregion

        #region Private Properties
        private static string DEFAULT_FILENAME = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Etiqueta.zpl");
        private double _ScaleLabel = 1;
        private string _FileName = DEFAULT_FILENAME;
        private string[] snippets =
        {
            "^XA\n\t^FO0,0^A0,20,20^FD|^FS\n^XZ",
            "^XA\n|\n^XZ",
            "^FO0,0^A0N,20,20^FD|^FS",
            "^FO0,0^A0N,20,20^FD@|^FS",
            "^FO50,50^FB100,4,0,J,0^A0N,20,20^FD|^FS",
            "^FO0,0^GB|,100,2^FS",
            "^FO0,0^B3N,N,50,N,N^FD|^FS",
            "^FO0,0^B3N,N,50,N,N^FD@|^FS",
            "^FO0,0^BAN,50,N,N,N^FD|^FS",
            "^FO0,0^BAN,50,N,N,N^FD@|^FS",
            "^FO0,0^BQN,2,3^FDQA, |^FS",
            "^FO0,0^BQN,2,3^FDQA, @|^FS",
            "^FX | ^FS"
        };
        private ZXing.BarcodeWriter BarcodeWriter = new ZXing.BarcodeWriter();
        private ZXing.BarcodeWriterSvg BCsvg = new ZXing.BarcodeWriterSvg();
        private double widthLabel = 4;
        private double heightLabel = 2;
        private AutocompleteMenu popupMenu;


        TextStyle labelStyle = new TextStyle(Brushes.DarkBlue, Brushes.WhiteSmoke, FontStyle.Regular);
        TextStyle initfieldStyle = new TextStyle(Brushes.Blue, Brushes.WhiteSmoke, FontStyle.Regular);

        TextStyle fieldValueStyle = new TextStyle(Brushes.DarkRed, Brushes.WhiteSmoke, FontStyle.Regular);
        TextStyle fieldVariableStyle = new TextStyle(Brushes.Red, null, FontStyle.Italic);

        TextStyle commentsStyle = new TextStyle(Brushes.DarkGreen, null, FontStyle.Italic);

        TextStyle fontConfigStyle = new TextStyle(Brushes.DodgerBlue, null, FontStyle.Regular);
        TextStyle rectConfigStyle = new TextStyle(Brushes.CadetBlue, null, FontStyle.Regular);

        TextStyle numbersConfigStyle = new TextStyle(Brushes.MediumBlue, null, FontStyle.Italic);
        #endregion

        #region Public Properties

        /// <summary>
        /// Controla si el ToolsStrip es visible o no.
        /// </summary>
        [Description("Habilita o deshabilita la barra de herramientas.")]
        public bool ShowToolStrip
        {
            get { return toolStrip1.Visible; }
            set { toolStrip1.Visible = value; this.Invalidate(); }
        }

        /// <summary>
        /// Nombre del archivo actual.
        /// </summary>
        [Description("Nombre del Archivo actual.")]
        public string FileName
        {
            get
            {
                return System.IO.Path.GetFileName(_FileName);
            }
        }

        /// <summary>
        /// Directorio del Archivo actual
        /// </summary>
        [Description("Directorio del Archivo actual.")]
        public string PathFile
        {
            get
            {
                return System.IO.Path.GetDirectoryName(_FileName);
            }
        }

        /// <summary>
        /// Factor de escala de la vista previa.
        /// </summary>
        [Description("Factor de la escala del al vista previa.")]
        public double ScaleLabel
        {
            get
            {
                return _ScaleLabel;
            }

            set
            {
                _ScaleLabel = value;
                PreviewPictureBox.Image?.Dispose();
                PreviewPictureBox.Image = previewLabel(fastColoredTextBox1.Text);
            }
        }

        /// <summary>
        /// Ancho de la etiqueta en pulgadas.
        /// </summary>
        [Description("Ancho de la etiqueta en pulgadas.")]
        public double WidthLabel
        {
            get
            {
                return widthLabel;
            }

            set
            {
                widthLabel = value;
                fastColoredTextBox1.OnTextChangedDelayed(fastColoredTextBox1.Range);
            }
        }

        /// <summary>
        /// Alto de la etiqueta en pulgadas
        /// </summary>
        [Description("Alto de la etiqueta en pulgadas.")]
        public double HeightLabel
        {
            get
            {
                return heightLabel;
            }

            set
            {
                heightLabel = value;
                fastColoredTextBox1.OnTextChangedDelayed(fastColoredTextBox1.Range);
            }
        }

        [Description("Codigo ZPL.")]
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ZPLText
        {
            get
            {
                return fastColoredTextBox1.Text;
            }
            set
            {
                fastColoredTextBox1.Text = value;
            }
        }


        private bool _ShowPreview = false;
        [Description("Muestra u oculta la vista previa de la Etiqueta")]
        public bool ShowPreview
        {
            get { return _ShowPreview; }
            set
            {
                _ShowPreview = value;
                this.kryptonSplitContainer1.Panel2Collapsed = !_ShowPreview;
                ViewPreviewToolStripButton.Checked = _ShowPreview;
                vistaPreviaToolStripMenuItem.Checked = _ShowPreview;
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Acciones que configuran la apariencia del codigo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FastColoredTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //throw new NotImplementedException();
            //clear previous highlighting

            e.ChangedRange.ClearStyle(fieldValueStyle);
            e.ChangedRange.ClearStyle(fieldVariableStyle);
            e.ChangedRange.ClearStyle(commentsStyle);
            e.ChangedRange.ClearStyle(fontConfigStyle);
            e.ChangedRange.ClearStyle(rectConfigStyle);
            e.ChangedRange.ClearStyle(numbersConfigStyle);

            e.ChangedRange.SetStyle(fieldValueStyle, @"(\^FD)[A-Za-z0-9 -.:|_,]+");
            e.ChangedRange.SetStyle(fieldVariableStyle, @"(\^FD@)[A-Za-z0-9 -.:\|_,]+");


            // Estiliza los comentarios
            e.ChangedRange.ClearStyle(commentsStyle);
            e.ChangedRange.SetStyle(commentsStyle, @"\^FX.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(commentsStyle, @"(\^FX.*?\^FS)", RegexOptions.Singleline);


            // Estiliza los campos y tipos de fields
            e.ChangedRange.ClearStyle(labelStyle);
            e.ChangedRange.ClearStyle(initfieldStyle);

            e.ChangedRange.SetStyle(labelStyle, @"\^[X][AZ]");
            e.ChangedRange.SetStyle(initfieldStyle, @"(\^FO)|(\^FS)");

            // Estiliza las fuentes y comendos del field            
            e.ChangedRange.SetStyle(fontConfigStyle, @"(\^A)");
            e.ChangedRange.SetStyle(rectConfigStyle, @"(\^G)[BF]+[A]*");

            e.ChangedRange.SetStyle(rectConfigStyle, @"(\^FB)");

            e.ChangedRange.SetStyle(rectConfigStyle, @"(\^B)[A3Q]{1}[NRIB]{1}");

            e.ChangedRange.SetStyle(numbersConfigStyle, @"[0-9]+[,]+[0-9]+[,]*[0-9]*");

        }
        private void fastColoredTextBox1_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            fastColoredTextBox1.Range.ClearFoldingMarkers();

            var currentIndent = 0;
            var lastNonEmptyLine = 0;

            for (int i = 0; i < fastColoredTextBox1.LinesCount; i++)
            {
                var line = fastColoredTextBox1[i];
                var spacesCount = line.StartSpacesCount;
                if (spacesCount == line.Count) //empty line
                    continue;

                if (currentIndent < spacesCount)
                    //append start folding marker
                    fastColoredTextBox1[lastNonEmptyLine].FoldingStartMarker = "m" + currentIndent;
                else
                if (currentIndent > spacesCount)
                    //append end folding marker
                    fastColoredTextBox1[lastNonEmptyLine].FoldingEndMarker = "m" + spacesCount;

                currentIndent = spacesCount;
                lastNonEmptyLine = i;
            }

            PreviewPictureBox.Image?.Dispose();
            PreviewPictureBox.Image = previewLabel(fastColoredTextBox1.Text);
        }
        /// <summary>
        /// Descripcion de los comandos disponibles
        /// </summary>
        private Dictionary<string, string> Comands = new Dictionary<string, string>
        {
            { "XA",     "Inicio de la Etiqueta" },
            { "FX",     "Inicia una linea de comentarios" },
            { "XZ",     "Fin de la Etiqueta" },
            { "FO",     "Inicio de un Campo\n\n ^FO{XPosition},{yPosition}" },
            { "FS",     "Cierre de un Campo"},
            { "FB",     "Bloque de campo\n^FB{ancho[numeric]}, {lineas[numeric]}, {espacio de linea[numeric]}, {alineacion[L : IZQUIERDA ,C : CENTER ,R : DERECHA]}, {sangria[numeric]}\n Retorno de carro: \\&"},
            { "A",      "Fuente:\n\n ^A{index},{Alto},{Ancho}\nDebe ir dentro de un campo"},
            { "GFA",    "Graficos:\n\n ^GFA{total}, {total}, {widthBytes}, {imageStringData}\n\nDebe ir dentro de un campo" },
            { "GB",     "Dibuja un rectangulo en la etiqueta:\n\n^GB{ancho},{largo},{anchoLapiz}\n\nDebe ir dentro de un campo" },
            { "FD",     "Datos del Campo:\n\n^FD{stringData}\n\nDebe ir dentro de un campo" },
            { "B3",     "Codigo de barras 39\n ^B3{orientation[N,R,B,I]}, {checkDigit[Y,N]}, {Height[integer]}, {Readable[Y,N]}, {Above BarCode[Y,N]}"},
            { "BA",     "Codigo de barras 93\n ^BA{orientation[N,R,B,I]}, {Heght[integer]}, {Readable{Y,N}}, {Above BarCode[Y,N]}, {checkDigit[Y,N]}"},
            { "BQN",    "Codigo QR\n^BQN{Model[1:Original,2:Enhaced(default)]}, {Magnification[1-10]}^FD{Correction[H,L,Q,M]}{TextMode[A:Automatic, M:Manual]}, {QrValue[string]}"}
        };
        private void BuildAutocompleteMenu()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();

            foreach (var item in snippets)
                items.Add(new SnippetAutocompleteItem(item));
            popupMenu.Items.SetAutocompleteItems(items);
        }
        private void fastColoredTextBox1_ToolTipNeeded(object sender, ToolTipNeededEventArgs e)
        {
            var range = new Range(sender as FastColoredTextBox, e.Place, e.Place);
            string hoveredWord = range.GetFragment("[\\^]*[FSXAZDOGBQN]+").Text;

            if (hoveredWord.Trim() != String.Empty && Comands.Keys.Contains(hoveredWord.Trim()))
            {
                e.ToolTipTitle = "^" + hoveredWord;
                e.ToolTipText = Comands[hoveredWord.Trim()];
            }
            Debug.WriteLine(hoveredWord);
        }
        private void vistaPreviaToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.ShowPreview = (bool)sender.GetType().GetProperty("Checked", typeof(bool)).GetValue(sender);// (sender as ToolStripMenuItem)?.Checked;
        }
        private void ImprimirLabel_Click(object sender, EventArgs e)
        {
            ImprimirEtiqueta();
        }
        private void imprimir_Click(object sender, EventArgs e)
        {
            ImprimirCodigo();

        }
        private void guardar_Click(object sender, EventArgs e)
        {
            GuardarArchivoCodigo();
        }
        private void abrir_Click(object sender, EventArgs e)
        {
            AbrirArchivoCodigo();
        }
        private void nuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
        private void GuardarComo_Click(object sender, EventArgs e)
        {
            GuardarComo();
        }

        private char MOD43CheckChar(string sValue)
        {
            const string charSet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%";
            int T = 0;
            int intRemainder = 0;

            foreach (var v in sValue)
            {
                T += Array.IndexOf(charSet.ToArray(), v);
            }
            intRemainder = T % 43;

            return charSet[intRemainder];
        }
        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ScaleLabel = double.Parse(((ToolStripMenuItem)sender).Tag.ToString());
        }
        /// <summary>
        /// importa una imagen y la convierte en ZPL.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            var frm = new importZPLImageForm() { };
            if (frm.ShowDialog() != DialogResult.OK) return;

            var IDX = fastColoredTextBox1.Text.IndexOf("^XZ");
            fastColoredTextBox1.Text = fastColoredTextBox1.Text.Insert(IDX, frm.ZPLResult.Replace("\n", "\n\t") + '\n');
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Crea un Archivo ZPl en blanco.
        /// </summary>
        public void Nuevo()
        {
            if (KryptonTaskDialog.Show("Confirme", "Confirme", "Realmente desea cerrar el documento actual y abrir uno nuevo?", MessageBoxIcon.Question, TaskDialogButtons.Yes | TaskDialogButtons.No) == DialogResult.No) return;

            this.fastColoredTextBox1.Clear();
            this.fastColoredTextBox1.Text = DEFAULT_TEXT;
            this._FileName = DEFAULT_FILENAME;
            ChangedFileName?.Invoke(this, new EventArgs { });
        }
        /// <summary>
        /// Envia la secuencia de comandos ZPl a la impresora(RAW).
        /// </summary>
        public void ImprimirEtiqueta()
        {
            using (var dlg = new PrintDialog { AllowCurrentPage = false, AllowPrintToFile = false, AllowSelection = false, AllowSomePages = false })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    RAWPrinter.RawPrinter.SendStringToPrinter(dlg.PrinterSettings.PrinterName, this.fastColoredTextBox1.Text);
                }
            }
        }

        /// <summary>
        /// Imprime el Codigo ZPL.
        /// </summary>
        public void ImprimirCodigo()
        {
            var settings = new PrintDialogSettings();

            settings.ShowPrintDialog = true;
            settings.IncludeLineNumbers = true;
            settings.ShowPrintPreviewDialog = true;
            settings.Title = FileName;
            settings.Header = "&b&w&b";
            settings.Footer = "&b&p";
            this.fastColoredTextBox1.Print(settings);
        }

        /// <summary>
        /// Guarda un Archivo de codigo ZPL con el nombre actual del archivo.
        /// </summary>
        public void GuardarArchivoCodigo()
        {

            if (this._FileName == DEFAULT_FILENAME)
            {
                sfdZPL.FileName = this.FileName;
                sfdZPL.InitialDirectory = this.PathFile;
                if (sfdZPL.ShowDialog() != DialogResult.OK) return;
                this._FileName = sfdZPL.FileName;
                ChangedFileName?.Invoke(this, new EventArgs { });
            }

            this.fastColoredTextBox1.SaveToFile(this._FileName, Encoding.UTF8);

        }

        /// <summary>
        /// Guarda el archivo de codigo ZPL con un nombre personalizable.
        /// </summary>
        public void GuardarComo()
        {
            sfdZPL.FileName = this._FileName;
            sfdZPL.InitialDirectory = this.PathFile;
            if (sfdZPL.ShowDialog() != DialogResult.OK) return;
            this._FileName = sfdZPL.FileName;
            this.fastColoredTextBox1.SaveToFile(this._FileName, Encoding.UTF8);
            ChangedFileName?.Invoke(this, new EventArgs { });
        }

        /// <summary>
        /// Abre un archivo de codigo ZPL.
        /// </summary>
        public void AbrirArchivoCodigo()
        {
            ofdZPL.InitialDirectory = this.PathFile;
            if (ofdZPL.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fastColoredTextBox1.Clear();
                if (ofdZPL.FileName != null)
                {
                    fastColoredTextBox1.OpenFile(ofdZPL.FileName);
                    this._FileName = ofdZPL.FileName;
                    ChangedFileName?.Invoke(this, new EventArgs { });
                }
            }
        }

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
        public Image previewLabel(string Code)
        {

            string[] ToAnalize = Regex
                .Split(Code.Replace("\r\n", ""), @"(?=\^XA)")
                .Where(x => x.Contains("^XZ"))
                .ToArray();

            var Resolution = (int)(203 * _ScaleLabel);


            var totalWidth = Resolution * widthLabel;
            var totalHeight = (Resolution * heightLabel) * ToAnalize.Count();

            Bitmap toRet = new Bitmap((int)totalWidth + 5, (int)totalHeight + 5);
            Graphics gp = Graphics.FromImage(toRet);

            var cnt = 0;

            try
            {
                foreach (var lbl in ToAnalize)
                {

                    var indexy = cnt;
                    var offsetY = (int)(Resolution * heightLabel) * indexy;
                    gp.ResetTransform();
                    gp.TranslateTransform(0, offsetY);

                    var rect = new Rectangle(0, 0, (int)(Resolution * widthLabel) - 2, (int)(Resolution * heightLabel) - 2);
                    gp.FillRectangle(Brushes.White, rect);
                    gp.DrawRectangle(Pens.Red, rect);

                    cnt++;

                    var Fields = Regex.Split(lbl
                    .Replace("^XA", "")
                    .Replace("^XZ", "")
                    , @"(?=\^FO)").ToList();

                    Fields.Sort((a, b) =>
                    {

                        var one = Regex.Match(a, "(GFA)|(A0)|(GB)|(B[3AQ])").Value;
                        var two = Regex.Match(b, "(GFA)|(A0)|(GB)|(B[3AQ])").Value;

                        int oneI = one == "GBA" ? 1 : (one == "A0" ? 3 : (one == "GB" ? 2 : 0));
                        int twoI = two == "GBA" ? 1 : (two == "A0" ? 3 : (two == "GB" ? 2 : 0));

                        return oneI.CompareTo(twoI);

                    });

                    foreach (var fld in Fields)
                    {
                        if (fld.Contains("^GFA"))
                        {
                            var splData = Regex.Split(fld.Replace("^FS", ""), @"\^");
                            var _point = splData.FirstOrDefault(t => t.Contains("FO")).Remove(0, 2).Split(',');
                            Point imgPoint = new Point((int)(int.Parse(_point[0]) * _ScaleLabel), (int)(int.Parse(_point[1]) * _ScaleLabel));

                            var code = Regex.Split(fld.Replace(" ", ""), @"(\^GFA,[0-9]+,[0-9]+,[0-9]+,)");

                            using (var img = this.zplImg.ZPLtoImage(code[0] + '\n' + code[1] + '\n' + code[2]))
                            {
                                gp.DrawImage(img, imgPoint.X, imgPoint.Y, (float)(img.Width * _ScaleLabel), (float)(img.Height * _ScaleLabel));
                            }
                        }
                        else if (fld.Contains("^A") && fld.Contains("^FD") && fld.Contains("^FB"))
                        {
                            var splData = Regex.Split(fld, @"\^");
                            var _point = splData.FirstOrDefault(t => t.Contains("FO")).Remove(0, 2).Split(',');
                            var _fieldData = splData.FirstOrDefault(t => t.Contains("FD")).Remove(0, 2).TrimEnd();
                            var _sizeFont = splData.FirstOrDefault(t => t.Contains("A0")).Split(',');
                            var _BlockData = splData.FirstOrDefault(t => t.Contains("FB")).Remove(0, 2).Split(',');

                            var angle = 0;
                            var isRotated = Regex.IsMatch(_sizeFont[0], @"(A0)[NRIB]{1}");
                            if (isRotated)
                            {
                                angle = _sizeFont[0].Contains("N") ? 0 : _sizeFont[0].Contains("R") ? 90 : _sizeFont[0].Contains("I") ? 180 : _sizeFont[0].Contains("B") ? 270 : 0;
                            }

                            Point lblPoint = new Point((int)(int.Parse(_point[0]) * _ScaleLabel), (int)(int.Parse(_point[1]) * _ScaleLabel));


                            double heightFont = int.Parse(_sizeFont[1]);
                            double widthFont = int.Parse(_sizeFont[2]);

                            Font fnt = new Font("Arial"
                                , (int)(heightFont * 9.5)
                                , FontStyle.Regular
                                , GraphicsUnit.Pixel
                                );


                            var y = gp.MeasureString(_fieldData, fnt);


                            double widthRectangle = int.Parse(_BlockData[0]) * 10;
                            double heightRectangle = (y.Height + 2) * (int.Parse(_BlockData[1]));

                            Rectangle rectangle = new Rectangle(new Point(0, 0), new Size((int)widthRectangle, (int)heightRectangle));

                            StringAlignment stA = StringAlignment.Near;
                            switch (_BlockData[3].Trim().First())
                            {
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

                            using (Bitmap bpStr = new Bitmap(
                                angle == 0 || angle == 180 ? (int)widthRectangle : (int)heightRectangle,
                                angle == 0 || angle == 180 ? (int)heightRectangle : (int)widthRectangle)
                                )
                            {
                                using (Graphics gpD = Graphics.FromImage(bpStr))
                                {
                                    switch (angle)
                                    {
                                        case 0:
                                            gpD.TranslateTransform(0, 0);
                                            break;
                                        case 90:
                                            gpD.TranslateTransform((float)bpStr.Width, 0);
                                            break;
                                        case 180:
                                            gpD.TranslateTransform((float)bpStr.Width, (float)bpStr.Height);
                                            break;
                                        case 270:
                                            gpD.TranslateTransform(0, (float)bpStr.Height);
                                            break;
                                    }

                                    gpD.RotateTransform(angle);
                                    gpD.DrawString(_fieldData, fnt, Brushes.Black, rectangle, new StringFormat { Alignment = stA });
                                }

                                gp.DrawImage(
                                    bpStr
                                    , lblPoint.X
                                    , lblPoint.Y
                                    , (float)(angle == 0 || angle == 180 ? (rectangle.Width / 10.5 * _ScaleLabel) : (rectangle.Height / 10.5 * _ScaleLabel))
                                    , (float)(angle == 0 || angle == 180 ? (rectangle.Height / 10.5 * _ScaleLabel) : (rectangle.Width / 10.5 * _ScaleLabel))
                                    );
                            }

                        }
                        else if (fld.Contains("^A") && fld.Contains("^FD") && !fld.Contains("^FB"))
                        {
                            var splData = Regex.Split(fld.Replace("^FS", ""), @"\^");
                            var _point = splData.FirstOrDefault(t => t.Contains("FO")).Remove(0, 2).Split(',');
                            var _fieldData = splData.FirstOrDefault(t => t.Contains("FD")).Remove(0, 2).TrimEnd();
                            var _sizeFont = splData.FirstOrDefault(t => t.Contains("A0")).Split(',');

                            var angle = 0;
                            var isRotated = Regex.IsMatch(_sizeFont[0], @"(A0)[NRIB]{1}");
                            if (isRotated)
                            {
                                angle = _sizeFont[0].Contains("N") ? 0 : _sizeFont[0].Contains("R") ? 90 : _sizeFont[0].Contains("I") ? 180 : _sizeFont[0].Contains("B") ? 270 : 0;
                            }

                            Point lblPoint = new Point((int)(int.Parse(_point[0]) * _ScaleLabel), (int)(int.Parse(_point[1]) * _ScaleLabel));

                            double heightData = int.Parse(_sizeFont[1]);
                            var y = gp.MeasureString(_fieldData, new Font("Arial", (int)heightData * 10));

                            double widthData = y.Width / 14.5;

                            using (Bitmap bpStr = new Bitmap(
                                angle == 0 || angle == 180 ?
                                (int)y.Width :
                                (int)y.Height
                                ,
                                angle == 0 || angle == 180 ?
                                (int)y.Height :
                                (int)y.Width

                                ))

                            {

                                using (Graphics gpD = Graphics.FromImage(bpStr))
                                {

                                    switch (angle)
                                    {
                                        case 0:
                                            gpD.TranslateTransform(0, 0);
                                            break;
                                        case 90:
                                            gpD.TranslateTransform((float)bpStr.Width, 0);
                                            break;
                                        case 180:
                                            gpD.TranslateTransform((float)bpStr.Width, (float)bpStr.Height);
                                            break;
                                        case 270:
                                            gpD.TranslateTransform(0, (float)bpStr.Height);
                                            break;
                                    }

                                    gpD.RotateTransform(angle);
                                    gpD.DrawString(_fieldData, new Font("Arial", (int)heightData * 10), Brushes.Black, 0, 0);
                                }

                                gp.DrawImage(bpStr,
                                    lblPoint.X,
                                    lblPoint.Y,
                                    (float)((angle == 0 || angle == 180 ? ((float)widthData * int.Parse(_sizeFont[2])) / int.Parse(_sizeFont[1]) : (float)heightData) * ScaleLabel),
                                    (float)((angle == 0 || angle == 180 ? (float)heightData : ((float)widthData * int.Parse(_sizeFont[2])) / int.Parse(_sizeFont[1])) * ScaleLabel));

                            }
                        }
                        else if (fld.Contains("^GB"))
                        {
                            var splData = Regex.Split(fld.Replace("^FS", ""), @"\^");
                            var _point = splData.FirstOrDefault(t => t.Contains("FO")).Remove(0, 2).Split(',');
                            Point rectPoint = new Point((int)(int.Parse(_point[0]) * _ScaleLabel), (int)(int.Parse(_point[1]) * _ScaleLabel));

                            var _sizeRect = splData.FirstOrDefault(t => t.Contains("GB")).Remove(0, 2).Split(',');
                            Size rectSize = new Size((int)(int.Parse(_sizeRect[0]) * _ScaleLabel), (int)(int.Parse(_sizeRect[1]) * _ScaleLabel));
                            Rectangle rec = new Rectangle(rectPoint, rectSize);

                            using (Pen pn = new Pen(Brushes.Black, (int)(int.Parse(_sizeRect[2]) * _ScaleLabel)))
                            {
                                gp.DrawRectangle(pn, rec);
                            }

                        }
                        else if (fld.Contains("^B3"))
                        {

                            var splData = Regex.Split(fld.Replace("^FS", ""), @"\^");
                            var _point = splData.FirstOrDefault(t => t.Contains("FO")).Remove(0, 2).Split(',');
                            var _fieldData = splData.FirstOrDefault(t => t.Contains("FD")).Remove(0, 2).TrimEnd();
                            var _BcodeD = splData.FirstOrDefault(t => t.Contains("B3")).Split(',');
                            Point imgPoint = new Point((int)(int.Parse(_point[0]) * _ScaleLabel), (int)(int.Parse(_point[1]) * _ScaleLabel));

                            var angle = 0;
                            var isRotated = Regex.IsMatch(_BcodeD[0], @"(B3)[NRIB]{1}");
                            if (isRotated)
                            {
                                angle = _BcodeD[0].Contains("N") ? 0 : _BcodeD[0].Contains("R") ? 90 : _BcodeD[0].Contains("I") ? 180 : _BcodeD[0].Contains("B") ? 270 : 0;
                            }

                            BarcodeWriter.Format = ZXing.BarcodeFormat.CODE_39;
                            BarcodeWriter.Options.Height = int.Parse(_BcodeD[2]) + ((_BcodeD[3].ToUpper() == "Y") ? 15 : 0);
                            BarcodeWriter.Options.Margin = 0;
                            BarcodeWriter.Options.PureBarcode = (!(_BcodeD[3].ToUpper() == "Y") ? true : false);

                            var imgCodeBar = BarcodeWriter.Write("*" + _fieldData + (_BcodeD[1] == "Y" ? MOD43CheckChar(_fieldData).ToString() : "") + "*");

                            using (Bitmap bpStr = new Bitmap(

                               angle == 0 || angle == 180 ?
                               (int)imgCodeBar.Width :
                               (int)imgCodeBar.Height
                               ,
                               angle == 0 || angle == 180 ?
                               (int)imgCodeBar.Height :
                               (int)imgCodeBar.Width

                               ))

                            {
                                using (Graphics gpD = Graphics.FromImage(bpStr))
                                {

                                    switch (angle)
                                    {
                                        case 0:
                                            gpD.TranslateTransform(0, 0);
                                            break;
                                        case 90:
                                            gpD.TranslateTransform((float)bpStr.Width, 0);
                                            break;
                                        case 180:
                                            gpD.TranslateTransform((float)bpStr.Width, (float)bpStr.Height);
                                            break;
                                        case 270:
                                            gpD.TranslateTransform(0, (float)bpStr.Height);
                                            break;
                                    }
                                    gpD.RotateTransform(angle);
                                    gpD.DrawImage(imgCodeBar, 0, 0);//, (float)(imgCodeBar.Width * ScaleLabel * 2.14), (float)(imgCodeBar.Height * ScaleLabel) );
                                                                    // gpD.DrawString( _fieldData, new Font( "Arial", (int)heightData * 10 ), Brushes.Black, 0, 0 );
                                }

                                gp.DrawImage(bpStr,
                                    imgPoint.X,
                                    imgPoint.Y,
                                    angle == 0 || angle == 180 ? (float)(imgCodeBar.Width * ScaleLabel * 2) : (float)(imgCodeBar.Height * ScaleLabel),
                                    angle == 0 || angle == 180 ? (float)(imgCodeBar.Height * ScaleLabel) : (float)(imgCodeBar.Width * ScaleLabel * 2)
                                    );
                            }
                        }
                        else if (fld.Contains("^BA"))
                        {
                            var splData = Regex.Split(fld.Replace("^FS", ""), @"\^");
                            var _point = splData.FirstOrDefault(t => t.Contains("FO")).Remove(0, 2).Split(',');
                            var _fieldData = splData.FirstOrDefault(t => t.Contains("FD")).Remove(0, 2).TrimEnd();
                            var _BcodeD = splData.FirstOrDefault(t => t.Contains("BA")).Split(',');

                            Point imgPoint = new Point((int)(int.Parse(_point[0]) * _ScaleLabel), (int)(int.Parse(_point[1]) * _ScaleLabel));
                            var angle = 0;
                            var isRotated = Regex.IsMatch(_BcodeD[0], @"(BA)[NRIB]{1}");
                            if (isRotated)
                            {
                                angle = _BcodeD[0].Contains("N") ? 0 : _BcodeD[0].Contains("R") ? 90 : _BcodeD[0].Contains("I") ? 180 : _BcodeD[0].Contains("B") ? 270 : 0;
                            }

                            BarcodeWriter.Format = ZXing.BarcodeFormat.CODE_93;
                            BarcodeWriter.Options.Height = int.Parse(_BcodeD[1]) + ((_BcodeD[2].ToUpper() == "Y") ? 15 : 0);
                            BarcodeWriter.Options.Margin = 0;
                            BarcodeWriter.Options.PureBarcode = (!(_BcodeD[2].ToUpper() == "Y") ? true : false);

                            var imgCodeBar = BarcodeWriter.Write("*" + _fieldData + (_BcodeD[4] == "Y" ? MOD43CheckChar(_fieldData).ToString() : "") + "*");

                            using (Bitmap bpStr = new Bitmap(

                               angle == 0 || angle == 180 ?
                               (int)imgCodeBar.Width :
                               (int)imgCodeBar.Height
                               ,
                               angle == 0 || angle == 180 ?
                               (int)imgCodeBar.Height :
                               (int)imgCodeBar.Width

                               ))

                            {
                                using (Graphics gpD = Graphics.FromImage(bpStr))
                                {

                                    switch (angle)
                                    {
                                        case 0:
                                            gpD.TranslateTransform(0, 0);
                                            break;
                                        case 90:
                                            gpD.TranslateTransform((float)bpStr.Width, 0);
                                            break;
                                        case 180:
                                            gpD.TranslateTransform((float)bpStr.Width, (float)bpStr.Height);
                                            break;
                                        case 270:
                                            gpD.TranslateTransform(0, (float)bpStr.Height);
                                            break;
                                    }
                                    gpD.RotateTransform(angle);
                                    gpD.DrawImage(imgCodeBar, 0, 0);//, (float)(imgCodeBar.Width * ScaleLabel * 2.14), (float)(imgCodeBar.Height * ScaleLabel) );
                                                                    // gpD.DrawString( _fieldData, new Font( "Arial", (int)heightData * 10 ), Brushes.Black, 0, 0 );
                                }

                                gp.DrawImage(bpStr,
                                    imgPoint.X,
                                    imgPoint.Y,
                                    angle == 0 || angle == 180 ? (float)(imgCodeBar.Width * ScaleLabel * 2) : (float)(imgCodeBar.Height * ScaleLabel),
                                    angle == 0 || angle == 180 ? (float)(imgCodeBar.Height * ScaleLabel) : (float)(imgCodeBar.Width * ScaleLabel * 2)
                                    );
                            }
                        }
                        else if (fld.Contains("^BQ"))
                        {
                            var splData = Regex.Split(fld.Replace("^FS", ""), @"\^");
                            var _point = splData.FirstOrDefault(t => t.Contains("FO")).Remove(0, 2).Split(',');
                            var _fieldData = Regex.Split(splData.FirstOrDefault(t => t.Contains("FD")), @"(?<=FD[QHLM]{1}[AM]{1},)");//splData.FirstOrDefault(t=>t.Contains("FD")).Split(',');
                            var _BcodeD = splData.FirstOrDefault(t => t.Contains("BQ")).Split(',');

                            Point imgPoint = new Point((int)(int.Parse(_point[0]) * _ScaleLabel), (int)(int.Parse(_point[1]) * _ScaleLabel));
                            BarcodeWriter.Format = ZXing.BarcodeFormat.QR_CODE;

                            Func<ZXing.QrCode.Internal.ErrorCorrectionLevel> y = () =>
                            {
                                switch (_fieldData[0][2])
                                {
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

                            QrCodeEncodingOptions options = new QrCodeEncodingOptions
                            {
                                DisableECI = _BcodeD[1].Trim() == "1" ? false : true,
                                CharacterSet = "UTF-8",
                                ErrorCorrection = y(),
                                Margin = 0
                            };
                            BarcodeWriter.Options = options;
                            BCsvg.Format = ZXing.BarcodeFormat.QR_CODE;
                            BCsvg.Options = options;
                            var bcSVG = BCsvg.Write(_fieldData[1].TrimStart().TrimEnd());

                            var svgDocument = Svg.SvgDocument.FromSvg<Svg.SvgDocument>(bcSVG.Content);
                            svgDocument.Width = bcSVG.Width * int.Parse(_BcodeD[2]);
                            svgDocument.Height = bcSVG.Height * int.Parse(_BcodeD[2]);
                            var bitmap = svgDocument.Draw(bcSVG.Width * int.Parse(_BcodeD[2]), bcSVG.Height * int.Parse(_BcodeD[2]));

                            gp.DrawImage(bitmap,
                                       imgPoint.X,
                                       imgPoint.Y,
                                       (float)(bitmap.Width * ScaleLabel),
                                       (float)(bitmap.Height * ScaleLabel)
                                       );
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                return null;
            }

            return toRet;
        }

        #endregion

        private Dictionary<string, string> toInsert = new Dictionary<string, string>()
        {
            { "CPF", "\t^FO50,50^A0N,20,20^FDSu Texto Aqui^FS\n"},
            { "CPV", "\t^FO50,50^A0N,20,20^FD@Su Texto Aqui^FS\n"},
            { "BXF", "\t^FO50,50^FB100,4,0,L,0^A0N,20,20^FDSu Texto Aqui^FS\n"},
            { "BXV", "\t^FO50,50^FB100,4,0,L,0^A0N,20,20^FD@Su Texto Aqui^FS\n"},
            { "C39", "\t^FO0,0^B3N,N,50,N,N^FD12345^FS\n" },
            { "C93", "\t^FO0,0^BAN,50,N,N,N^FD12345^FS\n" },
            { "CQR", "\t^FO0,0^BQN,2,3^FDQA, 123456^FS\n" },
            { "GFR", "\t^FO0,0^GB100,100,1^FS\n"}
        };
        
        private void fijoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tg = sender.GetType().GetProperty("Tag").GetValue(sender).ToString();

            if (toInsert.ContainsKey(tg))
            {                
                fastColoredTextBox1.InsertText(toInsert[tg]);
            }else
            {
                if (tg == "GFI")
                {
                    var frm = new importZPLImageForm() { };
                    if (frm.ShowDialog() != DialogResult.OK) return;
                    fastColoredTextBox1.InsertText(frm.ZPLResult.Replace("\n", "\n\t") + '\n');
                }
            }
        }
    }
}

