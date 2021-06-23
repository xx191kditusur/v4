
namespace View
{
    partial class AddForm
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
            this.AddTextBox3 = new System.Windows.Forms.TextBox();
            this.AddLabel3 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.RandomValueButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddTextBox2 = new System.Windows.Forms.TextBox();
            this.AddTextBox1 = new System.Windows.Forms.TextBox();
            this.TransportNameComboBox = new System.Windows.Forms.ComboBox();
            this.AddLabel2 = new System.Windows.Forms.Label();
            this.TransportNameLabel = new System.Windows.Forms.Label();
            this.AddLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddTextBox3
            // 
            this.AddTextBox3.Location = new System.Drawing.Point(200, 86);
            this.AddTextBox3.MaxLength = 10;
            this.AddTextBox3.Name = "AddTextBox3";
            this.AddTextBox3.Size = new System.Drawing.Size(116, 20);
            this.AddTextBox3.TabIndex = 48;
            // 
            // AddLabel3
            // 
            this.AddLabel3.AutoSize = true;
            this.AddLabel3.Location = new System.Drawing.Point(12, 89);
            this.AddLabel3.Name = "AddLabel3";
            this.AddLabel3.Size = new System.Drawing.Size(58, 13);
            this.AddLabel3.TabIndex = 47;
            this.AddLabel3.Text = "AddLabel3";
            // 
            // ExitButton
            // 
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Location = new System.Drawing.Point(221, 121);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(95, 37);
            this.ExitButton.TabIndex = 44;
            this.ExitButton.Text = "Отмена";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // RandomValueButton
            // 
            this.RandomValueButton.Location = new System.Drawing.Point(116, 121);
            this.RandomValueButton.Name = "RandomValueButton";
            this.RandomValueButton.Size = new System.Drawing.Size(96, 37);
            this.RandomValueButton.TabIndex = 45;
            this.RandomValueButton.Text = "Случайное значение";
            this.RandomValueButton.UseVisualStyleBackColor = true;
            this.RandomValueButton.Click += new System.EventHandler(this.RandomValueButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(15, 121);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(95, 37);
            this.AddButton.TabIndex = 46;
            this.AddButton.Text = "Ok";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddTextBox2
            // 
            this.AddTextBox2.Location = new System.Drawing.Point(200, 60);
            this.AddTextBox2.MaxLength = 10;
            this.AddTextBox2.Name = "AddTextBox2";
            this.AddTextBox2.Size = new System.Drawing.Size(116, 20);
            this.AddTextBox2.TabIndex = 43;
            // 
            // AddTextBox1
            // 
            this.AddTextBox1.Location = new System.Drawing.Point(200, 36);
            this.AddTextBox1.MaxLength = 10;
            this.AddTextBox1.Name = "AddTextBox1";
            this.AddTextBox1.Size = new System.Drawing.Size(116, 20);
            this.AddTextBox1.TabIndex = 42;
            // 
            // TransportNameComboBox
            // 
            this.TransportNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TransportNameComboBox.FormattingEnabled = true;
            this.TransportNameComboBox.Items.AddRange(new object[] {
            "Машина",
            "Машина-гибрид",
            "Вертолёт"});
            this.TransportNameComboBox.Location = new System.Drawing.Point(200, 6);
            this.TransportNameComboBox.Name = "TransportNameComboBox";
            this.TransportNameComboBox.Size = new System.Drawing.Size(116, 21);
            this.TransportNameComboBox.TabIndex = 41;
            this.TransportNameComboBox.SelectedIndexChanged += new System.EventHandler(this.TransportNameComboBox_SelectedIndexChanged);
            // 
            // AddLabel2
            // 
            this.AddLabel2.AutoSize = true;
            this.AddLabel2.Location = new System.Drawing.Point(12, 63);
            this.AddLabel2.Name = "AddLabel2";
            this.AddLabel2.Size = new System.Drawing.Size(58, 13);
            this.AddLabel2.TabIndex = 38;
            this.AddLabel2.Text = "AddLabel2";
            // 
            // TransportNameLabel
            // 
            this.TransportNameLabel.AutoSize = true;
            this.TransportNameLabel.Location = new System.Drawing.Point(12, 9);
            this.TransportNameLabel.Name = "TransportNameLabel";
            this.TransportNameLabel.Size = new System.Drawing.Size(118, 13);
            this.TransportNameLabel.TabIndex = 39;
            this.TransportNameLabel.Text = "Название транспорта";
            // 
            // AddLabel1
            // 
            this.AddLabel1.AutoSize = true;
            this.AddLabel1.Location = new System.Drawing.Point(12, 39);
            this.AddLabel1.Name = "AddLabel1";
            this.AddLabel1.Size = new System.Drawing.Size(58, 13);
            this.AddLabel1.TabIndex = 40;
            this.AddLabel1.Text = "AddLabel1";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(322, 163);
            this.Controls.Add(this.AddTextBox3);
            this.Controls.Add(this.AddLabel3);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RandomValueButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AddTextBox2);
            this.Controls.Add(this.AddTextBox1);
            this.Controls.Add(this.TransportNameComboBox);
            this.Controls.Add(this.AddLabel2);
            this.Controls.Add(this.TransportNameLabel);
            this.Controls.Add(this.AddLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление информации";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddTextBox3;
        private System.Windows.Forms.Label AddLabel3;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button RandomValueButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox AddTextBox2;
        private System.Windows.Forms.TextBox AddTextBox1;
        private System.Windows.Forms.ComboBox TransportNameComboBox;
        private System.Windows.Forms.Label AddLabel2;
        private System.Windows.Forms.Label TransportNameLabel;
        private System.Windows.Forms.Label AddLabel1;
    }
}