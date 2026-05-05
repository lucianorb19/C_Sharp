namespace ProductClientHub.Exceptions.ExceptionBase
{
    public abstract class ProductClientHubException : SystemException
    {

        //CONSTRUTOR
        //A MENSAGEM PASSADA EM errorMessage É ATRIBUÍDA AO CONSTRUTOR
        //DA CLASSE MÃE DESSA, QUE É SYSTEM EXCEPTION, OU SEJA
        //A PROPRIEDADE Message QUE JÁ EXISTE NA CLASSE SystemException
        //RECEBE O VALOR QUE FOR USADO QUANDO INSTANCIARMOS UM OBJETO 
        //ProductClientHubException
        public ProductClientHubException(string errorMessage): base(errorMessage)
        {
            
        }

        //MÉTODO ABSTRATO QUE DEVERÁ SER DEFINIDO NAS CLASSES FILHAS
        public abstract List<string> GetErrors();


    }
}
