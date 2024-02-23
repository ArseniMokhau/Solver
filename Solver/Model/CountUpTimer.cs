using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Solver.Model
{
    public class CountUpTimer : INotifyPropertyChanged
    {
        private Timer _timer;
        private TimeSpan _elapsedTime;

        public event PropertyChangedEventHandler PropertyChanged;

        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
            set
            {
                _elapsedTime = value;
                OnPropertyChanged(nameof(ElapsedTime));
            }
        }

        public CountUpTimer()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += TimerElapsed;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            ElapsedTime = ElapsedTime.Add(TimeSpan.FromSeconds(1));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}