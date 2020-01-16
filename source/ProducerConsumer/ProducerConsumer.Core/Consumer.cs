using System;
using System.Collections.Generic;

namespace ProducerConsumer.Core
{
    public class Consumer
    {
        private Task _currentTask;
        private int _maxDuration;
        private int _minDuration;
        private int _minutesToFinishConsumption;
        private Random _random;

        public Consumer(int min, int max, Task currentTask)
        {
            _minDuration = min;
            _maxDuration = max;
            _currentTask = currentTask;
        }


    }
}
