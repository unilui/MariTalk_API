using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Replace 'YOUR_API_URL' with the actual URL of the API you want to call
        string apiUrl = "https://chat.maritaca.ai/api/chat/inference";

        // Create an instance of HttpClient
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Define the data you want to send in the request body
                string jsonData = "{\"messages\": [{\"role\": \"user\", \"content\": \"Você pode me falar quanto é 25 + 27?\"}],\"do_sample\": true,\"max_tokens\": 200,\"temperature\": 0.7,\"top_p\": 0.95}";

                // Create the HTTP content with the JSON data
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Add custom headers to the request
                // Your key goes here -> "Key 12334567788"
                client.DefaultRequestHeaders.Add("authorization", "Your Key");

                // OR, if you want to add headers to the content specifically
                // content.Headers.Add("Your-Header-Name", "Your-Header-Value");

                // Make a POST request to the API with the content
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                // Check if the request was successful (status code 2xx)
                if (response.IsSuccessStatusCode)
                {
                    // Read and display the response content as a string
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}