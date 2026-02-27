using Ejercicio_Animaciones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_Animaciones
{
    public partial class Form1 : Form
    {
        Timer timerMovimiento = new Timer();
        Heroe Heroe1 = new Heroe();
        Timer TimerAnimacion = new Timer();

        public Form1()
        {
            InitializeComponent();
            Heroe1.skin.Size = new Size(200, 200);
            Heroe1.skin.Location = new Point(5, 30);
            Heroe1.skin.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(Heroe1.skin);

            Heroe1.CargarAnimaciones();

            TimerAnimacion.Interval = 50; // Velocidad: 150ms entre cada frame
            TimerAnimacion.Tick += (s, e) => Heroe1.SiguienteCuadro();
            TimerAnimacion.Start(); // ¡Empieza la animación!


        }//fin del constructor


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                case Keys.Right:
                    Heroe1.MoverHaciaLaDerecha();
                    Heroe1.SetAnimacion(Heroe1.FramesCaminataD);
                    break;
                case Keys.A:
                case Keys.Left:
                    Heroe1.MoverHaciaLaIzquierda();
                    Heroe1.SetAnimacion(Heroe1.FramesCaminataI);
                    break;
                case Keys.Space:
                    Heroe1.SetAnimacion(Heroe1.FramesAtacarD);
                    break;



            }
        }//fin del Form1_KeyDown

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                Heroe1.SetAnimacion(Heroe1.FramesIdle);
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                Heroe1.SetAnimacion(Heroe1.FramesIdle);
            }
            if (e.KeyCode == Keys.Space)
            {
                Heroe1.SetAnimacion(Heroe1.FramesIdle);
            }

        }// fin Form1_KeyUp
    }//fin de la clase
}//fin del namespace
