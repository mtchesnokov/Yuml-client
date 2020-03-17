using System.Threading.Tasks;
using NUnit.Framework;
using Tch.YumlClient.Domain.Objects;
using Tch.YumlClient.Interfaces;

namespace Tch.YumlClient.UnitTests.UseCases.YumlClientService
{
   public class HappyTests : UnitTestBase<IYumlClientService>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var umlTexts = new[] {"one", "two"};

         //act
         var diagramFile = await SUT().BuildDiagram(umlTexts, FileFormat.Svg);

         //arrange
         Assert.IsNotNull(diagramFile);
         Assert.AreEqual("Diagram.svg", diagramFile.FileName);
      }
   }
}