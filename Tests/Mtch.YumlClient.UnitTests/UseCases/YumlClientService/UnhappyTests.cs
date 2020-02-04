using System;
using System.Collections.Generic;
using NUnit.Framework;
using Tch.YumlClient.Domain.Objects;
using Tch.YumlClient.Interfaces;

namespace Tch.YumlClient.UnitTests.UseCases.YumlClientService
{
   public class UnhappyTests : UnitTestBase<IYumlClientService>
   {
      [Test]
      public void UmlTexts_Null()
      {
         //arrange
         IEnumerable<string> umlTexts = null;

         //act+assert
         Assert.ThrowsAsync<ArgumentNullException>(() => SUT().BuildDiagram(umlTexts, FileFormat.Svg));
      }

      [Test]
      public void UmlTexts_Empty()
      {
         //arrange
         IEnumerable<string> umlTexts = new string[0];

         //act+assert
         Assert.ThrowsAsync<ArgumentException>(() => SUT().BuildDiagram(umlTexts, FileFormat.Svg));
      }
   }
}