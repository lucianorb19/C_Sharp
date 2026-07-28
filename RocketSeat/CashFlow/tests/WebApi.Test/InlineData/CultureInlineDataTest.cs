using System.Collections;

namespace WebApi.Test.InlineData;

//CLASSE QUE REPRESENTA AS DIFERENTES LINGUAGENS ACEITAS PELO MIDDLEWARE
public class CultureInlineDataTest : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "en" };
        yield return new object[] { "pt-BR" };
    }
    //yield DETERMINA QUE É RETORNADO O ARRAY CONTENDO UMA STRING QUE REPRESENTA A LINGUAGEM
    //E QUE APÓS A EXECUÇÃO DA FUNÇÃO QUE USA ESSE ARRAY, NO NOSSO CASO AS FUNÇÕES DE TESTE
    //EM RegisterUserTest, A EXECUÇÃO VOLTA PARA ESTA CLASSE EXECUTA O CÓDIGO ABAIXO DO RETURN
    //QUE NESSE CASO SÃO OS PRÓXIMOS RETURNS.

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
