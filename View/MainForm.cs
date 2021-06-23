using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Делегат обновления данных в DataGridView.
    /// </summary>
    public delegate void UpdateInformation();

    /// <summary>
    /// Делегат поиска транспортного средства.
    /// </summary>
    /// <param name="transportModel">Объект с информацией о транспортном
    /// средстве.</param>
    public delegate void SearchDelegate(TransportModel transportModel);

    /// <summary>
    /// Класс описывающий действия с транспортными средствами
    /// (загрузку, сохранение, добавление, удаление, поиск).
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Конструктор класса MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _updateInformation = UpdateGridView;
        }

        /// <summary>
        /// Коллекция элементов с информацией о транспорте.
        /// </summary>
        private readonly List<TransportModel> _transportModels =
            new List<TransportModel>();

        /// <summary>
        /// Делегат обновления информации о транспорте.
        /// </summary>
        private readonly UpdateInformation
            _updateInformation = null;

        /// <summary>
        /// Объект c информацией об удаляемом транспорте. 
        /// </summary>
        private readonly TransportModel
            _deleteTransport = new TransportModel();

        /// <summary>
        /// Поле с информацией о пути для загрузки и сохранения.
        /// </summary>
        private string _path;

        /// <summary>
        /// Метод обновления информации в DataGridView.
        /// </summary>
        internal void UpdateGridView()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.SuspendBinding();
            bindingSource.DataSource = _transportModels;
            bindingSource.ResumeBinding();

            DataGridView.DataSource = bindingSource;

            DataGridView.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            DataGridView.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            DataGridView.Columns[1].DefaultCellStyle
                .Format = string.Format("0.###");

            DataGridView.Columns[0].HeaderText =
                "Название транспорта";
            DataGridView.Columns[1].HeaderText =
                "Количество затраченного топлива";
            DataGridView.ClearSelection();
        }

        /// <summary>
        /// Событие при нажатии на кнопку добавить.
        /// </summary>
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(_transportModels,
                _updateInformation);
            addForm.ShowDialog();
            UpdateGridView();
            addForm.Dispose();
        }

        /// <summary>
        /// Событие при нажатии на кнопку удалить.
        /// </summary>
        private void DelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in
                             this.DataGridView.SelectedRows)
                {
                    _deleteTransport.TransportName =
                        DataGridView[0, item.Index]
                        .Value.ToString();
                    _deleteTransport.SpendFuel = Convert.ToDouble
                        (DataGridView[1, item.Index].Value);
                }

                foreach (var item in _transportModels)
                {
                    if ((item.TransportName == _deleteTransport
                        .TransportName)
                        && (item.SpendFuel == _deleteTransport
                        .SpendFuel))
                    {
                        _transportModels.Remove(item);
                        break;
                    }
                }
                UpdateGridView();
            }
        }

        /// <summary>
        /// Событие при нажатии на кнопку найти.
        /// </summary>
        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindForm findForm = new FindForm(new
               SearchDelegate(FindTransport));
            findForm.ShowDialog();
            findForm.Dispose();
        }

        /// <summary>
        /// Метод поиска транспортного средства.
        /// </summary>
        /// <param name="transport">Объект хранящий информацию
        /// о транспортном средстве.</param>
        private void FindTransport(TransportModel transportModel)
        {
            for (int i = 0; i < DataGridView.RowCount; i++)
            {
                DataGridView.Rows[i].DefaultCellStyle
                    .BackColor = System.Drawing.Color.White;
            }

            if (transportModel.SpendFuel != null)
            {
                for (int i = 0; i < DataGridView.RowCount; i++)
                {
                    if (
                        (DataGridView.Rows[i].Cells[0].Value.ToString() ==
                        transportModel.TransportName.ToString())
                        &&
                        ((double)DataGridView.Rows[i].Cells[1].Value ==
                        transportModel.SpendFuel))
                    {
                        DataGridView.Rows[i].DefaultCellStyle.BackColor =
                            System.Drawing.Color.BlueViolet;
                    }
                    else
                    {
                        DataGridView.Rows[i].DefaultCellStyle.BackColor =
                            System.Drawing.Color.White;
                    }
                }
            }
            else
            {
                for (int i = 0; i < DataGridView.RowCount; i++)
                {

                    if ((DataGridView.Rows[i].Cells[0]
                        .Value.ToString()) == transportModel.TransportName
                        .ToString())
                    {
                        DataGridView.Rows[i].DefaultCellStyle
                            .BackColor = System.Drawing.Color.BlueViolet;
                    }
                    else
                    {
                        DataGridView.Rows[i].DefaultCellStyle
                            .BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }

        /// <summary>
        /// Событие при нажатии на кнопку сохранить.
        /// </summary>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            if (_path != null)
            {
                saveDialog.InitialDirectory = _path;
            }
            else
            {
                saveDialog.InitialDirectory = Application.StartupPath;
            }
            saveDialog.Filter = "Transport *.trb|*.trb";
            saveDialog.FilterIndex = 1;

            List<TransportModel> saveList = new List<TransportModel>();
            foreach (var item in _transportModels)
            {
                saveList.Add(item);
            }

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _path = saveDialog.FileName;
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream(
                    saveDialog.FileName, FileMode.OpenOrCreate))
                {
                    binaryFormatter.Serialize(fileStream, saveList);
                }
            }
            saveDialog.Dispose();
        }

        /// <summary>
        /// Событие при нажатии на кнопку загрузить.
        /// </summary>
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            if (_path != null)
            {
                openDialog.InitialDirectory = _path;
            }
            else
            {
                openDialog.InitialDirectory = Application.StartupPath;
            }
            openDialog.Filter = "Transport *.trb|*.trb";
            openDialog.FilterIndex = 1;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _path = openDialog.FileName;
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                using (FileStream fileStream = new FileStream(
                    openDialog.FileName, FileMode.OpenOrCreate))
                {
                    try
                    {
                        List<TransportModel> openlList =
                            (List<TransportModel>)binaryFormatter
                            .Deserialize(fileStream);
                        if (_transportModels.Count > 0)
                        {
                            _transportModels.Clear();
                        }
                        foreach (var item in openlList)
                        {
                            _transportModels.Add(item);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось загрузить файл." +
                            "Возможно файл повреждён.\n");
                    }
                }
                UpdateGridView();
            }
            openDialog.Dispose();
        }
    }
}