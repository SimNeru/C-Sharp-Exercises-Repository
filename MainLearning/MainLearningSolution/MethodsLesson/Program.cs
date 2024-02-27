using System;

class MethodsLesson
{
    public static void Main()
    {
        const string developerName = "Sim";

        Product product1 = new Product();
        Product.SetTotalNumberOfProducts(Product.GetTotalNumberOfProducts()+1); //1
        Product product2, product3;
        product2 = new Product();
        Product.SetTotalNumberOfProducts(Product.GetTotalNumberOfProducts()+1); //2
        product3 = new Product();
        Product.SetTotalNumberOfProducts(Product.GetTotalNumberOfProducts()+1); //3
        //architettura di programmazione astrazione

        product1.SetProductID(1001);
        product1.SetProductName("Mobile");
        product1.SetProductCost(20000);
        product1.SetProductStock(100);

        product2.SetProductID(1002);
        product2.SetProductName("Laptop");
        product2.SetProductCost(45000);
        product2.SetProductStock(50);

        product3.SetProductID(1003);
        product3.SetProductName("Speaker");
        product3.SetProductCost(36000);
        product3.SetProductStock(75);

        //call methods with named arguments
        System.Console.WriteLine("..Calling methods..");
        product1.CalculateTax(percentage:9.2);
        var p = 7.4;
        product2.CalculateTax(p);
        Console.WriteLine("p is:" + p);
        product3.CalculateTax(cost: 10000, percentage: 3.4);  

        /*var numero = 4;
        product1.MetodoProva(numero);
        Console.WriteLine("totale is:" + numero);
        Console.WriteLine("numeroProva è:" + product1.GetNumeroProva());*/

        Console.ReadKey();

        System.Console.WriteLine(developerName);

        System.Console.WriteLine(":::PRODUCT1:::");
        System.Console.WriteLine($"Category: {Product.CategoryName}");
        System.Console.WriteLine($"Product ID: {product1.GetProductID()}");
        System.Console.WriteLine($"Product NAME: {product1.GetProductName()}");
        System.Console.WriteLine($"Product COST: {product1.GetProductCost()}");
        System.Console.WriteLine($"Product TAX: {product1.GetProductTax()}");
        System.Console.WriteLine($"Product QUANTITY: {product1.GetProductStock()}");
        System.Console.WriteLine($"Date of purchase: {product1.GetDateOfPurchase()}\n");

        System.Console.WriteLine(":::PRODUCT2:::");
        System.Console.WriteLine($"Category: {Product.CategoryName}");
        System.Console.WriteLine($"Product ID: {product2.GetProductID()}");
        System.Console.WriteLine($"Product NAME: {product2.GetProductName()}");
        System.Console.WriteLine($"Product COST: {product2.GetProductCost()}");
        System.Console.WriteLine($"Product TAX: {product2.GetProductTax()}");
        System.Console.WriteLine($"Product QUANTITY: {product2.GetProductStock()}");
        System.Console.WriteLine($"Date of purchase: {product2.GetDateOfPurchase()}\n");

        System.Console.WriteLine(":::PRODUCT3:::");
        System.Console.WriteLine($"Category: {Product.CategoryName}");
        System.Console.WriteLine($"Product ID: {product3.GetProductID()}");
        System.Console.WriteLine($"Product NAME: {product3.GetProductName()}");
        System.Console.WriteLine($"Product COST: {product3.GetProductCost()}");
        System.Console.WriteLine($"Product TAX: {product3.GetProductTax()}");
        System.Console.WriteLine($"Product QUANTITY: {product3.GetProductStock()}");
        System.Console.WriteLine($"Date of purchase: {product3.GetDateOfPurchase()}\n");

        //Total Quantity
        int totalQuantity = Product.GetTotalQuantity(product1,product2,product3);

        System.Console.WriteLine($":::Total no. of products: {totalQuantity}:::");
        Console.ReadKey();
    }
}
