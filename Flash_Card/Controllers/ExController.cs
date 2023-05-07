//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//using Google.Cloud.Translate.V3;
//using Microsoft.AspNetCore.Mvc;

//[ApiController]
//[Route("[controller]")]
//public ExController : ControllerBase
//{
   
//private readonly IStringLocalizer<ExController> _localization;


//public ExController(IStringLocalizer Localizer, IStringLocalizer<ExController> localization)
//{
    
//    _localization = localization;

//}
//  [HttpGet("{id}")]
//    public async Task<IActionResult> GetById(int id, string language)
//    {
//        // Retrieve the data from the database
//        MyData data = await _dbContext.MyData.FindAsync(id);

//        // Translate the data
//        TranslationResult result = await _translationClient.TranslateTextAsync(
//            text: data.TextToTranslate,
//            targetLanguageCode: language
//        );

//        // Create a new object with the translated text
//        TranslatedData translatedData = new TranslatedData
//        {
//            Id = data.Id,
//            TranslatedText = result.TranslatedText
//        };

//        // Return the translated data as the API response
//        return Ok(translatedData);
//    }
//}
