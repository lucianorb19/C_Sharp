namespace ProductClientHub.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : ProductClientHubException
    {
        //readonly - SÓ PODE SER DEFINIDO NO CONSTRUTOR
        private readonly List<string> _errors;

        //: base(string.Empty) - USADO PQ NÃO IREMOS USAR O VALOR DO CONSTRUTOR HERDADO 
        //DA CLASSE MÃE
        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        public override List<string> GetErrors()
        {
            return _errors;
        }
        //OU
        //public override List<string> GetErrors() => _errors;
        
    }
}
