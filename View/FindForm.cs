using System;
using System.Windows.Forms;

namespace View
{    /// <summary>
     /// Класс поиска информации.
     /// </summary>
    public partial class FindForm : Form
    {
        /// <summary>
        /// Делегат поиска транспортного средства.
        /// </summary>
        private readonly SearchDelegate _searchDelegate = null;

        /// <summary>
        /// Конструктор класса FindForm.
        /// </summary>
        /// <param name="searchDelegate">Делегат поиска 
        /// транспортного средства.</param>
        public FindForm(SearchDelegate searchDelegate)
        {
            InitializeComponent();
            _searchDelegate = searchDelegate;
            SpendFuelTextBox.KeyPress += Verify.VerifyValue;
            TransportNameComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Событие при смене названия типа транспортного средства.
        /// </summary>
        private void TransportNameComboBox_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            SpendFuelTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Событие при нажатии на кнопку найти.
        /// </summary>
        private void FindButton_Click(object sender, EventArgs e)
        {
            Hide();
            TransportModel transportModel = new TransportModel
            {
                TransportName = TransportNameComboBox.Text.ToString()
            };
            if (!string.IsNullOrEmpty(SpendFuelTextBox.Text))
                transportModel.SpendFuel = Convert
                        .ToDouble(SpendFuelTextBox.Text);
            else
                transportModel.SpendFuel = null;
            _searchDelegate(transportModel);
        }

        /// <summary>
        /// Событие при нажатии на кнопку отмена.
        /// </summary>
        private void ExitFindButton_Click(object sender, EventArgs e)
        {
            Hide();
            TransportModel transportModel = new TransportModel
            {
                TransportName = "",
                SpendFuel = null
            };
            _searchDelegate(transportModel);
        }
    }
}