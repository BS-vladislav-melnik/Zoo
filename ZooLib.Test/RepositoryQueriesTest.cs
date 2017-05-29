using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.Core;
using ZooLib.Core.Animals;
using ZooLib.Extensions;
using NUnit.Framework;
namespace ZooLib.Test
{
    [TestFixture]
    public class RepositoryQueriesTest
    {
        private ListRepository repository = new ListRepository();
        [OneTimeSetUp]
        public void SetUp()
        {
            repository.Add(new Wolf("wolf1"));
            repository.Add(new Wolf("wolf2"));
            repository.Add(new Tiger("tiger1"));
            repository.Add(new Tiger("tiger2"));
            repository.Add(new Elephant("Elephant1"));
            repository.Add(new Elephant("Elephant2"));
            repository.Add(new Bear("Bear1"));
            repository.Add(new Bear("Bear2"));
            repository.Add(new Bear("Bear3"));
            repository.Add(new Bear("Bear4"));
        }
        [Test]
        public void GroupByType()
        {
           var result= repository.GroupByType(); 
        }
    }
}
