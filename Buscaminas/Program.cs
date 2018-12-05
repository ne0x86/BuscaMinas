using System;

namespace Buscaminas
{
    class Program
    {
        static string[,] CreaTablero()
        {
            string[,] tablero = new string[10, 10];
            for (int row = 0; row < tablero.GetLength(0); row++)
            {
                for (int col = 0; col < tablero.GetLength(1); col++)
                {
                    tablero[row, col] = "X";
                }
            }
            return tablero;
        }

        static void RellenaMinas(string[,] array, int numMinas)
        {
            Random generador = new Random();
            int contador = 0;
            do
            {
                int row = generador.Next(0,10);
                int col = generador.Next(0, 10);
                array[row, col] = "*";
                contador++;
            } while (contador <= numMinas);

        }

        static void ShowArray(string[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                Console.WriteLine(" ");
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write(array[row,col]+ " ");
                }
            }
        }

        static int ContadorMinas(string[,] array, int row, int col)
        {
            int mineCount = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                if (i < 0 || i >= array.GetLength(0))
                    continue;  // para no salirse de los bordes
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (j < 0 || j >= array.GetLength(1))
                        continue;  // para no salirse de los bordes

                    if (i == row && j == col)
                        continue;  // No contar la casilla seleccionada

                    if (array[i, j] == "*")
                        mineCount += 1;
                }
            }
         return mineCount;
        }

        static void Turno(string[,] tablero_Minas, string[,] tablero_Jugador)
        {
            int contador, col, row;
            bool vida = true;
            do
            {
                ShowArray(tablero_Jugador);
                Console.WriteLine("");
                Console.WriteLine("\n Dime la fila donde quieres probar suerte");
                row = int.Parse(Console.ReadLine());
                Console.WriteLine("Ahora la columna donde quieres probar suerte");
                col = int.Parse(Console.ReadLine());
                if (tablero_Minas[row, col] == "*")
                {
                    vida = false;
                    Console.WriteLine("Has perdido!");
                }
                else if (tablero_Minas[row, col] == "X")
                {
                    tablero_Jugador[row, col] = ContadorMinas(tablero_Minas, row, col).ToString();
                }
            } while (vida);
        }

        static void Main(string[] args)
        {
            string[,] tablero_Jugador = CreaTablero();
            string[,] tablero_Minas = CreaTablero();
            RellenaMinas(tablero_Minas, 10);
            Turno(tablero_Minas, tablero_Jugador);
            ShowArray(tablero_Minas);
            Console.ReadKey();
        }
    }
}