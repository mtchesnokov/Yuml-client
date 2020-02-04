using System;
using NUnit.Framework;
using StructureMap;

namespace Tch.YumlClient.UnitTests
{
   [TestFixture]
   public abstract class UnitTestBase
   {
      public IContainer Container { get; set; }

      [OneTimeSetUp]
      public void OneTimeSetup()
      {
         Container = new Container(cfg => cfg.AddRegistry<MasterRegistry>());
      }
   }

   public abstract class UnitTestBase<TSUT> : UnitTestBase
   {
      public Func<TSUT> SUT => () => Container.GetInstance<TSUT>();
   }
}