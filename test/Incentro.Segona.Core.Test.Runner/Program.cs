using System;
using System.Reflection;
using NUnit.Common;
using NUnitLite;

namespace Incentro.Segona.Core.Test.Runner
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return new AutoRun(typeof(TestBase).GetTypeInfo().Assembly)
                .Execute(args, new ExtendedTextWrapper(Console.Out), Console.In);
        }
    }
}
