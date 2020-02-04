using System.Collections.Generic;
using System.Threading.Tasks;
using Tch.YumlClient.Domain.Objects;

namespace Tch.YumlClient.Interfaces
{
   public interface IYumlClientService
   {
      Task<DiagramFile> BuildDiagram(IEnumerable<string> umlTexts, FileFormat fileFormat);
   }
}