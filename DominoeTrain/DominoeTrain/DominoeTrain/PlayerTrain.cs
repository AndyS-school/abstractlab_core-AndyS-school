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
        //if the hand returns -1 for the index of a domino that matches side 2 of the end of the train, there is no domino that can be played and therefore that player's train is open
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
        //if the h is the hand associated with the train or the train is open, then it calls the overloaded version of isplayable in the base method, else it returns false to both playable and mustflip
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            if(h == hand || isOpen == true)
            {
                return base.IsPlayable(d, out mustFlip);
            }
            else
            {
                mustFlip = false;
                return false;
            }
        }
    }
}
