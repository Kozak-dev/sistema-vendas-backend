using Microsoft.EntityFrameworkCore;
using SistemaDeVenda.Data;
using SistemaDeVenda.Models;

namespace SistemaDeVenda.Services
{
    public class VendaService
    {
        private readonly AppDbContext _context;

        public VendaService(AppDbContext context)
        {
            _context = context;
        }
        public List<Venda> ListarVendas()
        {
            return _context.Vendas.ToList();
        }

        // Total de vendas para o relatorio
        public decimal TotalVendas()
        {
            return _context.Vendas.Sum(v => v.Valor);
        }

        //Quantidade de vendas para o relatorio
        public int QuantidadeVendas()
        {
            return _context.Vendas.Count();
        }


        public void CriarVenda(Venda venda)
        {
           
            _context.Vendas.Add(venda);
            _context.SaveChanges(); 

            
            var contrato = new Contrato
            {
                Cliente = venda.Cliente,
                Data = DateTime.Now,
                VendaId = venda.Id 
            };

            var fatura = new Fatura
            {
                Valor = venda.Valor,
                Data = DateTime.Now,
                VendaId = venda.Id
            };

            _context.Contratos.Add(contrato);
            _context.Faturas.Add(fatura);

            _context.SaveChanges();

            Console.WriteLine($"Venda {venda.Id} criada com contrato e fatura");
        }

    }
}