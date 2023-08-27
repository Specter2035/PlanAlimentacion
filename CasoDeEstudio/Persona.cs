using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasoDeEstudio
{
    class Persona
    {
        private string nombre = "";
        private int fecha = 0;
        private string sexo = "";
        private double peso = 0;
        private double altura = 0;

        public int DNI = 0;
        public double IMC = 0;
        public int edad;
        public bool adultez;

        public Persona(string Nombre, int Fecha, string Sexo, double Peso, double Altura)
        {
            nombre = Nombre;
            fecha = Fecha;
            sexo = Sexo;
            peso = Peso;
            altura = Altura;
        }

        public double calcularIMC()
        {
            IMC = peso / (Math.Pow(altura, 2));
            return IMC;
        }

        public int calcularEdad()
        {
            edad = 2023 - fecha;
            return edad;
        }

        public bool esMayordeEdad()
        {
            if (edad >= 18)
            {
                adultez = true;
                return adultez;
            }
            else
            {
                adultez = false;
                return adultez;
            }
        }

        public int generaDNI()
        {
            Random rt = new Random();
            DNI = rt.Next(10000000, 99999999);
            return DNI;
        }
    }
}
