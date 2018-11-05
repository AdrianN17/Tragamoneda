using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tragamonedas
{
    public partial class Form1 : Form
    {
        int contador = 4;
        int tiempo = 0;
        int credito;
        int apuesta = 0;
        bool jugadagratis = false;
        int cantjugadas = 0;
        int loopjugada = 0;
        public int ganancia = 0;
        int[] dinero = { 5, 10, 20, 50, 100, 200 };
        Image[] img = new Image[5];
        int[] valor = new int[15];
        String ruta = "";
        public Form1()
        {
            InitializeComponent();
            credito = 0;
            txt1.Text = credito + "";

            lb1.Text = cantjugadas + "";
            ruta = Path.GetDirectoryName(Application.ExecutablePath);
            //inicializar imagenes
            for (int i = 0; i < 4; i++)
            {
                img[i] = Image.FromFile(ruta+@"\felinos\f" + (i + 1) + ".jpg");
            }

            img[4] = Image.FromFile(ruta+@"\felinos\cazador.jpg");

            Console.WriteLine(ruta);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (credito - 50 >= 0)
            {
                if (resultado() <= 20 && jugadagratis == false)
                {
                    contador = 5;
                }
                else
                {
                    contador = 4;
                }



                credito = credito - 50;
                txt1.Text = credito + "";
                tm1.Enabled = true;
                apuesta = 50;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (credito - 100 >= 0)
            {
                if (resultado() <= 20 && jugadagratis == false)
                {
                    contador = 5;
                }
                else
                {
                    contador = 4;
                }

                credito = credito - 100;
                txt1.Text = credito + "";
                tm1.Enabled = true;
                apuesta = 100;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (credito - 150 >= 0)
            {
                if (resultado() <= 20 && jugadagratis == false)
                {
                    contador = 5;
                }
                else
                {
                    contador = 4;
                }

                credito = credito - 150;
                txt1.Text = credito + "";
                tm1.Enabled = true;
                apuesta = 150;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (credito - 200 >= 0)
            {
                if (resultado() <= 20 && jugadagratis == false)
                {
                    contador = 5;
                }
                else
                {
                    contador = 4;
                }

                credito = credito - 200;
                txt1.Text = credito + "";
                tm1.Enabled = true;
                apuesta = 200;
            }
        }

        private void c1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c1.SelectedIndex != -1)
            {
                //10 = 1000
                //cada sol es 100 creditos
                credito = credito + dinero[c1.SelectedIndex] * 100;
                txt1.Text = credito + "";
                //tm1.Enabled = true;
            }
        }

        private void tm1_Tick(object sender, EventArgs e)
        {

            tiempo = tiempo + tm1.Interval;
            Random azar = new Random();

            int cuenta = 0;
            //15
            //10
            //5

            for (int i = 0; i < 15; i++)
            {
                int c = azar.Next(1, contador);
                //if cuenta ==0 
                if (c == 4)
                {

                    cuenta++;
                }

                if (cuenta > 5)
                {
                    c = azar.Next(1, 4);
                }



                valor[i] = c;
            }

            /*
            valor[0] = 4;
            valor[1] = 4;
            valor[2] = 4;
            */

            pic1.Image = img[valor[0]];
            pic2.Image = img[valor[1]];
            pic3.Image = img[valor[2]];
            pic4.Image = img[valor[3]];
            pic5.Image = img[valor[4]];
            pic6.Image = img[valor[5]];
            pic7.Image = img[valor[6]];
            pic8.Image = img[valor[7]];
            pic9.Image = img[valor[8]];
            pic10.Image = img[valor[9]];
            pic11.Image = img[valor[10]];
            pic12.Image = img[valor[11]];
            pic13.Image = img[valor[12]];
            pic14.Image = img[valor[13]];
            pic15.Image = img[valor[14]];


            //50 25 15

            if (tiempo == 500 && jugadagratis == false)
            {
                jugada();
                tiempo = 0;
                tm1.Enabled = false;

                if (jugadagratis == true)
                {
                    lb1.Text = cantjugadas + "";
                    tiempo = 0;
                    tm2.Enabled = true;
                }


            }


        }

        public void jugada()
        {
            ganancia = 0;
            //para 1-1
            Console.WriteLine("girando ...");

            if (valor[0] == valor[1] && valor[1] == valor[2] && valor[2] == valor[3] && valor[3] == valor[4])
            {
                ganancia = ganancia + apuesta * 100;
                Console.WriteLine("Has ganado  linea 1 -5");
                if (valor[0] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 50;
                }

            }
            else if (valor[0] == valor[1] && valor[1] == valor[2] && valor[2] == valor[3])
            {
                ganancia = ganancia + apuesta * 50;
                Console.WriteLine("Has ganado  linea 1 -4");
                if (valor[0] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 25;
                }
            }
            else if (valor[0] == valor[1] && valor[1] == valor[2])
            {
                ganancia = ganancia + apuesta * 20;
                Console.WriteLine("Has ganado  linea 1 -3");
                if (valor[0] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 15;
                }
            }


            //para 1-2
            if (valor[5] == valor[6] && valor[6] == valor[7] && valor[7] == valor[8] && valor[8] == valor[9])
            {
                ganancia = ganancia + apuesta * 100;
                Console.WriteLine("Has ganado linea 2 -5");
                if (valor[5] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 50;
                }
            }
            else if (valor[5] == valor[6] && valor[6] == valor[7] && valor[7] == valor[8])
            {
                ganancia = ganancia + apuesta * 50;
                Console.WriteLine("Has ganado linea 2 -4");
                if (valor[5] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 25;
                }
            }
            else if (valor[5] == valor[6] && valor[6] == valor[7])
            {
                ganancia = ganancia + apuesta * 20;
                Console.WriteLine("Has ganado linea 2 -3");
                if (valor[5] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 15;
                }
            }

            //para 1-3
            if (valor[10] == valor[11] && valor[11] == valor[12] && valor[12] == valor[13] && valor[13] == valor[14])
            {
                ganancia = ganancia + apuesta * 100;
                Console.WriteLine("Has ganado linea 3 -5");
                if (valor[10] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 50;
                }
            }
            else if (valor[10] == valor[11] && valor[11] == valor[12] && valor[12] == valor[13])
            {
                ganancia = ganancia + apuesta * 50;
                Console.WriteLine("Has ganado linea 3 -4");
                if (valor[10] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 25;
                }
            }
            else if (valor[10] == valor[11] && valor[11] == valor[12])
            {
                ganancia = ganancia + apuesta * 20;
                Console.WriteLine("Has ganado linea 3 -3");
                if (valor[10] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 15;
                }
            }

            //para 1-4
            if (valor[0] == valor[6] && valor[6] == valor[12] && valor[12] == valor[8] && valor[8] == valor[5])//0 6 12 8 5
            {
                ganancia = ganancia + apuesta * 100;
                Console.WriteLine("Has ganado linea 4 -5");
                if (valor[0] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 50;
                }
            }
            else if (valor[0] == valor[6] && valor[6] == valor[12] && valor[12] == valor[8])//0 6 12 8 5
            {
                ganancia = ganancia + apuesta * 50;
                Console.WriteLine("Has ganado linea 4 -4");
                if (valor[0] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 25;
                }
            }
            else if (valor[0] == valor[6] && valor[6] == valor[12])//0 6 12 8 5
            {
                ganancia = ganancia + apuesta * 20;
                Console.WriteLine("Has ganado linea 4 -3");
                if (valor[0] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 15;
                }
            }
            //para 1-5
            if (valor[10] == valor[6] && valor[6] == valor[2] && valor[2] == valor[8] && valor[8] == valor[14])//10 6 2 8 14
            {
                ganancia = ganancia + apuesta * 100;
                Console.WriteLine("Has ganado linea 5 -5");
                if (valor[10] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 50;
                }
            }
            else if (valor[10] == valor[6] && valor[6] == valor[2] && valor[2] == valor[8] && valor[8] == valor[14])//10 6 2 8 14
            {
                ganancia = ganancia + apuesta * 50;
                Console.WriteLine("Has ganado linea 5 -4");
                if (valor[10] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 25;
                }
            }
            else if (valor[10] == valor[6] && valor[6] == valor[2])//10 6 2 8 14
            {
                ganancia = ganancia + apuesta * 20;
                Console.WriteLine("Has ganado linea 5 -3");
                if (valor[10] == 4)
                {
                    jugadagratis = true;
                    loopjugada = apuesta;
                    cantjugadas = 15;
                }
            }





            //enviar datos
            txt2.Text = ganancia + "";
            credito = credito + ganancia;
            txt1.Text = credito + "";
            //invocar
            if (ganancia >= apuesta * 100)
            {
                ganador ganador1 = new ganador(ganancia);
                ganador1.Show();
            }
        }

        public int resultado()
        {
            int counter = 0;
            Random azar = new Random();
            counter = azar.Next(1, 100);
            Console.WriteLine(counter);
            return counter;
        }

        private void tm2_Tick(object sender, EventArgs e)
        {
            tiempo = tiempo + tm2.Interval;
            Random azar = new Random();

            //15
            //10
            //5

            for (int i = 0; i < 15; i++)
            {
                valor[i] = azar.Next(1, 4); ;
            }

            pic1.Image = img[valor[0]];
            pic2.Image = img[valor[1]];
            pic3.Image = img[valor[2]];
            pic4.Image = img[valor[3]];
            pic5.Image = img[valor[4]];
            pic6.Image = img[valor[5]];
            pic7.Image = img[valor[6]];
            pic8.Image = img[valor[7]];
            pic9.Image = img[valor[8]];
            pic10.Image = img[valor[9]];
            pic11.Image = img[valor[10]];
            pic12.Image = img[valor[11]];
            pic13.Image = img[valor[12]];
            pic14.Image = img[valor[13]];
            pic15.Image = img[valor[14]];

            if (tiempo == 500 && jugadagratis == true)
            {
                jugada();
                cantjugadas = cantjugadas - 1;
                lb1.Text = cantjugadas + "";
                if (cantjugadas < 1)
                {
                    Console.WriteLine("PAUSADO");
                    tiempo = 0;

                    tm2.Enabled = false;
                    jugadagratis = false;
                }

                tiempo = 0;
            }

        }
    }

}
