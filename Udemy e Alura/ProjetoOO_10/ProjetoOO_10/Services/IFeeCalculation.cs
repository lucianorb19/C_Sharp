using System;
using ProjetoOO_10.Entities;

namespace ProjetoOO_10.Services
{
    interface IFeeCalculation
    {
        //FUNÇÃO FeeCalculation QUE SERÁ IMPLEMENTADA NA CLASSE QUE USARÁ ESSA INTERFACE
        //O TIPO DA FUNÇÃO É List<Installment> PQ ELA RETORNA UMA LISTA DE PARCELAS COM SEUS RESPECTIVOS VALORES
        List<Installment> FeeCalculationFunction(DateTime contractDate, double contractValue, int numberInstallments);
    }
}
