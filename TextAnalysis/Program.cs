using System;

namespace TextAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            string id = Guid.NewGuid().ToString();
            Console.WriteLine("Enter text to analyze:");
            string text = Console.ReadLine();

            Console.WriteLine("Document Id: {0}", id);
            Console.WriteLine("Text Analyzed: {0}", text);

            SentimentAnalysis.AnalyzeSentimentAsync(id, text, "en").Wait();

            Console.WriteLine();

            KeyPhraseAnalysis.AnalyzeKeyPhraseAsync(id, text, "en").Wait();

            Console.WriteLine();

            LanguageAnalysis.AnalyzeLanguageAsync(id, text).Wait();

            Console.WriteLine();
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}
