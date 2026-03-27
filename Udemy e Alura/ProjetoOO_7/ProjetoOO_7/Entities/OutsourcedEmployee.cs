using System;


namespace ProjetoOO_7.Entities
{
    class OutsourcedEmployee : Employee
    {
        public double AdditionalCharge { get; set; }

        //CONSTRUTORES
        public OutsourcedEmployee()
        {
        }
        
        public OutsourcedEmployee(string name, int hours, double valuePerHour, double additionalCharge)
        : base(name, hours, valuePerHour)
        {
            AdditionalCharge = additionalCharge;
        }

        //DEMAIS MÉTODOS
        public override double Payment()
        {
            double base_salary=base.Payment();
            double aditional = AdditionalCharge * 1.1;//110% de AdditionalCharge
            return base_salary + aditional;
        }





    }
}
