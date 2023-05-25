using System.Text;

public class GoogleCloudVisionAPIService
{
    private static readonly HttpClient httpClient = new HttpClient();

    public async Task<List<string>> GeneratePhotoTags(string imagePath)
    {
        // Cargar la imagen en base64
        string base64Image = ConvertImageToBase64(imagePath);

        // Configurar la solicitud a la API de Cloud Vision
        string apiEndpoint = "https://vision.googleapis.com/v1/images:annotate?key=YOUR_API_KEY";
        var jsonContent = new
        {
            requests = new[]
            {
                new
                {
                    image = new
                    {
                        content = base64Image
                    },
                    features = new[]
                    {
                        new
                        {
                            type = "LABEL_DETECTION",
                            maxResults = 10
                        }
                    }
                }
            }
        };
        var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(jsonContent), Encoding.UTF8, "application/json");

        // Enviar la solicitud a la API
        var response = await httpClient.PostAsync(apiEndpoint, content);
        var responseContent = await response.Content.ReadAsStringAsync();

        // Obtener las etiquetas de la respuesta
        var tags = new List<string>();
        dynamic responseData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
        if (responseData.responses[0].labelAnnotations != null)
        {
            foreach (var annotation in responseData.responses[0].labelAnnotations)
            {
                tags.Add(annotation.description.ToString());
            }
        }

        return tags;
    }

    private string ConvertImageToBase64(string imagePath)
    {
        byte[] imageBytes = File.ReadAllBytes(imagePath);
        string base64Image = Convert.ToBase64String(imageBytes);
        return base64Image;
    }
}
