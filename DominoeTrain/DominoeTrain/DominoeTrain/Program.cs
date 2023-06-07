using System;

namespace DominoTrain
{
    class Program
    {
        //i cant use train tests but I'm keeping it because it might help me write future tests faster
        static void Main(string[] args)
        {
            /*
            TestTrainAdd();
            TestTrainIsPlayable();
            TestTrainPlay();
            TestTrainToString();
            */
            TestMexicanTrainAdd();
            TestMexicanTrainIsPlayable();
            TestMexicanTrainPlay();
            TestMexicanTrainToString();
        }
        /*
        public static void TestTrainAdd()
        {
            Train t = new Train();
            t.Count();
            t.Add(1, 1);
            t.Count();
        }
        public static void TestTrainIsPlayable()
        {
            Train t = new Train();
            Hand h = new Hand();
        }
        public static void TestTrainPlay()
        {
            Train t = new Train();
        }
        public static void TestTrainToString()
        {
            Train t = new Train(12);
        }
        */
        public static void TestMexicanTrainAdd()
        {
            MexicanTrain t = new MexicanTrain();
            Domino d = new Domino();
            t.Count();
            t.Add(d);
            Console.WriteLine(t.Count());
        }
        public static void TestTrainIsPlayable()
        {
            Train t = new Train();
            Hand h = new Hand();
        }
        public static void TestTrainPlay()
        {
            Train t = new Train();
        }
        public static void TestTrainToString()
        {
            Train t = new Train(12);
        }
    }
}
