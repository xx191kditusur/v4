#define Debug
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using Model;

namespace View
{
    /// <summary>
    ///  Класс добавления информации.
    /// </summary>
    public partial class AddForm : Form
    {
        /// <summary>
        /// Коллекция, хранящая информацию о транспорте. 
        /// </summary>
        private readonly List<TransportModel> _transportModels;

        /// <summary>
        /// Делегат обновления данных в DataGridView.
        /// </summary>
        private readonly UpdateInformation _updateInformation;

        public AddForm(List<TransportModel> transportModels,
            UpdateInformation updateInformation)
        {
            InitializeComponent();
            _transportModels = transportModels;
            _updateInformation = updateInformation;
            TransportNameComboBox.SelectedIndex = 0;
#if Release
            this.RandomValueButton.Visible = false;
#elif Debug
            this.RandomValueButton.Visible = true;
#endif
        }

        /// <summary>
        /// Событие выбора транспорта из выпадающего списка.
        /// </summary>
        private void TransportNameComboBox_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            AddTextBox1.Text = string.Empty;
            AddTextBox2.Text = string.Empty;
            AddTextBox3.Text = string.Empty;

            switch (TransportNameComboBox.SelectedIndex)
            {
                case 0:
                    AddLabel1.Visible = true;
                    AddLabel2.Visible = true;
                    AddLabel3.Visible = false;

                    AddLabel1.Text = "Расход топлива";
                    AddLabel2.Text = "Расстояние";

                    AddTextBox1.Visible = true;
                    AddTextBox2.Visible = true;
                    AddTextBox3.Visible = false;
                    break;
                case 1:
                    AddLabel1.Visible = true;
                    AddLabel2.Visible = true;
                    AddLabel3.Visible = true;

                    AddLabel1.Text = "Расход топлива";
                    AddLabel2.Text = "Общее расстояние";
                    AddLabel3.Text = "Расстояние на электродвигателе";

                    AddTextBox1.Visible = true;
                    AddTextBox2.Visible = true;
                    AddTextBox3.Visible = true;

                    break;
                case 2:
                    AddLabel1.Visible = true;
                    AddLabel2.Visible = true;
                    AddLabel3.Visible = false;

                    AddLabel1.Text = "Расход топлива";
                    AddLabel2.Text = "Время полёта";

                    AddTextBox1.Visible = true;
                    AddTextBox2.Visible = true;
                    AddTextBox3.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Событие при загрузке формы AddForm.
        /// </summary>
        private void AddForm_Load(object sender, EventArgs e)
        {
            TransportNameComboBox_SelectedIndexChanged(sender, e);

            AddTextBox1.KeyPress += Verify.VerifyValue;
            AddTextBox2.KeyPress += Verify.VerifyValue;
            AddTextBox3.KeyPress += Verify.VerifyValue;
        }

        /// <summary>
        /// Событие при нажатии на кнопку отмена.
        /// </summary>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Hide();
            if (_transportModels.Count > 0)
                _updateInformation();
        }

        /// <summary>
        /// Событие при нажатии на кнопку OK
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            try
            {
                switch (TransportNameComboBox.SelectedIndex)
                {
                    case 0:
                        if (AddTextBox1.Text == string.Empty)
                        {
                            message += "Необходимо ввести " +
                                "расход машины.\n";
                        }
                        if (AddTextBox2.Text == string.Empty)
                        {
                            message += "Необходимо ввести " +
                                "расстояние пройденное машиной.\n";
                        }
                        if (message == string.Empty)
                        {
                            TransportBase automobile =
                                new AutomobileTransport(Convert
                                .ToDouble(AddTextBox2.Text),
                                Convert.ToDouble(AddTextBox1.Text));
                            AddTransport(automobile);
                        }
                        break;
                    case 1:
                        if (AddTextBox1.Text == string.Empty)
                        {
                            message += "Необходимо ввести " +
                                "расход машины-гибрида.\n";
                        }
                        if (AddTextBox2.Text == string.Empty)
                        {
                            message += "Необходимо ввести " +
                                "общее расстояние пройдённое " +
                                "машиной-гибридом.\n";
                        }
                        if (AddTextBox3.Text == string.Empty)
                        {
                            message += "Необходимо ввести " +
                                "расстояние пройденное машиной-гибридом " +
                                "на электрическом двигателе.\n";
                        }
                        if (Convert.ToDouble(AddTextBox2.Text)
                            < Convert.ToDouble(AddTextBox3.Text))
                        {
                            message += "Общее расстояние должно " +
                                "быть больше или равно " +
                                "расстоянию пройденному " +
                                "на электрическом двигателе.\n";
                        }
                        if (message == string.Empty)
                        {
                            TransportBase hybrid = new HybridTransport(
                                Convert.ToDouble(AddTextBox2.Text),
                                Convert.ToDouble(AddTextBox3.Text),
                                Convert.ToDouble(AddTextBox1.Text));
                            AddTransport(hybrid);
                        }
                        break;
                    case 2:
                        if (AddTextBox1.Text == string.Empty)
                        {
                            message += "Необходимо ввести " +
                                "расход вертолёта.\n";
                        }
                        if (AddTextBox2.Text == string.Empty)
                        {
                            message += "Необходимо ввести " +
                                "время полёта вертолёта.\n";
                        }
                        if (message == string.Empty)
                        {
                            TransportBase helicopter = new
                                HelicopterTransport(Convert
                                .ToDouble(AddTextBox2.Text),
                                Convert.ToDouble(AddTextBox1.Text));
                            AddTransport(helicopter);
                        }
                        break;
                }
                if (message != string.Empty)
                {
                    MessageBox.Show(message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод добавления данных.
        /// </summary>
        /// <param name="transportBase">Объект с информацией о добавляемом
        /// транспорте.</param>
        private void AddTransport(TransportBase transportBase)
        {
            _transportModels.Add(new TransportModel
            {
                TransportName = TransportNameComboBox
                .SelectedItem.ToString(),
                SpendFuel = Math.Round(transportBase.SpendFuel, 3)
            });
        }

        /// <summary>
        /// Событие при нажатии на кнопку случайное значение.
        /// </summary>
        private void RandomValueButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int numberValue = random.Next(0, 3);
            TransportNameComboBox.SelectedIndex = numberValue;
            Thread.Sleep(9);
            switch (TransportNameComboBox.SelectedIndex)
            {
                case 0:
                    AddTextBox1.Text = random.Next(1, 
                        AutomobileTransport.maxFuelConsumption).ToString();
                    AddTextBox2.Text = random.Next(1, 
                        AutomobileTransport.maxDistance).ToString();
                    break;
                case 1:
                    AddTextBox1.Text = random.Next(1, 
                        HybridTransport.maxFuelConsumption)
                        .ToString();
                    AddTextBox2.Text = random.Next(1, 
                        HybridTransport.maxGeneralDistance - 1)
                        .ToString();
                    AddTextBox3.Text = random.Next(1, 
                        HybridTransport.maxElectricalDistance)
                        .ToString();
                    if (Convert.ToDouble(AddTextBox2.Text) 
                        <= Convert.ToDouble(AddTextBox3.Text))
                    {
                        string tempValue = AddTextBox2.Text;
                        AddTextBox2.Text = AddTextBox3.Text;
                        AddTextBox3.Text = tempValue;
                    }
                    break;
                case 2:
                    AddTextBox1.Text = random.Next(1, 
                        HelicopterTransport.maxFuelConsumption)
                        .ToString();
                    AddTextBox2.Text = random.Next(1, 
                        HelicopterTransport.maxTimeInFly)
                        .ToString();
                    break;
            }
        }
    }
}