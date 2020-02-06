using System;

namespace QuranSeving.Seveing
{
    public class VolumeEventArgs : EventArgs
    {
        public VolumeEventArgs(float volume)
        {
            Volume = volume;
        }

        public float Volume { get; private set; }
    }
}
