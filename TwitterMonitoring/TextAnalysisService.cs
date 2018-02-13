﻿using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.KeyPhrase;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterMonitoring
{
    public static class TextAnalysisService
    {
        public static float AnalyzeSentiment (string id, string text, string language)
        {
            float score = 0;
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
                var response = client.GetSentiment(request);
                score = response.Documents.First().Score * 100;
            }
            catch (Exception ex)
            {

                var message = "";
                var innerMessage = "";
                if (!String.IsNullOrEmpty(ex.Message))
                {
                    message = ex.Message;
                }

                try
                {
                    if ((ex.InnerException != null) & (!String.IsNullOrEmpty(innerMessage)))
                    {
                        innerMessage = ex.InnerException.Message;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return score;
        }

        public static IList<string> AnalyzeKeyPhrases(string id, string text, string language)
        {
            IList<string> keyPhrases = new List<string>();
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
                var response = client.GetKeyPhrases(request);
                var doc = response.Documents.First();
                foreach (var keyPhrase in doc.KeyPhrases)
                {
                    keyPhrases.Add(keyPhrase);
                }
            }
            catch (Exception ex)
            {

                var message = "";
                var innerMessage = "";
                if (!String.IsNullOrEmpty(ex.Message))
                {
                    message = ex.Message;
                }

                try
                {
                    if ((ex.InnerException != null) & (!String.IsNullOrEmpty(innerMessage)))
                    {
                        innerMessage = ex.InnerException.Message;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return keyPhrases;
        }

        public static DetectedLanguage AnalyzeLanguage(string id, string text)
        {
            DetectedLanguage language = new DetectedLanguage();
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
                var response = client.GetLanguages(request);
                var doc = response.Documents.First().DetectedLanguages.First();
            }
            catch (Exception ex)
            {

                var message = "";
                var innerMessage = "";
                if (!String.IsNullOrEmpty(ex.Message))
                {
                    message = ex.Message;
                }

                try
                {
                    if ((ex.InnerException != null) & (!String.IsNullOrEmpty(innerMessage)))
                    {
                        innerMessage = ex.InnerException.Message;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return language;
        }
    }
}
