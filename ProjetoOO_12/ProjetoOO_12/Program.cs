using System;
using ProjetoOO_12.Extensions;
using String;

namespace ProjetoOO_12
{
    class Program
    {
        static void Main(string[] args)
        {










            /*
            //--------------------------------------------------------------------
            //EXERCÍCIO
            try
            {
                Console.Write("Digite uma frase: ");
                string frase = Console.ReadLine();
                int tamanho = frase.Length;
                Console.Write($"Cortar até qual tamanho? max:{tamanho - 1}\n--> ");
                int tamanhoCorte = int.Parse(Console.ReadLine());
                while (tamanhoCorte >= tamanho)
                {
                    Console.WriteLine("Tamanho de corte muito grande. Tente novamente");
                    Console.Write($"Cortar até qual tamanho? max:{tamanho - 1}\n--> ");
                    tamanhoCorte = int.Parse(Console.ReadLine());
                }
                Console.WriteLine(frase.Cut(tamanhoCorte));
            }
            catch(Exception e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
            */


            /*
            //--------------------------------------------------------------------
            //EXERCÍCIO
            Console.Write("Digite uma data passada [DD/MM/YYYY]:");
            DateTime data = DateTime.Parse(Console.ReadLine());
            
            while (data >= DateTime.Now)
            {
                Console.WriteLine("Not a past data. Try again");
                Console.Write("Digite uma data passada [DD/MM/YYYY]:");
                data = DateTime.Parse(Console.ReadLine());

            }
            Console.WriteLine(data.ElapsedTime());
            //DateTime data = new DateTime(2025, 01, 10, 11, 30, 25);
            */



            /*
            //--------------------------------------------------------------------
            //EXERCÍCIO
            Dictionary<string, int> candidatos = new Dictionary<string, int>();

            try
            {
                //C:\\Users\\CREAS\\Desktop\\myfolder\\file2.txt
                //C:\Users\CREAS\Desktop\myfolder\file2.txt
                Console.Write("Digite o caminho do arquivo\n--> ");
                string path = Console.ReadLine();

                StreamReader sr = null;
                using (sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)//ENQUANTO NÃO CHEGAR AO FINAL DO ARQUIVO
                    {
                        string[] dados = sr.ReadLine().Split(",");
                        string name = dados[0];
                        int votos = int.Parse(dados[1]);

                        //AVALIAR A SITUAÇÃO DE O NOME SER IGUAL-NOME É A CHAVE
                        if (candidatos.ContainsKey(name))
                        {
                            candidatos[name] += votos;//ESSE CANDIDATO TEM SEU NÚMERO DE VOTOS INCREMENTADO
                        }
                        else//SE JÁ NÃO ESTIVER NO DICIONÁRIO, SÓ ADICIONO
                        {
                            candidatos.Add(name, votos);
                        }
                    }
                }
                
                //PERCORRENDO O DICIONÁRIO RESULTANTE
                foreach(KeyValuePair<string, int> candidato in candidatos)
                {
                    Console.WriteLine($"{candidato.Key} : {candidato.Value}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro. {e.Message}");
            }
            */



            /*
            //DECLARAÇÃO
            //<string, string> - TIPO CHAVE, TIPO VALOR
            Dictionary<string, string> cookie = new Dictionary<string, string>();

            //ATRIBUIÇÕES ÀS CHAVES VALORES
            cookie["user"] = "maria";
            cookie["email"] = "maria@gmail.com";
            cookie["phone"] = "33991457895";
            cookie["phone"] = "31995784985";//SOBRESCREVE O ÚLTIMO VALOR

            Console.WriteLine(cookie["phone"]);

            cookie.Remove("email");//REMOVE A CHAVE E SEUS VALORES
            
            if (cookie.ContainsKey("email"))//VERIFICA SE EXISTE A CHAVE
            {
                Console.WriteLine(cookie["email"]);
            }
            else
            {
                Console.WriteLine("There is no 'email key'");
            }


            foreach(var item in cookie)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
            */

        }
    }
}