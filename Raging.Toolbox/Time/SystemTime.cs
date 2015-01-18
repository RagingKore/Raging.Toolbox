using System;

namespace Raging.Toolbox.Time
{
    public static class SystemTime
    {
        private static AmbientSingleton<ITimeMachine> singleton;

        static SystemTime()
        {
            singleton = AmbientSingleton.Create(new UniversalTimeMachine() as ITimeMachine);
        }

        public static DateTime Now
        {
            get { return singleton.Value.Now; }
        }

        public static DateTime Today
        {
            get { return singleton.Value.Today; }
        }

        public static void Customize(Func<DateTime> customizeFunc)
        {
            singleton.Value.Customize(customizeFunc);
        }

        public static void TravelTo(DateTime date)
        {
            singleton.Value.TravelTo(date);
        }

        public static void FreezeTime(DateTime date)
        {
            singleton.Value.FreezeTime(date);
        }

        public static void Reset()
        {
            singleton.Value.Reset();
        }

        public static ITimeMachine SetFactory(Func<ITimeMachine> factory)
        {
            return (singleton = AmbientSingleton.Create(factory())).Value;
        }
    }
}