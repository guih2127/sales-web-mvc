using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj); // metódo para adicionar o objeto no banco de dados.
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        } // Editamos utilizando o Include, para obter também os dados de departmento dos sellers.

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (! _context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found"); // se não existir nenhum objeto com o id, lança a exceção
            }
            try // tenta fazer o update
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e) // se capturar a exceção do entityframework, relança a nossa exceção
            // Ou seja, capturamos uma exceção do nivel de acesso a dados e lançamos nossa exceção a nivel de serviços.
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
