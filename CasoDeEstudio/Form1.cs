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




            ObjR.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
