using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planet;
using System.Collections.Generic;
using System.Numerics;

namespace PlantTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UpdateNutrientLevel_Wombleroot_Alpha()
        {
            Plant plant = new Wombleroot("Hungry", 7);
            plant.UpdateNutrientLevel(2);
            Assert.AreEqual(9, plant.NutrientLevel);
        }

        [TestMethod]
        public void UpdateNutrientLevel_Wittentoot_Alpha()
        {
            Plant plant = new Wittentoot("Lanky", 5);
            plant.UpdateNutrientLevel(-3);
            Assert.AreEqual(2, plant.NutrientLevel);
        }

        [TestMethod]
        public void UpdateNutrientLevel_Woreroot_Alpha()
        {
            Plant plant = new Woreroot("Big", 4);
            plant.UpdateNutrientLevel(1);
            Assert.AreEqual(5, plant.NutrientLevel);
        }

        [TestMethod]
        public void UpdateNutrientLevel_Wittentoot_Delta()
        {
            Plant plant = new Wittentoot("Short", 8);
            plant.UpdateNutrientLevel(4);
            Assert.AreEqual(12, plant.NutrientLevel);
        }

        [TestMethod]
        public void UpdateNutrientLevel_Woreroot_Delta()
        {
            Plant plant = new Woreroot("Random1", 2);
            plant.UpdateNutrientLevel(1);
            Assert.AreEqual(3, plant.NutrientLevel);
        }

        [TestMethod]
        public void Withered_PlantWithNegativeNutrientLevel_ReturnsTrue()
        {
            Plant plant = new Woreroot("Random2", -3);
            
        }
    }
}
