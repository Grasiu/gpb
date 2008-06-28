using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace GrasiuPokerBot
{

    #region Enums
    enum Consts { FOO = 9 };
    enum Suits { h, s, d, c };
    //enum Suits { hearts, spades, diamonds, clubs};
    enum Values { _2, _3, _4, _5, _6, _7, _8, _9, T, J, Q, K, A };
    #endregion Enums

    

    class Player
    {
        double skill;
        public Player(double s)
        {
            skill = s;
        }
    }

    class Card
    {
        char value;
        char suit;

        public Card() { }

        public Card(char v, char s)
        {
            value = v;
            suit = s;
        }

        public override string ToString()
        {
            return ""+value+suit;
        }
    }


    
    class PokerHand
    {
        #region Attributes

        int myStack;
        int oppStack;
        int smallBlind;
        int bigBlind;
        int amIDealer;
        Player villain;

        List<Card> myCards = new List<Card>();
        List<Card> communityCards = new List<Card>();
        List<Card> oppCards = new List<Card>();
        internal List<Card> MyCards
        {
            get { return myCards; }
            //set { myCards = value; }
        }
        internal List<Card> CommunityCards
        {
            get { return communityCards; }
            set { communityCards = value; }
        }
        internal List<Card> OppCards
        {
            get { return oppCards; }
            set { oppCards = value; }
        }

        #endregion Attributes

        public PokerHand()
        {
            myStack = 1500;
            oppStack = 1500;
            smallBlind = 10;
            bigBlind = 20;
            amIDealer = 1;
            villain = new Player(0.2);
        }

        public void enterMyCards(Card c1, Card c2)
        {
            MyCards.Add(c1);
            MyCards.Add(c2);
        }
        public void enterOppCards(Card c1, Card c2)
        {
            OppCards.Add(c1);
            OppCards.Add(c2);
        }
        public void enterCommunityCards(params Card[] args)
        {
            for (int i = 0; i < args.Length; ++i)
            {
                communityCards.Add(args[i]);
            }
        }
    }




    public class PokerAI
    {
        PokerHand hand = new PokerHand();

        public PokerAI() { }

        public void LoadHand()
        {
            Card m1 = new Card('K', 'h');
            Card m2 = new Card('3', 'h');
            Card c1 = new Card('4', 's');
            Card c2 = new Card('7', 'h');
            Card c3 = new Card('A', 'h');
            Card c4 = new Card('2', 'c');
            Card c5 = new Card('7', 'd');

            hand.enterMyCards(m1, m2);
            hand.enterCommunityCards(c1, c2, c3);
            hand.enterCommunityCards(c4);
            hand.enterCommunityCards(c5);
        }

        public void PlayHand()
        {
            Console.Write("Dealt cards are ");
            hand.CommunityCards.ForEach(Console.Write);
            Console.WriteLine();

            Console.Write("... and I fold ");
            hand.MyCards.ForEach(Console.Write);
            Console.WriteLine();
        }
    }

}
