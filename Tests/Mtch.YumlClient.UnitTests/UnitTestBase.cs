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
         Container = new Container(cfg => cfg.Scan(s =>
         {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory(a => a.StartsWith("Mtch."));
            s.LookForRegistries();
         }));
      }
   }
}