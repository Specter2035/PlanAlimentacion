using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CasoDeEstudio
{
    public partial class Form1 : Form
    {
        private DataGridView MyDataGridView = new DataGridView();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //Leer datos ingresados

            string nombre = txtNombre.Text;
            int fecha = int.Parse(txtFechaNacimiento.Text);
            string sexo = txtSexo.Text;
            double peso = double.Parse(txtPeso.Text);
            double altura = double.Parse(txtAltura.Text);
            string ActFisica = cmbActFisica.SelectedItem.ToString();

            //Clase Persona

            Persona ObjP = new Persona(nombre, fecha, sexo, peso, altura);

            double IMC = ObjP.calcularIMC();
            int edad = ObjP.calcularEdad();
            bool esMayor = ObjP.esMayordeEdad();
            int DNI = ObjP.generaDNI();
            string DNIUnico = DNI.ToString();

            //Clase Plan Alimentacion
            PlanAlimentacion ObjPA = new PlanAlimentacion(edad, sexo, peso, altura, ActFisica);
            double GEB = ObjPA.CalcularGEB();
            double EFA = ObjPA.CalcularEFA();
            double ETA = ObjPA.CalcularETA();
            double GET = ObjPA.CalcularGET();

            //Resultados

            Resultados ObjR = new Resultados();
            

            ObjR.txtPaciente.Text = nombre;
            ObjR.txtIMC.Text = IMC.ToString();
            ObjR.txtEdad.Text = edad.ToString();
            ObjR.txtEsMayor.Text = esMayor.ToString();
            ObjR.txtDNI.Text = nombre[0].ToString() + nombre[1].ToString() + nombre[2].ToString() + DNIUnico.ToString();

            ObjR.txtGEB.Text = GEB.ToString();
            ObjR.txtEFA.Text = EFA.ToString();
            ObjR.txtETA.Text = ETA.ToString();
            ObjR.txtGET.Text = GET.ToString();

            //Tabla Dietosintética

            ObjR.MyDataGridView.ColumnCount = 5;

            string[] row0 = { "Nutrimento", "%", "Calc. Parcial", "Calc./gr", "Grms Nutrimento" };
            string[] row1 = { "Carbono", "50%", (GET/2).ToString(), "4", (GET/8).ToString()};
            string[] row2 = { "Proteína", "20%", (GET * 0.2).ToString(), "4", ((GET * 0.2)/4).ToString() };
            string[] row3 = { "Lípido", "20%", (GET * 0.2).ToString(), "9", ((GET * 0.2) / 9).ToString() };

            ObjR.MyDataGridView.Rows.Add(row0);
            ObjR.MyDataGridView.Rows.Add(row1);
            ObjR.MyDataGridView.Rows.Add(row2);
            ObjR.MyDataGridView.Rows.Add(row3);

            if (IMC < 18.5)
            {
                ObjR.lblPaciente.ForeColor = Color.Yellow;
                ObjR.lblIMC.ForeColor = Color.Yellow;
                ObjR.lblEdad.ForeColor = Color.Yellow;
                ObjR.lblMayor.ForeColor = Color.Yellow;
                ObjR.lblDNI.ForeColor = Color.Yellow;
            }
            else
            {
                if (IMC >= 18.5 && IMC <=24.9)
                {
                    ObjR.lblPaciente.ForeColor = Color.Green;
                ObjR.lblIMC.ForeColor = Color.Green;
                ObjR.lblEdad.ForeColor = Color.Green;
                ObjR.lblMayor.ForeColor = Color.Green;
                ObjR.lblDNI.ForeColor = Color.Green;
                }
                else
                {
                    if (IMC >= 25 && IMC <= 29.9)
                    {
                        ObjR.lblPaciente.ForeColor = Color.Orange;
                        ObjR.lblIMC.ForeColor = Color.Orange;
                        ObjR.lblEdad.ForeColor = Color.Orange;
                        ObjR.lblMayor.ForeColor = Color.Orange;
                        ObjR.lblDNI.ForeColor = Color.Orange;
                    }
                    else
                    {
                        if (IMC >= 30)
                        {
                            ObjR.lblPaciente.ForeColor = Color.Red;
                        ObjR.lblIMC.ForeColor = Color.Red;
                        ObjR.lblEdad.ForeColor = Color.Red;
                        ObjR.lblMayor.ForeColor = Color.Red;
                        ObjR.lblDNI.ForeColor = Color.Red;
                        }
                    }
                }
            }

            

            

            ObjR.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
