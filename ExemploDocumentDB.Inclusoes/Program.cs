using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using ExemploDocumentDB.Common;
using System.Dynamic;

namespace ExemploDocumentDB.Inclusoes
{
    class Program
    {
        private static async Task InserirDadosProdutos()
        {
            Produto prod001 = new Produto();
            prod001.id = "PROD001";
            prod001.Nome = "Detergente";
            prod001.Tipo = "Limpeza";
            prod001.Preco = 5.75;
            prod001.DadosFornecedor = new Fornecedor();
            prod001.DadosFornecedor.Codigo = "FORN001";
            prod001.DadosFornecedor.Nome = "EMPRESA XYZ";

            var prod002 = new
            {
                id = "PROD002",
                Nome = "Martelo",
                Tipo = "Ferramenta",
                Preco = 50.70
            };

            DocumentClient client = new DocumentClient(
                new Uri(Configuracoes.EndpointUri),
                Configuracoes.PrimaryKey);

            await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(
                    "MobileCloud", "Catalogo"), prod001);

            await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(
                    "MobileCloud", "Catalogo"), prod002);
        }

        private static async Task InserirDadosServicos()
        {
            Servico serv001 = new Servico();
            serv001.id = "SERV001";
            serv001.Nome = "LIMPEZA PREDIAL";
            serv001.ValorHora = 150.00;

            dynamic serv002 = new ExpandoObject();
            serv002.id = "SERV002";
            serv002.Nome = "GUARDA PATRIMONIAL";

            DocumentClient client = new DocumentClient(
                new Uri(Configuracoes.EndpointUri),
                Configuracoes.PrimaryKey);

            await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(
                    "MobileCloud", "Catalogo"), serv001);

            await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(
                    "MobileCloud", "Catalogo"), serv002);
        }

        static void Main(string[] args)
        {
            InserirDadosProdutos().Wait();
            InserirDadosServicos().Wait();
            Console.WriteLine("Dados inseridos...");
            Console.ReadKey();
        }
    }
}