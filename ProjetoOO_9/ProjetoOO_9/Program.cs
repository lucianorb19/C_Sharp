using System;
using System.IO; //FILES
namespace ProjetoOO_9
{
    class Program
    {
        static void Main(string[] args)
        {
            //CAMINHO ARQUIVO ORIGEM
            string sourcePath = @"C:\Users\CREAS\Desktop\arquivos\file1.txt";
            string targetPath = @"C:\Users\CREAS\Desktop\arquivos\file2.txt";

            try
            {
                //VETOR EM QUE CADA ITEM É UMA LINHA DO ARQUIVO ORIGINAL
                string[] lines = File.ReadAllLines(sourcePath);
                //MODO DE ESCRITA - NO FINAL DO ARQUIVO
                using(StreamWriter sw = File.AppendText(targetPath))
                {
                    //CADA ITEM DO VETOR É ESCRITO NO FINAL DO ARQUIVO - EM MAIÚSCULO
                    //ESCREVE UMA LINHA - ENTER
                    foreach(string line in lines)
                    {
                        sw.WriteLine(line.ToUpper());
                    }
                }


            }
            catch (IOException e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }


        }
    }
}
