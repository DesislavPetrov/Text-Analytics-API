using System;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;

namespace TextAnalysis
{
    public static class SentimentAnalysis
    {
        public static async Task AnalyzeSentimentAsync(string id, string text, string language)
        {
            var document = new SentimentDocument()
            {
                Id = id,
                Text = text,
                Language = language
            };

            var client = new SentimentClient(Constants.ApiKey)
            {
                Url = "https://westeurope.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment"
            };

            var request = new SentimentRequest();
            request.Documents.Add(document);

            try
            {
                var response = await client.GetSentimentAsync(request);
                foreach (var doc in response.Documents)
                {
                    Console.WriteLine("Sentiment Score: {0}", doc.Score);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}