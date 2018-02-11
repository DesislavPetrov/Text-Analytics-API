using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Language;
using System;
using System.Threading.Tasks;

namespace TextAnalysis
{
    public static class LanguageAnalysis
    {
        public static async Task AnalyzeLanguageAsync(string id, string text)
        {
            var document = new Document()
            {
                Id = id,
                Text = text
            };

            var client = new LanguageClient(Constants.ApiKey)
            {
                Url = "https://westeurope.api.cognitive.microsoft.com/text/analytics/v2.0/languages"
            };

            var request = new LanguageRequest();
            request.Documents.Add(document);

            try
            {
                var response = await client.GetLanguagesAsync(request);
                foreach (var doc in response.Documents)
                {
                    foreach (var language in doc.DetectedLanguages)
                    {
                        Console.WriteLine("The language is: {0} and the confidence is: {1}%", language.Name, language.Score * 100);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}