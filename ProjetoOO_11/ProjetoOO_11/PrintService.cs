using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOO_11
{
    class PrintService<T>
    {
        private T[] _values = new T[10];
        private int _count = 0;
        
        //CONSTRUTORES

        
        //DEMAIS MÉTODOS
        //MÉTODO QUE ADICIONA UM VALOR AO VETOR
        public void AddValue(T value)
        {
            if(_count == 10)//
            {
                throw new InvalidOperationException("PrintService Full");
            }

            _values[_count] = value;
            _count++;
        }

        //MÉTODO QUE RETORNA O PRIMEIRO ITEM DO VETOR
        public T First()
        {
            return _values[0];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            for(int i = 0; i < _values.Length; i++)
            {
                if(i <= _count-1)//ATÉ O PENÚLTIMO
                {
                    sb.Append($"{_values[i]},");
                }
                else
                {
                    sb.Append($"{_values[i]}");

                }
            }
            sb.Append(" ]");

            return sb.ToString();
        }


    }
}
