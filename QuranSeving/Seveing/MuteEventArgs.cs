using System;

namespace QuranSeving.Seveing
{
    public class MuteEventArgs : EventArgs
    {
        public MuteEventArgs(bool muted)
        {
            Muted = muted;
        }

        public bool Muted { get; private set; }
    }
}
