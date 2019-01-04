using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; } // Relação One to one, cada vendedor tem um departamento.
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        // Relação one to many, ou seja, um vendedor pode possuir várias vendas.

        public Seller()
        {

        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr); 
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
            // Utilizamos o metódo Where e uma expressão lambda para obtermos a soma de todas as vendas
            // em um determinado período. Primeiro filtramos a lista obtendo apenas as sales entre
            // as datas initial e final. Depois, usamos Sum para obter a soma de todos os amounts destas vendas.
        }
    }
}