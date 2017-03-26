namespace PasswordGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.keyPhrase = new System.Windows.Forms.TextBox();
            this.keyPhraseLabel = new System.Windows.Forms.Label();
            this.paramsGroup = new System.Windows.Forms.GroupBox();
            this.numChars = new System.Windows.Forms.NumericUpDown();
            this.numCharsLabel = new System.Windows.Forms.Label();
            this.resultGroup = new System.Windows.Forms.GroupBox();
            this.removeResourceButton = new System.Windows.Forms.Button();
            this.editResourceButton = new System.Windows.Forms.Button();
            this.addResourceButton = new System.Windows.Forms.Button();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.resourceSelectLabel = new System.Windows.Forms.Label();
            this.resourceSelect = new System.Windows.Forms.ComboBox();
            this.addNonAlphaNumericChars = new System.Windows.Forms.CheckBox();
            this.paramsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChars)).BeginInit();
            this.resultGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // keyPhrase
            // 
            this.keyPhrase.Location = new System.Drawing.Point(107, 19);
            this.keyPhrase.MaxLength = 200;
            this.keyPhrase.Name = "keyPhrase";
            this.keyPhrase.PasswordChar = '*';
            this.keyPhrase.Size = new System.Drawing.Size(175, 20);
            this.keyPhrase.TabIndex = 0;
            this.keyPhrase.TextChanged += new System.EventHandler(this.keyPhrase_TextChanged);
            // 
            // keyPhraseLabel
            // 
            this.keyPhraseLabel.AutoSize = true;
            this.keyPhraseLabel.Location = new System.Drawing.Point(6, 22);
            this.keyPhraseLabel.Name = "keyPhraseLabel";
            this.keyPhraseLabel.Size = new System.Drawing.Size(88, 13);
            this.keyPhraseLabel.TabIndex = 1;
            this.keyPhraseLabel.Text = "Key pass phrase:";
            // 
            // paramsGroup
            // 
            this.paramsGroup.Controls.Add(this.addNonAlphaNumericChars);
            this.paramsGroup.Controls.Add(this.numChars);
            this.paramsGroup.Controls.Add(this.numCharsLabel);
            this.paramsGroup.Controls.Add(this.keyPhrase);
            this.paramsGroup.Controls.Add(this.keyPhraseLabel);
            this.paramsGroup.Location = new System.Drawing.Point(12, 12);
            this.paramsGroup.Name = "paramsGroup";
            this.paramsGroup.Size = new System.Drawing.Size(288, 97);
            this.paramsGroup.TabIndex = 2;
            this.paramsGroup.TabStop = false;
            this.paramsGroup.Text = "Generation parameters";
            // 
            // numChars
            // 
            this.numChars.Location = new System.Drawing.Point(188, 45);
            this.numChars.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numChars.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numChars.Name = "numChars";
            this.numChars.Size = new System.Drawing.Size(94, 20);
            this.numChars.TabIndex = 3;
            this.numChars.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numChars.ValueChanged += new System.EventHandler(this.numChars_ValueChanged);
            // 
            // numCharsLabel
            // 
            this.numCharsLabel.AutoSize = true;
            this.numCharsLabel.Location = new System.Drawing.Point(6, 47);
            this.numCharsLabel.Name = "numCharsLabel";
            this.numCharsLabel.Size = new System.Drawing.Size(136, 13);
            this.numCharsLabel.TabIndex = 3;
            this.numCharsLabel.Text = "Number of password chars:";
            // 
            // resultGroup
            // 
            this.resultGroup.Controls.Add(this.removeResourceButton);
            this.resultGroup.Controls.Add(this.editResourceButton);
            this.resultGroup.Controls.Add(this.addResourceButton);
            this.resultGroup.Controls.Add(this.newPasswordLabel);
            this.resultGroup.Controls.Add(this.newPassword);
            this.resultGroup.Controls.Add(this.resourceSelectLabel);
            this.resultGroup.Controls.Add(this.resourceSelect);
            this.resultGroup.Location = new System.Drawing.Point(12, 107);
            this.resultGroup.Name = "resultGroup";
            this.resultGroup.Size = new System.Drawing.Size(288, 104);
            this.resultGroup.TabIndex = 3;
            this.resultGroup.TabStop = false;
            this.resultGroup.Text = "Generation result";
            // 
            // removeResourceButton
            // 
            this.removeResourceButton.Location = new System.Drawing.Point(194, 73);
            this.removeResourceButton.Name = "removeResourceButton";
            this.removeResourceButton.Size = new System.Drawing.Size(88, 23);
            this.removeResourceButton.TabIndex = 6;
            this.removeResourceButton.Text = "Remove";
            this.removeResourceButton.UseVisualStyleBackColor = true;
            this.removeResourceButton.Click += new System.EventHandler(this.removeResourceButton_Click);
            // 
            // editResourceButton
            // 
            this.editResourceButton.Location = new System.Drawing.Point(100, 73);
            this.editResourceButton.Name = "editResourceButton";
            this.editResourceButton.Size = new System.Drawing.Size(88, 23);
            this.editResourceButton.TabIndex = 5;
            this.editResourceButton.Text = "Edit";
            this.editResourceButton.UseVisualStyleBackColor = true;
            this.editResourceButton.Click += new System.EventHandler(this.editResourceButton_Click);
            // 
            // addResourceButton
            // 
            this.addResourceButton.Location = new System.Drawing.Point(6, 73);
            this.addResourceButton.Name = "addResourceButton";
            this.addResourceButton.Size = new System.Drawing.Size(88, 23);
            this.addResourceButton.TabIndex = 4;
            this.addResourceButton.Text = "Add";
            this.addResourceButton.UseVisualStyleBackColor = true;
            this.addResourceButton.Click += new System.EventHandler(this.addResourceButton_Click);
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(6, 50);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(80, 13);
            this.newPasswordLabel.TabIndex = 3;
            this.newPasswordLabel.Text = "New password:";
            // 
            // newPassword
            // 
            this.newPassword.Location = new System.Drawing.Point(92, 47);
            this.newPassword.Name = "newPassword";
            this.newPassword.ReadOnly = true;
            this.newPassword.Size = new System.Drawing.Size(190, 20);
            this.newPassword.TabIndex = 2;
            this.newPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.newPassword_MouseClick);
            // 
            // resourceSelectLabel
            // 
            this.resourceSelectLabel.AutoSize = true;
            this.resourceSelectLabel.Location = new System.Drawing.Point(6, 23);
            this.resourceSelectLabel.Name = "resourceSelectLabel";
            this.resourceSelectLabel.Size = new System.Drawing.Size(85, 13);
            this.resourceSelectLabel.TabIndex = 1;
            this.resourceSelectLabel.Text = "Resource name:";
            // 
            // resourceSelect
            // 
            this.resourceSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resourceSelect.FormattingEnabled = true;
            this.resourceSelect.Location = new System.Drawing.Point(92, 20);
            this.resourceSelect.MaxLength = 200;
            this.resourceSelect.Name = "resourceSelect";
            this.resourceSelect.Size = new System.Drawing.Size(190, 21);
            this.resourceSelect.TabIndex = 0;
            this.resourceSelect.SelectedIndexChanged += new System.EventHandler(this.resourceSelect_SelectedIndexChanged);
            // 
            // addNonAlphaNumericChars
            // 
            this.addNonAlphaNumericChars.AutoSize = true;
            this.addNonAlphaNumericChars.Checked = true;
            this.addNonAlphaNumericChars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addNonAlphaNumericChars.Location = new System.Drawing.Point(9, 72);
            this.addNonAlphaNumericChars.Name = "addNonAlphaNumericChars";
            this.addNonAlphaNumericChars.Size = new System.Drawing.Size(185, 17);
            this.addNonAlphaNumericChars.TabIndex = 4;
            this.addNonAlphaNumericChars.Text = "Add non alphanumeric characters";
            this.addNonAlphaNumericChars.UseVisualStyleBackColor = true;
            this.addNonAlphaNumericChars.CheckedChanged += new System.EventHandler(this.addNonAlphaNumericChars_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 226);
            this.Controls.Add(this.resultGroup);
            this.Controls.Add(this.paramsGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password generator";
            this.paramsGroup.ResumeLayout(false);
            this.paramsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChars)).EndInit();
            this.resultGroup.ResumeLayout(false);
            this.resultGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox keyPhrase;
        private System.Windows.Forms.Label keyPhraseLabel;
        private System.Windows.Forms.GroupBox paramsGroup;
        private System.Windows.Forms.NumericUpDown numChars;
        private System.Windows.Forms.Label numCharsLabel;
        private System.Windows.Forms.GroupBox resultGroup;
        private System.Windows.Forms.Button removeResourceButton;
        private System.Windows.Forms.Button editResourceButton;
        private System.Windows.Forms.Button addResourceButton;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.Label resourceSelectLabel;
        private System.Windows.Forms.ComboBox resourceSelect;
        private System.Windows.Forms.CheckBox addNonAlphaNumericChars;
    }
}

