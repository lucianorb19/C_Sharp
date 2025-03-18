using System;
using System.Collections.Generic;//LISTAS
using ProjetoOO_3.Entities.Enums;

namespace ProjetoOO_3.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level{ get; set; }     
        public double BaseSalary { get; set; }
        
        //COMPOSIÇÃO ENTRE WORKER E DEPARTMENT
        public Department Department { get; set; }
        
        //COMPOSIÇÃO ENTRE WORKER E HOURCONTRACT
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();
        // = new List<HourContract>(); - GARANTIR QUE A LISTA NÃO SEJA NULA, INICIALIZADA VAZIA
        

        //CONTRUTORES
        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        //DEMAIS MÉTODOS

        //MÉTODO QUE ADICIONA UM CONTRATO NOVO A LISTA DE CONTRATOS DO TRABALHADOR
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        //MÉTODO QUE REMOVE DA LISTA DE CONTRATOS DO FUNCIONÁRIO, O CONTRATO PASSADO
        //COMO ARGUMENTO
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        //MÉTODO QUE CALCULA O TOTAL DE GANHOS DOS CONTRATOS PARA O FUNCIONÁRIO
        public double Income(int year, int month)
        {

        }








    }
}
