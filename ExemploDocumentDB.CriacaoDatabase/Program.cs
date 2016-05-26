using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using ExemploDocumentDB.Common;

namespace ExemploDocumentDB.CriacaoDatabase
{
    class Program
    {
        private static async Task CriarBanco()
        {
            DocumentClient client = new DocumentClient(
                new Uri(Configuracoes.EndpointUri),
                Configuracoes.PrimaryKey);

            await client.CreateDatabaseAsync(
                new Database { Id = "MobileCloud" });
        }

        static void Main(string[] args)
        {
            CriarBanco().Wait();
            Console.WriteLine("Criação do banco finalizada...");
            Console.ReadKey();
        }
    }
}