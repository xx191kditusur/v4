namespace Model
{
    /// <summary>
    /// Класс описывающий транспортное средство (машина-гибрид).
    /// </summary>
    public class HybridTransport : TransportBase
    {
        /// <summary>
        /// Свойство для описания названия транспортного средства.
        /// </summary>
        public override string TransportName => "Машина-гибрид";

        /// <summary>
        /// Свойство для описания количества затраченного топлива.
        /// </summary>
        public override double SpendFuel => GetSpendFuel();

        /// <summary>
        /// Конструктор класса машина-гибрид.
        /// </summary>
        /// <param name="generalDistance">Значение параметра общее
        /// расстояние.</param>
        /// <param name="electricalDistance">Значение параметра пройденное
        /// расстояние на электричестве.</param>
        /// <param name="fuelConsumption">Значение параметра расход
        /// топлива.</param>
        public HybridTransport(double generalDistance,
                double electricalDistance, double fuelConsumption)
        {
            GeneralDistance = generalDistance;
            ElectricalDistance = electricalDistance;
            FuelConsumption = fuelConsumption;
        }

        /// <summary>
        /// Константа для описания максимального расстояния.
        /// </summary>
        public const int maxGeneralDistance = 1000;

        /// <summary>
        /// Поле для описания общего расстояния.
        /// </summary>
        private double _generalDistance;

        /// <summary>
        /// Свойство для описания общего пройденного расстояния.
        /// </summary>
        private protected double GeneralDistance
        {
            get => _generalDistance;
            set => _generalDistance = VerifyValue("общее расстояние",
                value, minValue, maxGeneralDistance);
        }

        /// <summary>
        /// Константа для описания максимального пройденного
        /// расстояния на электричестве.
        /// </summary>
        public const int maxElectricalDistance = 999;

        /// <summary>
        /// Поле для описания пройденного расстояния на электричестве.
        /// </summary>
        private double _electricalDistance;

        /// <summary>
        /// Свойство для описания пройденного расстояния на электричестве.
        /// </summary>
        private protected double ElectricalDistance
        {
            get => _electricalDistance;
            set => _electricalDistance = VerifyValue("расстояние на" +
                " электрическом двигателе",
                value, minValue, maxElectricalDistance);
        }

        /// <summary>
        /// Метод вычисления затраченного топлива.
        /// </summary>
        /// <returns>Количество затраченного топлива.</returns>
        private double GetSpendFuel()
        {
            if (GeneralDistance > ElectricalDistance)
                return (GeneralDistance - ElectricalDistance)
                    * FuelConsumption;
            else
                return 0;
        }
    }
}