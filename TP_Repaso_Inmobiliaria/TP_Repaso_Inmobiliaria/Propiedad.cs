using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Repaso_Inmobiliaria
{
    //ENUMERACIONES
    public enum TipoDeOperacion {Venta , Alquiler};
    public enum TipoDePropiedad {Departamento , Casa , Duplex , Penthhouse , Terrero}

    public class Propiedad
    {
        private int iD;
        private TipoDeOperacion tipodeoperacion;
        private TipoDePropiedad tipodepropiedad;
        private float tamanio;
        private int cantidadBanios;
        private int cantidadHabitaciones;
        private string domicilio;
        private int precio;
        private bool estadoInmueble;

        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public TipoDeOperacion Tipodeoperacion
        {
            get
            {
                return tipodeoperacion;
            }

            set
            {
                tipodeoperacion = value;
            }
        }

        public TipoDePropiedad Tipodepropiedad
        {
            get
            {
                return tipodepropiedad;
            }

            set
            {
                tipodepropiedad = value;
            }
        }

        public float Tamanio
        {
            get
            {
                return tamanio;
            }

            set
            {
                tamanio = value;
            }
        }

        public int CantidadBanios
        {
            get
            {
                return cantidadBanios;
            }

            set
            {
                cantidadBanios = value;
            }
        }

        public int CantidadHabitaciones
        {
            get
            {
                return cantidadHabitaciones;
            }

            set
            {
                cantidadHabitaciones = value;
            }
        }

        public string Domicilio
        {
            get
            {
                return domicilio;
            }

            set
            {
                domicilio = value;
            }
        }

        public int Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public bool EstadoInmueble
        {
            get
            {
                return estadoInmueble;
            }

            set
            {
                estadoInmueble = value;
            }
        }

        //CONSTRUCTOR
        public Propiedad(int _id, TipoDeOperacion _tipodeoperacion, TipoDePropiedad _tipodepropiedad, float _tamanio, int _cantidadbanios, int _cantidadhabitaciones, string _domicilio, int _precio ,bool _estadoinmueble)
        {
            this.ID = _id;
            this.Tipodeoperacion = _tipodeoperacion;
            this.Tipodepropiedad = _tipodepropiedad ;
            this.Tamanio = _tamanio;
            this.CantidadBanios = _cantidadbanios;
            this.CantidadHabitaciones = _cantidadhabitaciones ;
            this.Domicilio = _domicilio;
            this.Precio = _precio;
            this.EstadoInmueble = _estadoinmueble;

        }
        public int ValorDelInmueble()
        {
            if (Tipodeoperacion == TipoDeOperacion.Venta)
            {
                return Precio * (int)1.21 + 10000 + (int)1.10;
            }
            else
            {
                return Precio * (int)0.2 + (int)0.05;
            }
                
        }
    }
}
