using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace DataAccessAplicaciones.DataAccessDescuentos
{
    public class DataExcel
    {
        string _cadena = "";
        private Application ObjConection = null;

        public DataExcel(string cadena_conexion)
        {
            _cadena = cadena_conexion;
            if (ObjConection == null)
            {
                ObjConection = new Application();
            }
        }

        public void ClosedConection()
        {
            ObjConection.ActiveWorkbook.Close(true);
            ObjConection.Quit();
        }

        public void Dispose()
        {
            ObjConection = null;
        }

        public void OpenConection()
        {
            ObjConection.Workbooks.Open(_cadena);
        }

        public void EscribirEnCelda(int hoja, int fila, int columna, string valor)
        {
            ObjConection.Sheets[hoja].Cells(
                fila,
                columna).Value = valor;
        }

        public void EscribirEnCelda(string hoja, int fila, int columna, string valor)
        {
            ObjConection.Sheets[hoja].Cells(
                fila,
                columna).Value = valor;
        }

        public object RecibirCelda(int hoja, int fila, int columna)
        {
            var rdato = ObjConection.Sheets[hoja].Cells(
                fila,
                columna).Value;
            var dato = rdato == null ? 0 : rdato;
            return dato;
        }
        public object RecibirCelda(string hoja, int fila, int columna)
        {
            var rdato = ObjConection.Sheets[hoja].Cells(
                fila,
                columna).Value;
            var dato = rdato == null ? 0 : rdato;
            return dato;
        }
        public void ExecuteMacro(string _macro)
        {
            ObjConection.GetType().InvokeMember("Run",
                System.Reflection.BindingFlags.Default |
                System.Reflection.BindingFlags.InvokeMethod,
                null, ObjConection, new object[] { _macro });
        }

        public void ExecuteMacro(string _macro, string rango)
        {
            ObjConection.GetType().InvokeMember("Run",
                System.Reflection.BindingFlags.Default |
                System.Reflection.BindingFlags.InvokeMethod,
                null, ObjConection, new object[] { _macro, rango });
        }

    }
}
