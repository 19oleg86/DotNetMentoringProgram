﻿using System;
using System.ComponentModel.Composition;

namespace Plugins
{
    [Export]
    public class Logger
    {
        public void LoggerMethod()
        {
            Console.WriteLine("Message from Logger");
        }
    }
}