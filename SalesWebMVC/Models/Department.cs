using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        // Relação One To Many feita com o ICollection, cada departamento tem vários vendedores.

        public Department()
        {

        }

        public Department(int id, string name) // Atributos que são coleções não entram no construtor.
        {
            Id = id;
            Name = name;
        }

        public void AddSeler(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
            // Somamos o TotalSales() de cada vendedor daquele departamento, com as datas informadas.
        }
    }
}
