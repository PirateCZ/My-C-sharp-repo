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
using System.Runtime.CompilerServices;

namespace GTA_radio
{

    public partial class Form1 : Form
    {
        private WindowsMediaPlayer songPlayer;
        private WindowsMediaPlayer yapPlayer;
        private List<string> songs;
        private List<string> preYap;
        private Random rnd;
        private string directoryPath = @"C:\Users\fscho\source\repos\GTA radio\GTA radio\res\music\song\";
        private int volume;
        public Form1()
        {
            //declare all needed variables
            InitializeComponent();
            LoadMusicFiles(directoryPath, ref songs);
            LoadMusicFiles(@"C:\Users\fscho\source\repos\GTA radio\GTA radio\res\music\yap\pre\", ref preYap);
            volume = trackBar1.Value;
            songPlayer = new WindowsMediaPlayer();
            songPlayer.PlayStateChange += Player1_PlayStateChange;
            yapPlayer = new WindowsMediaPlayer();
            yapPlayer.PlayStateChange += Player2_PlayStateChange;
            rnd = new Random();
            PlayRadio();
        }

        //this block loads the music from !folderPath! into !target!
        private void LoadMusicFiles(string folderPath, ref List<string> target)
        {
            try
            {
                target = Directory.GetFiles(folderPath, "*.wav").ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //this block plays another song from !songs!
        private void PlayRadio()
        {
            if (songs.Count > 0)
            {
                int rndIndexForMusic = rnd.Next(0, songs.Count);
                List<string> yapList = new List<string>();
                songPlayer.URL = songs[rndIndexForMusic];
                for(int i = 0; i < preYap.Count; i++)
                {
                    if(CompareStringsUntilChar(Path.GetFileName(songs[rndIndexForMusic]), Path.GetFileName(preYap[i])))
                    {

                        yapPlayer.URL = preYap[i];
                        return;
                    }
                }
                yapPlayer.URL = yapList[rnd.Next(0, yapList.Count)];
                songs.RemoveAt(rndIndexForMusic);
                songPlayer.controls.play();
            }
            else
            {
                Console.WriteLine("ERROR, no more songs to play");
                return;
            }
        }

        //this changes volume
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            volume = trackBar1.Value;
            songPlayer.settings.volume = volume;
            yapPlayer.settings.volume = volume;
        }

        //event for changing state
        private void Player1_PlayStateChange(int NewState)
        {
            if ((WMPPlayState)NewState == WMPPlayState.wmppsMediaEnded)
            {
                songPlayer = new WindowsMediaPlayer();
                songPlayer.PlayStateChange += Player1_PlayStateChange;
                songPlayer.settings.volume = volume;
                PlayRadio();
            }
        }
        private void Player2_PlayStateChange(int NewState)
        {
            if ((WMPPlayState)NewState == WMPPlayState.wmppsReady)
            {
                songPlayer.settings.volume = volume - 40;
                for(int i = 0; i < 40; i++)
                {
                    for (int j = 0; j < 1000000000; i++) ;
                    songPlayer.settings.volume += 1;  
                }
            }

            if ((WMPPlayState)NewState == WMPPlayState.wmppsMediaEnded)
            {

            }
        }
        private void Transition()
        {
            songPlayer.controls.stop();
            Console.WriteLine("niga");
        }


        //chatGPT ahh code
        private bool CompareStringsUntilChar(string str1, string str2)
        {
            // Find the position of the stopChar in both strings
            int index1 = str1.IndexOf('_');
            int index2 = str2.IndexOf('_');

            // If stopChar is not found in either string, compare the full strings
            if (index1 == -1) index1 = str1.Length;
            if (index2 == -1) index2 = str2.Length;

            // Extract the substrings up to the position of stopChar
            string substr1 = str1.Substring(0, index1);
            string substr2 = str2.Substring(0, index2);

            // Compare the substrings
            return substr1.Equals(substr2);
        }

        /*
        stop music
        play transition
        add event to play once transitions is done
        in event rnd chance to play next song or continue transition
         
         */
    }
}