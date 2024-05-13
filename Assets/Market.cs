using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Market : MonoBehaviour
{
    public List<TradeOffer> tradeOffers = new List<TradeOffer>();

    public void AddOffer(TradeOffer offer)
    {
        tradeOffers.Add(offer);
    }

    public bool BuyOffer(TradeOffer offer, Trader buyer)
    {
        if (buyer.funds >= offer.price && offer.buyer == null)
        {
            buyer.funds -= offer.price;
            offer.seller.funds += offer.price;
            offer.buyer = buyer;
            tradeOffers.Remove(offer);
            return true;
        }
        return false;
    } 
}