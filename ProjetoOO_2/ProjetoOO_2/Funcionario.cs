using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ProjetoOO_2
{
    class Funcionario
    {
        //ATTRIBUTES / PROPERTIES
        //ATRIBUTOS / PROPRIEDADES
        internal string Id { get; set; }
        internal string Name { get; set; }
        internal double Salary { get; private set; }
        //private set - IT CAN ONLY BE MODIFIED IN THIS CLASS
        //private set - ELE SÓ PODE SER MODIFICADO NESTA CLASSE

        //OTHERS METHODS
        //OUTROS MÉTODOS
        public override string ToString()
        {
            return $"{Id}, {Name}, ${Salary}";
        }

        internal static void ShowEmployees(List<Funcionario> lista_funcionarios)
        {
            //SHOWING EMPLOYEES REGISTRED
            //MOSTRANDO FUNCIONÁRIOS REGISTRADOS
            Console.WriteLine("Current employees data:/Dados atualizados dos funcionários:");
            foreach (Funcionario funcionario in lista_funcionarios)
            {
                Console.WriteLine(funcionario);
            }
            Console.WriteLine();
        }

        internal static Funcionario RegisterEmployee(List<Funcionario> lista_funcionarios)
        {
            //FUNCTION THAT RETURNS A EMPLOYEE WITH ID, NAME AND SALARY
            //IT RECEIVES THE CURRENT LIST OF EMPLOYESS SO IT CAN VERITY THE DUPLICATED ID

            //FUNÇÃO QUE RETORNA UM EMPREGADO COM ID, NOME E SALÁRIO
            //ELA RECEBE A LISTA ATUAL DE EMPREGADOS PARA QUE POSSA VERIFICAR O ID DUPLICADO
            Console.Write("Id: ");
            string id = Console.ReadLine();

            //ID NEEDS TO BE 4 NUMBERS
            //ID PRECISA SER 4 NÚMEROS
            while (id.Length != 4 || id.All(char.IsDigit) == false)
            {
                Console.Write("Invalid Id. Try again [4 numbers]\n->>");
                id = Console.ReadLine();
            }
            

            foreach (Funcionario x in lista_funcionarios) 
            {
                while (x.Id == id)
                {
                    Console.WriteLine("Id already registred. Try again/Id já cadastrado. Tente novamente");
                    Console.Write("Id: ");
                    id = Console.ReadLine();
                }
            }
            Console.Write("Name:/Nome: ");
            string name = Console.ReadLine();
            Console.Write("Salary:/Salario: $");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Funcionario funcionario = new Funcionario();
            funcionario.Id = id;
            funcionario.Name = name;
            funcionario.Salary = salary;

            return funcionario;

        }

        internal static void SalaryRase(List<Funcionario> lista_funcionarios)
        {
            Console.WriteLine("Salary rase / Aumento salarial");
            Console.Write("For employee id:/Para funcionário id: ");
            string id = Console.ReadLine();
            Console.Write("Rase percentage/Porcentagem do aumento [%]: ");
            double rase_percentage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            //VERIFYING ID
            int contador = 0;
            foreach (Funcionario funcionario in lista_funcionarios)
            {
                if (funcionario.Id == id)
                {
                    funcionario.Salary += funcionario.Salary * (rase_percentage / 100);
                    contador++;
                }
            }

            if (contador == 0)
            {
                Console.WriteLine("There ins't any employee with the provided id. Try again\n" +
                                  "Não há funcionário com o id informado. Tente novamente.");
                SalaryRase(lista_funcionarios);
            }
            Console.WriteLine();
        }










    }
}
