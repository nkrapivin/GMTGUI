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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Exe files (*.exe)|*.exe";
            var parser = new FileIniDataParser();
            if (File.Exists(Application.StartupPath + "\\GMTGUI.ini"))
            {
                IniData data = parser.ReadFile("GMTGUI.ini");
                string GMTLauncherPath = data["Main"]["GMTLauncherPath"];
                foreach (var key in data["GamesFriendlyNames"])
                {
                    int tempgamescount = listBox1.Items.Count;
                    listBox1.Items.Insert(tempgamescount, key.Value);
                }
            }
            else
            {
                File.CreateText(Application.StartupPath + "\\GMTGUI.ini").Close(); //Make an empty file. Or else IniParser will crash :(
                IniData data = parser.ReadFile("GMTGUI.ini"); // yes.
                MessageBox.Show(this,"Looks like it's the first time you're running GMTogether GUI.\nYou need to specify path to GMT-Launcher.exe","Oh no",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) //ask for GMT-Launcher.exe
                    return;
                string GMTLauncherPath = openFileDialog1.FileName;
                data["Main"]["GMTLauncherPath"] = GMTLauncherPath;
                parser.WriteFile("GMTGUI.ini", data);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            int tempgamescount = listBox1.Items.Count;
            listBox1.Items.Insert(tempgamescount, filename);
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("GMTGUI.ini");
            data["Games"]["Game"+tempgamescount.ToString()] = filename;
            data["GamesFriendlyNames"]["Game" + tempgamescount.ToString()] = filename; //by default FriendlyName equals filename, user can change that in "Configure Game"
            data["GamesIsWindowed"]["Game" + tempgamescount.ToString()] = "No";
            parser.WriteFile("GMTGUI.ini", data);
        }

        //Links to cool, dino approved(tm) resources.
        //*yes they are hardcoded, i don't think they'll ever change*
        private void GMTDocsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://yal.cc/r/19/gmt");
        }

        private void GMTDiscordLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://discord.gg/4e63T3W");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("GMTGUI.ini");
            string GMTLauncherPath = data["Main"]["GMTLauncherPath"];
            string GamePath = data["Games"]["Game" + listBox1.SelectedIndex];
            if (File.Exists(GMTLauncherPath))
            {
                if (File.Exists(GamePath))
                {
                    if (data["GamesIsWindowed"]["Game" + listBox1.SelectedIndex] == "No")
                    Process.Start(GMTLauncherPath, GamePath);
                    else
                    Process.Start(GMTLauncherPath, GamePath + " -inawindow"); // -inawindow makes GM:S game force windowed mode
                }
                else //game exe does not exist!
                {
                    MessageBox.Show(this, "Looks like your game exe stopped existing at the path you chose!\nYou need to specify a new path and try again!", "Oh no", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel) //ask for new game exe
                        return;
                    string newGamePath = openFileDialog1.FileName;
                    listBox1.Items[listBox1.SelectedIndex] = newGamePath;
                    data["Games"]["Game" + listBox1.SelectedIndex.ToString()] = newGamePath;
                    parser.WriteFile("GMTGUI.ini", data);
                }
            }
            else //for some reason GMT-Launcher.exe doesn't exist
            {
                MessageBox.Show(this, "Looks like GMT-Launcher.exe stopped existing at the path you chose.\nYou need to specify a new one and try again!", "Oh no", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel) //ask for GMT-Launcher.exe....... again
                    return;
                string NewGMTLauncherPath = openFileDialog1.FileName;
                data["Main"]["GMTLauncherPath"] = NewGMTLauncherPath; //change gmt launcher path to a new file
                parser.WriteFile("GMTGUI.ini", data);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedindex = listBox1.SelectedIndex;
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("GMTGUI.ini");
            List<string> tempgamepaths = new List<string>() { };
            List<string> tempfriendlynames = new List<string>() { };
            List<string> tempiswindowed = new List<string>() { };
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                tempgamepaths.Insert(i, data["Games"]["Game" + i.ToString()]);
                tempfriendlynames.Insert(i, data["GamesFriendlyNames"]["Game" + i.ToString()]);
                tempiswindowed.Insert(i, data["GamesIsWindowed"]["Game" + i.ToString()]);
            }
            tempgamepaths.RemoveAt(selectedindex);
            tempfriendlynames.RemoveAt(selectedindex);
            tempiswindowed.RemoveAt(selectedindex);
            data.Sections.RemoveSection("Games");
            data.Sections.RemoveSection("GamesFriendlyNames");
            data.Sections.RemoveSection("GamesIsWindowed");
            listBox1.Items.Clear();
            for (int i = 0; i < tempgamepaths.Count; i++ )
            {
                data["Games"]["Game" + i.ToString()] = tempgamepaths[i];
                data["GamesFriendlyNames"]["Game" + i.ToString()] = tempfriendlynames[i];
                data["GamesIsWindowed"]["Game" + i.ToString()] = tempiswindowed[i];
            }
            foreach (var key in data["GamesFriendlyNames"])
            {
                int tempgamescount = listBox1.Items.Count;
                listBox1.Items.Insert(tempgamescount, key.Value);
            }
            parser.WriteFile("GMTGUI.ini", data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Not yet implemented, sorry.");
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("GMTGUI.ini");
            data["Main"]["LastSelectedGame"] = listBox1.SelectedIndex.ToString();
            parser.WriteFile("GMTGUI.ini", data);
            GameOptionsForm settingsForm = new GameOptionsForm();
            settingsForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e) //most elegant solution
        {
            if (GMTGUI.UpdateVar.UpdateMainFormOrWut)
            {
                GMTGUI.UpdateVar.UpdateMainFormOrWut = false;
                listBox1.Items.Clear();
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("GMTGUI.ini");
                string GMTLauncherPath = data["Main"]["GMTLauncherPath"];
                foreach (var key in data["GamesFriendlyNames"])
                {
                    int tempgamescount = listBox1.Items.Count;
                    listBox1.Items.Insert(tempgamescount, key.Value);
                }
            }
        }

    }
}
