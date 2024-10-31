namespace ViewsExaple.Models
{
    /* Classe Wrapper per poter richiamare entrambe le classi come strongly typed views
     */
    public class PersonProductWrapper
    {
        public Person? PersonData { get; set; }
        public Product? ProductData { get; set; }
    }
}
