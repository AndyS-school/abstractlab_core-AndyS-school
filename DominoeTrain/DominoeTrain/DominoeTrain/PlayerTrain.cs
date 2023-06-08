using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoTrain
{
    public class PlayerTrain : Train
    {
        public static Hand hand = new Hand();
        public static bool isOpen = false;

        public PlayerTrain(Hand h): base()
        {
            isOpen = false;
            hand = h;
        }

        public PlayerTrain(Hand h, int engineValue): base(engineValue)
        {
            isOpen = false;
            hand = h;
        }

        public bool IsOpen
        {
            get
            {
                Domino d = LastDomino;
                if (hand.IndexOfDomino(d.Side2) == -1)
                    isOpen = true;
                else
                    isOpen = false;
                return isOpen;
            }
        }

        public void Close()
        {
            isOpen = false;
        }

        public void Open()
        {
            isOpen = true;
        }

        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {

        }
    }
}
