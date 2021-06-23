namespace Model
{
    /// <summary>
    /// Класс описывающий транспортное средство (вертолёт).
    /// </summary>
    public class HelicopterTransport : TransportBase
    {
        /// <summary>
        /// Свойство для описания названия транспортного средства.
        /// </summary>
        public override string TransportName => "Вертолёт";

        /// <summary>
        /// Свойство для описания количества затраченного топлива.
        /// </summary>
        public override double SpendFuel => FuelConsumption * TimeInFly;


        /// <summary>
        /// Конструктор класса вертолёт.
        /// </summary>
        /// <param name="timeInFly">Значение параметра время полёта.</param>
        /// <param name="consumption">Значение параметра расход
        /// топлива.</param>
        public HelicopterTransport(double timeInFly, double consumption)
        {
            TimeInFly = timeInFly;
            FuelConsumption = consumption;
        }

        /// <summary>
        /// Константа для описания максимального времени полёта.
        /// </summary>
        public const int maxTimeInFly = 9999;

        /// <summary>
        /// Поле для описания времени полёта.
        /// </summary>
        private double _timeInFly;

        /// <summary>
        /// Свойство для описания времени полёта.
        /// </summary>
        private protected double TimeInFly
        {
            get => _timeInFly;
            set => _timeInFly = VerifyValue("время полёта",
                value, minValue, maxTimeInFly);
        }
    }
}