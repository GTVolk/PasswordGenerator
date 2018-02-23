using System;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class ResourceForm : Form
    {

        private int resourceId = 0;

        /// <summary>
        /// Form constructor
        /// </summary>
        /// <param name="resource">Resource to edit</param>
        public ResourceForm(Resource resource = null)
        {
            InitializeComponent();
            if (resource != null && resource.Id > 0)
            {
                this.resourceId = resource.Id;
                resourceName.Text = resource.Name;
                uniqueKey.Text = resource.UniqueKey;
                addNonAlphaNumericCharsOverride.Checked = resource.UseSpecialChars;
            }
        }

        /// <summary>
        /// Set form unique key value
        /// </summary>
        /// <param name="value"></param>
        public void setUniqueKey(string value)
        {
            uniqueKey.Text = value;
        }

        /// <summary>
        /// Cancel button handler (Close window)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Save resource handler (Save or edit resource)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (resourceName.Text.Trim().Length > 0)
            {
                if (uniqueKey.Text.Trim().Length > 0)
                {
                    (this.Owner as MainForm).processResource(this.resourceId, resourceName.Text.Trim(), uniqueKey.Text.Trim(), addNonAlphaNumericCharsOverride.Checked);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "No resource unique key specified", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(this, "No resource name specified", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
