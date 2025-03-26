using System;
using ProjetoOO_11.Entities;

namespace ProjetoOO_11
{
    class CalculationService
    {
      
        //DEMAIS MÉTODOS

        //T Max<T> - MÉTODO Max COM RETORNO TIPO T
        //<T> SIGNIFICA QUE O MÉTODO É GENÉRICO - DO TIPO T
        //where T: IComparable - SIGNIFICA "TENDO ELEMENTOS COMPARÁVEIS PELO IComparable
        public T Max<T>(List<T> list) where T: IComparable
        {
            //VERIFICAÇÃO SE A LISTA NÃO ESTÁ VAZIA
            if (list.Count == 0)
            {
                throw new ArgumentException("List empty");
            }

            //PRIMEIRO ELEMENTO É DEFINIDO COMO MAIOR
            T max = list[0];
            for(int i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo(max) > 0)//SE O ELEMENTO ATUAL FOR MAIOR QUE max
                {
                    max = list[i];//ELEMENTO ATUAL SE TORNA O MAIOR
                }
            }
            return max;
        }





    }
}
