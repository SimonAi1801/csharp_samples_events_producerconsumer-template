using System;
using System.Collections.Generic;

namespace ProducerConsumer.Core
{
    public class Consumer
    {
        readonly Random _random;
        readonly int _minDuration;
        readonly int _maxDuration;
        int _minutesToFinishConsumption;
        private readonly Queue<Task> _tasks;
        private Task _currentTask;

        /// <summary>
        /// Es wird innerhalb von minDuration und maxDuration
        /// ein Element verarbeitet.
        /// </summary>
        /// <param name="minDuration">Minimale Dauer in Minuten</param>
        /// <param name="maxDuration">Maximale Dauer in Minuten</param>
        public Consumer(int minDuration, int maxDuration, Queue<Task> tasks)
        {
            _tasks = tasks;
            _minDuration = minDuration;
            _maxDuration = maxDuration;
            FastClock.Instance.OneMinuteIsOver += Instance_OneMinuteIsOver;
            _random = new Random();
        }

        private void Instance_OneMinuteIsOver(object sender, DateTime e)
        {
            if (IsBusy)
            {
                _minutesToFinishConsumption--;
                if (_minutesToFinishConsumption == 0) // Bearbeitungszeit ist abgelaufen ==> Item verarbeitet
                {
                    _currentTask.Finish();
                    _currentTask = null;
                }
            }
            else
            {
                if (_tasks.Count > 0)
                {
                    _currentTask = _tasks.Dequeue();
                    _minutesToFinishConsumption = _random.Next(_minDuration, _maxDuration + 1);
                    _currentTask.BeginConsumption();
                }
            }
        }

        /// <summary>
        /// Arbeitet der Verbraucher gerade?
        /// </summary>
        public bool IsBusy {
            get { return _currentTask != null; }
        }

    }
}
