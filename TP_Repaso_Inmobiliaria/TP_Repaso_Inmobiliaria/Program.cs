using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Repaso_Inmobiliaria
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper_Archivos Archivito = new Helper_Archivos();
            Archivito.LeerArchivo();
            Archivito.EscribirArchivo();
            Archivito.MostrarListaPropiedades();
            Archivito.CrearBackup();
        }
    }
}
