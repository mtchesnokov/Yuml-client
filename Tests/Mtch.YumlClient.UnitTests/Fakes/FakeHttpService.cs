using System.Net;
using System.Threading.Tasks;
using Tch.YumlClient.Domain.Helpers;
using Tch.YumlClient.Domain.Objects;
using Tch.YumlClient.Interfaces.Helpers;

namespace Tch.YumlClient.UnitTests.Fakes
{
   internal class FakeHttpService : IHttpService
   {
      public Task<HttpResponseVm> PostUmlText(string dslText, string fileExtension)
      {
         var httpResponseVm = new HttpResponseVm
         {
            StatusCode = HttpStatusCode.OK,
            Body = $"Diagram.{fileExtension}"
         };

         return Task.FromResult(httpResponseVm);
      }

      public Task<DiagramFile> DownloadDiagramFile(string fileName)
      {
         return Task.FromResult(new DiagramFile {FileName = fileName});
      }
   }
}