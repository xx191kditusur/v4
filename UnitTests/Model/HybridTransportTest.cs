using System;

using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса HybridTransport.
    /// </summary>
    [TestFixture]
    public class HybridTransportTest
    {
        /// <summary>
        /// Тестирование свойства TransportName.
        /// </summary>
        [Test(Description = "Тестирование свойства TransportName")]
        public void TestName()
        {
            Assert.AreEqual("Машина-гибрид", new HybridTransport(100, 50, 7)
                .TransportName);
            Assert.AreNotEqual("машина-гибрид", 
                new HybridTransport(100, 50, 7).TransportName);
            Assert.AreNotEqual("Машина", new HybridTransport(100, 50, 7)
                .TransportName);
            Assert.AreNotEqual("Вертолёт", new HybridTransport(100, 50, 7)
                .TransportName);
        }

        /// <summary>
        /// Тестирование свойства SpendFuel (положительное тестирование).
        /// </summary>
        /// <param name="generalDistance">Общее расстояние.</param>
        /// <param name="electricalDistance">Расстояние 
        /// на электричестве.</param>
        /// <param name="fuelConsumption">Расход топлива.</param>
        [Test]
        [TestCase(1, 1, 1, TestName = "Tест количества затраченного " +
            "топлива при минимально допустимых параметрах.")]
        [TestCase(2, 2, 2, TestName = "Tест количества затраченного " +
            "топлива при минимально допустимых параметрах +1.")]
        [TestCase(2, 2, 2, TestName = "Tест количества затраченного " +
            "топлива при минимально допустимых параметрах +1.")]
        [TestCase(50, 50, 50, TestName = "Tест количества затраченного" +
            " топлива.")]
        [TestCase(998, 997, 97, TestName = "Tест количества затраченного" +
            " топлива при максимально допустимых параметрах-1.")]
        [TestCase(999, 998, 98, TestName = "Tест количества затраченного" +
            " топлива при максимально допустимых параметрах.")]
        public void TestPosetivSpendFuel(double generalDistance,
                double electricalDistance, double fuelConsumption)
        {
            HybridTransport hybrid = new HybridTransport(generalDistance,
                electricalDistance, fuelConsumption);
            Assert.True(hybrid.SpendFuel == ((generalDistance
                - electricalDistance) * fuelConsumption));
        }

        /// <summary>
        /// Тестирование свойства SpendFuel (негативное тестирование).
        /// </summary>
        /// <param name="generalDistance">Общее расстояние.</param>
        /// <param name="electricalDistance">Расстояние 
        /// на электричестве.</param>
        /// <param name="fuelConsumption">Расход топлива.</param>
        [Test]
        [TestCase(0, 1, 1, TestName = "Tест затраченного топлива " +
            "(при недопустимом (малом) значении общего расстояния).")]
        [TestCase(1, 0, 1, TestName = "Tест затраченного топлива " +
            "(при недопустимом (малом) значении" +
            " расстояния на электричестве).")]
        [TestCase(1, 1, 0, TestName = "Tест затраченного топлива " +
            "(при недопустимом (малом) значении расхода).")]
        [TestCase(-1, -1, -1, TestName = "Tест затраченного топлива " +
            "(при отрицательных значениях).")]
        [TestCase(1000, 1, 5, TestName = "Tест затраченного топлива " +
            "(при недопустимом (большом) значении общего расстояния).")]
        [TestCase(55, 999, 8, TestName = "Tест затраченного топлива " +
            "(при недопустимом (большом) расстояния на электричестве).")]
        [TestCase(15, 14, 99, TestName = "Tест затраченного топлива " +
            "(при недопустимом (большом) значении расхода).")]

        public void TestNegotiveSpendFuel(double generalDistance,
                double electricalDistance, double fuelConsumption)
        {
            Assert.Throws<Exception>(delegate () { HybridTransport hybrid =
                new HybridTransport(generalDistance, electricalDistance,
                fuelConsumption); });
        }

        /// <summary>
        /// Тестирование свойства SpendFuel (негативное тестирование).
        /// </summary>
        /// <param name="generalDistance">Общее расстояние.</param>
        /// <param name="electricalDistance">Расстояние 
        /// на электричестве.</param>
        /// <param name="fuelConsumption">Расход топлива.</param>
        [Test]
        [TestCase(55, 55, 7, TestName = "Tест затраченного топлива" +
            " (при расстоянии на электричестве равном общему расстоянию).")]
        [TestCase(55, 56, 7, TestName = "Tест затраченного топлива" +
            " (при расстоянии на электричестве большем " +
            "чем общее расстояние).")]

        public void TestNegotive2SpendFuel(double generalDistance,
                double electricalDistance, double fuelConsumption)
        {
            HybridTransport hybrid = new HybridTransport(generalDistance,
                electricalDistance, fuelConsumption);
            Assert.True(hybrid.SpendFuel == 0);
        }
    }
}