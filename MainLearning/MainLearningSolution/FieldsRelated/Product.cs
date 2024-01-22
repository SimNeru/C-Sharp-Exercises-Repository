public class Product 
{
    //FIELDS
    public int productID;
    public string productName;
    public double cost;
    public int quantityInStock;
    public static int totalNoProducts;
    public const string CategoryName = "Electronics";
    public readonly string dateOfPurchase;

    //costruttore inizializzato ogniqualvolta verrà creato un'oggetto relativo alla classe
    public Product() 
    { 
        dateOfPurchase = System.DateTime.Now.ToShortDateString(); //converte la data in mm//gg/anno
    }
}
