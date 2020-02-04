using System.IO;
using Tch.YumlClient.Domain.Objects;

namespace Tch.YumlClient.IntTests.TestExtensions
{
   public static class SaveDiagramToDiskExtension
   {
      public static void SaveDiagramToDisk(this IntegrationTestBase test, DiagramFile file)
      {
         var blob = file.Content;
         var path = Path.GetDirectoryName(test.GetType().Assembly.CodeBase).Replace("file:\\", "");
         var filePath = path + "\\" + file.FileName;
         File.WriteAllBytes(filePath, blob);
      }
   }
}