using ProjetoOO_10.Entities;
using System;


namespace ProjetoOO_10.Services
{
    class FeeCalculation : IFeeCalculation
    {
        public List<Installment> FeeCalculationFunction(DateTime contractDate, double contractValue, int numberInstallments)
        {
            List<Installment> lista = new List<Installment>();

            double base_value = contractValue / numberInstallments;
            for(int i = 1; i <= numberInstallments; i++)
            {
                DateTime installmentData = contractDate.AddMonths(i);
                //double installmentValue = 10;
                double valuePlusInterest = base_value + base_value * (0.01 * i);//200+200 * 1% * 1 dpois 2 dpois 3.... 
                double valuePlusPaymentFee = valuePlusInterest += 0.02 * valuePlusInterest;//+2%
                
                Installment installment = new Installment(installmentData, valuePlusPaymentFee);
                lista.Add(installment);
            }
            return lista;
        }
    
    
    
    
    
    }
}
