using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTAV_radio_stations
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// --All Components In Forms
        /// form1 is named "mediaPlayer"
        /// pictureBox is named "radioPicture": is used to display station color 
        /// trackbar1 is named "volumeSlider":  is used for changing volume
        /// 
        ///
        /// --All variables
        ///baseDirPath: used to find directories 
        ///stations: used to determine stations
        ///volume: volume of player
        ///songsList: get all songs from a station
        ///songPlayer: play song from !songsList!
        ///speachList: get all of the DJ's speach
        ///speachPlayer: play sound from !speachList!
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mediaPlayer());
        }
    }
}
