using System;

namespace Raging.Toolbox.Time
{
    internal class TimeMachine : ITimeMachine
    {
        private Func<DateTime> nowFunc = () => DateTime.UtcNow;

        public DateTime Now
        {
            get { return this.nowFunc(); }
        }

        public void Customize(Func<DateTime> func)
        {
            Guard.Null(() => func);

            this.nowFunc = func;
        }

        public void TravelTo(DateTime date)
        {
            var whnStd = DateTime.UtcNow;

            this.nowFunc = () => date + (DateTime.UtcNow - whnStd);
        }

        public void FreezeTime(DateTime date)
        {
            this.nowFunc = () => date;
        }

        public void Reset()
        {
            this.nowFunc = () => DateTime.UtcNow;
        }
    }
}