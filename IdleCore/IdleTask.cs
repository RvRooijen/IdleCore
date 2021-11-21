using System;

namespace IdleCore
{
    public class Task
    {
        private float _remainingTime;
        public float RemainingTime => _remainingTime;

        public EventHandler? OnCompletion;
        private EventArgs _args;

        public Task(float totalTime, EventHandler onCompletion, EventArgs args)
        {
            _args = args;
            _remainingTime = totalTime;
            OnCompletion += onCompletion;
        }

        public void Tick(float delta)
        {
            _remainingTime -= delta;
            if (_remainingTime <= 0)
            {
                OnCompletion?.Invoke(this, _args);
            }
        }
    }
}