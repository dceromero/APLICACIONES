using System.Web;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class ClassPDF
    {
        private Document documento = null;
        private PdfWriter Escribir = null;
        private string servidor = HttpContext.Current.Server.MapPath("../../FORMATOCUPO/");

        public void CrearDocuemto(string archivo)
        {
            servidor = servidor.Replace("\\api", "");
            documento = new Document(PageSize.A4);
            documento.SetMargins(-30, -30, 10, 40);
            var Ruta = string.Format("{0}/{1}.pdf", servidor, archivo);
            Escribir = PdfWriter.GetInstance(documento, new FileStream(Ruta, FileMode.Create));
        }

        public void CrearDocuemtoHorizontal(string archivo)
        {
            servidor = HttpContext.Current.Server.MapPath("../../FORMATOSAP/");
            servidor = servidor.Replace("\\api", "");
            documento = new Document(PageSize.A4.Rotate());
            documento.SetMargins(-80, -80, 10, 40);
            var Ruta = string.Format("{0}/{1}.pdf", servidor, archivo);
            Escribir = PdfWriter.GetInstance(documento, new FileStream(Ruta, FileMode.Create));
        }

        public void NuevaPagina()
        {
            documento.NewPage();
        }
        public void AbrirDocumento()
        {
            documento.Open();
        }

        public void NuevaLinea()
        {
            documento.Add(Chunk.NEWLINE);
        }

        public void Adiccionar(IElement obj)
        {
            documento.Add(obj);
        }

        public void TituloyAutor(string Titulo, string Autor)
        {
            documento.AddTitle(Titulo);
            documento.AddAuthor(Autor);
        }

        /// <summary>
        /// WidthColumnas =new float[] { 0.25F, 0.75F}
        /// Nota: Se debe de repartir el porcentaje deacuerdo al numero de columna
        /// </summary>
        public PdfPTable CrearTabla(int NumColumna, float[] WidthColumnas)
        {
            PdfPTable tabla = new PdfPTable(NumColumna);
            tabla.SetWidths(WidthColumnas);
            return tabla;
        }

        /// <summary>
        /// Alieneacion
        ///Element.ALIGN_LEFT=0
        ///Element.ALIGN_CENTER=1
        /// Element.ALIGN_RIGHT=2    
        /// </summary>
        public PdfPCell CrearCelda(string Texto, Font Fuente, float Border, int Alineacion, BaseColor backGround = null)
        {
            PdfPCell celda = new PdfPCell(new Phrase(Texto, Fuente));
            celda.BorderWidth = Border;
            celda.HorizontalAlignment = Alineacion;
            celda.VerticalAlignment = Alineacion;
            if (backGround != null)
            {
                celda.BackgroundColor = backGround;
            }
            return celda;
        }


        /// <summary>
        /// Alieneacion
        ///Element.ALIGN_LEFT=0
        ///Element.ALIGN_CENTER=1
        /// Element.ALIGN_RIGHT=2    
        /// </summary>
        public Image pdfImagen(string imagen, float Posicion, int SizeImg)
        {
            servidor = HttpContext.Current.Server.MapPath("../../Image/");
            servidor = servidor.Replace("\\api", "");
            Image img = Image.GetInstance(string.Format("{0}{1}", servidor, imagen));
            img.SetAbsolutePosition(0, Posicion);
            img.ScalePercent(SizeImg);
            return img;
        }

        public Image CrearCodigoBarra(string texto)
        {
            var qr = new BarcodeQRCode(texto, 1, 1, null);
            var img = qr.GetImage();
            return img;
        }

        public void pdfImagen(string imagen, float PosicionX, float PosicionY, int SizeImg)
        {
            Image img = Image.GetInstance(string.Format("{0}{1}", servidor, imagen));
            img.SetAbsolutePosition(PosicionX, PosicionY);
            img.ScalePercent(SizeImg);
            documento.Add(img);
        }
        public Font PdfLetra(int SizeLetra, bool Negrilla, bool Italica, bool Subrayado)
        {
            Font fuente = new Font(Font.FontFamily.HELVETICA, SizeLetra, Font.NORMAL, BaseColor.BLACK);
            if (Negrilla)
            {
                fuente.IsBold();
            }
            if (Italica)
            {
                fuente.IsItalic();
            }
            if (Subrayado)
            {
                fuente.IsUnderlined();
            }
            return fuente;
        }

        public void CerrarDocumento()
        {
            documento.Close();
        }
    }
}
