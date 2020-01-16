using System;

namespace ProducerConsumer.Core
{
    public class Task
    {
        public int BeginnConsumtionTime { get; set; }
        public DateTime CreationTime { get; set; }
        public int TaskNumber { get; set; }

        public event EventHandler<Task> LogTask;

        public Task()
        {

        }


    }
}
