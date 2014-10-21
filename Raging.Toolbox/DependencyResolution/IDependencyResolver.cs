﻿using System;
using System.Collections.Generic;

namespace Raging.Toolbox.DependencyResolution
{
    public interface IDependencyResolver
    {
        TService Resolve<TService>() where TService : class;

        IEnumerable<TService> ResolveAll<TService>() where TService : class;

        object Resolve(Type serviceType);

        IEnumerable<object> ResolveAll(Type serviceType);
    }
}