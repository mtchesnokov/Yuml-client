using StructureMap;
using Tch.YumlClient.Interfaces;
using Tch.YumlClient.Interfaces.Helpers;
using Tch.YumlClient.Services;
using Tch.YumlClient.UnitTests.Fakes;

namespace Tch.YumlClient.UnitTests
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         For<IHttpService>().Use<FakeHttpService>();

         For<IYumlClientService>().Use<YumlClientService>()
            .SelectConstructor(() => new YumlClientService((IHttpService)null));
      }
   }
}