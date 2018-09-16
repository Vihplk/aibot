using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBot.Game.Logic
{
    public class Sound
    {
        public static void Play()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = @"E:\projects\Bot\AIBot\AIBot.Game\AIBot.Game\SoundClip\start.mp3";
            wplayer.controls.play();
        }

    }
}
