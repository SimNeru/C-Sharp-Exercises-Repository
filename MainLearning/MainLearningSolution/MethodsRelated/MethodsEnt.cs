public class Product
{
    private int productID;
    private string productName;
    private double cost;
    private double tax;
    private int quantityInStock;
    public static int totalNoProducts;
    public const string CategoryName = "Electronics";
    //readonly non può avere set, modificabile solo nel costruttore
    private readonly string dateOfPurchase;
    //private int numeroProva;

    public Product()
    {
        dateOfPurchase = System.DateTime.Now.ToShortDateString(); //converte la data in mm//gg/anno
    }

    //SET METHOD for ProdcutID
    //this. indica il riferimento al "campo" appartenente all'oggetto invocato di riferimento ed è presente di default
    public void SetProductID(int value) 
    { 
        this.productID = value;
    }

    //GET METHOD for ProductID
    public int GetProductID()
    {
        return productID;
    }

    //SET METHOD for ProdcutName
    public void SetProductName(string value)
    {
        productName = value;
    }

    //GET METHOD for ProductName
    public string GetProductName()
    {
        return productName;
    }

    //SET METHOD for ProdcutCost
    public void SetProductCost(double value)
    {
        cost = value;
    }

    //GET METHOD for ProductCost
    public double GetProductCost()
    {
        return cost;
    }

    //SET METHOD for ProdcutTax
    public void SetProductTax(double value)
    {
        tax = value;
    }

    //GET METHOD for ProductTax
    public double GetProductTax()
    {
        return tax;
    }

    //SET METHOD for ProdcutTax
    public void SetProductStock(int value)
    {
        quantityInStock = value;
    }

    //GET METHOD for ProductTax
    public int GetProductStock()
    {
        return quantityInStock;
    }

    //GET METHOD for ProductTax
    public string GetDateOfPurchase()
    {
        return dateOfPurchase;
    }

    public int GetNumeroProva()
    {
        return numeroProva;
    }

    /*method
    cost <= 20000 then tax = 10%
    cost > 20000 then tax = 12.5%
    il parametro del metodo è definito di default "= 4.5"
    */

    /*public void MetodoProva(int numero) 
    {
        numero = 1;

        int tot;

        tot = numero + 1;

        numeroProva = tot;
    }*/

    public void CalculateTax(double percentage = 4.5) 
    {
        //local var
        double t;

        //calculation
        if (cost <= 20000) 
        {
            t = cost * 10 / 100;
            //tax = cost + (cost * 0.1); 
        }
        else 
        { 
            t = cost * percentage / 100;
            //tax = cost + (cost * 0.12); 
        }
        tax = t;
    }
    
    //method overload
    public void CalculateTax(double cost, double percentage) 
    {
        double t;

        if (cost <= 50000)
        {
            t = cost * 5 / 100;
        }
        else
        {
            t = cost * percentage / 100;
        }
        tax = t;
    }

    //static method: SET METHOD for TotalNumberOfProducts
    public static void SetTotalNumberOfProducts(int value) 
    {
        totalNoProducts = value;
    }

    //static method: GET METHOD for TotalNumberOfProducts
    public static int GetTotalNumberOfProducts()
    {
       return totalNoProducts;
    }

    //static method: Calculates TotalQuantity
    public static int GetTotalQuantity(Product product1, Product product2, Product product3) 
    {
        int tot;
        tot = product1.GetProductStock() + product2.GetProductStock() + product3.GetProductStock();
        return tot;
    }

}
