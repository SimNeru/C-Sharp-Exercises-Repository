using System;

//Enumeration sono utili quando abbiamo un range specifico da rientrare (es. giorni settimana)

class Program
{
    static void Main()
    {
        Person person = new Person();
        person.PersonName = "Bob";
        person.Email = "bobs@mail.com";
        person.AgeGroup = Person.AgeGroupEnumeration.Adult;

        Console.WriteLine($"USER: {person.PersonName}\nEMAIL: {person.Email}\nAGE: {person.AgeGroup}");

        Console.ReadKey();
    }
}
