using igiSnap.Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace igiSnap.GamePlay
{
    public class SnapCardDealer : ICardDealer
    {
        ICardTransport cardTransport;

        public SnapCardDealer(ICardTransport cardTransport)
        {
            this.cardTransport = cardTransport;
        }

        public void Deal(ICardDeck cardDeck, IEnumerable<IPlayer> players)
        {
            var playerCount = players.Count();

            while(cardDeck.Count >= playerCount)
            {
                foreach(var player in players)
                {
                    cardTransport.Transfer(cardDeck, player.Hand);
                }
            }
        }
    }
}
