using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace GTAV_radio_stations
{
    public partial class mediaPlayer : Form
    {

        string baseDirPath = AppDomain.CurrentDomain.BaseDirectory; //gets this path "C:\Users\fscho\Documents\GitHub\My-C-sharp-repo\winForms\GTAV radio stations\bin\Debug\"
        string station; //determines the station thats playing
        int volume; // value of the player volume
        int counter = 0;

        //create a rnd var
        Random rnd = new Random();

        //these are for songs
        List<string> songsList;
        WindowsMediaPlayer songPlayer;

        //these are for the DJ speach
        List<string> speachList;
        List<string> djLoreList;
        WindowsMediaPlayer speachPlayer;

        //start
        public mediaPlayer()
        {
            InitializeComponent();//basic stuff

            //import sound files
            LoadSoundFiles(Path.Combine(baseDirPath, "res", "sound", "songs"), ref songsList);
            LoadSoundFiles(Path.Combine(baseDirPath, "res", "sound", "speach", "b4music"), ref speachList);
            LoadSoundFiles(Path.Combine(baseDirPath, "res", "sound", "speach", "djlore"), ref djLoreList);

            //declare media players
            songPlayer = new WindowsMediaPlayer();
            songPlayer.PlayStateChange += Player1_PlayStateChange;
            speachPlayer = new WindowsMediaPlayer();
            speachPlayer.PlayStateChange += Player2_PlayStateChange;


            //change default volume
            ChangeVolume();

            //start playback
            PlayRadio();
        }
        private void PlayRadio()
        {
            //speachPlayer.URL = djLoreList[counter++]; experimental
            
            //initialize bs
            int rndIndex = rnd.Next(0, songsList.Count);
            List<string> tempList = new List<string>();

            if(songsList.Count<0) LoadSoundFiles(Path.Combine(baseDirPath, "res", "sound", "songs"), ref songsList);//if song run out load new ones
            for (int i = 0; i < speachList.Count; i++)
            {
                //get all intro to songs 
                if (CompareUntilChar(Path.GetFileName(songsList[rndIndex]),Path.GetFileName(speachList[i])))
                {
                    tempList.Add(speachList[i]);
                }
            }

            //play song and remove so no repeats
            songPlayer = new WindowsMediaPlayer();
            songPlayer.URL = songsList[rndIndex];
            songPlayer.PlayStateChange += Player1_PlayStateChange;
            songsList.RemoveAt(rndIndex);

            //play intro to song
            speachPlayer = new WindowsMediaPlayer();
            speachPlayer.URL = tempList.Count == 0 ? null : tempList[rnd.Next(0, tempList.Count)];
            speachPlayer.PlayStateChange += Player2_PlayStateChange;
            ChangeVolume();
        }

        //change volume to volumeSlider value
        private void volumeSlider_Scroll(object sender, EventArgs e)
        {
            ChangeVolume();
        }
        private void ChangeVolume()
        {
            volume = volumeSlider.Value;
            songPlayer.settings.volume = volume;
            speachPlayer.settings.volume = volume;
        }

        //load files into a list
        private void LoadSoundFiles(string folderPath, ref List<string> target)
        {
            //try to add files to the target
            try
            {
                target = Directory.GetFiles(folderPath, "*.wav").ToList();
            }
            //write error msg
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //compare first word
        private bool CompareUntilChar(string str1, string str2)
        {
            //find position where first word ends
            int index1 = str1.IndexOf('_');
            int index2 = str2.IndexOf('_');

            // create substrings of the first word
            string substr1 = str1.Substring(0, index1);
            string substr2 = str2.Substring(0, index2);

            //if first word equal then return true
            return substr1.Equals(substr2);
        }

        //event for changing !songPlayer!
        private void Player1_PlayStateChange(int NewState)
        {
            if ((WMPPlayState)NewState == WMPPlayState.wmppsMediaEnded)
            {
                PlayRadio();
            }
        }
        private void Player2_PlayStateChange(int NewState)
        {
            if ((WMPPlayState)NewState == WMPPlayState.wmppsReady)
            {
            }
        }
    }
}
