﻿using System;

namespace Raging.Toolbox.Time
{
    public interface ITimeMachine
    {
        DateTime Now { get; }

        DateTime Today { get; }

        void Customize(Func<DateTime> dateFunc);

        void TravelTo(DateTime date);

        void FreezeTime(DateTime date);

        void Reset();
    }
}