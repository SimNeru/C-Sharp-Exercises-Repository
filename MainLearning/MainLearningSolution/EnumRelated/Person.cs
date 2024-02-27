public class Person
{
    public string PersonName { get; set; }
    public string Email { get; set; }
    public AgeGroupEnumeration AgeGroup { get; set; }

    //si possono anche assegnare dei numeri e si può cambiare il datatype
    public enum AgeGroupEnumeration : short //solo alcuni sono concessi
    { 
        Child,
        Teenager,
        Adult = 100,
        Senior
    }
}
