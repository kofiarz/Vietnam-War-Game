using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    public class Music
    {
        public void Playmusic()
        {
            if (OperatingSystem.IsWindows()) //https://www.youtube.com/watch?v=wAYN2BABnG0 Credits: Creedence Clearwater Revival
            {
                SoundPlayer player = new SoundPlayer("Fortunate Son.wav");
                player.Load();
                player.PlayLooping();
            }
        }
    }
}
