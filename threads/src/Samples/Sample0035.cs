using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{

    /**
     * В этом примере пытаемся типизировать входящие параметры потока в связке с ParameterizedThreadStart
     */
    public static class Sample0035
    {
        public static void Run()
        {
            Common.WriteSeparator();
            Common.WriteSeparateString(typeof(Sample0035).Name);

            ParameterizedThreadStart delegate1 = new ParameterizedThreadStart(StaticPrint);
            Thread myThread1 = new Thread(delegate1);
            ParamsForPrint params1 = new ParamsForPrint("Val1", 123);
            myThread1.Start(params1);

            /*
                        ParamsStaticPrintDelegate myDelegate = new ParamsStaticPrintDelegate(StaticPrintParametrized);
                        Thread myThread2 = new Thread(myDelegate);
                        ParamsForPrint params2 = new ParamsForPrint("Val2", 321);
                        myThread2.Start(params2);
            */

            myThread1.Join();
            //            myThread2.Join();

            Common.WriteSeparator();
        }

        static void StaticPrint(object? untypedParams)
        {
            if (untypedParams is ParamsForPrint)
            {
                ParamsForPrint typedParams = (ParamsForPrint)untypedParams;
                Console.WriteLine($"StaticPrint: val1 = {typedParams.val1}; val2 = {typedParams.val2}");
                return;
            }
            Console.WriteLine($"StaticPrint: message = {untypedParams}");
        }

        delegate void ParamsStaticPrintDelegate(ParamsForPrint obj);

        /*
        // Решить через наследование не получится т.к. Thread объявлен sealed
        // Объявление такое: "public sealed partial class Thread : CriticalFinalizerObject"
                class ThreadStaticPrintParametrized : Thread{
                    public Thread(ParamsStaticPrintDelegate start)
                    {
                        if (start == null)
                        {
                            throw new ArgumentNullException(nameof(start));
                        }

                        _startHelper = new StartHelper(start);

                        Initialize();
                    }
                }
        */
        static void StaticPrintParametrized(ParamsForPrint? message)
        {
            //            if (message is ParamsStaticPrint) {
            //ParamsStaticPrint params = message as ParamsStaticPrint;
            //ParamsStaticPrint params = (ParamsStaticPrint)message;
            //message = "StaticPrintParametrized: " + params.
            //} 
            Console.WriteLine($"static: {message.val1}, {message.val2}");
        }

        class ParamsForPrint
        {
            public string val1;
            public int val2;
            public ParamsForPrint(string val1, int val2)
            {
                this.val1 = val1;
                this.val2 = val2;
            }
        }
    }
}