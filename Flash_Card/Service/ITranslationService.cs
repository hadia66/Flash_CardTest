namespace Flash_Card.Service
{
    public interface ITranslationService
    {
        Task<string> Translate(string text, string targetLanguageCode);
    }
}
