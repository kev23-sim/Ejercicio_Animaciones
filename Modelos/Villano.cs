using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_Animaciones.Modelos
{
    internal class Villano : Personaje
    {
        public override PictureBox skin { get; set; } = new PictureBox();//creamos el picture box en el diseño
        public override string nombre { get; set; }//le creamos el atributo nombre al heroe
        public override int vida { get; set; }//le creamos el atributo vida al heroe


        public List<Image> FramesIdle { get; set; } = new List<Image>();//lista para almacenar frames de idle
        public int FrameActual = 0;//para controlar la secuencia de la animación



        public void siguienteCuadro()
        {
            skin.Image = FramesIdle[FrameActual];
            FrameActual = (FrameActual + 1) % FramesIdle.Count;
        }

        public void cargarFrames()
        {
            string rutaBase = Path.Combine(Application.StartupPath, "idle_izquierda");
            if (!Directory.Exists(rutaBase)) return;
            string[] archivos = Directory.GetFiles(rutaBase, "Left - Idle_*.png");
            for (int i = 0; i <= 15; i++)
            {
                string nombreArchivo = $"Left - Idle_{i:000}.png";
                string rutaArchivo = Path.Combine(rutaBase, nombreArchivo);
                if (File.Exists(rutaArchivo))
                {
                    FramesIdle.Add(Image.FromFile(rutaArchivo));
                }

            }

        }//fin de cargar frames
    }//fin de la clase
}//fin del namespace
