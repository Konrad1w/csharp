using System;
using System.Reflection;

class Program
{
    public static void Main(string[] args)
    {   
        //Cwiczenie 1 nie cale
        
        /*var type = Type.GetType("Cw6Refleksje.Customer");
        // var customer = Activator.CreateInstance(type);
        Console.WriteLine("Fields: ");
        var fieldsPublic = type.GetFields();
        var fieldsNotPublic= type.GetFields(BindingFlags.NonPublic|BindingFlags.Instance);
        Console.WriteLine("--Public: ");
        foreach ( var fieldPublic in fieldsPublic )
        {
            Console.WriteLine("Type: "+fieldPublic.FieldType+"; name: "+ fieldPublic.Name);
        }
        Console.WriteLine("--Non Public: ");
        foreach (var fieldNotPublic in fieldsNotPublic)
        {
            Console.WriteLine("Type: " + fieldNotPublic.FieldType + "; name: " + fieldNotPublic.Name);
        }*/

        //Cw 2 z zadania dowowego
        var type = Type.GetType("Cw6Refleksje.Customer");
        var customer = Activator.CreateInstance(type,"Adam");
        var properties=type.GetProperties();
        foreach(var property in properties)
        {
            if(property.CanWrite == true && property.PropertyType==typeof(string))
            {
                property.SetValue(customer, "some value");
            }
            else if(property.CanWrite == true && property.PropertyType==typeof(int))
            { 
                property.SetValue(customer, 0);
            }
            Console.WriteLine(property.Name+": "+property.GetValue(customer));
        }

        
    }
}