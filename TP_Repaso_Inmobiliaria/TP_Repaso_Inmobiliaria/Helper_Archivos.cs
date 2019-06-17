using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Repaso_Inmobiliaria
{
    public class Helper_Archivos
    {
        public StreamReader Reader;
        public StreamWriter Writer;
        static Random aleatorio = new Random();
        public List<Propiedad> TucumanPropiedades = new List<Propiedad>();         

        public void LeerArchivo()
        {
            try
            {
                Reader = new StreamReader(@"Registro_Inmobiliaria.csv");
                while (!Reader.EndOfStream)
                {
                    string cadena = Reader.ReadLine(); //Guarda el primero renglon
                    string[] array_cadena = cadena.Split(',');//Guarda en un arreglo de cadena cada palabra separada por ","
                    TucumanPropiedades.Add(new Propiedad(24,0,(TipoDePropiedad)Convert.ToInt32(array_cadena[1]),26323,3,4,array_cadena[0],7000,false));
                }
                Reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR AL LEER: {ex.Message}");
            }
        }

        public void EscribirArchivo()
        {
            try
            {
                Writer = new StreamWriter("Registro_Inmobiliaria_Completo.csv");
                foreach (Propiedad propiedad in TucumanPropiedades)
                {
                    Writer.WriteLine(propiedad.ID +","+ propiedad.Tipodeoperacion +"," + propiedad.Tipodepropiedad +","+ propiedad.Tamanio +","+ propiedad.CantidadBanios +","+ propiedad.CantidadHabitaciones +","+ propiedad.Domicilio +","+ propiedad.Precio + ","+ propiedad.EstadoInmueble);
                }
                Writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR AL ESCRIBIR: {ex.Message}");
            }
        }
        public void MostrarListaPropiedades()
        {
            foreach (Propiedad propiedad in TucumanPropiedades)
            {
                Console.WriteLine($"ID: {propiedad.ID}|Operacion: {propiedad.Tipodeoperacion}|T.Propiedad: {propiedad.Tipodepropiedad}|Tamanio: {propiedad.Tamanio}|Baños: {propiedad.CantidadBanios}|Habitaciones: {propiedad.CantidadHabitaciones}|Domicilio: {propiedad.Domicilio}|Precio: {propiedad.Precio}|Estado: {propiedad.EstadoInmueble}");
                Console.WriteLine($"El valor del Inmueble es : {propiedad.ValorDelInmueble()}");
            }
        }
        public void CrearBackup()
        {
            Console.WriteLine("Seleccione un disco para su BackUp");
            foreach (string discos in Directory.GetLogicalDrives()) //MUESTRA DISCOS
            {
                    Console.Write($"{discos} ");
            }
            string RutaDirectorio = Console.ReadLine().ToUpper() + @":\BackUpPropiedades"; //RUTA DEL DIRECTORIO
            if (!Directory.Exists(RutaDirectorio)) //SI NO EXISTE EL DIRECTORIO LO CREA
            {
                Directory.CreateDirectory(RutaDirectorio);
            }
            string RutaArchivo = RutaDirectorio + @"\Inmobiliaria_Backup.csv"; //RUTA DEL ARCHIVO

            if (!File.Exists(RutaArchivo)) //SI EL CVS NO EXISTE LO CREO
            {
                try
                {
                    Writer = new StreamWriter(RutaArchivo);
                    foreach (Propiedad propiedad in TucumanPropiedades)
                    {
                        Writer.WriteLine(propiedad.ID + "," + propiedad.Tipodeoperacion + "," + propiedad.Tipodepropiedad + "," + propiedad.Tamanio + "," + propiedad.CantidadBanios + "," + propiedad.CantidadHabitaciones + "," + propiedad.Domicilio + "," + propiedad.Precio + "," + propiedad.EstadoInmueble);
                    }
                    Writer.Close();
                    File.Copy(RutaDirectorio + @"\Inmobiliaria_Backup.csv", RutaDirectorio + @"\Inmobiliaria_Backup.bk");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR AL ESCRIBIR: {ex.Message}");
                }
            }
            else //SI EXISTE EL CVS..
            {
                if (File.Exists(RutaDirectorio + @"\Inmobiliaria_Backup.bk")) //SI EXISTE EL ARCHIVO BK LO BORRO
                {
                    File.Delete(RutaDirectorio + @"\Inmobiliaria_Backup.bk");
                    File.Copy(RutaDirectorio + @"\Inmobiliaria_Backup.csv", RutaDirectorio + @"\Inmobiliaria_Backup.bk");
                }
                else
                {
                    File.Copy(RutaDirectorio + @"\Inmobiliaria_Backup.csv", RutaDirectorio + @"\Inmobiliaria_Backup.bk");
                }
            }
        }
    }
}
