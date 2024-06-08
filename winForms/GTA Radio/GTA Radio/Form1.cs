using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WMPLib;

namespace GTA_Radio
{
    public partial class Form1 : Form
    {
        private List<string> musicFiles;
        private WindowsMediaPlayer player;
        private Random rnd;


        public Form1()
        {
            InitializeComponent();
            LoadMusicFiles(@"C:\Users\fscho\Documents\test"); // Replace with your folder path
            player = new WindowsMediaPlayer();
            rnd = new Random();
            player.URL = musicFiles[rnd.Next(0,musicFiles.Count)];
            player.controls.play();


        }
        private void LoadMusicFiles(string folderPath)
        {
            try
            {
                musicFiles = Directory.GetFiles(folderPath, "*.wav").ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading music files: {ex.Message}");
            }
        }
    }
}
