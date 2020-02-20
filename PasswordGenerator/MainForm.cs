using System;
using System.Windows;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace PasswordGenerator
{
    public partial class MainForm : Form
    {

        // Key file name
        const string DEFAULT_KEY_FILE = "default_key";

        // Resources file name
        const string DEFAULT_RESOURCE_FILE = "data.bin";

        // Default resource id
        const int DEFAULT_RESOURCE_ID = 0;

        // Default resource name
        const string DEFAULT_RESOURCE_NAME = "Other";

        // Default resource unique key
        const string DEFAULT_RESOURCE_KEY = "";

        // Password characters
        const string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
        const string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
        const string PASSWORD_CHARS_NUMERIC = "23456789";
        const string PASSWORD_CHARS_SPECIAL = "*$-+?_&=!%{}/";

        // Generation key size in bytes
        const int BYTES_COUNT = 256;

        // Resource list
        private List<Resource> resources;

        /// <summary>
        /// Form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.LoadResources();
        }

        /// <summary>
        /// Load resources from file
        /// </summary>
        public void LoadResources()
        {
            resourceSelect.Items.Clear();
            this.resources = new List<Resource>();

            resourceSelect.Items.Add(new Resource(DEFAULT_RESOURCE_ID, DEFAULT_RESOURCE_NAME, DEFAULT_RESOURCE_KEY));
            resourceSelect.SelectedIndex = 0;

            addNonAlphaNumericChars.Enabled = true;
            editResourceButton.Enabled = false;
            removeResourceButton.Enabled = false;
            try
            {
                using (Stream stream = File.Open(DEFAULT_RESOURCE_FILE, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    // Save in binary format
                    List<Resource> resList = (List<Resource>)bin.Deserialize(stream);
                    this.resources = resList;

                    foreach (Resource resource in resList)
                    {
                        resourceSelect.Items.Add(resource);
                    }
                }
            }
            catch (IOException)
            {
                // Skip exception because we allready processed default resource and file content is no required to work
            }
            this.GenerateNewPassword();
        }

        /// <summary>
        /// Save resources to file
        /// </summary>
        public void SaveResources()
        {
            try
            {
                using (Stream stream = File.Open(DEFAULT_RESOURCE_FILE, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, resources);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Cannot save resources", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.LoadResources(); // Reload resources
        }

        /// <summary>
        /// Process resource action (add, edit)
        /// </summary>
        /// <param name="id">Id of resource if zero (by default) then add new resource to list, otherwise edit resource with same id</param>
        /// <param name="name">Display name of resource</param>
        /// <param name="key">Resource unique key</param>
        /// <param name="useSpecialChars">Use special chars override for resource</param>
        public void ProcessResource(int id, string name, string key, bool useSpecialChars = true)
        {
            int maxResourceId = DEFAULT_RESOURCE_ID;
            List<Resource> newList = new List<Resource>();
            foreach (Resource res in this.resources)
            {
                if (id > DEFAULT_RESOURCE_ID)
                {
                    if (res.Id == id)
                    {
                        res.Name = name;
                        res.UniqueKey = key;
                        res.UseSpecialChars = useSpecialChars;
                    }
                }
                else
                {
                    maxResourceId = Math.Max(res.Id, maxResourceId);
                }
            }
            if (id == 0)
            {
                this.resources.Add(new Resource(maxResourceId + 1, name, key, useSpecialChars));
            }
            this.SaveResources();
        }

        /// <summary>
        /// Generate fully random password key with needed length
        /// </summary>
        /// <param name="length">Length of key</param>
        /// <returns></returns>
        public string GenerateRandomKey(int length)
        {
            // Make sure that input parameters are valid.
            if (length <= 0)
                return null;

            // Create a local array containing supported password characters
            // grouped by types. You can remove character groups from this
            // array, but doing so will weaken the password strength.
            char[][] charGroups = new char[][]
            {
                PASSWORD_CHARS_LCASE.ToCharArray(),
                PASSWORD_CHARS_UCASE.ToCharArray(),
                PASSWORD_CHARS_NUMERIC.ToCharArray(),
                PASSWORD_CHARS_SPECIAL.ToCharArray()
            };

            // Use this array to track the number of unused characters in each
            // character group.
            int[] charsLeftInGroup = new int[charGroups.Length];

            // Initially, all characters in each group are not used.
            for (int i = 0; i < charsLeftInGroup.Length; i++)
                charsLeftInGroup[i] = charGroups[i].Length;

            // Use this array to track (iterate through) unused character groups.
            int[] leftGroupsOrder = new int[charGroups.Length];

            // Initially, all character groups are not used.
            for (int i = 0; i < leftGroupsOrder.Length; i++)
                leftGroupsOrder[i] = i;

            // Because we cannot use the default randomizer, which is based on the
            // current time (it will produce the same "random" number within a
            // second), we will use a random number generator to seed the
            // randomizer.

            // Use a 4-byte array to fill it with random bytes and convert it then
            // to an integer value.
            byte[] randomBytes = new byte[4];

            // Generate 4 random bytes.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            // Convert 4 bytes into a 32-bit integer value.
            int seed = BitConverter.ToInt32(randomBytes, 0);

            // Now, this is real randomization.
            Random random = new Random(seed);

            // This array will hold password characters.
            char[] password = null;

            // Allocate appropriate memory for the password.
            password = new char[length];

            // Index of the next character to be added to password.
            int nextCharIdx;

            // Index of the next character group to be processed.
            int nextGroupIdx;

            // Index which will be used to track not processed character groups.
            int nextLeftGroupsOrderIdx;

            // Index of the last non-processed character in a group.
            int lastCharIdx;

            // Index of the last non-processed group.
            int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

            // Generate password characters one at a time.
            for (int i = 0; i < password.Length; i++)
            {
                // If only one character group remained unprocessed, process it;
                // otherwise, pick a random character group from the unprocessed
                // group list. To allow a special character to appear in the
                // first position, increment the second parameter of the Next
                // function call by one, i.e. lastLeftGroupsOrderIdx + 1.
                if (lastLeftGroupsOrderIdx == 0)
                    nextLeftGroupsOrderIdx = 0;
                else
                    nextLeftGroupsOrderIdx = random.Next(0,
                                                         lastLeftGroupsOrderIdx);

                // Get the actual index of the character group, from which we will
                // pick the next character.
                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];

                // Get the index of the last unprocessed characters in this group.
                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

                // If only one unprocessed character is left, pick it; otherwise,
                // get a random character from the unused character list.
                if (lastCharIdx == 0)
                    nextCharIdx = 0;
                else
                    nextCharIdx = random.Next(0, lastCharIdx + 1);

                // Add this character to the password.
                password[i] = charGroups[nextGroupIdx][nextCharIdx];

                // If we processed the last character in this group, start over.
                if (lastCharIdx == 0)
                    charsLeftInGroup[nextGroupIdx] =
                                              charGroups[nextGroupIdx].Length;
                // There are more unprocessed characters left.
                else
                {
                    // Swap processed character with the last unprocessed character
                    // so that we don't pick it until we process all characters in
                    // this group.
                    if (lastCharIdx != nextCharIdx)
                    {
                        char temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][lastCharIdx] =
                                    charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }
                    // Decrement the number of unprocessed characters in
                    // this group.
                    charsLeftInGroup[nextGroupIdx]--;
                }

                // If we processed the last group, start all over.
                if (lastLeftGroupsOrderIdx == 0)
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                // There are more unprocessed groups left.
                else
                {
                    // Swap processed group with the last unprocessed group
                    // so that we don't pick it until we process all groups.
                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] =
                                    leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }
                    // Decrement the number of unprocessed groups.
                    lastLeftGroupsOrderIdx--;
                }
            }

            // Convert password characters into a string and return the result.
            return new string(password);
        }

        /// <summary>
        /// Generate password for specified pass phrase and unique key
        /// </summary>
        public void GenerateNewPassword()
        {
            string value = keyPhrase.Text;
            if (value.Length > 0)
            {
                int maxChars = Convert.ToInt32(numChars.Value);
                Resource resource = resourceSelect.SelectedItem as Resource;
                bool isUseNonAlphaNumericChars = addNonAlphaNumericChars.Checked;

                string uniqueKey = "";
                bool useSpecialChars = addNonAlphaNumericChars.Checked;

                if (resource != null && resource.Id > 0)
                {
                    uniqueKey = resource.UniqueKey;
                    useSpecialChars = resource.UseSpecialChars;
                }
                else
                {
                    if (File.Exists(DEFAULT_KEY_FILE))
                    {
                        uniqueKey = File.ReadAllText(DEFAULT_KEY_FILE);
                    }
                    if (uniqueKey.Length != maxChars)
                    {
                        uniqueKey = this.GenerateRandomKey(maxChars);
                        File.WriteAllText(DEFAULT_KEY_FILE, uniqueKey);
                    }
                }

                char[] charArray = (PASSWORD_CHARS_LCASE + PASSWORD_CHARS_UCASE + PASSWORD_CHARS_NUMERIC + (useSpecialChars ? PASSWORD_CHARS_SPECIAL : "")).ToCharArray();
                byte[] pass = Encoding.UTF8.GetBytes(value);
                byte[] salt = Encoding.UTF8.GetBytes(uniqueKey);
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(pass, salt, 2);
                byte[] keyBytes = key.GetBytes(BYTES_COUNT);
                int byteInChar = BYTES_COUNT / maxChars;

                string result = "";
                for (int i = 0; i < maxChars; i++)
                {
                    int newChar = 0;
                    for (int j = 0; j < byteInChar; j++)
                    {
                        newChar = newChar + keyBytes[(i * byteInChar) + j];
                    }
                    result += charArray[newChar % charArray.Length];
                }
                newPassword.Text = result;
            }
        }

        /// <summary>
        /// Copy password on text box click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (newPassword.Text.Length > 0)
            {
                Clipboard.SetText(newPassword.Text);
            }
        }

        /// <summary>
        /// On change key phrase regenerate password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyPhrase_TextChanged(object sender, EventArgs e)
        {
            this.GenerateNewPassword();
        }

        /// <summary>
        /// Add resource button handler (show resource editing form)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addResourceButton_Click(object sender, EventArgs e)
        {
            int maxChars = Convert.ToInt32(numChars.Value);
            ResourceForm resourceForm = new ResourceForm();
            resourceForm.SetUniqueKey(this.GenerateRandomKey(maxChars));
            resourceForm.ShowDialog(this);
        }

        /// <summary>
        /// Number of chars change handler (regenerate passowrd)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numChars_ValueChanged(object sender, EventArgs e)
        {
            this.GenerateNewPassword();
        }

        /// <summary>
        /// Use special characters check change handler (regenerate password)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNonAlphaNumericChars_CheckedChanged(object sender, EventArgs e)
        {
            this.GenerateNewPassword();
        }

        /// <summary>
        /// Edit resource button handler (show resource editing window)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editResourceButton_Click(object sender, EventArgs e)
        {
            int maxChars = Convert.ToInt32(numChars.Value);
            Resource resource = resourceSelect.SelectedItem as Resource;
            ResourceForm resourceForm = new ResourceForm(resource);
            resourceForm.ShowDialog(this);
        }

        /// <summary>
        /// On resource select (not default) generate password with specified resource unique key and special chars ovveride
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resourceSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resource resource = resourceSelect.SelectedItem as Resource;
            addNonAlphaNumericChars.Enabled = !(resource != null && resource.Id > 0);
            editResourceButton.Enabled = resource != null && resource.Id > 0;
            removeResourceButton.Enabled = resource != null && resource.Id > 0;
            this.GenerateNewPassword();
        }

        /// <summary>
        /// Remove resource handler (Delete resource from list)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeResourceButton_Click(object sender, EventArgs e)
        {
            Resource resource = resourceSelect.SelectedItem as Resource;
            List<Resource> newList = new List<Resource>();
            foreach (Resource res in this.resources)
            {
                if (resource.Id != res.Id)
                {
                    newList.Add(res);
                }
            }
            this.resources = newList;
            this.SaveResources();
        }
    }
}
