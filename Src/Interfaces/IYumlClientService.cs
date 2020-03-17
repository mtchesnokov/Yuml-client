using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.YumlClient.Domain.Objects;

namespace Tch.YumlClient.Interfaces
{
   /// <summary>
   /// This interface represents client to communicate with yuml.me 
   /// </summary>
   public interface IYumlClientService
   {
      /// <summary>
      /// Send uml strings to yuml.me and download diagram file
      /// </summary>
      /// <param name="umlTexts"></param>
      /// <param name="fileFormat"></param>
      /// <returns></returns>
      Task<DiagramFile> BuildDiagram(IEnumerable<string> umlTexts, FileFormat fileFormat);
   }
}