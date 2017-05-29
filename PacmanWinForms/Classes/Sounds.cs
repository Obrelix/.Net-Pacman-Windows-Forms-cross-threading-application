using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace PacmanWinForms
{
    public enum Streams : byte
    {
        EATDOT = 1,
    }

    
    public  class Sounds
    {
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);


        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        private uint CurrVol;
        private int volume;

        MediaPlayer BG, wakawaka, p1, p2;//, eatGhostEffect, eatGhostEffectBG, dies, fruit, live, win, bonus;

        public PlaySample receiveSound;

        public Sounds()
        {
            // By the default set the volume to 0
            CurrVol = 0;
            // At this point, CurrVol gets assigned the volume
            waveOutGetVolume(IntPtr.Zero, out CurrVol);
            // Calculate the volume
            volume = (ushort)(CurrVol & 0x0000ffff) / (ushort.MaxValue / 10);

            //string path = Path.GetFullPath("siren.wav");

            wakawaka = new MediaPlayer();
            wakawaka.MediaEnded += new EventHandler(Media_EndedWaka);
            wakawaka.Position = TimeSpan.Zero;

            BG = new MediaPlayer();
            BG.MediaEnded += new EventHandler(Media_EndedBG);
           

            //p1 = new MediaPlayer();
            //p1.MediaEnded += new EventHandler(Media_Ended1);
           
            //p2 = new MediaPlayer();
            //p2.MediaEnded += new EventHandler(Media_Ended2);
            //p2.Open(new System.Uri(@"C:\Users\tataki\Source\Repos\Pacman\sounds\Original Sounds\dot12.wav"));
            //p2.Position = TimeSpan.Zero;
            //p2.Play();
            setVolume(10);

        }

        public void playBackground(int state, bool stop)
        {

            //new System.Threading.Thread(() => {
            //    var c = new System.Windows.Media.MediaPlayer();
            //    c.Open(new System.Uri(@"C:\windows\media\tada.wav"));
            //    c.MediaEnded += new EventHandler((object sender, EventArgs e) => {
            //        c.Position = TimeSpan.Zero;
            //        c.Play();
            //    });
            //    c.Play();
            //}).Start();
            //string appPath = Environment.
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
            switch (state)
            {
                case 1:
                    BG.Open(new Uri(Path.Combine(path, "siren.wav")));
                    break;
                case 2:
                    BG.Open(new Uri(@"C:\Users\tataki\Source\Repos\Pacman\sounds\Original Sounds\siren.wav"));
                    break;
                case 3:
                    BG.Open(new Uri(@"C:\Users\tataki\Source\Repos\Pacman\sounds\Original Sounds\siren.wav"));
                    break;
                case 4:
                    BG.Open(new Uri(@"C:\Users\tataki\Source\Repos\Pacman\sounds\Original Sounds\siren.wav"));
                    break;
            }

            BG.Position = TimeSpan.Zero;
            //if (!stop) BG.Play();
            //else BG.Stop();
        }
        public void eatDot(bool stop)
        {
           // mySound(stop);
        }

        public void playIntro()
        {

        }
        bool wakaEnd = true;
        public void playWaka(bool stop)
        {
            //if (wakawaka.Position == TimeSpan.Zero)
            //{
            if (wakaEnd)
            {
                wakaEnd = false;
                wakawaka.Open(new Uri(@"C:\Users\tataki\Source\Repos\Pacman\sounds\Original Sounds\06.wav"));
                //wakawaka.Play();
            }
            //}
        }

        public void setVolume(int volume)
        {
            // Calculate the volume that's being set. BTW: this is a trackbar!
            int NewVolume = ((ushort.MaxValue / 10) * volume);
            // Set the same volume for both the left and the right channels
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }


        private void Media_EndedBG(object sender, EventArgs e)
        {
            BG.Position = TimeSpan.Zero;
            BG.Play();
        }
        private void Media_EndedWaka(object sender, EventArgs e)
        {

            wakaEnd = true;
            //wakawaka.Position = TimeSpan.Zero;
            //wakawaka.Play();
        }

        private void Media_Ended1(object sender, EventArgs e)
        {
            p1.Position = TimeSpan.Zero;
            p1.Play();
        }
        private void Media_Ended2(object sender, EventArgs e)
        {
            p2.Position = TimeSpan.Zero;
            p2.Play();
        }

    }
}
