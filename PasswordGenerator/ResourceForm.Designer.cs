namespace PasswordGenerator
{
    partial class ResourceForm
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
            this.resourceParamsGroup = new System.Windows.Forms.GroupBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.resourceNameLabel = new System.Windows.Forms.Label();
            this.resourceName = new System.Windows.Forms.TextBox();
            this.uniqueKey = new System.Windows.Forms.TextBox();
            this.uniqueKeyLabel = new System.Windows.Forms.Label();
            this.addNonAlphaNumericCharsOverride = new System.Windows.Forms.CheckBox();
            this.resourceParamsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // resourceParamsGroup
            // 
            this.resourceParamsGroup.Controls.Add(this.addNonAlphaNumericCharsOverride);
            this.resourceParamsGroup.Controls.Add(this.uniqueKey);
            this.resourceParamsGroup.Controls.Add(this.uniqueKeyLabel);
            this.resourceParamsGroup.Controls.Add(this.resourceName);
            this.resourceParamsGroup.Controls.Add(this.resourceNameLabel);
            this.resourceParamsGroup.Location = new System.Drawing.Point(12, 12);
            this.resourceParamsGroup.Name = "resourceParamsGroup";
            this.resourceParamsGroup.Size = new System.Drawing.Size(260, 98);
            this.resourceParamsGroup.TabIndex = 0;
            this.resourceParamsGroup.TabStop = false;
            this.resourceParamsGroup.Text = "Resource parameters";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(116, 116);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(197, 116);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // resourceNameLabel
            // 
            this.resourceNameLabel.AutoSize = true;
            this.resourceNameLabel.Location = new System.Drawing.Point(6, 24);
            this.resourceNameLabel.Name = "resourceNameLabel";
            this.resourceNameLabel.Size = new System.Drawing.Size(85, 13);
            this.resourceNameLabel.TabIndex = 0;
            this.resourceNameLabel.Text = "Resource name:";
            // 
            // resourceName
            // 
            this.resourceName.Location = new System.Drawing.Point(123, 21);
            this.resourceName.MaxLength = 200;
            this.resourceName.Name = "resourceName";
            this.resourceName.Size = new System.Drawing.Size(131, 20);
            this.resourceName.TabIndex = 1;
            // 
            // uniqueKey
            // 
            this.uniqueKey.Location = new System.Drawing.Point(123, 47);
            this.uniqueKey.Name = "uniqueKey";
            this.uniqueKey.Size = new System.Drawing.Size(131, 20);
            this.uniqueKey.TabIndex = 3;
            // 
            // uniqueKeyLabel
            // 
            this.uniqueKeyLabel.AutoSize = true;
            this.uniqueKeyLabel.Location = new System.Drawing.Point(6, 50);
            this.uniqueKeyLabel.Name = "uniqueKeyLabel";
            this.uniqueKeyLabel.Size = new System.Drawing.Size(111, 13);
            this.uniqueKeyLabel.TabIndex = 2;
            this.uniqueKeyLabel.Text = "Resource unique key:";
            // 
            // addNonAlphaNumericCharsOverride
            // 
            this.addNonAlphaNumericCharsOverride.AutoSize = true;
            this.addNonAlphaNumericCharsOverride.Checked = true;
            this.addNonAlphaNumericCharsOverride.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addNonAlphaNumericCharsOverride.Location = new System.Drawing.Point(22, 73);
            this.addNonAlphaNumericCharsOverride.Name = "addNonAlphaNumericCharsOverride";
            this.addNonAlphaNumericCharsOverride.Size = new System.Drawing.Size(232, 17);
            this.addNonAlphaNumericCharsOverride.TabIndex = 5;
            this.addNonAlphaNumericCharsOverride.Text = "Add non alphanumeric characters (override)";
            this.addNonAlphaNumericCharsOverride.UseVisualStyleBackColor = true;
            // 
            // ResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 145);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.resourceParamsGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResourceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ResourceForm";
            this.resourceParamsGroup.ResumeLayout(false);
            this.resourceParamsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox resourceParamsGroup;
        private System.Windows.Forms.TextBox uniqueKey;
        private System.Windows.Forms.Label uniqueKeyLabel;
        private System.Windows.Forms.TextBox resourceName;
        private System.Windows.Forms.Label resourceNameLabel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.CheckBox addNonAlphaNumericCharsOverride;
    }
}