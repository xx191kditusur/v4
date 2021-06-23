using System;

using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса AutomobileTransport.
    /// </summary>
    [TestFixture]
    public class AutomobileTransportTest
    {
        /// <summary>
        /// Тестирование свойства TransportName.
        /// </summary>
        [Test(Description = "Тестирование свойства TransportName")]
        public void TestName()
        {
            Assert.AreEqual("Машина", new AutomobileTransport(5, 5)
                .TransportName);
            Assert.AreNotEqual("машина", new AutomobileTransport(5, 5)
                .TransportName);
            Assert.AreNotEqual("Машина-гибрид", 
                new AutomobileTransport(5, 5).TransportName);
            Assert.AreNotEqual("Вертолёт", new AutomobileTransport(5, 5)
                .TransportName);
        }

        /// <summary>
        /// Тестирование свойства SpendFuel (положительное тестирование).
        /// </summary>
        /// <param name="distance">Расстояние.</param>
        /// <param name="fuelConsumption">Расход.</param>
        [Test]
        [TestCase(1, 1, TestName = "Tест количества затраченного топлива " +
            "при минимально допустимых параметрах.")]
        [TestCase(2, 2, TestName = "Tест количества затраченного топлива " +
            "при минимально допустимых параметрах +1.")]
        [TestCase(50, 50, TestName = "Tест количества затраченного" +
            " топлива.")]
        [TestCase(997, 97, TestName = "Tест количества затраченного " +
            "топлива при максимально допустимых параметрах -1.")]
        [TestCase(998, 98, TestName = "Tест количества затраченного " +
            "топлива при максимально допустимых параметрах.")]
        public void TestPosetivSpendFuel(double distance,
            double fuelConsumption)
        {
            AutomobileTransport auto = new AutomobileTransport(distance,
                fuelConsumption);
            Assert.True(auto.SpendFuel == (distance * fuelConsumption));
            Assert.AreEqual(distance, fuelConsumption, distance
                * fuelConsumption);
        }

        /// <summary>
        /// Тестирование свойства SpendFuel (негативное тестирование).
        /// </summary>
        /// <param name="distance">Расстояние.</param>
        /// <param name="fuelConsumption">Расход.</param>
        [Test]
        [TestCase(0, 1, TestName = "Tест затраченного топлива " +
            "(при недопустимом (малом) значении расстояния).")]
        [TestCase(1, 0, TestName = "Tест затраченного топлива " +
            "(при недопустимом (малом) значении расхода).")]
        [TestCase(-1, -1, TestName = "Tест затраченного топлива " +
            "(при отрицательных значениях).")]
        [TestCase(999, 1, TestName = "Tест затраченного топлива " +
            "(при недопустимом (большом) значении расстояния).")]
        [TestCase(1, 99, TestName = "Tест затраченного топлива " +
            "(при недопустимом (большом) значении расхода).")]
        public void TestNegotiveSpendFuel(double distance,
            double fuelConsumption)
        {
            Assert.Throws<Exception>(delegate () { 
                AutomobileTransport auto = new AutomobileTransport(distance,
                    fuelConsumption); });
        }
    }
}