using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasoDeEstudio
{
    class PlanAlimentacion
    {
        int Edad = 0;
        string Sexo = "";
        double Peso = 0;
        double Altura = 0;
        string actfisica = "";

        public double GET;
        public double GEB;
        public double ETA;
        public double EFA;

        public PlanAlimentacion(int edad, string sexo, double peso, double altura, string ActFisica)
        {
            Edad = edad;
            Sexo = sexo;
            Peso = peso;
            Altura = altura;
            actfisica = ActFisica;
        }

        public double CalcularGEB()
        {
            if (Sexo == "H")
            {
                GEB = (9.99 * Peso) + (6.25 * (Altura*100)) - (4.92 * Edad) + 5;
                return GEB;
            }
            else if (Sexo == "M")
            {
                GEB = (9.99 * Peso) + (6.25 * Altura) - (4.92 * Edad) - 161;
                return GEB;
            }
            throw new InvalidOperationException("Valor de sexo inválido.");
        }

        public double CalcularETA()
        {
            ETA = GEB * 0.06;
            return ETA;
        }

        public double CalcularEFA()
        {
            if (actfisica == "Sedentaria")
            {
                EFA = GEB * 0.1;
                return EFA;
            }
            else
            {
                    if(actfisica == "Moderada")
                    {
                        EFA = GEB * 0.2;
                        return EFA;
                    }
                    else
                    {
                        if (actfisica == "Activa")
                        {
                            EFA = GEB * 0.3;
                            return EFA;
                        }
                        else
                        {
                            if (actfisica == "Muy activa")
                            {
                                EFA = GEB * 0.4;
                                return EFA;
                            }
                        }
                    }
            }
            throw new InvalidOperationException("No se seleccionó una opción.");
        }

        public double CalcularGET()
        {
            GET = GEB + ETA + EFA;
            return GET;
        }
    }
}
