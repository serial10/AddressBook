using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignement_3
{
    class Program
    {
        // Create a new Person list
        private static List<Person> personList = new List<Person>();

        static void Main(string[] args)
        {
            // Ask user to enter one of the options below
            string input = String.Empty;
            Console.WriteLine("Enter AddPerson, FindPerson, ListAll, DeletePerson, or UpdatePerson or exit to quit.");
            input = Console.ReadLine();

            // Change any choice to lower case
            while (input.ToLower() != "exit")
            {
                // If the user entered AddPerson, go into the AddPerson if statement
                if (input.ToLower() == "addperson")
                {
                    // create a new person object to store the individuals information
                    Person newPersonObject = new Person();

                    // Add the First Name
                    Console.WriteLine("Please enter the individuals first name: ");
                    newPersonObject.FirstName = Console.ReadLine();

                    // Add the Middle Name
                    Console.WriteLine("Please enter the individuals middle name: ");
                    newPersonObject.MiddleName = Console.ReadLine();

                    // Add the Last Name
                    Console.WriteLine("Please enter the individuals last name: ");
                    newPersonObject.LastName = Console.ReadLine();

                    // Check to see if the first, middle, lastname is unique
                    foreach (var name in personList)
                    {
                        if (newPersonObject.FirstName.Contains(Convert.ToString(name.FirstName)) && newPersonObject.MiddleName.Contains(Convert.ToString(name.MiddleName)) && newPersonObject.LastName.Contains(Convert.ToString(name.LastName)))
                        {
                            // If the name is not unique, alert the user and accept another name.
                            Console.WriteLine("This name already exists in the list, please enter a different name.");
                            Console.WriteLine("Please enter the individuals first name: ");
                            newPersonObject.FirstName = Console.ReadLine();

                            Console.WriteLine("Please enter the individuals middle name: ");
                            newPersonObject.MiddleName = Console.ReadLine();

                            Console.WriteLine("Please enter the individuals last name: ");
                            newPersonObject.LastName = Console.ReadLine();

                            //(newPersonObject.FirstName.Contains(Convert.ToString(name.FirstName)) && newPersonObject.MiddleName.Contains(Convert.ToString(name.MiddleName)) && newPersonObject.LastName.Contains(Convert.ToString(name.LastName)))
                            //Console.WriteLine("This name already exists in the list, please enter a different name.");
                            //Console.WriteLine("Please enter the individuals first name: ");
                            //newPersonObject.FirstName = Console.ReadLine();
                        }
                        else
                        {
                            // If the name is unique, continue on collecting data from the individual
                            continue;
                        }
                    }

                    // Add the Birthdate 
                    string dateInput = String.Empty;
                    Console.WriteLine("Please enter the individuals birthday (mm/dd/yyyy): ");
                    dateInput = Console.ReadLine();

                    // Take the user's input and checks it against the DateTime Method. If the input is accepted, it passes into the person object and the person object is added to the list
                    while (dateInput.ToLower() != "exit")
                    {
                        // Checks to see if dateInput is in a DateTime Format, then is passed into the validateDateTime variable
                        var dateInputStructure = DateTime.MinValue;
                        var validateDateTime = DateTime.TryParse(dateInput, out dateInputStructure);

                        // validateDateTime is evaluated. If it is true, the date is converted and put into the person object, which is then stored into the list. If false, user is told the format is incorrect and to re-enter the birthdate
                        if (validateDateTime)
                        {
                            // Convert DateTime to string and add it to the person object
                            newPersonObject.BirthDate = DateTime.Parse(Convert.ToString(dateInputStructure));
                            break;
                        }
                        else
                        {
                            // When the if statement becomes false, tell user the format is wrong and tell them to re-enter it the correct way
                            Console.WriteLine($"{dateInput} is not in the correct format. Please enter the date in the correct format. mm/dd/yyyy");
                            dateInput = Console.ReadLine();
                            DateTime.TryParse(dateInput, out dateInputStructure);
                        }
                    }

                    // Add the Gender
                    Console.WriteLine("Please enter the individuals gender: ");
                    newPersonObject.Gender = Console.ReadLine();

                    // Add the Weight in LBS.
                    Console.WriteLine("Please enter the individuals weight(lbs): ");
                    string pounds = Console.ReadLine();
                    int poundsInput = Convert.ToInt32(pounds);
                    newPersonObject.Weight = poundsInput;

                    // Add the Height in inches.
                    Console.WriteLine("Please enter the individuals height(inches): ");
                    string inches = Console.ReadLine();
                    int inchesInput = Convert.ToInt32(inches /);
                    newPersonObject.Height = inchesInput;

                    // Add the person object into the person list.
                    personList.Add(newPersonObject);

                    // Ask user to enter one of the options below.
                    Console.WriteLine("Enter AddPerson, FindPerson, ListAll, DeletePerson, or UpdatePerson or exit to quit.");
                    input = Console.ReadLine();
                }

                // If the user entered FindPerson, go into the FindPerson if statement.
                else if (input.ToLower() == "findperson")
                {

                    Console.WriteLine("Find Person: Type the First, Middle and Last name of the person you want to find an individual.");
                    string findPerson = Console.ReadLine();

                    // string[] words = findPerson.Split(' ');

                    var personByFullName = GetPersonByFullName(findPerson);

                    if (personByFullName != null)
                    {
                        Console.WriteLine($"1 Entry found: {findPerson}");
                    }
                    else
                    {
                        Console.WriteLine("This person does not exist in the list. Please add them.");
                        Console.WriteLine("Enter AddPerson, FindPerson, ListAll, DeletePerson, or UpdatePerson or exit to quit.");
                        input = Console.ReadLine();
                    }
                    Console.WriteLine("Enter AddPerson, FindPerson, ListAll, DeletePerson, or UpdatePerson or exit to quit.");
                    input = Console.ReadLine();
                }

                // If the user entered ListAll, go into the ListAll if statement.
                else if (input.ToLower() == "listall")
                {
                    // List everyone that is in the list.
                    foreach (var item in personList)
                    {
                        Console.WriteLine();
                        Console.WriteLine("First Name: {0}", item.FirstName);
                        Console.WriteLine("Middle Name: {0}", item.MiddleName);
                        Console.WriteLine("Last Name: {0}", item.LastName);
                        Console.WriteLine("Birthday: {0}", item.BirthDate.ToString("MM/dd/yyyy"));
                        Console.WriteLine("Gender: {0}", item.Gender);
                        Console.WriteLine("Weight: {0}", item.Weight + " lbs");
                        Console.WriteLine("Height: {0:0}", item.Height + " inches" + Environment.NewLine);
                    }
                    Console.WriteLine("Enter AddPerson, FindPerson, ListAll, DeletePerson, or UpdatePerson or exit to quit.");
                    input = Console.ReadLine();
                }
                // If the user entered DeletePerson, go into the DeletePerson if statement.
                else if (input.ToLower() == "deleteperson")
                {
                    //string removePerson = String.Empty;
                    Console.WriteLine("Delete Person: Type the First, Middle and Last name of the person you want to remove.");
                    string removePerson = Console.ReadLine();

                    // Call GetPersonByFullName Method to look up a user to be removed.
                    var personByFullName = GetPersonByFullName(removePerson);

                    // Check to see if the input is null
                    if (personByFullName != null)
                    {
                        // If the input is not null, remove individual by index number. Let user know that the individual has been removed.
                        personList.Remove(personByFullName);
                        Console.WriteLine();
                        Console.WriteLine($"{removePerson} removed from list");
                    }
                    else
                    {
                        // If the input is null or the person doesn't exist, let user know.
                        Console.WriteLine("This person does not exist in the list.");
                        Console.WriteLine("Enter a different name to delete from the list");
                        removePerson = Console.ReadLine();
                    }
                    Console.WriteLine("Enter AddPerson, FindPerson, ListAll, DeletePerson, or UpdatePerson or exit to quit.");
                    input = Console.ReadLine();
                }
                // If the user entered UpdatePerson, go into the UpdatePerson if statement.
                else if (input.ToLower() == "updateperson")
                {

                    Console.WriteLine("Update Person: Type the First, Middle and Last name of the person you want to update.");
                    string updatePerson = Console.ReadLine();

                    // Call GetPersonByFullName Method to look up a user to be updated.
                    var personVerification = GetPersonByFullName(updatePerson);

                    if (personVerification != null)
                    {
                        // Ask user to put in the first, middle and last name of the individual.
                        Console.WriteLine("Choose one of the following to update: FirstName, MiddleName, LastName, Birthdate, Gender, Weight, Height.");

                        // Store input into a string.
                        string attributeChoice = Console.ReadLine();

                        while (attributeChoice != "exit")
                        {
                            // If firstname is typed, enter the firstname if statement.
                            if (attributeChoice.ToLower() == "firstname")
                            {
                                // Enter a different first name here
                                Console.WriteLine("Update First Name: Correct or change your first name here. Press Enter to enter changes.");

                                // Store the input in a string.
                                string firstNameChange = Console.ReadLine();

                                // Link the new name to the verified name stored in the list.
                                personVerification.FirstName = firstNameChange;
                                Console.WriteLine("First name was updated sucessfully!");                              
                            }

                            else if (attributeChoice.ToLower() == "middlename")
                            {
                                // Enter a different middle name here
                                Console.WriteLine("Update Middle Name: Correct or change your middle name here. Press Enter to enter changes.");

                                // Store the input in a string
                                string middleNameChange = Console.ReadLine();

                                // Link the new name to the verified name stored in the list.
                                personVerification.MiddleName = middleNameChange;
                                Console.WriteLine("Middle name was updated sucessfully!");
                            }

                            else if (attributeChoice.ToLower() == "lastname")
                            {
                                // Enter a different last name here
                                Console.WriteLine("Update Last Name: Correct or change your last name here. Press Enter to enter changes.");

                                // Store the input in a string
                                string lastNameChange = Console.ReadLine();

                                // Link the new name to the verified name stored in the list.
                                personVerification.LastName = lastNameChange;
                                Console.WriteLine("Last name was updated sucessfully!");
                            }

                            else if (attributeChoice.ToLower() == "birthdate")
                            {
                                // Enter a different birthday name here
                                Console.WriteLine("Update Birthday: Correct or change your birthday here. Press Enter to enter changes.");

                                // Store the input in a string
                                string dateChange = Console.ReadLine();

                                // Link the new birthdate to the verified name stored in the list.
                                personVerification.BirthDate = DateTime.Parse(dateChange);
                                Console.WriteLine("Birthday was updated sucessfully!");
                            }

                            else if (attributeChoice.ToLower() == "gender")
                            {
                                // Enter a different gender here
                                Console.WriteLine("Update Gender: Correct or change your gender here. Press Enter to enter changes.");

                                // Store the input in a string
                                string genderChange = Console.ReadLine();

                                // Link the new gender to the verified name stored in the list.
                                personVerification.Gender = genderChange;
                                Console.WriteLine("Gender was updated sucessfully!");
                            }

                            else if (attributeChoice.ToLower() == "weight")
                            {
                                // Enter a different weight here
                                Console.WriteLine("Update Weight: Correct or change your weight here. Press Enter to enter changes.");

                                // Store the input in a string
                                string weightChange = Console.ReadLine();

                                // Link the new weight to the verified name stored in the list.
                                personVerification.Weight = Convert.ToInt32(weightChange);
                                Console.WriteLine("Weight was updated sucessfully!");
                            }

                            else if (attributeChoice.ToLower() == "height")
                            {
                                // Enter a different weight here
                                Console.WriteLine("Update Height: Correct or change your height here. Press Enter to enter changes.");

                                // Store the input in a string
                                string heightChange = Console.ReadLine();

                                // Link the new height to the verified name stored in the list.
                                personVerification.Height = Convert.ToInt32(heightChange);
                                Console.WriteLine("Height was updated sucessfully!");
                            }

                            else
                            {
                                Console.WriteLine("Invalid choice, try again.");

                                // Ask user to put in the first, middle and last name of the individual.
                                Console.WriteLine("Choose one of the following to update: FirstName, MiddleName, LastName, Birthdate, Gender, Weight, Height.");

                                // Store input into a string.
                                attributeChoice = Console.ReadLine();
                            }
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Person does not exist!");
                        Console.WriteLine("Update Person: Type the First, Middle and Last name of the person you want to remove.");
                        updatePerson = Console.ReadLine();
                    }
                    Console.WriteLine("Enter AddPerson, FindPerson, ListAll, DeletePerson, or UpdatePerson or exit to quit.");
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine("Enter AddPerson, FindPerson, ListAll, DeletePerson, or UpdatePerson or exit to quit.");
                    input = Console.ReadLine();
                }
            }
            // When exit is typed and enter is pressed, this will exit the application.
            Environment.Exit(0);
        }

        private static Person GetPersonByFullName(string fullName)
        {
            // Set result to null.
            Person result = null;

            // Create words array, split the fullName input into seperate value.
            string[] words = fullName.Split(' ');

            // Check to see if the number of valuses in the array is greater than or equal to 2.
            if (words.Length >= 2)
            {
                // If the above passes, check again to see if there are 3 array values.
                if (words.Length == 3)
                {
                    // Go through each value and validate input with what is stored in the personList First, Middle and Last name.
                    foreach (var person in personList)
                    {
                        if (person.FirstName == words[0] && person.MiddleName == words[1] && person.LastName == words[2])
                        {
                            // If everything matches, store all of the individuals information into result.
                            Console.WriteLine("Match found!");
                            result = person;
                        }
                        else
                        {
                            // If no result is found. Return this message and ask again.
                            Console.WriteLine("No matches found, please re-enter the first, middle and last name.");
                            fullName = Console.ReadLine();
                            GetPersonByFullName(fullName);
                        }
                    }
                }
                else
                {
                    // Go through each value and validate input with what is stored in the personList First and Last name.
                    foreach (var person in personList)
                    {
                        if (person.FirstName == words[0] && person.LastName == words[1])
                        {
                            // If everything matches, store all of the individuals information into result.
                            Console.WriteLine("Match found!");
                            result = person;
                        }
                        else
                        {
                            // If no result is found. Return this message and ask again.
                            Console.WriteLine("No matches found, please re-enter the first and last name.");
                            fullName = Console.ReadLine();
                            GetPersonByFullName(fullName);
                        }
                    }
                }
            }
            else
            {
                // If there is not enough information to find an individual. Display this message to the user.
                Console.WriteLine("There is not enough information to do a search, please enter the individual's first, middle, and lastname.");
                fullName = Console.ReadLine();
                GetPersonByFullName(fullName);
            }
            return result;
        }
        //private static List<Person> GetPeopleByLastName(string lastName)
        //{
        //    // Find an individual by last name.
        //    return personList.Where(x => x.LastName == lastName).ToList<Person>();
        //}

    }
}
