using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosPDFs
    {
        public string PDFSOLICTUDCUPO(long id)
        {
            MetodosCreditos mtc = new MetodosCreditos();
            View_SOLICITUDESCUPO vm = mtc.VistaAprobacion(id);
            List<VIEW_FIRMAS_CREDITOS> vf = mtc.ListaFirma(id);
            ClassPDF pdf = new ClassPDF();
            string nameflie = $"{vm.IDSOL}-{vm.CODRESPAGO}";
            #region Creacion Documento
            pdf.CrearDocuemto(nameflie);
            pdf.TituloyAutor("Solicitud Credito", "Gloria Colombia");
            pdf.AbrirDocumento();
            #endregion

            #region  Tipos de Letras
            Font LetraCabecera = pdf.PdfLetra(12, true, false, true);
            Font LetraTitulo = pdf.PdfLetra(10, true, false, false);
            Font LetraContenido = pdf.PdfLetra(8, false, false, false);
            Font LetraFooter = pdf.PdfLetra(6, true, false, true);
            #endregion

            #region Cabecera
            PdfPTable TCabecera = pdf.CrearTabla(2, new float[] { 0.20F, 0.80F });
            TCabecera.AddCell(pdf.pdfImagen("LogoEmpresa.png", PageSize.LETTER.Right, 20));
            PdfPTable TCabecera0 = pdf.CrearTabla(1, new float[] { 0.99F });
            string tpsol = "1" == vm.TIPOSOL.ToString() ? "MODIFICACIÓN DE CUPO" : "DE EXTRACUPO";
            PdfPCell CCabecera = pdf.CrearCelda($"SOLICITUD {tpsol} ", LetraCabecera, 0, Element.ALIGN_CENTER);
            TCabecera0.AddCell(pdf.CrearCelda(" ", LetraCabecera, 0, Element.ALIGN_CENTER));
            TCabecera0.AddCell(pdf.CrearCelda(" ", LetraCabecera, 0, Element.ALIGN_CENTER));
            TCabecera0.AddCell(CCabecera);
            TCabecera0.AddCell(pdf.CrearCelda(" ", LetraCabecera, 0, Element.ALIGN_CENTER));
            TCabecera.AddCell(TCabecera0);
            #endregion

            #region Codigo Formato
            string version = vm.TIPOSOL == 1 ? "VERSIÓN: 01" : "VERSIÓN: 02";
            string n = vm.TIPOSOL == 1 ? "1" : "2";
            PdfPTable TCODFORM = pdf.CrearTabla(2, new float[] { 0.5F, 0.5F });
            TCODFORM.AddCell(pdf.CrearCelda($"CÓDIGO: FR-AF2-00{n}", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TCODFORM.AddCell(pdf.CrearCelda(version, LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            #endregion

            #region Fecha  Solicitud y Numero de Proceso
            PdfPTable TFP = pdf.CrearTabla(4, new float[] { 0.3F, 0.2F, 0.3F, 0.2F });
            TFP.AddCell(pdf.CrearCelda("FECHA DE SOLICITUD : ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
            TFP.AddCell(pdf.CrearCelda(vm.FECSOL.ToString("yyyy-MM-dd"), LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TFP.AddCell(pdf.CrearCelda("Número de Proceso:", LetraContenido, 0.75F, Element.ALIGN_LEFT));
            TFP.AddCell(pdf.CrearCelda(vm.IDSOL.ToString(), LetraContenido, 0.75F, Element.ALIGN_RIGHT));
            #endregion

            #region Titulo Comercial
            PdfPTable TTLCOM = pdf.CrearTabla(1, new float[] { 0.99F });
            TTLCOM.AddCell(pdf.CrearCelda(" ", LetraTitulo, 0, Element.ALIGN_CENTER));
            TTLCOM.AddCell(pdf.CrearCelda("DILIGENCIAMIENTO AREA COMERCIAL", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            #endregion

            #region Codigo Formato
            PdfPTable TCLIENTE = pdf.CrearTabla(2, new float[] { 0.5F, 0.5F });
            TCLIENTE.AddCell(pdf.CrearCelda("EMPLEADO SOLICITANTE : ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
            TCLIENTE.AddCell(pdf.CrearCelda(vm.VENDEDOR, LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TCLIENTE.AddCell(pdf.CrearCelda("CLIENTE : ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
            TCLIENTE.AddCell(pdf.CrearCelda(vm.RAZSOCRESP, LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TCLIENTE.AddCell(pdf.CrearCelda("CODIGO SAP : ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
            TCLIENTE.AddCell(pdf.CrearCelda(vm.CODRESPAGO.ToString(), LetraTitulo, 0.75F, Element.ALIGN_CENTER));

            TCLIENTE.AddCell(pdf.CrearCelda("CUPO ASIGNADO : ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
            TCLIENTE.AddCell(pdf.CrearCelda($"$ {vm.CUPOASIGNADO.ToString("0,0")}", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
            TCLIENTE.AddCell(pdf.CrearCelda("CUPO SOLICITADO: ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
            TCLIENTE.AddCell(pdf.CrearCelda($"$ {vm.CUPOSOLICITADO.ToString("0,0")}", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
            #endregion

            #region Titulo HIPOTECA
            PdfPTable TTLHIP = pdf.CrearTabla(1, new float[] { 0.99F });
            TTLHIP.AddCell(pdf.CrearCelda("CONCEPTO", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TTLHIP.AddCell(pdf.CrearCelda(vm.OBS.ToUpper(), LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TTLHIP.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
            TTLHIP.AddCell(pdf.CrearCelda("GARANTIAS DEL CLIENTE", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TTLHIP.AddCell(pdf.CrearCelda("HIPOTECA", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            #endregion

            #region Codigo Formato
            PdfPTable THIP = pdf.CrearTabla(2, new float[] { 0.5F, 0.5F });
            THIP.AddCell(pdf.CrearCelda("1) VALOR : ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
            THIP.AddCell(pdf.CrearCelda($"$ {vm.hipoteca.ToString("0,0")} ", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
            #endregion

            #region Titulo PIGNORACION
            PdfPTable TTLPIG = pdf.CrearTabla(1, new float[] { 0.99F });
            TTLPIG.AddCell(pdf.CrearCelda("PIGNORACIÓN", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            #endregion

            #region Codigo Formato
            PdfPTable TPIGP = pdf.CrearTabla(2, new float[] { 0.5F, 0.5F });
            TPIGP.AddCell(pdf.CrearCelda("1) VALOR : ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
            TPIGP.AddCell(pdf.CrearCelda($"$ {vm.pignoracion.ToString("0,0")} ", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
            #endregion

            #region Titulo Cartera
            PdfPTable TTLCAR = pdf.CrearTabla(1, new float[] { 0.99F });
            TTLCAR.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
            TTLCAR.AddCell(pdf.CrearCelda("DILIGENCIAMIENTO AREA CREDITO Y CARTERA", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            #endregion

            double total = vm.TIPOSOL == 1 ? vm.CUPOSOLICITADO : vm.CUPOSOLICITADO + vm.CUPOASIGNADO;
            #region Cartera
            PdfPTable TCARTERA = null;
            if (vm.TIPOSOL == 1)
            {
                TCARTERA = pdf.CrearTabla(2, new float[] { 0.5F, 0.5F });
                TCARTERA.AddCell(pdf.CrearCelda("CUPO APROBADO: ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                TCARTERA.AddCell(pdf.CrearCelda($"$ {total.ToString("0,0")}", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                TCARTERA.AddCell(pdf.CrearCelda("FECHA MODIFICACIÓN SAP(DD/MM/AAAA): ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                TCARTERA.AddCell(pdf.CrearCelda("____/____ /_____", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));

            }
            else
            {
                TCARTERA = pdf.CrearTabla(4, new float[] { 0.5F, 0.5F, 0.6F, 0.4F });
                TCARTERA.AddCell(pdf.CrearCelda("SALDO CARTERA : ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                TCARTERA.AddCell(pdf.CrearCelda($"$ {vm.CUPOENCARTERA.ToString("0,0")}", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                TCARTERA.AddCell(pdf.CrearCelda("SALDO VENCIDO: ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                TCARTERA.AddCell(pdf.CrearCelda($"$ {vm.CUPOVENCIDO.ToString("0,0")}", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                TCARTERA.AddCell(pdf.CrearCelda("DÍAS EN MORA : ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                TCARTERA.AddCell(pdf.CrearCelda(vm.DIASVEN.ToString(), LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                TCARTERA.AddCell(pdf.CrearCelda("CUPO ACTUAL + EXTRA: ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                TCARTERA.AddCell(pdf.CrearCelda($"$ {total.ToString("0,0")}", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
            }

            #endregion

            if (vm.TIPOSOL == 2)
            {
                string Vigencia = $"VIGENCIA HASTA : {vm.VIGENCIA.ToString("yyyy-MM-dd")}";
                #region Vigencia
                PdfPTable TVIG = pdf.CrearTabla(1, new float[] { 0.99F });
                TVIG.AddCell(pdf.CrearCelda(Vigencia, LetraFooter, 0.75F, Element.ALIGN_CENTER));
                #endregion
            }

            #region Titulo Firmas
            PdfPTable TTF = pdf.CrearTabla(1, new float[] { 0.99F });
            TTF.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
            TTF.AddCell(pdf.CrearCelda("FIRMAS", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            #endregion
            pdf.Adiccionar(TCabecera);
            pdf.Adiccionar(TCODFORM);
            pdf.Adiccionar(TFP);
            pdf.Adiccionar(TTLCOM);
            pdf.Adiccionar(TCLIENTE);
            pdf.Adiccionar(TTLHIP);
            pdf.Adiccionar(THIP);
            pdf.Adiccionar(TTLPIG);
            pdf.Adiccionar(TPIGP);
            pdf.Adiccionar(TTLCAR);
            pdf.Adiccionar(TCARTERA);
            pdf.Adiccionar(TTF);

            #region Firmas
            int col = 2;
            float[] filas = new float[] { 0.50F, 0.50F };
            if (vf.Count > 2)
            {
                col = 3;
                filas = new float[] { 0.33F, 0.33F, 0.33F };
            }

            PdfPTable TFIRM = pdf.CrearTabla(col, filas);
            int columna = 1;
            foreach (var f in vf)
            {
                PdfPTable TFCONT = pdf.CrearTabla(1, new float[] { 0.99F });
                TFCONT.AddCell(pdf.CrearCelda(f.NAMECARGO, LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TFCONT.AddCell(pdf.CrearCelda(f.NOMBRE, LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TFCONT.AddCell(pdf.CrearCelda(f.CEDULA.ToString(), LetraFooter, 0.75F, Element.ALIGN_CENTER));
                string texto = $"Cargo: {f.NAMECARGO} \n Nombres: {f.NAMECARGO} \n  Cedula: {f.CEDULA}";
                PdfPTable TFCODBAR = pdf.CrearTabla(3, new float[] { 0.33F, 0.33F, 0.33F });
                TFCODBAR.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                TFCODBAR.AddCell(pdf.CrearCodigoBarra(texto));
                TFCODBAR.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                TFCONT.AddCell(TFCODBAR);
                TFCONT.AddCell(pdf.CrearCelda(f.FECAPROB.ToString("yyyy-MM-dd hh:mm"), LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TFIRM.AddCell(TFCONT);
                columna++;
            }
            if (vf.Count > 3)
            {
                while (columna != 7)
                {
                    TFIRM.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                    columna++;
                }
            }
            #endregion


            pdf.Adiccionar(TFIRM);
            pdf.CerrarDocumento();

            return nameflie;
        }

        public string pdfGanadero(List<LiqGanaderos> _liq)
        {
            MetodosLiqGanaderos mtLiqGan = new MetodosLiqGanaderos();
            string carpeta = "No encontro Cerfitificado";
            foreach (var liq in _liq)
            {
                carpeta = "Certificados generados, Por favor revisar la carpeta";
                ClassPDF pdf = new ClassPDF();
                string nameflie = $"Liq_{liq.NIT_CED}";
                #region Creacion Documento
                pdf.CrearDocuemto(nameflie);
                pdf.TituloyAutor("Formato de Liquidacion", "Gloria Colombia");
                pdf.AbrirDocumento();
                #endregion

                #region  Tipos de Letras
                Font LetraCabecera = pdf.PdfLetra(12, true, false, true);
                Font LetraTitulo = pdf.PdfLetra(10, true, false, false);
                Font LetraContenido = pdf.PdfLetra(8, false, false, false);
                Font LetraFooter = pdf.PdfLetra(8, true, false, true);
                #endregion


                #region Cabecera
                PdfPTable TCabecera = pdf.CrearTabla(2, new float[] { 0.10F, 0.80F });
                TCabecera.AddCell(pdf.pdfImagen("LogoEmpresa.png", PageSize.LETTER.Right, 10));
                PdfPTable TCabecera0 = pdf.CrearTabla(1, new float[] { 0.99F });
                string tpsol = "FORMATO PARA LIQUIDACIÓN Y PAGO DE LA LECHE CRUDA AL PRODUCTOR ";
                PdfPCell CCabecera = pdf.CrearCelda(tpsol, LetraCabecera, 0, Element.ALIGN_CENTER);
                TCabecera0.AddCell(CCabecera);
                TCabecera0.AddCell(pdf.CrearCelda(" ", LetraCabecera, 0, Element.ALIGN_CENTER));
                TCabecera.AddCell(TCabecera0);
                #endregion

                #region Codigo Formato
                PdfPTable TCODFORM = pdf.CrearTabla(2, new float[] { 0.5F, 0.5F });
                TCODFORM.AddCell(pdf.CrearCelda($"Fecha de liquidación : {liq.FEC_LIQ.ToString("yyyy-MM-dd")}", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                TCODFORM.AddCell(pdf.CrearCelda("Período liquidado ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region Fecha  Solicitud y Numero de Proceso
                PdfPTable TFP = pdf.CrearTabla(4, new float[] { 0.3F, 0.2F, 0.3F, 0.2F });
                TFP.AddCell(pdf.CrearCelda("Desde : ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                TFP.AddCell(pdf.CrearCelda($"{liq.FECINI_LIQ.ToString("yyyy-MM-dd")}", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                TFP.AddCell(pdf.CrearCelda("Hasta :", LetraContenido, 0.75F, Element.ALIGN_LEFT));
                TFP.AddCell(pdf.CrearCelda($"{liq.FECFIN_LIQ.ToString("yyyy-MM-dd")}", LetraContenido, 0.75F, Element.ALIGN_RIGHT));
                #endregion

                #region Titulo Agente Economico
                PdfPTable tTAEco = pdf.CrearTabla(1, new float[] { 0.99F });
                tTAEco.AddCell(pdf.CrearCelda(" ", LetraTitulo, 0, Element.ALIGN_CENTER));
                tTAEco.AddCell(pdf.CrearCelda("DATOS DEL AGENTE ECONÓMICO COMPRADOR DE LECHE", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region Titulo Agente Economico detalle
                PdfPTable tTAEcoDet = pdf.CrearTabla(2, new float[] { 0.5F, 0.5F });
                tTAEcoDet.AddCell(pdf.CrearCelda("Nombre o Razón Social : GLORIA COLOMBIA S.A", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tTAEcoDet.AddCell(pdf.CrearCelda("Nit ó Cédula : 830507278-9", LetraTitulo, 0.75F, Element.ALIGN_CENTER));


                PdfPTable tTAEcoDet2 = pdf.CrearTabla(3, new float[] { 0.3F, 0.3F, 0.3F });
                tTAEcoDet2.AddCell(pdf.CrearCelda("Dirección : DG 63 F 86 35", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tTAEcoDet2.AddCell(pdf.CrearCelda("Departamento : Bogotá D.C.", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tTAEcoDet2.AddCell(pdf.CrearCelda("Municipio: Bogotá, D.C.", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region DATOS DEL PRODUCTOR DE LECHE
                PdfPTable tDPL = pdf.CrearTabla(1, new float[] { 0.99F });
                tDPL.AddCell(pdf.CrearCelda("DATOS DEL PRODUCTOR DE LECHE", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region DATOS DEL PRODUCTOR DE LECHE DETALLE
                PdfPTable tDPLD = pdf.CrearTabla(3, new float[] { 0.4F, 0.3F, 0.3F });
                tDPLD.AddCell(pdf.CrearCelda($"Nombre ó Razón Social : {liq.NOMBRE} ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tDPLD.AddCell(pdf.CrearCelda($"Nit ó Cédula : {liq.NIT_CED} ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tDPLD.AddCell(pdf.CrearCelda($"Teléfono : {liq.TELEFONO}", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tDPLD.AddCell(pdf.CrearCelda($"Región  : {liq.REGION}", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tDPLD.AddCell(pdf.CrearCelda($"Departamento : {liq.DEPARTAMENTO}", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tDPLD.AddCell(pdf.CrearCelda($"Municipio : {liq.MUNICIPIO}", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region PAGO POR CALIDAD COMPOSICIONAL
                PdfPTable tTPCC = pdf.CrearTabla(1, new float[] { 0.99F });
                tTPCC.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                tTPCC.AddCell(pdf.CrearCelda("PAGO POR CALIDAD COMPOSICIONAL", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region  PAGO POR CALIDAD COMPOSICIONAL DETALLE
                PdfPTable TPCCD = pdf.CrearTabla(3, new float[] { 0.3F, 0.3F, 0.3F });
                TPCCD.AddCell(pdf.CrearCelda("RESULTADOS ANALISIS DE CALIDAD", LetraTitulo, 0.75F, Element.ALIGN_CENTER));

                PdfPTable TPCCD2_1 = pdf.CrearTabla(1, new float[] { 0.99F });
                TPCCD2_1.AddCell(pdf.CrearCelda("Resultado promedio ultimas 3 quincenas / lt", LetraTitulo, 0, Element.ALIGN_CENTER));
                PdfPTable TPCCD2_1_1 = pdf.CrearTabla(5, new float[] { 0.2F, 0.2F, 0.2F, 0.2F, 0.2F });
                TPCCD2_1_1.AddCell(pdf.CrearCelda("1", LetraContenido, 0, Element.ALIGN_CENTER));
                TPCCD2_1_1.AddCell(pdf.CrearCelda("2", LetraContenido, 0, Element.ALIGN_CENTER));
                TPCCD2_1_1.AddCell(pdf.CrearCelda("3", LetraContenido, 0, Element.ALIGN_CENTER));
                TPCCD2_1_1.AddCell(pdf.CrearCelda("Prom", LetraContenido, 0, Element.ALIGN_CENTER));
                TPCCD2_1_1.AddCell(pdf.CrearCelda("Cant (gr)", LetraContenido, 0, Element.ALIGN_CENTER));
                TPCCD2_1.AddCell(TPCCD2_1_1);
                TPCCD.AddCell(TPCCD2_1);

                TPCCD.AddCell(pdf.CrearCelda("Valor pagado según cantiad de gramos ($/Litro)", LetraTitulo, 0.75F, Element.ALIGN_CENTER));



                PdfPTable TPCCD1 = pdf.CrearTabla(2, new float[] { 0.5F, 0.5F });
                PdfPTable TPCCD1_1 = pdf.CrearTabla(1, new float[] { 0.99F });
                TPCCD1_1.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                TPCCD1_1.AddCell(pdf.CrearCelda("Calidad Composicional", LetraTitulo, 0, Element.ALIGN_CENTER));
                TPCCD1_1.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                TPCCD1.AddCell(TPCCD1_1);
                PdfPTable TPCCD1_2 = pdf.CrearTabla(1, new float[] { 0.99F });
                TPCCD1_2.AddCell(pdf.CrearCelda("Proteína (%)", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD1_2.AddCell(pdf.CrearCelda("Grasa (%)", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                TPCCD1_2.AddCell(pdf.CrearCelda("Sólidos Totales (%)", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD1.AddCell(TPCCD1_2);
                TPCCD.AddCell(TPCCD1);


                PdfPTable TPCCD2_1_2 = pdf.CrearTabla(5, new float[] { 0.2F, 0.2F, 0.2F, 0.2F, 0.2F });
                TPCCD2_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda($"{liq.CALIDAD1}", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda($"{liq.CALIDAD2}", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda($"{liq.CALIDAD3}", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda($"{liq.CAL_PROMED} ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD2_1_2.AddCell(pdf.CrearCelda($"{liq.CANTIDAD} ", LetraFooter, 0.75F, Element.ALIGN_CENTER));

                TPCCD.AddCell(TPCCD2_1_2);


                PdfPTable TPCCD3_1 = pdf.CrearTabla(1, new float[] { 0.99F });
                TPCCD3_1.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD3_1.AddCell(pdf.CrearCelda(" ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD3_1.AddCell(pdf.CrearCelda($"{liq.VAL_PAGADO} ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TPCCD.AddCell(TPCCD3_1);
                #endregion

                #region BONIFICACIONES OBLIGATORIAS
                PdfPTable tBO = pdf.CrearTabla(1, new float[] { 0.99F });
                tBO.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                tBO.AddCell(pdf.CrearCelda("BONIFICACIONES OBLIGATORIAS", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion


                #region  BONIFICACIONES OBLIGATORIASL DETALLE
                PdfPTable tBOD = pdf.CrearTabla(3, new float[] { 0.3F, 0.3F, 0.3F });
                tBOD.AddCell(pdf.CrearCelda("RESULTADOS ANALISIS DE CALIDAD ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));




                PdfPTable tBOD2_1 = pdf.CrearTabla(1, new float[] { 0.99F });
                tBOD2_1.AddCell(pdf.CrearCelda("Resultado promedio ultimas 3 quincenas ", LetraTitulo, 0, Element.ALIGN_CENTER));
                PdfPTable tBOD2_1_1 = pdf.CrearTabla(4, new float[] { 0.25F, 0.25F, 0.25F, 0.25F });
                tBOD2_1_1.AddCell(pdf.CrearCelda("1", LetraContenido, 0, Element.ALIGN_CENTER));
                tBOD2_1_1.AddCell(pdf.CrearCelda("2", LetraContenido, 0, Element.ALIGN_CENTER));
                tBOD2_1_1.AddCell(pdf.CrearCelda("3", LetraContenido, 0, Element.ALIGN_CENTER));
                tBOD2_1_1.AddCell(pdf.CrearCelda("Prom", LetraContenido, 0, Element.ALIGN_CENTER));
                tBOD2_1.AddCell(tBOD2_1_1);
                tBOD.AddCell(tBOD2_1);


                tBOD.AddCell(pdf.CrearCelda("Bonificación ó descuento según promedio ($/Litro)", LetraTitulo, 0.75F, Element.ALIGN_CENTER));


                PdfPTable tBOD1 = pdf.CrearTabla(2, new float[] { 0.18F, 0.82F });
                PdfPTable tBOD1_1 = pdf.CrearTabla(1, new float[] { 0.99F });

                PdfPTable tBOD1_1_1 = pdf.CrearTabla(1, new float[] { 0.99F });
                tBOD1_1_1.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                tBOD1_1_1.AddCell(pdf.CrearCelda("Calidad Higiénica", LetraContenido, 0, Element.ALIGN_CENTER));
                tBOD1_1_1.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                tBOD1_1.AddCell(tBOD1_1_1);


                PdfPTable tBOD1_1_2 = pdf.CrearTabla(1, new float[] { 0.99F });
                tBOD1_1_1.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                tBOD1_1_2.AddCell(pdf.CrearCelda("Calidad Sanitaria (Tuberculosis - Brucellosis)", LetraContenido, 0, Element.ALIGN_CENTER));
                tBOD1_1_2.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                tBOD1_1.AddCell(tBOD1_1_2);

                PdfPTable tBOD1_1_3 = pdf.CrearTabla(1, new float[] { 0.99F });
                tBOD1_1_3.AddCell(pdf.CrearCelda("BPG", LetraContenido, 0, Element.ALIGN_CENTER));
                tBOD1_1.AddCell(tBOD1_1_3);

                tBOD1.AddCell(tBOD1_1);

                PdfPTable tBOD1_2 = pdf.CrearTabla(6, new float[] { 0.19F, 0.1F, 0.1F, 0.1F, 0.1F, 0.41F });

                tBOD1_2.AddCell(pdf.CrearCelda("Unidades Formadoras de Colonia (UFC/ml)", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda($"{liq.MIC_MICRO1} ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda($"{liq.MIC_MICRO2} ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda($"{liq.MIC_MICRO3} ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda($"{liq.MIC_PROMED} ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda($"{liq.BONIF_DCTO_MICRO} ", LetraContenido, 0.75F, Element.ALIGN_CENTER));

                tBOD1_2.AddCell(pdf.CrearCelda("Frío (ºC)", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));

                tBOD1_2.AddCell(pdf.CrearCelda("Hato libre de  Tuberculosis(SI ó NO)", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda($"{liq.HATOSINTUBERCULOSIS} ", LetraContenido, 0.75F, Element.ALIGN_CENTER));

                tBOD1_2.AddCell(pdf.CrearCelda("Hato libre de Brucela (SI ó NO)", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda($"{liq.HATOSINTUBERCULOSIS} ", LetraContenido, 0.75F, Element.ALIGN_CENTER));

                tBOD1_2.AddCell(pdf.CrearCelda("Buenas Prácticas Ganaderas  (SI ó NO)", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda(" ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1_2.AddCell(pdf.CrearCelda($"{liq.BGP} ", LetraContenido, 0.75F, Element.ALIGN_CENTER));
                tBOD1.AddCell(tBOD1_2);


                #endregion


                #region BONIFICACIONES VOLUNTARIAS
                PdfPTable tBV = pdf.CrearTabla(1, new float[] { 0.99F });
                tBV.AddCell(pdf.CrearCelda("BONIFICACIONES VOLUNTARIAS", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region BONIFICACIONES VOLUNTARIAS DETALLE
                PdfPTable tBVD = pdf.CrearTabla(3, new float[] { 0.3F, 0.3F, 0.3F });
                tBVD.AddCell(pdf.CrearCelda("Concepto ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                tBVD.AddCell(pdf.CrearCelda("Dato de referencia ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tBVD.AddCell(pdf.CrearCelda("Pago ($/Litro) ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tBVD.AddCell(pdf.CrearCelda("", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                tBVD.AddCell(pdf.CrearCelda(" ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tBVD.AddCell(pdf.CrearCelda($"{liq.BON_VOLUNT} ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region DESCUENTOS
                PdfPTable tD = pdf.CrearTabla(1, new float[] { 0.99F });
                tD.AddCell(pdf.CrearCelda("DESCUENTOS", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region DESCUENTOS DETALLE
                PdfPTable tDD = pdf.CrearTabla(4, new float[] { 0.4F, 0.2F, 0.2F, 0.2F });
                tDD.AddCell(pdf.CrearCelda("Descuento por Transporte  ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                tDD.AddCell(pdf.CrearCelda("Distancia ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tDD.AddCell(pdf.CrearCelda("Tipo de Vehiculo  ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tDD.AddCell(pdf.CrearCelda("Descuento ($/Litro) ", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                tDD.AddCell(pdf.CrearCelda("Trayecto: De la planta mas cercana al punto de compra de la leche y viceversa ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tDD.AddCell(pdf.CrearCelda($"{liq.DISTANCIA_KM} ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tDD.AddCell(pdf.CrearCelda($"{liq.TIPO_VEHIC} ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                tDD.AddCell(pdf.CrearCelda($"{liq.DES_TRANSP} ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region  LIQUIDACION Y PAGO 
                PdfPTable tLP = pdf.CrearTabla(1, new float[] { 0.99F });
                tLP.AddCell(pdf.CrearCelda(" LIQUIDACION Y PAGO ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
                #endregion

                #region  LIQUIDACION Y PAGO  DETALLE
                string formato = "0,0.00";
                PdfPTable tLPD = pdf.CrearTabla(2, new float[] { 0.7F, 0.3F });
                tLPD.AddCell(pdf.CrearCelda("Pago por calidad composicional $/lt ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.VAL_PAGADO.ToString(formato)} ", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                tLPD.AddCell(pdf.CrearCelda("Total bonificaciones obligatorias $/lt ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($" {(liq.BONIF_DCTO_MICRO + liq.HATOSINBRUCELA + liq.HATOSINTUBERCULOSIS + liq.BGP).ToString(formato)} ", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                tLPD.AddCell(pdf.CrearCelda("Total bonificaciones voluntarias  $/lt ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.BON_VOLUNT.ToString(formato)} ", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                tLPD.AddCell(pdf.CrearCelda("Total descuentos  $/lt ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.DES_TRANSP.ToString(formato)} ", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                tLPD.AddCell(pdf.CrearCelda("PRECIO FINAL POR LITRO ($) ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.PRECIO_LITRO.ToString(formato)} ", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                tLPD.AddCell(pdf.CrearCelda("Número total de litros ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.NUM_LITROS.ToString(formato)} ", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                tLPD.AddCell(pdf.CrearCelda("PRECIO FINAL  ($) ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.TOTAL.ToString(formato)} ", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                tLPD.AddCell(pdf.CrearCelda("Descuento Fedegan  0.75%", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.DECTO_FEDEGAN.ToString(formato)} ", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                tLPD.AddCell(pdf.CrearCelda("Retencion en la fuente  1.5%", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.DECTO_RETEFUENTE.ToString(formato)}", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                tLPD.AddCell(pdf.CrearCelda("Bolsa nacional Agropecuaria", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.DECTO_BNA.ToString(formato)}", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                tLPD.AddCell(pdf.CrearCelda("Otros descuentos", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.DCTO_OTROS.ToString(formato)}", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));

                tLPD.AddCell(pdf.CrearCelda("TOTAL A PAGAR ($) ", LetraTitulo, 0.75F, Element.ALIGN_LEFT));
                tLPD.AddCell(pdf.CrearCelda($"{liq.TOTAL_PAGAR.ToString(formato)}", LetraTitulo, 0.75F, Element.ALIGN_RIGHT));
                #endregion

                #region  Resumen
                PdfPTable tR = pdf.CrearTabla(1, new float[] { 0.99F });
                tR.AddCell(pdf.CrearCelda("Para consultas relacionadas con la Resolución 017 de 2012, los valores por gramo y las tablas de bonificación o descuento para cada región, por favor escribir al correo electronico: leche@minagricultura.gov.co ¿b0oowq9op´f+g" +
                    "" +
                    "Liquidación manual para dar cumplimiento a la resolución 072 de 2020 y que se realiza por contingencia de COVID19.", LetraFooter, 0.75F, Element.ALIGN_CENTER));
                #endregion

                pdf.Adiccionar(TCabecera);
                pdf.Adiccionar(TCODFORM);
                pdf.Adiccionar(TFP);
                pdf.Adiccionar(tTAEco);
                pdf.Adiccionar(tTAEcoDet);
                pdf.Adiccionar(tTAEcoDet2);
                pdf.Adiccionar(tDPL);
                pdf.Adiccionar(tDPLD);
                pdf.Adiccionar(tTPCC);
                pdf.Adiccionar(TPCCD);
                pdf.Adiccionar(tBO);
                pdf.Adiccionar(tBOD);
                pdf.Adiccionar(tBOD1);
                pdf.Adiccionar(tBV);
                pdf.Adiccionar(tBVD);
                pdf.Adiccionar(tD);
                pdf.Adiccionar(tDD);
                pdf.Adiccionar(tLP);
                pdf.Adiccionar(tLPD);
                pdf.Adiccionar(tR);
                pdf.CerrarDocumento();
            }

            return carpeta;
        }

        public string PDFInventario(VIEW_AI aiPDF)
        {
            ClassPDF pdf = new ClassPDF();
            string nameflie = $"{aiPDF.ID_MOVCABAJ}-{aiPDF.DOCUMENSAP}";
            MetodosAInventarios mtinv = new MetodosAInventarios();
            var firmas = mtinv.firmas(aiPDF.ID_MOVCABAJ);
            #region Creacion Documento
            pdf.CrearDocuemtoHorizontal(nameflie);
            pdf.TituloyAutor("SAP", "Gloria Colombia");
            pdf.AbrirDocumento();
            #endregion

            #region  Tipos de Letras
            Font LetraCabecera = pdf.PdfLetra(12, true, false, true);
            Font LetraTitulo = pdf.PdfLetra(10, true, false, false);
            Font LetraContenido = pdf.PdfLetra(8, false, false, false);
            Font LetraFooter = pdf.PdfLetra(6, true, false, true);
            #endregion

            #region Cabecera
            PdfPTable TCabecera = pdf.CrearTabla(2, new float[] { 0.05F, 0.95F });
            TCabecera.AddCell(pdf.pdfImagen("LogoEmpresa.png", PageSize.LETTER.Right, 20));
            PdfPTable TCabecera0 = pdf.CrearTabla(1, new float[] { 0.99F });
            PdfPCell CCabecera = pdf.CrearCelda("FORMATO SOLICITUD AJUSTE DE INVENTARIO", LetraCabecera, 0, Element.ALIGN_CENTER);
            TCabecera0.AddCell(pdf.CrearCelda(" ", LetraCabecera, 0, Element.ALIGN_CENTER));
            TCabecera0.AddCell(CCabecera);
            TCabecera0.AddCell(pdf.CrearCelda(" ", LetraCabecera, 0, Element.ALIGN_CENTER));
            TCabecera.AddCell(TCabecera0);
            #endregion

            #region Codigo Formato
            PdfPTable TCODFORM = pdf.CrearTabla(2, new float[] { 0.5F, 0.5F });
            TCODFORM.AddCell(pdf.CrearCelda($"CÓDIGO: FR-AF-13", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TCODFORM.AddCell(pdf.CrearCelda("VERSIÓN: 01", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            #endregion

            #region Fecha  Solicitud y Numero de Proceso
            PdfPTable TFP = pdf.CrearTabla(3, new float[] { 0.3F, 0.3F, 0.3F});
            TFP.AddCell(pdf.CrearCelda($"Fecha de Solicitud : {aiPDF.FECING.ToString("yyyy-MM-dd")}", LetraContenido, 0.75F, Element.ALIGN_LEFT));
            TFP.AddCell(pdf.CrearCelda($"Fecha de Inventario : {aiPDF.FECINV.ToString("yyyy-MM-dd")}", LetraContenido, 0.75F, Element.ALIGN_LEFT)); 
            TFP.AddCell(pdf.CrearCelda($"Número de Proceso : {aiPDF.ID_MOVCABAJ.ToString()}", LetraContenido, 0.75F, Element.ALIGN_RIGHT));
           


            TFP.AddCell(pdf.CrearCelda($"Centro Logístico : {aiPDF.CD}", LetraContenido, 0.75F, Element.ALIGN_LEFT));
            TFP.AddCell(pdf.CrearCelda($"Documento SAP : {aiPDF.DOCUMENSAP}", LetraContenido, 0.75F, Element.ALIGN_LEFT));
            TFP.AddCell(pdf.CrearCelda("Movimiento : 701 - 702 ", LetraContenido, 0.75F, Element.ALIGN_LEFT));
            #endregion

            #region Titulo Comercial
            PdfPTable TTLCOM = pdf.CrearTabla(1, new float[] { 0.99F });
            TTLCOM.AddCell(pdf.CrearCelda(" ", LetraTitulo, 0, Element.ALIGN_CENTER));
            TTLCOM.AddCell(pdf.CrearCelda("DETALLE DEL INVENTARIO", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            #endregion


            #region Detalle Ajuste Inventario
            PdfPTable tDetalleAI = pdf.CrearTabla(12, new float[] { 0.05F, 0.1F  , 0.2F , 0.08F , 0.08F , 0.08F,
             0.09F, 0.09F, 0.09F, 0.1F, 0.1F, 0.24F});

            tDetalleAI.AddCell(pdf.CrearCelda("No", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Referencia", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Descripción", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Lote", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Bodega", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Unidad", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Cantidad Teórica", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Cantidad Contada", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Cantidad Diferencia", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Valor (+)", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Valor (-)", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            tDetalleAI.AddCell(pdf.CrearCelda("Justificación", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            int cont = 1;
            double valorn = 0;
            double valorp = 0;
            foreach (var det in aiPDF.detAI)
            {
                var color = new BaseColor(255, 255, 255);
                var letrat = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);
                var letrat1 = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.WHITE);
                var lt = det.AJUSTAR == "NO" ? letrat1 : letrat;
                if (det.AJUSTAR == "NO")
                {
                    color =new BaseColor(0, 0, 0);
                }
                else
                {
                    valorp = valorp + det.VALORp;
                    valorn = valorn + det.VALORn;
                }

                tDetalleAI.AddCell(pdf.CrearCelda(cont.ToString(), lt, 0.75F, Element.ALIGN_CENTER,color));
                tDetalleAI.AddCell(pdf.CrearCelda(det.CODPRODUCTO, lt, 0.75F, Element.ALIGN_CENTER, color));
                tDetalleAI.AddCell(pdf.CrearCelda(det.DESCRIPCION, lt, 0.75F, Element.ALIGN_LEFT, color));
                tDetalleAI.AddCell(pdf.CrearCelda(det.LOTE, lt, 0.75F, Element.ALIGN_CENTER, color));
                tDetalleAI.AddCell(pdf.CrearCelda(det.BODEGA.ToString(), lt, 0.75F, Element.ALIGN_CENTER, color));
                tDetalleAI.AddCell(pdf.CrearCelda(det.UNDMED, lt, 0.75F, Element.ALIGN_CENTER, color));
                tDetalleAI.AddCell(pdf.CrearCelda(det.CANTTEORICA.ToString(), lt, 0.75F, Element.ALIGN_RIGHT, color));
                tDetalleAI.AddCell(pdf.CrearCelda(det.CANTIDAD.ToString(), lt, 0.75F, Element.ALIGN_RIGHT, color));
                tDetalleAI.AddCell(pdf.CrearCelda(det.CANTDIF.ToString(), lt, 0.75F, Element.ALIGN_RIGHT, color));

               
                tDetalleAI.AddCell(pdf.CrearCelda(det.VALORp.ToString(), lt, 0.75F, Element.ALIGN_RIGHT, color));
                tDetalleAI.AddCell(pdf.CrearCelda(det.VALORn.ToString(), lt, 0.75F, Element.ALIGN_RIGHT, color));
                tDetalleAI.AddCell(pdf.CrearCelda(det.JUSTIFICACION, lt, 0.75F, Element.ALIGN_LEFT, color));
                cont++;
            }
            #endregion


            #region Totales
            PdfPTable TTotales = pdf.CrearTabla(4, new float[] { 0.25F, 0.25F, 0.25F, 0.25F });
            TTotales.AddCell(pdf.CrearCelda($"Total Ajuste : ", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TTotales.AddCell(pdf.CrearCelda(valorp.ToString(), LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TTotales.AddCell(pdf.CrearCelda(valorn.ToString(), LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            TTotales.AddCell(pdf.CrearCelda((valorp + valorn).ToString(), LetraTitulo, 0.75F, Element.ALIGN_CENTER));

            #endregion

            #region Titulo Firmas
            PdfPTable TTF = pdf.CrearTabla(1, new float[] { 0.99F });
            TTF.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
            TTF.AddCell(pdf.CrearCelda("FIRMAS", LetraTitulo, 0.75F, Element.ALIGN_CENTER));
            #endregion

            #region Firmas
            PdfPTable TFIRM = pdf.CrearTabla(6, new float[] { 0.16F, 0.16F, 0.16F, 0.16F, 0.16F, 0.16F });
            foreach (var f in firmas)
            {
                PdfPTable TFCONT = pdf.CrearTabla(1, new float[] { 0.99F });
                TFCONT.AddCell(pdf.CrearCelda(f.NAMECARGO, LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TFCONT.AddCell(pdf.CrearCelda(f.NOMBRE, LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TFCONT.AddCell(pdf.CrearCelda(f.CEDULA.ToString(), LetraFooter, 0.75F, Element.ALIGN_CENTER));
                string texto = $"Cargo: {f.NAMECARGO} \n Nombres: {f.NOMBRE} \n  Cedula: {f.CEDULA}";
                PdfPTable TFCODBAR = pdf.CrearTabla(3, new float[] { 0.33F, 0.33F, 0.33F });
                TFCODBAR.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                TFCODBAR.AddCell(pdf.CrearCodigoBarra(texto));
                TFCODBAR.AddCell(pdf.CrearCelda(" ", LetraFooter, 0, Element.ALIGN_CENTER));
                TFCONT.AddCell(TFCODBAR);
                TFCONT.AddCell(pdf.CrearCelda(f.FECAPROB.ToString("yyyy-MM-dd hh:mm"), LetraFooter, 0.75F, Element.ALIGN_CENTER));
                TFIRM.AddCell(TFCONT);
            }
            #endregion

            pdf.Adiccionar(TCabecera);
            pdf.Adiccionar(TCODFORM);
            pdf.Adiccionar(TFP);
            pdf.Adiccionar(TTLCOM);
            pdf.Adiccionar(tDetalleAI);
            pdf.Adiccionar(TTotales);
            pdf.Adiccionar(TTF);
            pdf.Adiccionar(TFIRM);


            pdf.CerrarDocumento();

            return nameflie;
        }

    }
}
