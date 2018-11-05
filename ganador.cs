using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tragamonedas
{
    public partial class ganador : Form
    {
        int ganancia;
        int dinero = 0;
        public ganador(int g)
        {
            InitializeComponent();
            //Console.WriteLine(g);
            ganancia = g;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dinero < ganancia)
            {
                dinero = dinero + tm1.Interval*12;
                lb1.Text = dinero + "";
            }
            else 
            {
                lb1.Text = ganancia + "";
                tm1.Enabled = false;
                this.Hide();
            }
                
        }
    }
}
