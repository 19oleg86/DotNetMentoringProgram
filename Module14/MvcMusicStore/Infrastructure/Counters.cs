using PerformanceCounterHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Infrastructure
{
    [PerformanceCounterCategory("MvcMusicStore", System.Diagnostics.PerformanceCounterCategoryType.MultiInstance, "MvcMusic Store Info")]
    public enum Counters
    {
        [PerformanceCounter("Go to Home count", "Go to Home Info", System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        GoToHome,
        [PerformanceCounter("Successful Log In count", "Successful Log In Info", System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        SuccessLogIn,
        [PerformanceCounter("Successful Log Off count", "Successful Log Off Info", System.Diagnostics.PerformanceCounterType.NumberOfItems32)]
        successLogOff
    }
}