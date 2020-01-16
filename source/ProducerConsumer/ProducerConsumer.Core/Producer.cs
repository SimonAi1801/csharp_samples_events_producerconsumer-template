using System;
using System.Collections.Generic;

namespace ProducerConsumer.Core
{
    public class Producer
    {
        private readonly Queue<Task> _tasks = new Queue<Task>();
        private readonly Random _random = new Random();
        private int _maxDuration;
        private int _minDuration;
        private int _taskNumber;
        private FastClock _instance;

        public bool IsBusy { get; set; }

        public Producer(int min, int max, Queue<Task> tasks)
        {
            _minDuration = min;
            _maxDuration = max;
            //_logTask = tasks;
        }
        

    }
}
