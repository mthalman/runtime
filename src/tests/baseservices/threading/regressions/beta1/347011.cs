// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading;
using Xunit;

public class TimerTest
{
    public static void Target(Object foo){}

    [Fact]
    public static int TestEntryPoint()
    {
        int retVal = 0;
        Timer timer = new Timer(new TimerCallback(Target),new Object(), 1000,1000);
        timer.Dispose();
        try
        {
            timer.Change(5000,5000);
            retVal = -5;
        }
        catch(ObjectDisposedException)
        {
            Console.WriteLine("Caught Expected exception");
            retVal = 100;
        }
        catch(Exception ex)
        {
            Console.WriteLine("Unexpected exception: " + ex.ToString());
            retVal = -1;
        }
        Console.WriteLine(100 == retVal ? "Test Passed":"Test Failed");
        return retVal;
    }
}
