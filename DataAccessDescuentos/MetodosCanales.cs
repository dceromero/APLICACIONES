using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataEntitysAplicaciones.DataEntitysDescuentos;
namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class MetodosCanales
    {
        ModelAplicacionesDescuentos dbcontext = null;

        public long SaveMCDsctoCanal(MCDCTOCANAL mc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec Proc_SaveMCDctoCanal '{mc.CEDULA}', '{mc.ID_OFICVENTA}', '{mc.ID_CANAL}','{mc.GRPCLIENTE}','{mc.FECINI.ToString("yyyy-MM-dd")}', '{mc.FECFIN.ToString("yyyy-MM-dd")}', '{mc.IDMOTIVOS}','{mc.JUSTIFICACION}'";
            long query = dbcontext.Database.SqlQuery<long>(tsql).FirstOrDefault();
            return query;
        }

        public Mensajes SaveMDDsctoCanal(MDDCTOCANAL md,  long cedula)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec Proc_SaveMDDctoCanal '{cedula}', '{md.ID_MCDCTOCANAL}','{md.CODPRODUCTO}', '{md.PORCENDCTO}', '{md.CANT}', '{md.VALOR.ToString().Replace(",",".")}'";
            Mensajes query = dbcontext.Database.SqlQuery<Mensajes>(tsql).FirstOrDefault();
            return query;
        }

        public Mensajes UpdateMDDescuentos(MDDCTOCANAL md, long cc)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            String tsql = $"exec PROC_APROBACION_COMERCIALCN '{cc}','{md.ID_MDDCTOCANAL}','{md.VERIFICA1}', '{md.OBS}'";
            var query = dbcontext.Database.SqlQuery<Mensajes>(tsql).FirstOrDefault();
            return query;
        }

        public List<CANALES> ListadoCanales()
        {
            dbcontext = new ModelAplicacionesDescuentos();
            return dbcontext.CANALES.SqlQuery($"select * from CANALES ORDER BY NAMECANALES ").ToList();
        }

        public List<VIEW_HEADER_CANAL> CabeceraCanal(long cedula)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"exec Proc_View_Headers_canal '{cedula}'";
            return dbcontext.Database.SqlQuery<VIEW_HEADER_CANAL>(tsql).ToList();
        }


        public VIEW_HEADER_CANAL CabeceraCN(long id)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"SELECT * FROM VIEW_ENCABEZADO_CANAL where ID_MCDCTOCANAL ='{id}'";
            return dbcontext.Database.SqlQuery<VIEW_HEADER_CANAL>(tsql).First();   
        }

        public List<VIEW_VALORPORCANAL> ValorProductXCanal(long id)
        {
            dbcontext = new ModelAplicacionesDescuentos();
            string tsql = $"select ID_MDDCTOCANAL, Material, PORCENDCTO, CANT, subtotal, Descuento, total, estado from VIEW_VALORPORCANAL WHERE ID_MCDCTOCANAL = '{id}'";
            return dbcontext.Database.SqlQuery<VIEW_VALORPORCANAL>(tsql).ToList();
        }
    }
}
