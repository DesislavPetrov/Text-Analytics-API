using Microsoft.ProjectOxford.Text.KeyPhrase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    public static class KeyPhraseAnalysis
    {
        public static async Task AnalyzeKeyPhraseAsync(string id, string text, string language)
        {
            var document = new KeyPhraseDocument()
            {
                Id = id,
                Text = text,
                Language = language
            };

            var client = new KeyPhraseClient(Constants.ApiKey)
            {
                Url = "https://westeurope.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases"
            };

            var request = new KeyPhraseRequest();
            request.Documents.Add(document);

            try
            {
                var response = await client.GetKeyPhrasesAsync(request);
                foreach (var doc in response.Documents)
                {
                    foreach (var keyPhrase in doc.KeyPhrases)
                    {
                        Console.WriteLine("Key Phrase: {0}", keyPhrase);
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

