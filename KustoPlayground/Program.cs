// See https://aka.ms/new-console-template for more information



using Kusto.Data;
using Kusto.Data.Net.Client;

namespace HelloKusto {
    class HelloKusto {
        static void Main(string[] args) {
            string clusterUri = "https://kvc-h40srsfcp0a7vg1ade.northeurope.kusto.windows.net/";
            var kcsb = new KustoConnectionStringBuilder(clusterUri).WithAadUserPromptAuthentication();
    
            using (var kustoClient = KustoClientFactory.CreateCslQueryProvider(kcsb)) {
                string database = "AutomationTesting";
                string query = "TransferMapping";

                using (var response = kustoClient.ExecuteQuery(database, query, null)) {
                    response.Read();

                    int columnNo = response.GetOrdinal("Signature");
                    Console.WriteLine(columnNo);
                    Console.WriteLine(response.GetString(columnNo));
                }
            }
        }
    }
}