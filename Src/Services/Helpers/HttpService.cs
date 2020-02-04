using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tch.YumlClient.Domain.Helpers;
using Tch.YumlClient.Domain.Objects;
using Tch.YumlClient.Interfaces.Helpers;

namespace Tch.YumlClient.Services.Helpers
{
   internal class HttpService : IHttpService
   {
      public async Task<HttpResponseVm> PostUmlText(string dslText, string fileExtension)
      {
         using (var client = new HttpClient())
         {
            HttpContent content = new StringContent($"dsl_text={dslText}", Encoding.UTF8, "application/x-www-form-urlencoded");

            using (var httpResponseMessage = await client.PostAsync($"https://yuml.me/diagram/scruffy/class.{fileExtension}", content))
            {
               var responseStatusCode = httpResponseMessage.StatusCode;
               var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

               return new HttpResponseVm
               {
                  StatusCode = responseStatusCode,
                  Body = responseBody
               };
            }
         }
      }

      public async Task<DiagramFile> DownloadDiagramFile(string fileName)
      {
         using (var client = new HttpClient())
         {
            using (var httpResponseMessage = await client.GetAsync($"https://yuml.me/{fileName}"))
            {
               var content = await httpResponseMessage.Content.ReadAsByteArrayAsync();

               return new DiagramFile
               {
                  FileName = fileName,
                  Content = content,
                  ContentType = httpResponseMessage.Content.Headers.ContentType.MediaType
               };
            }
         }
      }
   }
}