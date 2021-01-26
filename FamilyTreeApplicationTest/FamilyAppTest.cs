using System;
using System.Collections.Generic;
using System.Text;
using FamilyTreeApplication;
using NUnit.Framework;

namespace FamilyTreeApplicationTest
{
    class FamilyAppTest
    {
        [Test]
        public void TestFamilyApp()
        {
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
            sverreMagnus.Father = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father = harald;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("show 3");
            var expectedResponse = "(Id: 3) FirstName: Haakon Magnus, BirthYear: 1973, Fathers firstname: Harald (Id: 6), "
                                   + "Children: "
                                   + "Childrens FirstName is: Sverre Magnus(Id: 1), BirthYear: 2005 "
                                   + "Childrens FirstName is: Ingrid Alexandra(Id: 2), BirthYear: 2004 ";
            Assert.AreEqual(expectedResponse, actualResponse);
        }
        [Test]
        public void TestFamilyNoChildren()
        {

            var Will = new Person { Id = 1, FirstName = "Will", BirthYear = 1995, };
            var Sami = new Person { Id = 2, FirstName = "Samantha", BirthYear = 1978, };
            var Lucas = new Person { Id = 3, FirstName = "Lucas", BirthYear = 1976, };
            Will.Father = Lucas;
            Will.Mother = Sami;
            var app = new FamilyApp(Will);
            var actualResponse = app.HandleCommand("show 1");
            var expectedResponse = "(Id: 1) FirstName: Will, BirthYear: 1995, Fathers firstname: Lucas (Id: 3), Mothers firstname: Samantha (Id: 2), ";
            Assert.AreEqual(expectedResponse, actualResponse);
        }
    }
}
