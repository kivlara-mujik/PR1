using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Data;
public class Example
{
    // A semaphore that simulates a limited resource pool.
    //
    private static Semaphore _pool;
    // A padding interval to make the output more orderly.
    private static int _padding;
    static CountdownEvent _countdown = new CountdownEvent(1);
    static CountdownEvent _countdown2 = new CountdownEvent(1);
    static CountdownEvent _countdown3 = new CountdownEvent(1);
    static CountdownEvent _countdown4 = new CountdownEvent(1);
    static CountdownEvent _countdown5 = new CountdownEvent(1);
    static CountdownEvent _countdown6 = new CountdownEvent(1);
    public static void Main()
    {
        Example F1 = new Example();
        Example F2 = new Example();
        Example F3 = new Example();
        Example F4 = new Example();
        Example F5 = new Example();
        Example F6 = new Example();
        Example F7 = new Example();
        Thread tid1 = new Thread(new ThreadStart(F1.T1));
        Thread tid2 = new Thread(new ThreadStart(F2.T2));
        Thread tid3 = new Thread(new ThreadStart(F3.T3));
        Thread tid4 = new Thread(new ThreadStart(F4.T4));
        Thread tid5 = new Thread(new ThreadStart(F5.T5));
        Thread tid6 = new Thread(new ThreadStart(F6.T6));
        Thread tid7 = new Thread(new ThreadStart(F7.T7));
        tid1.Name = "Thread 1";
        tid2.Name = "Thread 2";
        tid3.Name = "Thread 3";
        tid4.Name = "Thread 4";
        tid5.Name = "Thread 5";
        tid6.Name = "Thread 6";
        tid7.Name = "Thread 7";
        tid1.Start();
        tid2.Start();
        tid3.Start();
        tid4.Start();
        tid5.Start();
        tid6.Start();
        tid7.Start();
        Console.ReadKey();
    }
    public void T1()
    {
        Thread F = Thread.CurrentThread;
        Console.WriteLine(F.Name);
        _countdown.Signal();
    }
    public void T2()
    {
        _countdown.Wait();
        Thread F = Thread.CurrentThread;
        Console.WriteLine(F.Name);
        _countdown2.Signal();
    }
    public void T3()
    {
        _countdown.Wait();
        Thread F = Thread.CurrentThread;
        Console.WriteLine(F.Name);
        _countdown3.Signal();
    }

    public void T5()
    {
        _countdown2.Wait();
        Thread F = Thread.CurrentThread;
        Console.WriteLine(F.Name);
       
    }
    public void T6()
    {
        _countdown2.Wait();
        Thread F = Thread.CurrentThread;
        Console.WriteLine(F.Name);
       
    }
    public void T4()
    {
        _countdown3.Wait();
        Thread F = Thread.CurrentThread;
        Console.WriteLine(F.Name);
        
    }
    public void T7()
    {
        _countdown3.Wait();
        Thread F = Thread.CurrentThread;
        Console.WriteLine(F.Name);
        
    }
   
}