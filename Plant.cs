using System;
using TextFile;

namespace Planet
{
    public abstract class Plant
    {
        public string Name { get; }
        public int NutrientLevel { get; protected set; }
        public string Species { get; }
        public bool IsAlive { get; protected set; }

        protected Plant(string name, int nutrientLevel, string species)
        {
            Name = name;
            NutrientLevel = nutrientLevel;
            Species = species;
            IsAlive = true;
        }

        public virtual void UpdateNutrientLevel(int amount)
        {
            NutrientLevel += amount;
            if (NutrientLevel <= 0)
            {
                NutrientLevel = 0;
                IsAlive = false;
            }
        }

        public abstract IRadiation GetRadiationDemand();
        public abstract IRadiation ApplyRadiation(IRadiation currentRadiation);
    }

    public class Wombleroot : Plant
    {
        public Wombleroot(string name, int nutrientLevel) : base(name, nutrientLevel, "Wombleroot") { }

        public override IRadiation GetRadiationDemand()
        {
            return Alpha.Instance();
        }

        public override IRadiation ApplyRadiation(IRadiation currentRadiation)
        {
            return currentRadiation.Change(this);
        }
    }

    public class Wittentoot : Plant
    {
        public Wittentoot(string name, int nutrientLevel) : base(name, nutrientLevel, "Wittentoot") { }

        public override IRadiation GetRadiationDemand()
        {
            if (NutrientLevel < 5)
            {
                return Delta.Instance();
            }
            else if (NutrientLevel >= 5 && NutrientLevel <= 10)
            {
                return Delta.Instance();
            }
            else
            {
                return NoRadiation.Instance();
            }
        }

        public override IRadiation ApplyRadiation(IRadiation currentRadiation)
        {
            return currentRadiation.Change(this);
        }
    }

    public class Woreroot : Plant
    {
        public Woreroot(string name, int nutrientLevel) : base(name, nutrientLevel, "Woreroot") { }

        public override IRadiation GetRadiationDemand()
        {
            return NoRadiation.Instance();
        }

        public override IRadiation ApplyRadiation(IRadiation currentRadiation)
        {
            return currentRadiation.Change(this);
        }
    }
}
