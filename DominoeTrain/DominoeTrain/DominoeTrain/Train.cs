using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoTrain
{
    public abstract class Train: IEnumerable<Domino>
    {
        protected List<Domino> dominoes;
        protected int engineValue;
        //constructors
        public Train()
        {
            engineValue = 12;
            dominoes = new List<Domino>();
        }
        public Train(int engineValue)
        {
            this.engineValue = engineValue;
            dominoes = new List<Domino>();
        }
        //properties
        public int Count
        {
            get
            {
                return dominoes.Count;
            }
        }

        public int EngineValue
        {
            get
            {
                return engineValue;
            }
            set
            {
                engineValue = value;
            }
        }
        public bool IsEmpty
        {
            get
            {
                return dominoes.Count == 0;
            }
        }
        public Domino LastDomino
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }
                else
                {
                    return dominoes[dominoes.Count - 1];
                }
            }
        }
        public int PlayableValue
        {
            get
            {
                if (IsEmpty)
                    return engineValue;
                else
                    return LastDomino.Side2;
            }
        }
        //adds given domino to train
        public void Add(Domino d)
        {
            dominoes.Add(d);
        }
        //returns domino in given index
        public Domino this[int i]
        {
            get
            {
                return dominoes[i];
            }
        }
        //abstract method to be defined in child classes
        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);
        public bool IsPlayable(Domino d, out bool mustFlip)
        {
            if(PlayableValue == d.Side1)
            {
                mustFlip = false;
                return true;
            }
            else if(PlayableValue == d.Side2)
            {
                mustFlip = true;
                return true;
            }
            else
            {
                mustFlip = false;
                return false;
            }
        }
        //takes domino from a player hand and puts it on the train, or gives exeption when the given domino is not playable
        public void Play(Hand h, Domino d)
        {
            bool mustFlip = false;
            if (IsPlayable(h, d, out mustFlip))
            {
                if (mustFlip)
                {
                    d.Flip();
                }
                Add(d);
            }

            else
            {
                throw new Exception("Domino " + d.ToString() + " does not match last domino in the train and cannot be played.");
            }
        }
        //tostring
        public override string ToString()
        {
            string output = "";
            int index = 0;
            foreach (Domino d in dominoes)
            {
                output += index + ": " + d.ToString() + "\n";
                index++;
            }
            output += "\n";
            return output;
        }
        //automatic implimentation
        public IEnumerator<Domino> GetEnumerator()
        {
            return ((IEnumerable<Domino>)dominoes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)dominoes).GetEnumerator();
        }
    }
}
