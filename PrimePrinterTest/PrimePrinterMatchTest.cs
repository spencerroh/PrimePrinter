using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PrimePrinterTest
{
    [TestClass]
    public class PrimePrinterMatchTest
    {
        [TestMethod]
        public void MakeSureOutputMatchesGold()
        {
            TextWriter ConsoleOutStream = Console.Out;
            Console.SetOut(new StreamWriter(File.Open("lead.txt", FileMode.Create)));

            PrimePrinter.Program.Main(null);

            Console.Out.Close();
            Console.SetOut(ConsoleOutStream);
            

            StreamReader lead = null;
            StreamReader gold = null;

            try
            {
                lead = new StreamReader(File.Open("lead.txt", FileMode.Open));
                gold = new StreamReader(File.Open("..\\..\\gold.txt", FileMode.Open));

                while (!lead.EndOfStream && !gold.EndOfStream)
                {
                    Assert.AreEqual(
                        lead.ReadLine(),
                        gold.ReadLine());
                }
            }
            finally
            {
                lead.Close();
                gold.Close();
            }
        }
    }
}
