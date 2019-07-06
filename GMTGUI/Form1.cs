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
                foreach (var key in data["Games"])
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
            parser.WriteFile("GMTGUI.ini", data);
        }

        //Links to cool, dino approved(tm) resources.
        private void GMTDocsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://yal.cc/r/19/gmt");
        }

        private void GMTDiscordLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/4e63T3W");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("GMTGUI.ini");
            string GMTLauncherPath = data["Main"]["GMTLauncherPath"];
            if (File.Exists(GMTLauncherPath))
            {
                if (File.Exists(listBox1.SelectedItem.ToString()))
                {
                    Process.Start(GMTLauncherPath, listBox1.SelectedItem.ToString());
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox1.SetSelected(listBox1.SelectedIndex, true);
            // NO!
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedindex = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(selectedindex);
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("GMTGUI.ini");
            data.Sections.RemoveSection("Games");
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                data["Games"]["Game" + i.ToString()] = listBox1.Items[i].ToString(); //I know it's terrible.
            }
            parser.WriteFile("GMTGUI.ini", data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented, sorry.");
        }
    }
}
