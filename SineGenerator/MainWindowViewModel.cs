using System;
using System.ComponentModel;
using System.Windows.Input;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace SineGenerator
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private IWavePlayer player;
        private readonly SineWaveProvider sineProvider;

        public ICommand PlayCommand { get; private set; }
        public ICommand PauseCommand { get; private set; }
        public ICommand StopCommand { get; private set; }

        public float Volume
        {
            get { return sineProvider.Volume; }
            set
            {
                if (sineProvider.Volume == value)
                    return;
                sineProvider.Volume = value;
                OnPropertyChanged("Volume");
                OnPropertyChanged("VolumeLabel");
            }
        }

        public string VolumeLabel => $"{(int) (Volume*100.0)}%";

        public string FrequencyLabel => $"{(int) Frequency}Hz";

        public double Frequency
        {
            get { return sineProvider.Frequency; }
            set
            {
                if (sineProvider.Frequency == value)
                    return;
                sineProvider.Frequency = value;
                OnPropertyChanged("Frequency");
                OnPropertyChanged("FrequencyLabel");
            }
        }


        public MainWindowViewModel()
        {
            PlayCommand = new RelayCommand(Play);
            PauseCommand = new RelayCommand(Pause);
            StopCommand = new RelayCommand(Stop);
            sineProvider = new SineWaveProvider();
        }


        private void Play()
        {
            if (player == null)
            {
                var waveOutEvent = new WaveOutEvent();
                waveOutEvent.NumberOfBuffers = 2;
                waveOutEvent.DesiredLatency = 100;
                player = waveOutEvent;
                player.Init(new SampleToWaveProvider(sineProvider));
            }
            player.Play();
        }

        private void Stop()
        {
            if (player == null)
                return;
            player.Dispose();
            player = null;
        }

        private void Pause()
        {
            player?.Pause();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

