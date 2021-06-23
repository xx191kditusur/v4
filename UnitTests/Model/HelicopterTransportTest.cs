using System;

using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса HelicopterTransport.
    /// </summary>
    [TestFixture]
    public class HelicopterTransportTest
    {
        /// <summary>
        /// Тестирование свойства TransportName.
        /// </summary>
        [Test(Description = "Тестирование свойства TransportName")]
        public void TestName()
        {
            Assert.AreEqual("Вертолёт", new HelicopterTransport(5, 5)
                .TransportName);
            Assert.AreNotEqual("вертолёт", new HelicopterTransport(5, 5)
                .TransportName);
            Assert.AreNotEqual("Машина-гибрид", 
                new HelicopterTransport(5, 5).TransportName);
            Assert.AreNotEqual("Машина", new HelicopterTransport(5, 5)
                .TransportName);
        }

        /// <summary>
        /// Тестирование свойства SpendFuel (положительное тестирование).
        /// </summary>
        /// <param name="timeInFly">Значение параметра время полёта.</param>
        /// <param name="consumption">Значение параметра расход.</param>
        [Test]
        [TestCase(1, 1, TestName = "Tест количества затраченного топлива" +
            " при минимально допустимых параметрах.")]
        [TestCase(2, 2, TestName = "Tест количества затраченного топлива" +
            " при минимально допустимых параметрах +1.")]
        [TestCase(50, 50, TestName = "Tест количества " +
            "затраченного топлива.")]
        [TestCase(9997, 97, TestName = "Tест количества затраченного" +
            " топлива при максимально допустимых параметрах -1.")]
        [TestCase(9998, 98, TestName = "Tест количества затраченного" +
            " топлива при максимально допустимых параметрах.")]
        public void TestPosetivSpendFuel(double timeInFly,
            double consumption)
        {
            HelicopterTransport auto = new HelicopterTransport(timeInFly,
                consumption);
            Assert.True(auto.SpendFuel == (timeInFly * consumption));
            Assert.AreEqual(timeInFly, consumption,
                timeInFly * consumption);
        }

        /// <summary>
        /// Тестирование свойства SpendFuel (негативное тестирование).
        /// </summary>
        /// <param name="timeInFly">Значение параметра время полёта.</param>
        /// <param name="consumption">Значение параметра расход.</param>
        [Test]
        [TestCase(0, 1, TestName = "Tест затраченного топлива " +
            "(при недопустимом (малом) значении времени полёта).")]
        [TestCase(1, 0, TestName = "Tест затраченного топлива " +
            "(при недопустимом (малом) значении расхода).")]
        [TestCase(-1, -1, TestName = "Tест затраченного топлива " +
            "(при отрицательных значениях).")]
        [TestCase(9999, 1, TestName = "Tест затраченного топлива" +
            " (при недопустимом (большом) значении времени полёта).")]
        [TestCase(1, 99, TestName = "Tест затраченного топлива" +
            " (при недопустимом (большом) значении расхода).")]
        public void TestNegotiveSpendFuel(double timeInFly,
            double consumption)
        {
            Assert.Throws<Exception>(delegate () { 
                HelicopterTransport auto = new HelicopterTransport(timeInFly,
                    consumption); });
        }
    }
}