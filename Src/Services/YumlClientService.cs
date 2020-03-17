using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tch.YumlClient.Data;
using Tch.YumlClient.Domain.Objects;
using Tch.YumlClient.Interfaces;
using Tch.YumlClient.Interfaces.Helpers;
using Tch.YumlClient.Services.Helpers;

namespace Tch.YumlClient.Services
{
   /// <summary>
   ///    Implementation of <see cref="IYumlClientService" />
   /// </summary>
   public class YumlClientService : IYumlClientService
   {
      private readonly IHttpService _httpService;

      #region ctor

      internal YumlClientService(IHttpService httpService)
      {
         _httpService = httpService;
      }

      public YumlClientService() : this(new HttpService())
      {
      }

      #endregion

      public async Task<DiagramFile> BuildDiagram(IEnumerable<string> umlTexts, FileFormat fileFormat)
      {
         if (umlTexts == null)
         {
            throw new ArgumentNullException(nameof(umlTexts));
         }

         if (!umlTexts.Any())
         {
            throw new ArgumentException("Uml texts cannot be empty");
         }

         var text = string.Join(",", umlTexts);
         var fileExtension = Constants.FileExtensions[fileFormat];
         var httpResponseDto = await _httpService.PostUmlText(Uri.EscapeUriString(text), fileExtension);
         var fileName = httpResponseDto.Body;
         var result = await _httpService.DownloadDiagramFile(fileName);
         return result;
      }
   }
}