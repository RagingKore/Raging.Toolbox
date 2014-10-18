using System.ComponentModel;

namespace Raging.Toolbox.Time
{
    public static class SystemTime
    {
        private static ITimeMachine timeMachine = new TimeMachine();

        public static System.DateTime Now
        {
            get { return timeMachine.Now.ToLocalTime(); }
        }

        public static System.DateTime UtcNow
        {
            get { return timeMachine.Now; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ITimeMachine TimeMachine
        {
            get { return timeMachine; }
            set { timeMachine = value ?? timeMachine; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Reset()
        {
            timeMachine = new TimeMachine();
        }
    }
}