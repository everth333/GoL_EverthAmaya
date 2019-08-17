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

        public static int vivo = 1;
        public static int muerto = 0;
       

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

        public bool estaVivo(int fila, int columna)
        {
            if (fila >= 0 && columna >= 0 && fila < filas && columna < columnas)            
                return tabla[fila][columna] == vivo;            
            else
                return false;
           
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
