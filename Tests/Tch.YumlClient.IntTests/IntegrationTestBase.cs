using System;
using NUnit.Framework;
using StructureMap;

namespace Tch.YumlClient.IntTests
{
   [TestFixture]
   [Category("IntegrationTest")]
   public abstract class IntegrationTestBase
   {
      public IContainer Container { get; set; }

      [OneTimeSetUp]
      public void OneTimeSetup()
      {
         Container = new Container(cfg => cfg.Scan(s =>
         {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory();
            s.RegisterConcreteTypesAgainstTheFirstInterface();
         }));
      }
   }

   public abstract class IntegrationTestBase<TSUT> : IntegrationTestBase
   {
      public Func<TSUT> SUT => () => Container.GetInstance<TSUT>();
   }
}