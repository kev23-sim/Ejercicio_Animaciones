using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_Animaciones.Modelos
{
    internal abstract class Personaje
    {
        public abstract PictureBox skin { get; set; }
        public abstract string nombre { get; set; }
        public abstract int vida { get; set; }

    }//fin de la clase
}//fin del namespace
