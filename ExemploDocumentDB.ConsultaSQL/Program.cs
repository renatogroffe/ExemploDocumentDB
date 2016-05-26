using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Documents.Client;
using ExemploDocumentDB.Common;
using Newtonsoft.Json;

namespace ExemploDocumentDB.ConsultaSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentClient client = new DocumentClient(
                new Uri(Configuracoes.EndpointUri),
                Configuracoes.PrimaryKey);

            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            var itens =
                client.CreateDocumentQuery(
                    UriFactory.CreateDocumentCollectionUri("MobileCloud", "Catalogo"),
                    "SELECT * FROM Catalogo", queryOptions)
                        .AsEnumerable();

            foreach (var item in itens)
            {
                Console.WriteLine(
                    JsonConvert.SerializeObject(item));
                Console.WriteLine(new String('-', 30));
            }
            Console.ReadKey();
        }
    }
}