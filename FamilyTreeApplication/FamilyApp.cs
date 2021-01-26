using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamilyTreeApplication
{
    public class FamilyApp
    {
        public List<Person> _persons;
        public string WelcomeMessage { get; set; }
        public bool CommandPromt { get; internal set; }

        public FamilyApp(params Person[] persons) =>
            (_persons, WelcomeMessage) = (new List<Person>(persons), @"Write Help for Commands");



        public object HandleCommand(string command)
        {
            if (HelpText(command, out var handleCommand)) return handleCommand;
            if (command == "list".ToUpper() || command == "list" || command == "Liste")
            {
                return _persons.Aggregate((string)null, (current, person) => current + person.GetDescription());
            }

            foreach (var person in _persons)
            {
                var id = person.Id;
                if (command != $"show {person.Id}" || person.Id != id) continue;
                var children = FindPersonChildrens(person);
                var description = (string)person.GetDescription();
                description = AddChildrenToDescription(children, description);
                return description;

            }

            return "Something went wrong, Please try one more time!";
        }

        private bool HelpText(string command, out string handleCommand)
        {
            if (command == "help".ToUpper() || command == "help" || command == "Help")
            {
                {
                    handleCommand = "Commands: " +
                                    "List: List of all persons with Id, FirstName, BirthYear, DeathYear " +
                                    " and Name and Id on Father and Mother if its registered in the register " +
                                    "Show (id) : Shows on one specific person with, father, mother and children, and Id of these persons ";
                    return true;
                }
            }

            handleCommand = null;
            return false;
        }

        private List<Person> FindPersonChildrens(Person person)
        {
            var children = new List<Person>();
            foreach (var child in _persons)
            {
                if (child.Father == person || child.Mother == person)
                    children.Add(child);
            }

            return children;
        }

        private string AddChildrenToDescription(List<Person> children, string description)
        {
            if (children.Count <= 0) return description;
            description += "Children: ";
            foreach (var child in children)
            {
                description += "Childrens FirstName is: " + child.FirstName + "(Id: " + child.Id + ")," +
                               " BirthYear: " + child.BirthYear + " ";

            }

            return description;
        }
    }

}
