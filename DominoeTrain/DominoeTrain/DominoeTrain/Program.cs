using System;

namespace DominoTrain
{
    class Program
    {
        //i cant use train tests but I'm keeping it because it might help me write future tests faster
        static void Main(string[] args)
        {

            //TestTrainAdd();
            //TestTrainIsPlayable();
            //TestTrainPlay();
            //TestTrainToString();
            //TestTrainPlayableValue();
            //TestTrainIsEmpty();
            //TestTrainEngineValue();
            //TestTrainLastDomino();

            //Mex tests
            //TestMexicanTrainIsPlayable();

            //Player Tests
            TestPlayerTrainIsPlayable();
            TestPlayerIsOpen();
            TestPlayerOpenClose();

            //compare and enumerate tests
            //TestDominoCompare();
            //TestTrainEnumorator();
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
        #region TrainTests
        public static void TestTrainAdd()
        {
            MexicanTrain t = new MexicanTrain();
            Domino d = new Domino(12, 12);
            Console.WriteLine("Testing add. Expect 0: " + t.Count);
            t.Add(d);
            Console.WriteLine("Testing add. Expect 1: " + t.Count);
        }
        public static void TestTrainIsPlayable()
        {
            bool mustFlip = false;
            MexicanTrain t = new MexicanTrain();
            Domino engine = new Domino(12, 12);
            t.Add(engine);
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(12, 12);
            Console.WriteLine("Testing Train IsPlayable, expect False:");
            Console.WriteLine(t.IsPlayable(d1, out mustFlip));
            Console.WriteLine("Testing Train IsPlayable, expect True:");
            Console.WriteLine(t.IsPlayable(d2, out mustFlip));
        }
        public static void TestTrainPlay()
        {
            MexicanTrain t = new MexicanTrain();
            Hand h = new Hand();
            Domino engine = new Domino(12, 12);
            t.Add(engine);
            Console.WriteLine("Testing Train Count, expect 1: " + t.Count);
            Domino d1 = new Domino(12, 12);
            h.Add(d1);
            t.Play(h, d1);
            Console.WriteLine("Testing Train Count, expect 2: " + t.Count);
        }
        public static void TestTrainToString()
        {
            Console.WriteLine("Testing Train ToString, expect 12/12");
            MexicanTrain t = new MexicanTrain();
            Domino d1 = new Domino(12, 12);
            t.Add(d1);
            Console.WriteLine(t.ToString());
        }
        public static void TestTrainPlayableValue()
        {
            Console.WriteLine("Testing Train PlayableValue, expect 12");
            MexicanTrain t = new MexicanTrain();
            Console.WriteLine(t.PlayableValue);
        }
        public static void TestTrainIsEmpty()
        {
            Console.WriteLine("Testing Train IsEmpty, expect true:");
            MexicanTrain t = new MexicanTrain();
            Domino d1 = new Domino(12, 12);
            Console.WriteLine(t.IsEmpty);
            t.Add(d1);
            Console.WriteLine("Testing Train IsEmpty, expect false:");
            Console.WriteLine(t.IsEmpty);
        }
        public static void TestTrainEngineValue()
        {
            Console.WriteLine("Testing Train EngineValue, expect 12");
            MexicanTrain t = new MexicanTrain();
            Console.WriteLine(t.EngineValue);
        }
        public static void TestTrainLastDomino()
        {
            Console.WriteLine("Testing Train EngineValue, expect 12");
            MexicanTrain t = new MexicanTrain();
            Domino d1 = new Domino(1, 1);
            t.Add(d1);
            Console.WriteLine("Testing TRain LastDomino, expect 1/1: " + t.LastDomino);
        }

        #endregion

        #region MexicanTrainTest
        public static void TestMexicanTrainIsPlayable()
        {
            bool mustFlip = false;
            MexicanTrain t = new MexicanTrain();
            Domino engine = new Domino(12, 12);
            t.Add(engine);
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(12, 12);
            Console.WriteLine("Testing MexicanTrain IsPlayable, expect False:");
            Console.WriteLine(t.IsPlayable(d1, out mustFlip));
            Console.WriteLine("Testing MexicanTrain IsPlayable, expect True:");
            Console.WriteLine(t.IsPlayable(d2, out mustFlip));
        }
        #endregion
        #region PlayerTrainTest
        public static void TestPlayerTrainIsPlayable()
        {
            bool mustFlip = false;
            Hand h = new Hand();
            PlayerTrain t = new PlayerTrain(h);
            Domino engine = new Domino(12, 12);
            t.Add(engine);
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(12, 12);
            Console.WriteLine("Testing PlayerTrain IsPlayable, expect False:");
            Console.WriteLine(t.IsPlayable(d1, out mustFlip));
            Console.WriteLine("Testing PlayerTrain IsPlayable, expect True:");
            Console.WriteLine(t.IsPlayable(d2, out mustFlip));
        }

        public static void TestPlayerIsOpen()
        {
            Hand h = new Hand();
            PlayerTrain t = new PlayerTrain(h);
            Domino d = new Domino(12, 12);
            t.Add(d);
            Console.WriteLine("Testing Player Train isOpen, expect true:" + t.IsOpen);
        }
        public static void TestPlayerOpenClose()
        {
            Hand h = new Hand();
            PlayerTrain t = new PlayerTrain(h);
            Domino d = new Domino(12, 12);
            t.Add(d);
            t.Open();
            Console.WriteLine("Testing Player Open, Expect True:" + t.IsOpen);
            t.Close();
            Console.WriteLine("Testing Player Open, Expect False:" + t.IsOpen);
        }

        #endregion

        #region InterfaceTests
        public static void TestDominoCompare()
        {
            Hand h = new Hand();
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(2, 2);
            Domino d3 = new Domino(3, 3);
            h.Add(d3);
            h.Add(d1);
            h.Add(d2);
            Console.WriteLine("Testing Compare, expect out of order:");
            Console.WriteLine(h.ToString());
            h.Sort();
            Console.WriteLine("Testing Compare, expect in order:");
            Console.WriteLine(h.ToString());
        }
        public static void TestTrainEnumorator()
        {
            Console.WriteLine("Testing Enumeration: Expect 12/12 1/1 2/2 3/3");
            MexicanTrain t = new MexicanTrain();
            Domino d = new Domino(12, 12);
            Domino d1 = new Domino(1, 1);
            Domino d2 = new Domino(2, 2);
            Domino d3 = new Domino(3, 3);
            t.Add(d); t.Add(d1); t.Add(d2); t.Add(d3);
            foreach(Domino i in t)
            {
                Console.WriteLine(i.ToString());
            }
        }
        #endregion
    }
}
