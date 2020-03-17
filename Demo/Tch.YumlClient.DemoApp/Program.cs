using System;
using System.Threading.Tasks;
using Tch.YumlClient.Domain.Objects;
using Tch.YumlClient.Interfaces;
using Tch.YumlClient.Services;

namespace Tch.YumlClient.DemoApp
{
   internal class Program
   {
      private static async Task Main(string[] args)
      {
         IYumlClientService clientService = new YumlClientService();

         string[] umlStrings =
         {
            "[Customer|-forname:string;-surname:string|doShiz()]<>-orders*>[Order]",
            "[Order] -0..*>[LineItem{bg:red}]",
            "[Order]-[note:Aggregate Root ala DDD{bg:wheat}]"
         };

         DiagramFile diagramFile = await clientService.BuildDiagram(umlStrings, FileFormat.Svg);

         new{FileName = diagramFile.FileName, ContentType = diagramFile.ContentType, Content = diagramFile.Content=new byte[]{12,3}}.Print();

         //Console.WriteLine(diagramFile.FileName);
         //Console.WriteLine(diagramFile.ContentType);
         //Console.WriteLine(diagramFile.Content.Length);
      }
   }
}