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
            // 7 , 8
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
            if (estaVivo(fila + 1, columna-1))
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

        // RULE1: Any Live cell with fewer than two live neighbours DIES, as if caused by under-population.
        private bool EstaVivaConMenosDeDosVecinosVivos(int fila, int columna)
        {
            int cantidadVecinosV = cantidadVecinosVivos(fila, columna);
            if (estaVivo(fila, columna) && (cantidadVecinosV < 2))
                return true;
            else
                return false;
        }

        // RULE2: Any Live cell with two or three live neighbours LIVES, on the next generation.
        private bool EstaVivaConDosOrTresVecinosVivos(int fila, int columna)
        {
            int cantidadVecinosV = cantidadVecinosVivos(fila, columna);
            if (estaVivo(fila, columna) && (cantidadVecinosV == 2 || cantidadVecinosV == 3))
                return true;
            else
                return false;
        }

        // RULE3: Any Live cell with more than three live neighbours DIES, as if by over-population.
        private bool EstaVivaConMasDeTresVecinosVivos(int fila, int columna)
        {
            int cantidadVecinosV = cantidadVecinosVivos(fila, columna);
            if (estaVivo(fila, columna) && (cantidadVecinosV > 3))
                return true;
            else
                return false;
        }

        // RULE4: Any Dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        private bool EstaMuertoConExactamenteTresVecinosVivos(int fila, int columna)
        {
            int cantidadVecinosV = cantidadVecinosVivos(fila, columna);
            if (estaMuerto(fila, columna) && (cantidadVecinosV == 3))
                return true;
            else
                return false;
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
                        if ((i == 7) && (j == 7))
                        {

                        }
                        if (EstaVivaConDosOrTresVecinosVivos(i, j))
                        {
                            proximaTabla[i][j] = vivo;
                        }
                        else
                        {
                            if (EstaVivaConMasDeTresVecinosVivos(i, j))
                            {
                                proximaTabla[i][j] = muerto;
                            }
                            else
                            {
                                if (EstaMuertoConExactamenteTresVecinosVivos(i, j))
                                {
                                    proximaTabla[i][j] = vivo;
                                }
                                else
                                {
                                    proximaTabla[i][j] = tabla[i][j];
                                }
                            }
                        }
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
