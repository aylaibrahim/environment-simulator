using System;
using System.Collections.Generic;
using System.IO;
using TextFile;

namespace Planet
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter filename please:");
            string filename = Console.ReadLine();

            if (filename == null)
            {
                Console.WriteLine("No filename entered.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);

            int numPlants = int.Parse(lines[0]);
            List<Plant> plants = new List<Plant>();

            for (int i = 1; i <= numPlants; i++)
            {
                string[] plantData = lines[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string name = plantData[0];
                string species = plantData[1];
                int nutrientLevel = int.Parse(plantData[2]);

                switch (species)
                {
                    case "wom":
                        plants.Add(new Wombleroot(name, nutrientLevel));
                        break;
                    case "wit":
                        plants.Add(new Wittentoot(name, nutrientLevel));
                        break;
                    case "wor":
                        plants.Add(new Woreroot(name, nutrientLevel));
                        break;
                    default:
                        throw new ArgumentException("No such species!");
                }
            }

            int numDays = int.Parse(lines[numPlants + 1]);

            IRadiation currentRadiation = NoRadiation.Instance();

            for (int day = 1; day <= numDays; day++)
            {
                int alphaDemand = 0;
                int deltaDemand = 0;

                Console.WriteLine($"Day {day}:");

                foreach (Plant plant in plants)
                {
                    if (plant.IsAlive)
                    {
                        currentRadiation = plant.ApplyRadiation(currentRadiation);
                        IRadiation demand = plant.GetRadiationDemand();
                        if (demand is Alpha)
                        {
                            alphaDemand += 10;
                        }
                        else if (demand is Delta)
                        {
                            deltaDemand += (plant is Wittentoot && plant.NutrientLevel < 5) ? 4 : 1;
                        }

                        Console.WriteLine($"{plant.Name} {plant.Species} [nutrient level: {plant.NutrientLevel}, radiation: {currentRadiation.GetType().Name}]");
                    }
                }

                if (alphaDemand >= deltaDemand + 3)
                {
                    currentRadiation = Alpha.Instance();
                }
                else if (deltaDemand >= alphaDemand + 3)
                {
                    currentRadiation = Delta.Instance();
                }
                else
                {
                    currentRadiation = NoRadiation.Instance();
                }

                Console.WriteLine();
            }

            Plant strongestPlant = null;

            foreach (Plant plant in plants)
            {
                if (plant.IsAlive && (strongestPlant == null || plant.NutrientLevel > strongestPlant.NutrientLevel))
                {
                    strongestPlant = plant;
                }
            }

            Console.WriteLine("Strongest plant still alive:");
            if (strongestPlant != null)
            {
                Console.WriteLine($"{strongestPlant.Name} {strongestPlant.Species} with nutrient level {strongestPlant.NutrientLevel}");
            }
            else
            {
                Console.WriteLine("No plants alive. :(");
            }
        }
    }
}
