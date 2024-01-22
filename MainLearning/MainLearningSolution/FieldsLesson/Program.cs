using System;

/*
 * ::ASSEMBLY::
 * ONE ASSEMBLY FOR ONE PROJECT, ogni progetto in una soluzione 
 * compone un singolo ASSEMBLY con i file al suo interno 
 */

class Fields 
{ 
    public static void Main() 
    {
        //local constant
        const string developerName = "Simone";

        //create PRODUCT objects from Product class in library project FieldsRelated
        Product product1 = new Product();
        Product.totalNoProducts++; //1
        Product product2, product3;
        product2 = new Product(); //2
        Product.totalNoProducts++;
        product3 = new Product(); //3
        Product.totalNoProducts++;

        //questi oggetti avranno ciascuno la loro allocazione nella memoria HEAP

        //inizializzo i FIELDS
        product1.productID = 1001;
        product1.productName = "Mobile";
        product1.cost = 1200;
        product1.quantityInStock = 100;

        product2.productID = 1002;
        product2.productName = "Laptop";
        product2.cost = 2400;
        product2.quantityInStock = 50;

        product3.productID = 1003;
        product3.productName = "Speaker";
        product3.cost = 120;
        product3.quantityInStock = 75;

        //ottieni i valori contenuti nei FIELD
        System.Console.WriteLine(developerName);

        System.Console.WriteLine(":::PRODUCT1:::");
        System.Console.WriteLine($"Category: {Product.CategoryName}");
        System.Console.WriteLine($"Product ID: {product1.productID}");
        System.Console.WriteLine($"Product NAME: {product1.productName}");
        System.Console.WriteLine($"Product COST: {product1.cost}");
        System.Console.WriteLine($"Product QUANTITY: {product1.quantityInStock}\n ");

        System.Console.WriteLine(":::PRODUCT2:::");
        System.Console.WriteLine($"Category: {Product.CategoryName}");
        System.Console.WriteLine($"Product ID: {product2.productID}");
        System.Console.WriteLine($"Product NAME: {product2.productName}");
        System.Console.WriteLine($"Product COST: {product2.cost}");
        System.Console.WriteLine($"Product QUANTITY: {product2.quantityInStock}\n ");

        System.Console.WriteLine(":::PRODUCT3:::");
        System.Console.WriteLine($"Category: {Product.CategoryName}");
        System.Console.WriteLine($"Product ID: {product3.productID}");
        System.Console.WriteLine($"Product NAME: {product3.productName}");
        System.Console.WriteLine($"Product COST: {product3.cost}");
        System.Console.WriteLine($"Product QUANTITY: {product3.quantityInStock}\n ");

        System.Console.WriteLine($":::Total no. of products: {Product.totalNoProducts}:::");
        Console.ReadKey();
    }
}