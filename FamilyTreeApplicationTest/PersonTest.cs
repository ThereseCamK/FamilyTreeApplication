using FamilyTreeApplication;
using NUnit.Framework;

namespace FamilyTreeApplicationTest
{
    public class Tests
    {
       

        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { Id = 23, FirstName = "Per" },
                Mother = new Person() { Id = 29, FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id: 17) FirstName: Ola, LastName: Nordmann, BirthYear: 2000, DeathYear: 3000, Fathers firstname: Per (Id: 23), Mothers firstname: Lise (Id: 29), ";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id: 1) ";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestSomeFields()
        {
            var p = new Person
            {
                Id = 1,
                FirstName = "Therese",
                BirthYear = 1990,
                Mother = new Person() { LastName = "Nordnes"}
            };

            var actualDescription = p.GetDescription(); 
            var expectedDescription = "(Id: 1) FirstName: Therese, BirthYear: 1990, Mothers lastname: Nordnes ";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}