
namespace View
{
    partial class FindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TransportNameComboBox = new System.Windows.Forms.ComboBox();
            this.TransportNameLabel = new System.Windows.Forms.Label();
            this.ExitFindButton = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.SpendFuelLabel = new System.Windows.Forms.Label();
            this.SpendFuelTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TransportNameComboBox
            // 
            this.TransportNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TransportNameComboBox.FormattingEnabled = true;
            this.TransportNameComboBox.Items.AddRange(new object[] {
            "Машина",
            "Машина-гибрид",
            "Вертолёт"});
            this.TransportNameComboBox.Location = new System.Drawing.Point(141, 6);
            this.TransportNameComboBox.Name = "TransportNameComboBox";
            this.TransportNameComboBox.Size = new System.Drawing.Size(113, 21);
            this.TransportNameComboBox.TabIndex = 38;
            this.TransportNameComboBox.SelectedIndexChanged += new System.EventHandler(this.TransportNameComboBox_SelectedIndexChanged);
            // 
            // TransportNameLabel
            // 
            this.TransportNameLabel.AutoSize = true;
            this.TransportNameLabel.Location = new System.Drawing.Point(12, 9);
            this.TransportNameLabel.Name = "TransportNameLabel";
            this.TransportNameLabel.Size = new System.Drawing.Size(118, 13);
            this.TransportNameLabel.TabIndex = 37;
            this.TransportNameLabel.Text = "Название транспорта";
            // 
            // ExitFindButton
            // 
            this.ExitFindButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitFindButton.Location = new System.Drawing.Point(179, 63);
            this.ExitFindButton.Name = "ExitFindButton";
            this.ExitFindButton.Size = new System.Drawing.Size(75, 23);
            this.ExitFindButton.TabIndex = 36;
            this.ExitFindButton.Text = "Отмена";
            this.ExitFindButton.UseVisualStyleBackColor = true;
            this.ExitFindButton.Click += new System.EventHandler(this.ExitFindButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(15, 63);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(75, 23);
            this.FindButton.TabIndex = 35;
            this.FindButton.Text = "Найти";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // SpendFuelLabel
            // 
            this.SpendFuelLabel.AutoSize = true;
            this.SpendFuelLabel.Location = new System.Drawing.Point(12, 37);
            this.SpendFuelLabel.Name = "SpendFuelLabel";
            this.SpendFuelLabel.Size = new System.Drawing.Size(87, 13);
            this.SpendFuelLabel.TabIndex = 33;
            this.SpendFuelLabel.Text = "Расход топлива";
            this.SpendFuelLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SpendFuelTextBox
            // 
            this.SpendFuelTextBox.Location = new System.Drawing.Point(141, 34);
            this.SpendFuelTextBox.MaxLength = 10;
            this.SpendFuelTextBox.Name = "SpendFuelTextBox";
            this.SpendFuelTextBox.Size = new System.Drawing.Size(113, 20);
            this.SpendFuelTextBox.TabIndex = 34;
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 100);
            this.Controls.Add(this.TransportNameComboBox);
            this.Controls.Add(this.TransportNameLabel);
            this.Controls.Add(this.ExitFindButton);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.SpendFuelLabel);
            this.Controls.Add(this.SpendFuelTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск информации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TransportNameComboBox;
        private System.Windows.Forms.Label TransportNameLabel;
        private System.Windows.Forms.Button ExitFindButton;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Label SpendFuelLabel;
        private System.Windows.Forms.TextBox SpendFuelTextBox;
    }
}