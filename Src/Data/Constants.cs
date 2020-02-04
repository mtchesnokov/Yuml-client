using System.Collections.Generic;
using Tch.YumlClient.Domain.Objects;

namespace Tch.YumlClient.Data
{
   internal static class Constants
   {
      public static Dictionary<FileFormat, string> FileExtensions = new Dictionary<FileFormat, string>
      {
         {FileFormat.Svg, "svg"},
         {FileFormat.Png, "png"},
         {FileFormat.Pdf, "pdf"}
      };
   }
}