using System;

namespace View
{
    [Serializable]
    /// <summary>
    /// Класс описывающий характеристики транспортного средства .
    /// </summary>
    public class TransportModel
    {
        /// <summary>
        /// Свойство для описания названия транспортного средства.
        /// </summary>
        public string TransportName { get; set; }

        /// <summary>
        /// Свойство для описания количества затраченного топлива.
        /// </summary>
        public double? SpendFuel { get; set; }
    }
}
