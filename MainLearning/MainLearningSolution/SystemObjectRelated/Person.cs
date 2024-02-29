public class Person
{
    //properties
    public string PersonName { get; set; }
    public string Email { get; set; }

    //overriding Equals method
    public override bool Equals(object? obj)
    {
        Person p = (Person)obj;
        if (this.PersonName == p.PersonName && this.Email == p.Email)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    //overriding ToString method
    public override string ToString()
    {
        return $"\nName: {this.PersonName}\nEmail: {this.Email}";
    }
}
