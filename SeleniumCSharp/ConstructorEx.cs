using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp
{
    public class ConstructorEx
    {
        String name;
        String firstName, lastName;
        public ConstructorEx()
        {

        }
        public ConstructorEx(String name)
        {
            this.name= name;
        }
        public ConstructorEx(String firstName, String LastName)
        {
            this.firstName = firstName;
            this.lastName = LastName;   
        }

        public void getName() {
            Console.WriteLine("My name is " +name);
            Console.WriteLine("My firstName is " + firstName);
            Console.WriteLine("My lastName is " + lastName);
        }
        public static void Main(string[] args) {
            ConstructorEx constructorEx = new ConstructorEx("Bhavani");
            ConstructorEx constructorEx1 = new ConstructorEx("Akhila", "Alimela");

            constructorEx.getName();
            constructorEx1.getName();
        }
        
    }
    
}
