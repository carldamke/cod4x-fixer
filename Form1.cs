using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace cod4x_fixer
{
    public partial class Form1 : Form
    {
        private string userSid;
        private string registryPath;
        private List<KeyData> keyDataList;

        public Form1()
        {
            InitializeComponent();
            LoadUserSid();
            LoadRegistryValue();
            LoadComboBox();

            Icon = new Icon("cod4.ico");
        }

        private void LoadUserSid()
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            userSid = currentUser.User?.Value;
            registryPath = $"HKEY_USERS\\{userSid}\\SOFTWARE\\Activision\\Call of Duty 4";
        }

        private void LoadRegistryValue()
        {
            string codKey = (string)Registry.GetValue(registryPath, "codkey", null);
            textBoxCodKey.Text = codKey;
        }

        private void LoadComboBox()
        {
            string jsonFilePath = "keys.json";
            var jsonData = File.ReadAllText(jsonFilePath);
            keyDataList = JsonConvert.DeserializeObject<List<KeyData>>(jsonData);

            comboBoxValues.Items.Clear();
            comboBoxValues.Items.AddRange(keyDataList.ToArray());
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (comboBoxValues.SelectedItem is KeyData selectedKeyData && selectedKeyData.Key.Length == 20)
            {
                Registry.SetValue(registryPath, "codkey", selectedKeyData.Key, RegistryValueKind.String);
                UpdateJsonFile(selectedKeyData.Key);
                MessageBox.Show("Registry-Eintrag wurde aktualisiert.");
                LoadRegistryValue();
                LoadComboBox();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen gültigen Key aus.");
            }
        }

        private void UpdateJsonFile(string selectedKey)
        {
            string jsonFilePath = "keys.json";
            foreach (var keyData in keyDataList)
            {
                if (keyData.Key == selectedKey)
                {
                    keyData.User = Environment.UserName;
                    break;
                }
            }
            File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(keyDataList, Formatting.Indented));
        }
    }
}
