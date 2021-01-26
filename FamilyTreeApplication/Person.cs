using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTreeApplication
{
   public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public int Id { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }

        public string GetDescription()
        {
            string Output = null;
            Output = GetDescriptionOfPerson(Output);
            Output = GetDescriptionOfFather(Output);
            Output = GetDescriptionOfMother(Output);
            return Output;
        }
        private string GetDescriptionOfPerson(string output)
        {
            if (Id != 0) output += "(Id: " + Id + ") ";
            if (FirstName != null) output += "FirstName: " + FirstName + ", ";
            if (LastName != null) output += "LastName: " + LastName + ", ";
            if (BirthYear != null) output += "BirthYear: " + BirthYear + ", ";
            if (DeathYear != null) output += "DeathYear: " + DeathYear + ", ";
            return output;
        }
     

        private string GetDescriptionOfFather(string output)
        {
            if (Father != null)
            {
                if (Father.FirstName != null) output += "Fathers firstname: " + Father.FirstName + " ";
                if (Father.LastName != null) output += "Fathers lastname: " + Father.LastName + " ";
                if (Father.Id != 0) output += "(Id: " + Father.Id + "), ";
            }

            return output;
        }
        private string GetDescriptionOfMother(string output)
        {
            if (Mother != null)
            {
                if (Mother.FirstName != null) output += "Mothers firstname: " + Mother.FirstName + " ";
                if (Mother.LastName != null) output += "Mothers lastname: " + Mother.LastName + " ";
                if (Mother.Id != 0) output += "(Id: " + Mother.Id + "), ";
            }

            return output;
        }

    }
}
