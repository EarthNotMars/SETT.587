//Variant 8
//Define a class Animal which contains:
//Fields BirthYear, Color
//Method Move() that returns a string like “I am moving!!!”
//Constructor with parameters
//Input() and output() methods for input / output from / to console
//Getters and setters
//Method GetAge() calculating the animal’s age in full years
//Overridden ToString() method calling the Voice() method
//Define a descendant class Fish that has:
//Additional fields Kind (sea or river), Species
//Constructor with parameters 
//Additional getters and setters
//Overridden Move() method
//Overridden input() and output() methods
//Create a collection of animals and add some different animals and fishes to it.              
//Output the data about fishes elder than 3 years
//Sort the data by Species
//Output the collection to a file
//Implement exception handling
//Serialize the collection to XML file
//Deserialize it back
//Write unit tests

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Linq;

namespace Vpfayfer_demo2
{
    [XmlInclude(typeof(Fish))]
    [Serializable]
    // Let's Define a class Animal which contains:
    public class Animal
    {
        //Fields BirthYear, Color
        public int birthYear;
        public string color;
        public string name;
        public string species = "None";
        // Constructor without params for serialization
        public Animal() { }
        static DateTime now = DateTime.Today;
        int currentYear = int.Parse(now.ToString("yyyy"));
        //Getters and Setters
        public int Birth
        { get { return birthYear; }
          set { birthYear = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        //Constructor with parameters: name, birthYear, color
        public Animal(string aname, int abirth, string acolor)
        {
            birthYear = abirth;
            color = acolor;
            name = aname;
        }
        //Method Move() that returns a string
        virtual public void Move()
        {
            Console.WriteLine("I am moving !!!");
        }
        //Input() method for input from console
        virtual public void Input()
        {
            Console.WriteLine("Input name");
            name = Console.ReadLine();
            Console.WriteLine("Input color");
            color = Console.ReadLine();
            Console.WriteLine("Input birth year");
            Birth = int.Parse(Console.ReadLine());
        }
        //output() method for output from console
        virtual public void Output()
        {
            ToString();
        }
        //Method GetAge() calculating the animal’s age in full years
        public double GetAge()
        {
            return (currentYear - birthYear);
        }
        public virtual string Voice()
        {
            return "Pfffffff";
        }
        //Overridden ToString() method calling the Voice() method
        public override string ToString()
        {
            Console.WriteLine($"Animal name: {name} color is: {color}, animal birthyear is: {Birth}, species: {species}");
            return Voice();
        }
        // Method Species() for success sorting by species 
        public virtual string Species()
        {
            return species;
        }
        // Method Output_to_file() for output information about animal in .txt file
        public virtual string Output_to_file()
        {
            return ($"Animal name: {name} color is: {color}, animal birthyear is: {Birth}, species: {species}");
        }
    }

    [Serializable]
    //Define a descendant class Fish that has:
    public class Fish : Animal
    {
        //Additional fields Kind (sea or river), Species
        private string kind;
        //Additional getters and setters
        public string Kind
        { set { kind = value; }
          get { return kind;  }
        }
        //Constructor with parameters: name, birthYear, color, species
        public Fish(string fname, int fbirth, string fcolor, string fspecies) : base(fname, fbirth, fcolor)
        {
            this.name = fname;
            this.Birth = fbirth;
            this.color = fcolor;
            this.species = fspecies;
        }
        public Fish() { }
        //Overridden Move() method
        public override void Move()
        {
            Console.WriteLine("get away! fish on the wave");
        }
        //Overridden output() method
        public override void Output()
        {
            Console.WriteLine($"Fish name {name}, kind is: {kind}, his species is: {species}, animal birthyear is: {Birth}");
        }
        //Overridden input() method
        public override void Input()
        {
            Console.WriteLine($"THE Kind of {name} is: ");
            Console.WriteLine("Input kind of the fish");
            this.kind = Console.ReadLine();
        }
        // Method Kind_Out() is returning kind of fish
        public string Kind_Out()
        {
            return kind;
        }
        //Overridden Voice() method
        public override string Voice()
        {
            return ($"The {name} voice is: bul- bul- bul");
        }
        //Overridden Output_to_file() method
        public override string Output_to_file()
        {
            return ($"Fish name {name}, kind is: {kind}, his species is: {species}, animal birthyear is: {Birth}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Create a collection of animals and add some different animals and fishes to it.
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal("Tigero", 2018, "Cyan"));
            animals.Add(new Fish("Nemo", 2020, "red-blue", "Sea"));
            animals.Add(new Animal("Lione", 2021, "Silver"));
            animals.Add(new Fish("Gilly", 1998, "green-yellow", "River"));
            animals.Add(new Fish("Lolly", 2000, "White", "River"));
            Console.WriteLine("------------------------------------");
            // Input kind of fish. Exception is arising when input is empty
            Regex regex = new Regex("kind is: ,");
            foreach (var animal in animals)
            {
                if (animal is Fish)
                {
                    try
                    {
                        animal.Input();
                        MatchCollection matches = regex.Matches(animal.Output_to_file());
                        if (matches.Count > 0)
                        {
                            throw new Exception("");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"This field is empty, please write again");
                        animal.Input();
                    }
                }
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine("List before sorting:");
            foreach (var animal in animals)
            {
                animal.Output();
            }
            Console.WriteLine("------------------------------------");
            //Sort the data by Species
            animals.Sort((x, y) => x.Species().CompareTo(y.Species()));
            Console.WriteLine("List after sorting (by species):");
            foreach (var animal in animals)
            {
                animal.Output();
            }
            //Output the data about fishes elder than 3 years
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Output info about fishes elder then 3 years");
            foreach (var animal in animals)
            {
                if (animal is Fish && animal.GetAge() > 3.0)
                {
                    animal.Output();
                    animal.Voice();
                }
            }
            //Output the collection to a file
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Iformation is stored in source/repos/Serialization/bin/Debug/netcoreapp3.1/SavedAnimals.txt");
            TextWriter tw = new StreamWriter("SavedAnimals.txt");
            foreach (var animal in animals)
            {
                tw.WriteLine(animal.Output_to_file());
            }
            tw.Close();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Serialization is done. XML file URl:source/repos/Serialization/bin/Debug/netcoreapp3.1/animals.xml"); 
            // Serialization
            Animal[] animalsXML = new Animal[] { animals[0], animals[1], animals[2], animals[3], animals[4] };
            XmlSerializer formatter = new XmlSerializer(typeof(Animal[]));
            using (FileStream fs = new FileStream("animals.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, animalsXML);
            }
            //Deserealization. Implement exception handling System.InvalidOperationException: 
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Deserealized output:");
            using (FileStream fs = new FileStream("animals.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    Animal[] newAnimal = (Animal[])formatter.Deserialize(fs);
                    foreach (Animal p in newAnimal)
                    {
                        Console.WriteLine($"Name: {p.name} --- Year of birth: {p.birthYear} --- fcolor: {p.color} ---- Species: {p.species} ");
                    }
                } catch (InvalidOperationException)
                {
                    Console.WriteLine("We've catched an Exception about not workind Deserealization. Trying to fix ..");
                    try
                    {
                        using (FileStream fileStream = new FileStream("animals1.xml", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fileStream, animalsXML);

                            Animal[] newAnimal = (Animal[])formatter.Deserialize(fileStream);
                            foreach (Animal p in newAnimal)
                            {
                                Console.WriteLine($"Name: {p.name} --- Year of birth: {p.birthYear} --- fcolor: {p.color} ---- Species: {p.species} ");
                            }
                        }
                    } catch (InvalidOperationException)
                    {
                        Console.WriteLine("Try to run it again");
                    }

                }
            }
        }
    }
}