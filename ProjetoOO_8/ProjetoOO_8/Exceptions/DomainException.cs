using System;


namespace ProjetoOO_8.Exceptions
{
    class DomainException : ApplicationException
    {
        //CONSTRUTOR QUE HERDA DE ApplicationException
        public DomainException(string message)
        : base(message)    
        { 
        }

    }
}
