using System;
using System.ComponentModel.Composition;

namespace MainHost
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ImportConstructor : ImportAttribute
    {

    }
}
