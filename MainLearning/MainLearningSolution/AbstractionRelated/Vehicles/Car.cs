using System;
using AbstractionRelated;

public abstract class Car : IVehicle
{
    public abstract void ChangeGear();

    public void RequiredLicense()
    {
        Console.WriteLine("YES, TYPE B");
    }

    public void TypeOf()
    {
        Console.WriteLine("LAND");
    }

    public void VehicleClassification()
    {
        Console.WriteLine("MOTOR VEHICLE");
    }
}

