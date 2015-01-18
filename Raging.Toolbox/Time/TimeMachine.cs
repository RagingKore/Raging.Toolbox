using System;

namespace Raging.Toolbox.Time
{
    internal class UniversalTimeMachine : ITimeMachine
    {
        private Func<DateTime> nowFunc = () => DateTime.UtcNow;

        public DateTime Now
        {
            get { return this.nowFunc(); }
        }

        public DateTime Today
        {
            get { return this.nowFunc().Date; }
        }

        public void Customize(Func<DateTime> func)
        {
            Guard.Null(() => func, func);

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