using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var cliente = contexto.Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoDeEntrega.Logradouro}");

                var produto = contexto
                    .Produtos
                    .Include(p => p.Compras)
                    .Where(p => p.Id == 1002)
                    .FirstOrDefault();

                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 10)
                    .Load();

                Console.WriteLine($"Mostrando as compras do produto {produto.Nome}");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine("\t"+item);
                }
            }
        }

        private static void ExibeProdutosDaPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = contexto
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();

                Console.WriteLine("\nMotrando os produtos da promoção...");

                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void IncluiPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = new Promocao();
                promocao.Descricao = "Queima de estoque Agosto 2018";
                promocao.DataInicio = new DateTime(2018, 8, 1);
                promocao.DataTermino = new DateTime(2018, 8, 31);

                var produtos = contexto.Produtos
                    .Where(p => p.Categoria == "Bebidas").ToList();

                foreach (var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                contexto.Promocoes.Add(promocao);

                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
            }
        }

        private static void UmParaUm()
        {
                var fulano = new Cliente();
                fulano.Nome = "Fulano de Tal";
                fulano.EnderecoDeEntrega = new Endereco()
                {
                    Numero = 12,
                    Logradouro = "Rua Vinicius",
                    Complemento = "Casa",
                    Bairro = "Centro",
                    Cidade = "Borba"
                };

                using (var contexto = new LojaContext())
                {
                    var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                    var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                    loggerFactory.AddProvider(SqlLoggerProvider.Create());

                    contexto.Clientes.Add(fulano);
                    contexto.SaveChanges();
                }
        }

        private static void MuitosParaMuitos()
            {
                var p1 = new Produto() { Nome = "Hambúrguer", Categoria = "Lanches", PrecoUnitario = 12.0, Unidade = "Unidade" };
                var p2 = new Produto() { Nome = "Refrigerante", Categoria = "Bebidas", PrecoUnitario = 10.0, Unidade = "Litros" };
                var p3 = new Produto() { Nome = "Batata Frita", Categoria = "Aperitivos", PrecoUnitario = 20.0, Unidade = "Kg" };

                //Promoção de Pascoa
                var promocaoPascoa = new Promocao();
                promocaoPascoa.Descricao = "Páscoa Feliz";
                promocaoPascoa.DataInicio = DateTime.Now;
                promocaoPascoa.DataTermino = DateTime.Now.AddMonths(3);


                promocaoPascoa.IncluiProduto(p1);
                promocaoPascoa.IncluiProduto(p2);
                promocaoPascoa.IncluiProduto(p3);


                using (var contexto = new LojaContext())
                {
                    var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                    var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                    loggerFactory.AddProvider(SqlLoggerProvider.Create());

                    //contexto.Promocoes.Add(promocaoDePascoa);
                    var promocao = contexto.Promocoes.Find(3);
                    contexto.Promocoes.Remove(promocao);
                    contexto.SaveChanges();

                    //contexto.Promocoes.Add(promocaoPascoa);
                    //ExibeEntries(contexto.ChangeTracker.Entries());
                    //contexto.SaveChanges();
                }

            }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
            {
                Console.WriteLine("===================");
                foreach (var e in entries)
                {
                    Console.WriteLine(e.Entity.ToString() + " - " + e.State);
                }
            }
    }
}

