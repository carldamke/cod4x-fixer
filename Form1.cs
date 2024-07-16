using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cod4x_fixer
{
    public partial class Form1 : Form
    {
        private string userSid;
        private string registryPath;

        public Form1()
        {
            InitializeComponent();
            LoadUserSid();
            LoadRegistryValue();
            LoadComboBox();
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
            var values = JsonConvert.DeserializeObject<string[]>(jsonData);
            comboBoxValues.Items.AddRange(values);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string selectedValue = comboBoxValues.SelectedItem?.ToString();
            if (selectedValue != null && selectedValue.Length == 20)
            {
                Registry.SetValue(registryPath, "codkey", selectedValue, RegistryValueKind.String);
                MessageBox.Show("Registry-Eintrag erfolgreich aktualisiert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRegistryValue();
            }
            else
            {
                MessageBox.Show("Bitte einen gültigen Wert auswählen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
