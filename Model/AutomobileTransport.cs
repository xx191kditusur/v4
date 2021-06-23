namespace Model
{
    /// <summary>
    /// Класс описывающий транспортное средство (машина).
    /// </summary>
    public class AutomobileTransport : TransportBase
    {
        /// <summary>
        /// Свойство для описания названия транспортного средства.
        /// </summary>
        public override string TransportName => "Машина";

        /// <summary>
        /// Свойство для описания количества затраченного топлива.
        /// </summary>
        public override double SpendFuel => FuelConsumption * Distance;

        /// <summary>
        /// Конструктор класса машина.
        /// </summary>
        /// <param name="distance">Значение параметра пройденное
        /// растояние.</param>
        /// <param name="fuelConsumption">Значение параметра
        /// расход топлива.</param>
        public AutomobileTransport(double distance, double fuelConsumption)
        {
            Distance = distance;
            FuelConsumption = fuelConsumption;
        }

        /// <summary>
        /// Константа для описания максимального расстояния.
        /// </summary>
        public const int maxDistance = 999;

        /// <summary>
        /// Поле для описания расстояния.
        /// </summary>
        private double _distance;

        /// <summary>
        /// Свойство для описания расстояния.
        /// </summary>
        private protected double Distance
        {
            get => _distance;
            set => _distance = VerifyValue("расстояние",
                value, minValue, maxDistance);
        }
    }
}