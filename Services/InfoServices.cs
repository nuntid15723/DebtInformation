using System.Net.Http;
using DebtInformation.Models;

namespace DebtInfoModels.Services
{
    public class InfoServices
    {
        private List<DebtInformation.Models.InfoModels> infodetails = new List<DebtInformation.Models.InfoModels>
        {
            new InfoModels { coop_id = "1", memcoop_id = "ntre1", member_no = "123", deptaccount_name = "pptyas1" },
            new InfoModels { coop_id = "2", memcoop_id = "ntre2", member_no = "1234", deptaccount_name = "pptyas2" },
            new InfoModels { coop_id = "3", memcoop_id = "ntre3", member_no = "12345", deptaccount_name = "pptyas3" },
            new InfoModels { coop_id = "4", memcoop_id = "ntre4", member_no = "123456", deptaccount_name = "pptyas4" },
            new InfoModels { coop_id = "5", memcoop_id = "ntre5", member_no = "1234567", deptaccount_name = "pptyas5" },
        };

        public async Task<List<DebtInformation.Models.InfoModels>> InfoModelsList()
        {
            return await Task.FromResult(infodetails);
        }
    }
    public class InfoServicess
    {
        private readonly HttpClient httpClient;

        // Constructor to inject the HttpClient
        public InfoServicess(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ApiResponse> GetDataAsync(string coopId, string deptAccountNo)
        {
            try
            {
                // Make the GET request to the API
                var response = await httpClient.GetAsync($"{Apiurl.ApibaseUrl}DepOfInitDataOffline?coop_Control={coopId}&deptaccount_No={deptAccountNo}");

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read the response content as a string
                var json = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into your data model
                var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse>(json);

                return apiResponse;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error: {ex.Message}");
                return null; // or throw an exception based on your requirement
            }
        }
    }

}
