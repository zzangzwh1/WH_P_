using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REVIEW_LAB01_CMPE2800_Wonhyuk;

namespace Tess_ReviewLab01
{
    class Program
    {
        static Random _rnd = new Random();
        static void Main(string[] args)
        {
            // construction tests
            // construction tests
            {

         
                GInt a = new GInt(12345);
                Console.WriteLine($"Should be 12345 : {a}");
                GInt b = new GInt("12345");
                Console.WriteLine($"Should be 12345 : {b}");
                GInt c = new GInt(b);
                Console.WriteLine($"Should be 12345 : {c}");
                GInt d = new GInt(UInt64.MaxValue);
                Console.WriteLine($"Should be 2^64 - 1 : {d}");
            }

            // equals / CompareTo tests
            {
                Console.WriteLine("500 sorted values (0-49) : ");
                List<GInt> stuff = new List<GInt>();
                for (int i = 0; i < 500; ++i)
                    stuff.Add(new GInt((uint)_rnd.Next(1, 50)));
                stuff.Sort();
                for (int i = 0; i < 500; ++i)
                    Console.Write($"{stuff[i],2}, ");
                Console.WriteLine();
                Console.WriteLine("TESTCODE---1500 sorted values (0-49) : ");
                List<GInt> stuffs = new List<GInt>();
                for (int i = 0; i < 1500; ++i)
                    stuffs.Add(new GInt((uint)_rnd.Next(1, 150)));
                stuffs.Sort();
                for (int i = 0; i < 1500; ++i)
                    Console.Write($"{stuffs[i],2}, ");
                Console.WriteLine();
            }

            // basic adding tests
            {
                GInt a = new GInt(56);
                GInt b = new GInt(5);
                GInt c = a.Add(b);
                Console.WriteLine($"56 + 5 == {56 + 5} : {c}");
                GInt aTest = new GInt(5);
                GInt bTest = new GInt(5555);
                GInt cTest = aTest.Add(bTest);
                Console.WriteLine($"TESTCODE : 5 + 5555 == {5 + 5555} : {cTest}");
                GInt aGiant = new GInt("463264328976498273648236428364783264872364879236498326487236");
                GInt bGiant = new GInt("463264328976498273648236428364783264872364879236498326487236");
                GInt cGiant = aGiant.Add(bGiant);
                Console.WriteLine($"TEST CODE :463264328976498273648236428364783264872364879236498326487236 + 463264328976498273648236428364783264872364879236498326487236 : \n{cGiant}");
                GInt d = new GInt("");
                GInt e = new GInt(0);
                GInt f = d.Add(e);
                Console.WriteLine($"0 + 0 == {0} : {f}");

                Console.WriteLine($"Slow count to 1M start...");
                while (f.ToString() != "1000000")
                    f = f.Add(new GInt(1));
                Console.WriteLine(f);
                Console.WriteLine($"Slow count to 1M done!");

                // static form
                Console.WriteLine($"{67} + {45} is {67 + 45} : {GInt.Add(new GInt(67), new GInt(45))}");
            }

            // basic subtraction tests
            {
                GInt a = new GInt(56);
                GInt b = new GInt(5);

                GInt c = a.Sub(b);

                Console.WriteLine($"{56} - {5} == {56 - 5} : {c}");
                GInt aa = new GInt(5615555);
                GInt bb = new GInt(5555);

                GInt cc = aa.Sub(bb);

                Console.WriteLine($"TEST CODE ========={5615555} - {5555} == {5615555 - 5555} : {cc}");

                try
                {
                    GInt d = b.Sub(a);
                    Console.WriteLine($"{5} - {56} == {5 - 56} : {d}");
                }
                catch (Exception err)
                {
                    Console.WriteLine($"Sub: expected, inverted args {err.Message}");
                }
            }

            // basic multiplication tests
            {
                // random test (low hammer)
                Console.WriteLine($"low value range hammer test for SMult");
                for (int i = 0; i < 10; ++i)
                {
                    int a = _rnd.Next(0, 5);
                    int b = _rnd.Next(0, 5);
                    GInt ga = new GInt((uint)a);
                    GInt gb = new GInt((uint)b);
                    GInt gc = ga.SMult(gb);
                    if (gc.ToString() != (a * b).ToString())
                        Console.WriteLine($"Error {a} x {b} == {a * b}, not {gc}!");
                    else
                        Console.WriteLine($"{a} * {b} = {a * b} : {gc}");
                }
                Console.WriteLine();
                Console.WriteLine($"TESTCODE----low value range hammer test for SMult");
                for (int i = 0; i < 10; ++i)
                {
                    int a1 = _rnd.Next(0, 20);
                    int b1 = _rnd.Next(0, 20);
                    GInt ga = new GInt((uint)a1);
                    GInt gb = new GInt((uint)b1);
                    GInt gc = ga.SMult(gb);
                    if (gc.ToString() != (a1 * b1).ToString())
                        Console.WriteLine($"Error {a1} x {b1} == {a1 * b1}, not {gc}!");
                    else
                        Console.WriteLine($"{a1} * {b1} = {a1 * b1} : {gc}");
                }
                Console.WriteLine();

                Console.WriteLine($"high value range hammer test for SMult");
                // random test (high hammer)
                //500
                for (int i = 0; i < 5; ++i)
                {
                    // max would be 250M, so well within int range

                    int a = _rnd.Next(0, 50000);
                    int b = _rnd.Next(0, 5000);
                    GInt ga = new GInt((uint)a);
                    GInt gb = new GInt((uint)b);
                    GInt gc = ga.SMult(gb);
                    if (gc.ToString() != (a * b).ToString())
                        Console.WriteLine($"Error {a} x {b} == {a * b}, not {gc}!");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
                Console.WriteLine($"TEST--------high value range hammer test for SMult");
                // random test (high hammer)
                //500
                for (int i = 0; i < 25; ++i)
                {
                    // max would be 250M, so well within int range

                    int a1 = _rnd.Next(0, 50);
                    int b1 = _rnd.Next(0, 80);
                    GInt ga = new GInt((uint)a1);
                    GInt gb = new GInt((uint)b1);
                    GInt gc = ga.SMult(gb);
                    if (gc.ToString() != (a1 * b1).ToString())
                        Console.WriteLine($"Error {a1} x {b1} == {a1 * b1}, not {gc}!");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();

                Console.WriteLine($"SMult operand inversion performance tests");
                {
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    GInt ga = new GInt(100000000000);
                    GInt gb = new GInt(100);
                    GInt gc = ga.SMult(gb);
                    Console.WriteLine($"Product [big/little] {gc}, took {sw.ElapsedMilliseconds}ms");
                }
                {
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    GInt ga = new GInt(100000000000);
                    GInt gb = new GInt(100);
                    GInt gc = gb.SMult(ga);
                    Console.WriteLine($"Product [little/big] {gc}, took {sw.ElapsedMilliseconds}ms");
                }
                Console.WriteLine();
                // }

                // IDiv tests
                {
                    GInt a = new GInt(55);
                    GInt b = new GInt(10);
                    //49
                    GInt c = a.IDiv(b);
                    Console.WriteLine($"{55} IDIV {10} == {55 / 10} : {c}");
                }
                {
                    Console.WriteLine("TESTCODE");
                    GInt a = new GInt(5555);
                    GInt b = new GInt(13);
                    //49
                    GInt c = a.IDiv(b);
                    Console.WriteLine($"{5555} IDIV {13} == {5555 / 13} : {c}");
                }
                // FMult tests
                {
                    Console.WriteLine("Really big FMult test : ");
                    GInt a = new GInt("57434234232342342345756745856723452345456567786783456345876545332");
                    GInt b = new GInt("235189237490128374291837412837461482384761289374450235098273450982345723459823465982347569823756923874569832475692387456983475");
                    GInt c = a.FMult(b);
                    /*    GInt a = new GInt("1234");
                        GInt b = new GInt("1000");
                        GInt c = a.FMult(b);*/
                    Console.WriteLine(c);
                }
                {
                    Console.WriteLine("TESTCODE----Really big FMult test : ");
                    GInt a = new GInt("574324324324324324321111111111111111111111111111111111111111111111111111111111111111111114444444444444444444444444444444434234232342342345756745856723452345456567786783456345876545332");
                    GInt b = new GInt("23518923749012837429183741283746148238476128937445023509827345098234572345982346598234756982375692387456983247569238745644444444444444444444444444444444444444444444444444444444444444444444444444444444983475");
                    GInt c = a.FMult(b);
                    /*    GInt a = new GInt("1234");
                        GInt b = new GInt("1000");
                        GInt c = a.FMult(b);*/
                    Console.WriteLine(c);
                }
                {
                    Console.WriteLine("TESTCODE----Really big FMult test : ");
                    GInt a = new GInt("100");
                    GInt b = new GInt("1000");
                    GInt c = a.FMult(b);
                    /*    GInt a = new GInt("1234");
                        GInt b = new GInt("1000");
                        GInt c = a.FMult(b);*/
                    Console.WriteLine(c);
                }
                Console.WriteLine("All tests done!");
                Console.ReadKey();
            }
        }
    }
}




