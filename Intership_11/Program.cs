using System;

namespace Intership_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static char[,] CryptMatrix(string str, bool[,] matKey, char[,] cryptMat)
        { 

            if (str == "") return cryptMat; // Вывод матрицы с зашифрованным текстом

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matKey[i, j]) // Проверка на прорезь в матрице-ключе
                    {
                        cryptMat[i, j] = str[0];
                        str = str.Remove(0, 1);

                        if (str.Length % 25 == 0) // Проверка на обход четверти текста
                            return CryptMatrix(str, Rotate(matKey), cryptMat);
                    }
                }
                
            }

            return new char[0, 0];
        }

        static string DecryptMatrix(char[,] cryptMat, bool[,] matKey, string str)
        {
            if (str.Length == 100) return str; // Выводим расшифованный текст, если расшифровали его полностью

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (matKey[i, j]) // Проверка на прорезь в матрице-ключе
                    {
                        str += cryptMat[i, j];

                        if (str.Length % (10 * 10 / 4) == 0) // Проверка на обход четверти текста
                            return DecryptMatrix(cryptMat, Rotate(matKey), str);
                    }
                }                             
            }
            return "";
        } 

        static bool[,] Rotate(bool[,] mat)
        {
            bool[,] result = new bool[0,0];
            return result;
        }
    }
}
