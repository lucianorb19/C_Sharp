using System;
using System.IO; //FILES
using System.Collections.Generic;
using System.Globalization;//IEnumerable
namespace ProjetoOO_9
{
    class Program
    {
        static void Main(string[] args)
        {
            //PASTA ARQUIVO ORIGINAL
            string sourcePath = @"C:\Users\CREAS\Desktop\myfolder\file1.txt";

            try
            {
                //CRIANDO PASTA PARA ARQUIVO SAÍDA
                string targetPath = Path.GetDirectoryName(sourcePath) + @"\out";
                Directory.CreateDirectory(targetPath);


                using (FileStream fs = new FileStream(sourcePath, FileMode.OpenOrCreate))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string linha = sr.ReadLine();
                            string[] dados_linha = linha.Split(",");
                            string nome = dados_linha[0];
                            double valor = Convert.ToDouble(dados_linha[1], System.Globalization.CultureInfo.InvariantCulture) ;
                            double quantidade = Convert.ToDouble(dados_linha[2], System.Globalization.CultureInfo.InvariantCulture) ;

                            double valor_total = valor * quantidade;
                            Console.WriteLine($"{nome} - {valor_total.ToString("f2",CultureInfo.InvariantCulture)}");

                            //ESCREVER NO ARQUIVO NOVO
                            //NOME,VALOR TOTAL
                            //using (StreamWriter sw = File.AppendText(targetPath))
                            //{
                            //
                            //}
                        }

                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
        }
    }
}
