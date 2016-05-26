using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using ExemploDocumentDB.Common;
using System.Dynamic;

namespace ExemploDocumentDB.Exclusao
{
    class Program
    {
        public static async Task ExcluirServico()
        {
            DocumentClient client = new DocumentClient(
                new Uri(Configuracoes.EndpointUri),
                Configuracoes.PrimaryKey);

            await client.DeleteDocumentAsync(
                UriFactory.CreateDocumentUri("MobileCloud", "Catalogo", "SERV002"));
        }

        static void Main(string[] args)
        {
            ExcluirServico().Wait();
            Console.WriteLine("Exclusão finalizada...");
            Console.ReadKey();
        }
    }
}