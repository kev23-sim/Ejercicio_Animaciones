using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ejercicio_Animaciones.Modelos
{
    internal class Heroe : Personaje
    {
        public int velocidad = 2;//velocidad movimiento heroe
        public int nuevaX;//variable para moverse horizontalmente
        public override PictureBox skin { get; set; } = new PictureBox();//creamos el picture box en el diseño
        public override string nombre { get; set; }//le creamos el atributo nombre al heroe
        public override int vida { get; set; }//le creamos el atributo vida al heroe
        public List<Image> FramesCaminataD { get; set; } = new List<Image>();//lista para almacenar frames de caminada hacia la derecha
        public List<Image> FramesCaminataI { get; set; } = new List<Image>();//lista para almacenar frames de caminada hacia la izquierda
        public List<Image> FramesIdle { get; set; } = new List<Image>();//lista frames del idle cuando esta quieto
        public List<Image> FramesAtacarD { get; set; } = new List<Image>();
        private List<Image> AnimacionActual;//variable para diferenciar cuando camina y se esta quieto
        private int FrameActual = 0;//para controlar la secuencia de la animación

        public Heroe ()
        {
            AnimacionActual = FramesIdle;
        }//fin del constructor

        //aqui los cambios de la animación
        public void SetAnimacion (List<Image> nuevaAnimacion)
        {
            if (AnimacionActual != nuevaAnimacion)
            {
                AnimacionActual = nuevaAnimacion;
                FrameActual = 0;
            }
        }//fin SetAnimacion

        public void SiguienteCuadro()
        {
            if (AnimacionActual == null || AnimacionActual.Count == 0) return;
            skin.Image = AnimacionActual[FrameActual];
            FrameActual = (FrameActual + 1) % AnimacionActual.Count;
        }//fin SiguienteCuadro

        public void MoverHaciaLaDerecha()
        {
            nuevaX = skin.Location.X + velocidad;
            skin.Location = new Point(nuevaX, skin.Location.Y);

        }//fin de mover hacia la derecha


        public void MoverHaciaLaIzquierda()
        {
            nuevaX = skin.Location.X - velocidad;
            skin.Location = new Point(nuevaX, skin.Location.Y);

        }//fin de mover hacia la izquierda

        public void CargarAnimaciones ()
        {
            CargarLista(FramesIdle, "idle_frente", "Front - Idle_");
            CargarLista(FramesCaminataD, "caminar_derecha", "Right - Walking_");
            CargarLista(FramesCaminataI, "caminar_izquierda", "Left - Walking_");
            CargarLista(FramesAtacarD, "atacar_derecha", "Right - Attacking_");

            AnimacionActual = FramesIdle;

        }//fin cargar animaciones

        private void CargarLista(List<Image>lista, string carpeta, string prefijo)
        {
            string rutaCarpeta = Path.Combine(Application.StartupPath, carpeta);
            if (!Directory.Exists(rutaCarpeta)) return;

            for (int i = 1; i <= carpeta.Length; i++)
            {
                string nombreArchivo = $"{prefijo}{i:000}.png";
                string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);
                if (File.Exists(rutaCompleta))
                {
                    lista.Add(Image.FromFile(rutaCompleta));
                }
            }
        }//fin de cargarLista

    }//fin de la clase
}//fin del namespace
