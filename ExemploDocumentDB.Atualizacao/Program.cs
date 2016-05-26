using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using ExemploDocumentDB.Common;

namespace ExemploDocumentDB.Atualizacao
{
    class Program
    {
        private static async Task AtualizarServico()
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
                var serv001 = servicos.FirstOrDefault();
                serv001.ValorHora = 300.00;

                await client.ReplaceDocumentAsync(
                    UriFactory.CreateDocumentUri(
                        "MobileCloud", "Catalogo", "SERV001"), serv001);

                Console.WriteLine("Atualização realizada...");
            }
        }

        static void Main(string[] args)
        {
            AtualizarServico().Wait();
            Console.ReadKey();
        }
    }
}