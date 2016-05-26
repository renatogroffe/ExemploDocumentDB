using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Documents.Client;
using ExemploDocumentDB.Common;
using Newtonsoft.Json;

namespace ExemploDocumentDB.ConsultaLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentClient client = new DocumentClient(
                new Uri(Configuracoes.EndpointUri),
                Configuracoes.PrimaryKey);

            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

            IEnumerable<Servico> servicos =
                client.CreateDocumentQuery<Servico>(
                    UriFactory.CreateDocumentCollectionUri("MobileCloud", "Catalogo"), queryOptions)
                        .Where(p => p.id == "SERV001").AsEnumerable();

            if (servicos.Count() == 1)
            {
                Console.WriteLine(
                    JsonConvert.SerializeObject(servicos.FirstOrDefault()));
            }
            Console.ReadKey();
        }
    }
}