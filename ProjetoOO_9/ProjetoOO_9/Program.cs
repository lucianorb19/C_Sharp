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
            string sourcePath = @"C:\Users\Luciano\Desktop\myfolder\file1.txt";

            try
            {
                //CRIANDO PASTA PARA ARQUIVO SAÍDA
                string targetPath = Path.GetDirectoryName(sourcePath) + @"\out";
                Directory.CreateDirectory(targetPath);
                //TORNANDO A MESMA VARIÁVEL O PRÓPRIO ARQUIVO - PARA ESCRITA
                targetPath = targetPath + @"\summary.txt";

                //FileStream - ABRE OU CRIA, CASO AINDA NÃO HAJA
                using (FileStream fs = new FileStream(sourcePath, FileMode.OpenOrCreate))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        //ENQUANTO NÃO CHEGAR AO FINAL DO ARQUIVO
                        while (!sr.EndOfStream)
                        {
                            string linha = sr.ReadLine();//SALVO CADA LINHA EM linha
                            string[] dados_linha = linha.Split(",");//DIVIDO A LINHA EM ELEMENTOS - SEPARADOR: ,
                            string nome = dados_linha[0];
                            double valor = Convert.ToDouble(dados_linha[1], System.Globalization.CultureInfo.InvariantCulture) ;
                            double quantidade = Convert.ToDouble(dados_linha[2], System.Globalization.CultureInfo.InvariantCulture) ;

                            double valor_total = valor * quantidade;
                            //MOSTRANDO NA TELA A PRÉVIA
                            Console.WriteLine($"{nome} - {valor_total.ToString("f2",CultureInfo.InvariantCulture)}");

                            //ESCREVER NO ARQUIVO NOVO
                            //NOME,VALOR TOTAL
                            using (StreamWriter sw = File.AppendText(targetPath))
                            {
                               sw.WriteLine($"{nome},{valor_total.ToString("f2",CultureInfo.InvariantCulture)}");
                            }
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
