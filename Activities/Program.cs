using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivitiesBL;

namespace Activities
{
    class Program
    {
        static void Main(string[] args)
        {
            Course obj = new Course();
            obj.ConnectToDB();
            obj.ReadfromDB();
            var result = obj.ReadfromDB();
            Console.WriteLine("Courses loading:");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Batch obj1 = new Batch();
            obj1.ConnectToDB();
            obj1.ReadfromDB();
            var r1 = obj1.ReadfromDB();
            Console.WriteLine("Batch loading:");
            foreach (var item in r1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Grader obj2 = new Grader();
            obj1.ConnectToDB();
            obj1.ReadfromDB();
            Console.WriteLine("Grader loading:");
            var r2 = obj2.ReadfromDB();
            foreach (var item in r2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Faculty obj3 = new Faculty();
            obj3.ConnectToDB();
            obj3.ReadfromDB();
            Console.WriteLine("Faculty loading:");
            var r3 = obj1.ReadfromDB();
            foreach (var item in r3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Model obj4 = new Model();
            obj4.ConnectToDB();
            obj4.ReadfromDB();
            Console.WriteLine("Delivery Model loading:");
            var r4 = obj4.ReadfromDB();
            foreach (var item in r4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Participants obj5 = new Participants();
            obj5.ConnectToDB();
            obj5.ReadfromDB();
            Console.WriteLine("Participants Information:");
            var r5 = obj5.ReadfromDB();
            foreach (var item in r5)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
