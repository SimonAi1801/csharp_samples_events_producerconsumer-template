using System;
using System.Collections.Generic;

namespace ProducerConsumer.Core
{
    public class Producer
    {
        int _taskNumber;
        readonly Random _random;
        readonly int _minDuration;
        readonly int _maxDuration;
        int _minutesToNextProduction;
        private EventHandler<String> _logTask;
        private Queue<Task> _tasks;

        /// <summary>
        /// Es wird innerhalb der von minDuration und maxDuration
        /// ein neues Element erzeugt.
        /// </summary>
        /// <param name="minDuration">Minimale Dauer in Minuten</param>
        /// <param name="maxDuration">Maximale Dauer in Minuten</param>
        /// <param name="logTask"></param>
        public Producer(int minDuration, int maxDuration, EventHandler<String> logTask, Queue<Task> tasks )
        {
            _tasks = tasks;
            _taskNumber = 0;
            _minDuration = minDuration;
            _maxDuration = maxDuration;
            FastClock.Instance.OneMinuteIsOver += Instance_OneMinuteIsOver;
            _random = new Random();
            _minutesToNextProduction = _random.Next(minDuration, maxDuration + 1);
            _logTask = logTask;
        }

        /// <summary>
        /// Auf der schnell laufenden Uhr ist eine Minute vergangen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Instance_OneMinuteIsOver(object sender, DateTime e)
        {
            _minutesToNextProduction--;
            if (_minutesToNextProduction == 0)  // Wartezeit abgelaufen
            {
                var task = new Task(_taskNumber);
                task.LogTask += _logTask;
                _tasks.Enqueue(task);
                task.Create();
                _taskNumber++;
                _minutesToNextProduction = _random.Next(_minDuration, _maxDuration + 1);
            }
        }

    }
}
