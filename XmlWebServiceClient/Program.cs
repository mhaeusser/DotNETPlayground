using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Adjust the base address to wherever your service is running
        const string baseAddress = "http://localhost:5134";  // TODO make configurable

        // Create a reusable HttpClient instance
        using var httpClient = new HttpClient();

        // 1) Check the health endpoint
        await CheckHealth(httpClient, baseAddress);

        // 2) Send XML payload
        await PostXml(httpClient, baseAddress);
    }

    private static async Task CheckHealth(HttpClient httpClient, string baseAddress)
    {
        var healthEndpoint = $"{baseAddress}/health";
        try
        {
            Console.WriteLine($"Calling {healthEndpoint}");
            // Send GET request
            var response = await httpClient.GetAsync(healthEndpoint);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Health Check:");
            Console.WriteLine($"  StatusCode: {response.StatusCode}");
            Console.WriteLine($"  Content:    {content}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to check health:");
            Console.WriteLine(ex.Message);
        }
    }

    private static async Task PostXml(HttpClient httpClient, string baseAddress)
    {
        var xmlEndpoint = $"{baseAddress}/xml";
        try
        {
            // Sample XML payload
            var xmlPayload = "<TestMessage>Hello World!</TestMessage>";

            // Create a StringContent with the XML payload
            using var stringContent = new StringContent(xmlPayload, Encoding.UTF8, "application/xml");

            // Send POST request
            var response = await httpClient.PostAsync(xmlEndpoint, stringContent);
            response.EnsureSuccessStatusCode();

            // Read the echoed XML response
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine("\nXML POST Response:");
            Console.WriteLine($"  StatusCode: {response.StatusCode}");
            Console.WriteLine($"  Content:    {responseContent}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to POST XML:");
            Console.WriteLine(ex.Message);
        }
    }
}
