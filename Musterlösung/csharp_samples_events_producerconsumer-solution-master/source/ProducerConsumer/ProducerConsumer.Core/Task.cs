using System;

namespace ProducerConsumer.Core
{
    public class Task
    {
        public event EventHandler<String> LogTask;

        public DateTime CreationTime { get; private set; }
        public DateTime BeginConsumptionTime { get; private set; }

        public Task(int taskNumber)
        {
            TaskNumber = taskNumber;
            CreationTime = FastClock.Instance.Time;
        }

        public int TaskNumber { get; }

        public void Finish()
        {
            LogTask?.Invoke(this, $"Task {TaskNumber} wurde um {CreationTime.ToShortTimeString()} erzeugt und von {BeginConsumptionTime.ToShortTimeString()} - {FastClock.Instance.Time.ToShortTimeString()} bearbeitet!");
        }

        public void BeginConsumption()
        {
            LogTask?.Invoke(this, $"Task {TaskNumber} wird bearbeitet!");
            BeginConsumptionTime = FastClock.Instance.Time;
        }

        public void Create()
        {
            LogTask?.Invoke(this, $"Task {TaskNumber} erzeugt!");
        }
    }
}
