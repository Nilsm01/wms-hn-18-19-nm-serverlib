using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerLib.GUI
{
    public partial class AddFileDialog : MetroFramework.Forms.MetroForm
    {
        public AddFileDialog()
        {
            InitializeComponent();
        }

        private void AddFileDialog_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 7; i++)
            {
                MetaData.Template.MetaKategory k = (MetaData.Template.MetaKategory)i;                
                metroComboBox1.Items.Add(k.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && System.IO.File.Exists(textBox1.Text) && textBox2.Text != string.Empty && textBox3.Text != string.Empty && metroComboBox1.SelectedItem != null)
            {
                FileManager.DirectoryAvailabilityChecker.CheckDirectories();
                MetaData.MetaFiles.Create(textBox3.Text, textBox3.Text, textBox2.Text, (MetaData.Template.MetaKategory)metroComboBox1.SelectedIndex);
                System.IO.File.Copy(textBox1.Text, Environment.CurrentDirectory + "\\Files\\" + textBox3.Text + ".mp3");
            }
            else
            {
                MessageBox.Show("Unbgültige Eingabe! Überprüfen sie nochmals alle Eingabefelder.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                this.Text = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            }
        }
    }
}
