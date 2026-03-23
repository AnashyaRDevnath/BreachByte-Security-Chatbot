using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace BreachByte_SecurityBot
{
    public class AudioPlayer
    {
        public void PlayVoiceGreeting()
        {
            SoundPlayer voiceGreeting = new SoundPlayer("VoiceGreeting.wav");
            voiceGreeting.PlaySync();
        } 



    }
}
