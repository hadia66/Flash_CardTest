using Google.Cloud.Translation.V2;
using Newtonsoft.Json;
using System.Web;

namespace Flash_Card.Service
{
    public class TranslationService: ITranslationService
    {

        //private readonly TranslationClient _translationClient;

        //public TranslationService(TranslationClient translationClient)
        //{
        //    _translationClient = translationClient;
        //}

        //public async Task<string> TranslateText(string text, string targetLanguageCode)
        //{
        //    var response = await _translationClient.TranslateTextAsync(text, targetLanguageCode);
        //    return response.TranslatedText;
        //}
      
            private readonly string _apiKey;
            private readonly HttpClient _httpClient;

            public TranslationService(string apiKey)
            {
                _apiKey = apiKey;
                _httpClient = new HttpClient();
            }

            public async Task<string> Translate(string text, string targetLanguageCode)
            {
                var encodedText = HttpUtility.UrlEncode(text);
                var url = $"https://translation.googleapis.com/language/translate/v2?AIzaSyC69tYuAo11VZ44WcgUE2yefAZ5r3jmZNU={_apiKey}&q={encodedText}&target={targetLanguageCode}";

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    // handle the error
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<GoogleCloudTranslationResponse>(responseContent);

                return responseObject.Data.Translations.FirstOrDefault()?.TranslatedText;
            }
        }

        public class GoogleCloudTranslationResponse
        {
            public GoogleCloudTranslationData Data { get; set; }
        }

        public class GoogleCloudTranslationData
        {
            public List<GoogleCloudTranslation> Translations { get; set; }
        }

        public class GoogleCloudTranslation
        {
            public string TranslatedText { get; set; }
        }

    }

