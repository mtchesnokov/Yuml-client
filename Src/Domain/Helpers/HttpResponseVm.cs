using System.Net;

namespace Tch.YumlClient.Domain.Helpers
{
   /// <summary>
   /// Helper class to parse http response
   /// </summary>
   internal class HttpResponseVm
   {
      public HttpStatusCode StatusCode { get; set; }

      public string Body { get; set; }
   }
}