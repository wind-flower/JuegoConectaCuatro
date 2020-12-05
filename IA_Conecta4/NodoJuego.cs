using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Conecta4
{
    class NodoJuego: Algoritmo
    {
        public char[] Estado { get; private set; }
        int[][] lineas;

        public NodoJuego()
        {
            if (Estado == null)
            {
                Estado = new char[42];
            }

            // Llenar los posibles estados
            for (int i = 0; i < Estado.Length; i++)
            {
                Estado[i] = ' ';
            }

            /*
             * REPRESENTACIÓN DEL TABLERO (7 x 6)
             * 0    1   2   3   4   5   6       <-- 4 formas de ganar (0,1,2,3)(1,2,3,4)(2,3,4,5)(3,4,5,6) x 6 = 24
             * 7    8   9   10  11  12  13
             * 14   15  16  17  18  19  20
             * 21   22  23  24  25  26  27
             * 28   29  30  31  32  33  34      <-- 12 formas en diagonal (3,11,19,27)(2,10,18,26)(10,18,26,34)(1,9,17,25)(9,17,25,33)
             * 35   36  37  38  39  40  41      (17,25,33,41)(0,8,16,24)(8,16,24,32)(16,24,32,40)(7,15,23,31)(15,23,31,39)(14,22,30,38)
             * |                                12 x 2 = 24
             * |
             * 3 formas de ganar (0,7,14,21)(7,14,21,28)(14,21,28,35) x 7 = 21
             * 24 + 24 + 21 = 69 formas de ganar
             */

            // Llenar el tablero
            if (lineas == null)
            {
                lineas = new int[69][];

                // Ganar en Horizontal
                lineas[0] = new int[] { 0, 1, 2, 3 };
                lineas[1] = new int[] { 1, 2, 3, 4 };
                lineas[2] = new int[] { 2, 3, 4, 5 };
                lineas[3] = new int[] { 3, 4, 5, 6 };

                lineas[4] = new int[] { 7, 8, 9, 10 };
                lineas[5] = new int[] { 8, 9, 10, 11 };
                lineas[6] = new int[] { 9, 10, 11, 12 };
                lineas[7] = new int[] { 10, 11, 12, 13 };

                lineas[8] = new int[] { 14, 15, 16, 17 };
                lineas[9] = new int[] { 15, 16, 17, 18 };
                lineas[10] = new int[] { 16, 17, 18, 19 };
                lineas[11] = new int[] { 17, 18, 19, 20 };

                lineas[12] = new int[] { 21, 22, 23, 24 };
                lineas[13] = new int[] { 22, 23, 24, 25 };
                lineas[14] = new int[] { 23, 24, 25, 26 };
                lineas[15] = new int[] { 24, 25, 26, 27 };

                lineas[16] = new int[] { 28, 29, 30, 31 };
                lineas[17] = new int[] { 29, 30, 31, 32 };
                lineas[18] = new int[] { 30, 31, 32, 33 };
                lineas[19] = new int[] { 31, 32, 33, 34 };

                lineas[20] = new int[] { 35, 36, 37, 38 };
                lineas[21] = new int[] { 36, 37, 38, 39 };
                lineas[22] = new int[] { 37, 38, 39, 40 };
                lineas[23] = new int[] { 38, 39, 40, 41 };

                // Ganar en vertical
                lineas[24] = new int[] { 0, 7, 14, 21 };
                lineas[25] = new int[] { 7, 14, 21, 28 };
                lineas[26] = new int[] { 14, 21, 28, 35 };

                lineas[27] = new int[] { 1, 8, 15, 22 };
                lineas[28] = new int[] { 8, 15, 22, 29 };
                lineas[29] = new int[] { 15, 22, 29, 36 };

                lineas[30] = new int[] { 2, 9, 16, 23 };
                lineas[31] = new int[] { 9, 16, 23, 30 };
                lineas[32] = new int[] { 16, 23, 30, 37 };

                lineas[33] = new int[] { 3, 10, 17, 24 };
                lineas[34] = new int[] { 10, 17, 24, 31 };
                lineas[35] = new int[] { 17, 24, 31, 38 };

                lineas[36] = new int[] { 4, 11, 18, 25 };
                lineas[37] = new int[] { 11, 18, 25, 32 };
                lineas[38] = new int[] { 18, 25, 32, 39 };

                lineas[39] = new int[] { 5, 12, 19, 26 };
                lineas[40] = new int[] { 12, 19, 26, 33 };
                lineas[41] = new int[] { 19, 26, 33, 40 };

                lineas[42] = new int[] { 6, 13, 20, 27 };
                lineas[43] = new int[] { 13, 20, 27, 34 };
                lineas[44] = new int[] { 20, 27, 34, 41 };

                // Ganar en diagonal
                lineas[45] = new int[] { 21, 15, 9, 3 };

                lineas[46] = new int[] { 28, 22, 16, 10 };
                lineas[47] = new int[] { 22, 16, 10, 4 };

                lineas[48] = new int[] { 35, 29, 23, 17 };
                lineas[49] = new int[] { 29, 23, 17, 11 };
                lineas[50] = new int[] { 23, 17, 11, 5 };

                lineas[51] = new int[] { 36, 30, 24, 18 };
                lineas[52] = new int[] { 30, 24, 18, 12 };
                lineas[53] = new int[] { 24, 18, 12, 6 };

                lineas[54] = new int[] { 37, 31, 25, 19 };
                lineas[55] = new int[] { 31, 25, 19, 13 };

                lineas[56] = new int[] { 38, 32, 26, 20 };

                lineas[57] = new int[] { 27, 19, 11, 3 };

                lineas[58] = new int[] { 34, 26, 18, 10 };
                lineas[59] = new int[] { 26, 18, 10, 2 };

                lineas[60] = new int[] { 41, 33, 25, 17 };
                lineas[61] = new int[] { 33, 25, 17, 9 };
                lineas[62] = new int[] { 25, 17, 9, 1 };

                lineas[63] = new int[] { 40, 32, 24, 16 };
                lineas[64] = new int[] { 32, 24, 16, 8 };
                lineas[65] = new int[] { 24, 16, 8, 0 };

                lineas[66] = new int[] { 39, 31, 23, 15 };
                lineas[67] = new int[] { 31, 23, 15, 7 };

                lineas[68] = new int[] { 38, 30, 22, 14 };
            }
        }

            // Determinar si alguien ganó (J=Jugador, C=Computador)
            /// </summary>
            /// <param name="JC">Debe contener 'J' u 'C'</param>
            /// <returns></returns>
            public bool Gano(char CJ)
            {
                foreach (var linea in lineas)
                {
                    if (Estado[linea[0]] == CJ && Estado[linea[1]] == CJ && Estado[linea[2]] == CJ && Estado[linea[3]] == CJ)
                        return true;
                }
                return false;
            }

            public override void CalcularValor()
            {
                foreach (var linea in lineas)
                {
                    if (Estado[linea[0]] == 'C' && Estado[linea[1]] == 'C' && Estado[linea[2]] == 'C' && Estado[linea[3]] == 'C')
                    {
                        Valor = 20;
                        return;
                    }
                    if (Estado[linea[0]] == 'J' && Estado[linea[1]] == 'J' && Estado[linea[2]] == 'J' && Estado[linea[3]] == 'J')
                    {
                        Valor = -20;
                        return;
                    }
                    if (Estado[linea[0]] != 'C' && Estado[linea[1]] != 'C' && Estado[linea[2]] != 'C' && Estado[linea[3]] != 'C')
                    {
                        Valor--;
                    }
                    if (Estado[linea[0]] != 'J' && Estado[linea[1]] != 'J' && Estado[linea[2]] != 'J' && Estado[linea[3]] != 'J')
                    {
                        Valor++;
                    }
                }
            }

        public override void GenerarFicha(bool esTurnoPC)
        {
            char c = esTurnoPC ? 'C' : 'J';
            for (int i = 0; i < Estado.Length; i++)
            {
                if (i <= 34)
                {
                    if (Estado[i] == ' ' && Estado[i + 7] != ' ')
                    {
                        if (Fichas == null)
                            Fichas = new List<Algoritmo>();
                        NodoJuego n = new NodoJuego();
                        n.Estado = (char[])Estado.Clone();
                        n.Estado[i] = c;

                        Fichas.Add(n);
                    }
                }
                else
                {
                    if (Estado[i] == ' ')
                    {
                        if (Fichas == null)
                            Fichas = new List<Algoritmo>();

                        NodoJuego n = new NodoJuego();
                        n.Estado = (char[])Estado.Clone();
                        n.Estado[i] = c;

                        Fichas.Add(n);
                    }
                }
            }
        }

        public override bool TerminarJuego()
        {
            return Gano('C') || Gano('J');
        }

        public override string ToString()
        {
            return Valor.ToString();
        }
    }
}
