using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeOffer
{
    public int itemId;       // 商品のID
    public float price;      // 販売価格
    public Trader seller;    // 売り手
    public Trader buyer;     // 買い手（初期はnull）

    public TradeOffer(int itemId, float price, Trader seller)
    {
        this.itemId = itemId;
        this.price = price;
        this.seller = seller;
    }
}