using System;
using System.Collections.Generic;


class CoffeeMachine
{
    private bool _isOn;
    public Coffee ActualCoffee;
    public int Id;
    private List<Type> Coffeetype;
    public CoffeeMachine()
    {
        Coffeetype  = new List<Type>()
        {
            typeof(Americano),
            typeof(Espresso),
            typeof(Cappuccino),
        };
    }
    public CreateCoffee(string coffeeName, int milkVolume, int shugarVolume, int cinamoonVolume)
    {
        Coffee coffee = null;

        List<Coffee> coffeeInstances = new List<Coffee>
        {
            new Americano(),
            new Espresso(),
            new Cappuccino()
        };

        foreach (Coffee tempCoffee in coffeeInstances)
        {
            if (tempCoffee.Name == coffeeName)
            {
                coffee = tempCoffee;
                break;
            }
        }
        Console.WriteLine("Invalid coffee name. Please try again.");
        return null;
    }  
    public void On()
    {
        _isOn = true;
    }
    public void Off()
    {
        _isOn = false;
    }

    public Additionals ChooseAdditionals(int milkVolume, int shugarVolume, int cinamoonVolume)
    {
        if (ActualCoffee != null)
        {
            ActualCoffee.Addition.MilkVolume += milkVolume;
            ActualCoffee.Addition.SugarVolume += sugarVolume;
            ActualCoffee.Addition.CinnamonVolume += cinnamonVolume;
        }
        else
        {
            Console.WriteLine("No coffee has been created yet. Please create a coffee first.");
        }
    }
    public void GetCoffeeInfo(List<Coffee> coffees)
    {
        foreach (Coffee coffeeInfo in Coffeetype)
        {
            Console.WriteLine($"Name : {coffee.Name} \nCost : {coffee.Cost}\nMinimal Additions {coffee.MinimalAddition}");
        }
    }

}
abstract class Coffee
{
    public abstract string Name { get; }
    public abstract int Cost { get; }
    public abstract Additionals Addition { get ; }
    public abstract void ToServe();
}

class Americano : Coffee
{
    public static string StaticName => "Americano";
    public static int StaticCost => 100;
    public static Additionals StaticAddition => new Additionals(0, 0, 10);
    public override string Name => StaticName;
    public override int Cost => StaticCost;
    public override Additionals Addition => StaticAddition;

    public override void ToServe()
    {
        Console.WriteLine("Americano is Ready");
    }
}

class Espresso : Coffee
{
    public static string StaticName => "Espresso";
    public static int StaticCost => 200;
    public static Additionals StaticAddition => new Additionals(0, 10, 0);
    public override string Name => StaticName;
    public override int Cost => StaticCost;
    public override Additionals Addition => StaticAddition;

    public override void ToServe()
    {
        Console.WriteLine("Espresso is Ready");
    }
}

class Cappuccino : Coffee
{
    public static string StaticName => "Espresso";
    public static int StaticCost => 300;
    public static Additionals StaticAddition => new Additionals(10, 0, 0);
    public override string Name => StaticName;
    public override int Cost => StaticCost;
    public override Additionals Addition => StaticAddition;

    public override void ToServe()
    {
        Console.WriteLine("Cappuccino is Ready");
    }
}

class Additionals
{
    public int MilkVolume { get ; set; }
    public int ShugarVolume { get ; set; }
    public int CinamoonVolume { get ; set; }

    public Additionals(int milkVoulme, int shugarVolume,int cinamoonVolume)
    {
        MilkVolume = milkVoulme;
        ShugarVolume = shugarVolume;
        CinamoonVolume = cinamoonVolume;
    }
}

