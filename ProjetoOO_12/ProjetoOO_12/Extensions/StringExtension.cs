using System;


namespace String
{
    public static class StringExtension
    {
        public static string Cut(this string frase,int tamanho)
        {
            return frase.Substring(0, tamanho)+"...";
             
        }
    }
}
