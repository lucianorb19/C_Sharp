using ProjetoOO_10.Services;
using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoOO_10.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public int NumberInstallments { get; set; }

        public List<Installment> Installments = new List<Installment>();//LIST OF Installments
        
        private IFeeCalculation _feeCalculationService;
        
        //CONSTRUTORES
        public Contract()
        {
        }

        public Contract(int number, DateTime date, double totalValue, int numberInstallmentes, IFeeCalculation feeCalculationService)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
            NumberInstallments = numberInstallmentes;
            _feeCalculationService = feeCalculationService;
        }

        //DEMAIS MÉTODOS
        public override string ToString()
        {
            List<Installment> lista = _feeCalculationService.FeeCalculationFunction(Date, TotalValue, NumberInstallments);
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            
            sb.AppendLine("Installments");
            foreach(Installment installment in lista)
            {
                sb.AppendLine($"{installment.DueDate.ToShortDateString()} - {installment.Amount}");
            }
            return sb.ToString();
        }



    }
}
