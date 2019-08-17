using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace caGOLeamaya
{
    public class clGoL
    {
        public int[][] tabla;

        private int filas;
        private int columnas;     

        public  int vivo = 1;
        public  int muerto = 0;
       

        public clGoL()
        {

        }

        public string Hello()
        {
            return "Hello";
        }
        
        public clGoL(int filas, int columnas)
        {
            tabla = new int[filas][];
            this.filas = tabla.Length;
            for (int i = 0; i < this.filas; i++)
                tabla[i] = new int[columnas];

            this.columnas = columnas;

            for (int i = 0; i < this.filas; i++)
                for (int j = 0; j < this.filas; j++)
                    tabla[i][j] = muerto;
        }

        public bool estaVivo(int fila, int columna)
        {
            if (fila >= 0 && columna >= 0 && fila < filas && columna < columnas)
                return tabla[fila][columna] == vivo;
            else
                return false;

        }
                
        public int cantidadVecinosVivos(int fila, int columna)
        {
            int cantidadVecinosVivos = 0;

            if (estaVivo(fila - 1, columna - 1))
                cantidadVecinosVivos++;
            if (estaVivo(fila - 1, columna ))
                cantidadVecinosVivos++;
            if (estaVivo(fila - 1, columna + 1))
                cantidadVecinosVivos++;
            if (estaVivo(fila , columna + 1))
                cantidadVecinosVivos++;
            if (estaVivo(fila + 1, columna + 1))
                cantidadVecinosVivos++;
            if (estaVivo(fila + 1, columna ))
                cantidadVecinosVivos++;
            if (estaVivo(fila , columna - 1))
                cantidadVecinosVivos++;
            
            return cantidadVecinosVivos;
        }

        public void ponerCeldaViva(int fila, int columna)
        {
            tabla[fila][columna] = vivo;
        }

        public bool estaMuerto(int fila, int columna)
        {
            if (fila >= 0 && columna >= 0 && fila < filas && columna < columnas)
                return tabla[fila][columna] == muerto;
            else
                return true;
        }

        //RULE1: Any Live cell with fewer than two live neighbours DIES, as if caused by under-population.
        private bool EstaVivaConMenosDeDosVecinosVivos(int fila, int columna)
        {
            int cantidadVecinosV = cantidadVecinosVivos(fila, columna);
            return estaVivo(fila, columna) && cantidadVecinosV < 2;
        }

        public void iterar()
        {

            int[][] proximaTabla = new int[this.filas][];
            for (int i = 0; i < this.filas; i++)
                proximaTabla[i] = new int[this.columnas];

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {

                    if (EstaVivaConMenosDeDosVecinosVivos(i, j))
                    {
                        proximaTabla[i][j] = muerto;
                    }
                    else
                    {
                        proximaTabla[i][j] = tabla[i][j];
                    }
                }

            }

            proximaTabla.CopyTo(tabla, 0);
        }

        
        public int obtenerValor(int fila, int columna)
        {
            if (fila >= 0 && columna >= 0 && fila < filas && columna < columnas)
                return Int32.Parse( tabla[fila][columna].ToString());
            else
                return 0;
        }
        public String imprimir()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-------------------------");
            for (int i = 0; i < this.filas; i++)
            {
                for (int j = 0; j < this.filas; j++)
                    sb.Append(tabla[i][j].ToString() + " ");
                sb.AppendLine();
            }
            return sb.ToString(); 
        }


    }
}
