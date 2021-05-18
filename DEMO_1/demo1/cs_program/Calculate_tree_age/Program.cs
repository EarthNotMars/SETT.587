using System;

namespace Calculate_tree_age
{
    class Program
    {
        static void Main(string[] args)
        {
            int treeType;

            float girth;

            double radius;

            Console.WriteLine("Calculate an age of tree in minute ");

            Console.WriteLine("-----------------------------------");

            Console.WriteLine("Choose tree type from the list below:");
            Console.WriteLine("id: 1 - Pine " +

                "id: 2 - Oak " +

                "id: 3 - Maple" +

                "id: 4 - Birch " +

                "id: 5 - Tree ");

        

            treeType = int.Parse(Console.ReadLine());

            Console.WriteLine("Specify the girth of the trunk (e.g: 5,56) at levels 1 - 1.5 m above the ground");

            girth = float.Parse(Console.ReadLine());

            if (girth == 0)

            {

                treeType = 0;

            }

            radius = (girth / 3.14) / 2;

            switch (treeType)

            {

                case 0:

                    Console.WriteLine("Invalid input");

                    break;


                case 1:

                    Console.WriteLine("The Pine age is:" + " " + (radius - 0.02) / 0.015 + " years");

                    break;

                case 2:

                    Console.WriteLine("The Oak age is" + " " + (radius - 0.02) / 0.015 + " years");

                    break;

                case 3:

                    Console.WriteLine("The Maple age is" + " " + (radius - 0.01) / 0.015 + " years");

                    break;

                case 4:

                    Console.WriteLine("The Birch age is" + " " + (radius - 0.01) / 0.015 + " years");

                    break;

                case 5:

                    Console.WriteLine("The Tree age is" + " " + (radius - 0.01) / 0.015 + "  years");

                    break;

                default:

                    Console.WriteLine("Type is undefined");

                    break;

            }
        }
    }
}
