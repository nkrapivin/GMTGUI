using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

// INI config lib
using System.IO;
using IniParser;
using IniParser.Model;

namespace GMTGUI
{
    public partial class GameOptionsForm : Form
    {
        public int GameIndex { get; set; }

        public GameOptionsForm()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Exe files (*.exe)|*.exe";
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("GMTGUI.ini");
            GameIndex = Convert.ToInt32(data["Main"]["LastSelectedGame"]);
            textBox1.Text = data["Games"]["Game" + GameIndex];
            textBox2.Text = data["GamesFriendlyNames"]["Game" + GameIndex];
            if (data["GamesIsWindowed"]["Game" + GameIndex] == "Yes")
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) //ask for new game exe
                return;
            string newGamePath = openFileDialog1.FileName;
            textBox1.Text = newGamePath;
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("GMTGUI.ini");
            data["Games"]["Game" + GameIndex] = newGamePath;
            parser.WriteFile("GMTGUI.ini", data);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("GMTGUI.ini");
            if (checkBox1.Checked) data["GamesIsWindowed"]["Game" + GameIndex] = "Yes";
            else data["GamesIsWindowed"]["Game" + GameIndex] = "No";
            data["GamesFriendlyNames"]["Game" + GameIndex] = textBox2.Text;
            parser.WriteFile("GMTGUI.ini", data);
            Close();
            GMTGUI.UpdateVar.UpdateMainFormOrWut = true;
            //GameIndex = 0;
        }

    }
}
