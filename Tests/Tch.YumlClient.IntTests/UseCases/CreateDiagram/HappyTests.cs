using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Tch.YumlClient.Domain.Objects;
using Tch.YumlClient.Interfaces;
using Tch.YumlClient.IntTests.TestExtensions;

namespace Tch.YumlClient.IntTests.UseCases.CreateDiagram
{
   [Explicit]
   public class HappyTests : IntegrationTestBase<IYumlClientService>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         string[] arr =
         {
            "[Customer|-forname:string;-surname:string|doShiz()]<>-orders*>[Order]",
            "[Order] -0..*>[LineItem{bg:red}]",
            "[Order]-[note:Aggregate Root ala DDD{bg:wheat}]"
         };

         //act
         var diagramFile = await SUT().BuildDiagram(arr, FileFormat.Svg);

         //arrange
         Assert.IsNotNull(diagramFile);

         //print
         Console.WriteLine(diagramFile.FileName);
         Console.WriteLine(diagramFile.ContentType);
         Console.WriteLine(diagramFile.Content.Length);

         //save file to disk
         this.SaveDiagramToDisk(diagramFile);
      }
   }
}