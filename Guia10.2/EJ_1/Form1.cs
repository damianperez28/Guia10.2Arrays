using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJ_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnCalcular.Enabled = false;
            btnListar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        static int[] numeros = new int[10];
        static int indice = 0;
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarNumero_Click(object sender, EventArgs e)
        {

            int num = Convert.ToInt32(tbNumIng.Text);
            if (indice < 10) 
            {
                numeros[indice] = num;
                indice++;
                if (indice == 10)
                {
                    btnAgregarNumero.Enabled = false;
                }
            }

            
            if (indice > 0)
            {
                btnCalcular.Enabled = true;
                btnListar.Enabled = true;
                btnBuscar.Enabled = true;
            }

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            lblPromedio.Text = CalcPromedio(numeros).ToString();

        }

        private int BusqSecuencial(int nroBuscado)
        {
            int pos = -1, n=0;
            while(pos == -1 && n < indice)
            {
                if (numeros[n] == nroBuscado)
                {
                    pos = n;
                }
                n++;
            }

            return pos;
        }
        private static double CalcPromedio(int[] vector)
        {
            double acum = 0, promedio;
            for(int i = 0; i < indice; i++)
            {
                acum += vector[i];
            }
            promedio = acum /indice;
            return promedio;
        }
        private static void Ordenar(int[]vector)
        {
            int aux;
            for(int i = 0; i < indice - 1; i++)
            {
                for(int j = i + 1; j < indice; j++)
                {
                    if (vector[i] < vector[j])
                    {
                        aux = vector[i];
                        vector[i] = vector[j];
                        vector[j] = aux;
                    }
                }
            }

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for(int i = 0;i < indice;i++)
            {
                listBox1.Items.Add(numeros[i].ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(tbNumBusc.Text);
            if (rbSecuencial.Checked == true)
            {
                if(BusqSecuencial(num) != -1)
                {
                    MessageBox.Show("Tu numero esta en la posicion: " + BusqSecuencial(num));
                }
                else { MessageBox.Show("Numero inexistente"); }
                
            }
            if(rbBinaria.Checked == true)
            {
                Ordenar(numeros);
            }
        }
    }
}
