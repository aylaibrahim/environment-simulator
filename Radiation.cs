using System;

namespace Planet
{
    public interface IRadiation
    {
        IRadiation Change(Wombleroot p);
        IRadiation Change(Wittentoot p);
        IRadiation Change(Woreroot p);
    }

    public class Alpha : IRadiation
    {
        public IRadiation Change(Wombleroot p)
        {
            p.UpdateNutrientLevel(2);
            return this;
        }

        public IRadiation Change(Wittentoot p)
        {
            p.UpdateNutrientLevel(-3);
            return this;
        }

        public IRadiation Change(Woreroot p)
        {
            p.UpdateNutrientLevel(1);
            return this;
        }

        private Alpha() { }
        private static Alpha instance = new Alpha();
        public static Alpha Instance()
        {
            return instance;
        }
    }

    public class Delta : IRadiation
    {
        public IRadiation Change(Wombleroot p)
        {
            p.UpdateNutrientLevel(-2);
            return this;
        }

        public IRadiation Change(Wittentoot p)
        {
            p.UpdateNutrientLevel(4);
            return this;
        }

        public IRadiation Change(Woreroot p)
        {
            p.UpdateNutrientLevel(1);
            return this;
        }

        private Delta() { }
        private static Delta instance = new Delta();
        public static Delta Instance()
        {
            return instance;
        }
    }

    public class NoRadiation : IRadiation
    {
        public IRadiation Change(Wombleroot p)
        {
            p.UpdateNutrientLevel(-1);
            return this;
        }

        public IRadiation Change(Wittentoot p)
        {
            p.UpdateNutrientLevel(-1);
            return this;
        }

        public IRadiation Change(Woreroot p)
        {
            p.UpdateNutrientLevel(-1);
            return this;
        }

        private NoRadiation() { }
        private static NoRadiation instance = new NoRadiation();
        public static NoRadiation Instance()
        {
            return instance;
        }
    }
}
