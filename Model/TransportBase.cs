using System;

namespace Model
{
    /// <summary>
    /// Абстрактный класс описывающий базовое транспортное средство.
    /// </summary>
    public abstract class TransportBase
    {
        /// <summary>
        /// Свойство для описания названия транспортного средства.
        /// </summary>
        public abstract string TransportName { get; }

        /// <summary>
        /// Свойство для описания количества затраченного топлива.
        /// </summary>
        public abstract double SpendFuel { get; }

        /// <summary>
        /// Константа для описания минимального значения параметра.
        /// </summary>
        public const int minValue = 0;

        /// <summary>
        /// Константа для описания максимального расхода топлива.
        /// </summary>
        public const int maxFuelConsumption = 99;

        /// <summary>
        /// Поле для описания расхода.
        /// </summary>
        private double _fuelConsumption;

        /// <summary>
        /// Свойство для описания расхода.
        /// </summary>
        private protected double FuelConsumption
        {
            get => _fuelConsumption;
            set => _fuelConsumption = VerifyValue("расход топлива",
                value, minValue, maxFuelConsumption);
        }

        /// <summary>
        /// Метод проверки правильности ввода значений.
        /// </summary>
        /// <param name="parametrName">Название параметра.</param>
        /// <param name="parametrValue">Значение параметра.</param>
        /// <param name="minValue">Минимальное значение.</param>
        /// <param name="maxValue">Максимальное значение.</param>
        /// <returns>Результат проверки.</returns>
        public static double VerifyValue(string parametrName,
            double parametrValue, double minValue, double maxValue)
        {
            if ((parametrValue > minValue) && (parametrValue < maxValue))
            {
                return parametrValue;
            }
            else
            {
                throw new Exception($"Значение поля {parametrName}" +
                    $" должно быть больше чем {minValue} и меньше" +
                    $" чем {maxValue}.");
            }
        }
    }
}