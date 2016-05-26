using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using ExemploDocumentDB.Common;

namespace ExemploDocumentDB.GerarColecao
{
    class Program
    {
        private static async Task CriarColecao()
        {
            DocumentClient client = new DocumentClient(
                new Uri(Configuracoes.EndpointUri),
                Configuracoes.PrimaryKey);

            DocumentCollection collectionInfo = new DocumentCollection();
            collectionInfo.Id = "Catalogo";

            collectionInfo.IndexingPolicy =
                new IndexingPolicy(new RangeIndex(DataType.String) { Precision = -1 });

            await client.CreateDocumentCollectionAsync(
                UriFactory.CreateDatabaseUri("MobileCloud"),
                collectionInfo,
                new RequestOptions { OfferThroughput = 400 });
        }

        static void Main(string[] args)
        {
            CriarColecao().Wait();
            Console.WriteLine("Criação da coleção finalizada...");
            Console.ReadKey();
        }
    }
}