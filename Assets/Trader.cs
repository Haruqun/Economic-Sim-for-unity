using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trader : MonoBehaviour
{
    public EconomyManager economyManager;
    public Market market;
    public float funds = 1000.0f; // 所持金
    private float timer;
    public float purchaseInterval = 5.0f;  // 購入間隔の宣言

    void Update()
    {
        if (market == null)
        {
            Debug.LogError("Market reference not set!");
        }
        if (economyManager == null)
        {
            Debug.LogError("EconomyManager reference not set!");
        }

        timer += Time.deltaTime;
        if (timer >= purchaseInterval)
        {
            PerformTrade();
            timer = 0;
        }
    }

    void PerformTrade()
    {
        Debug.Log("Attempting to perform trade...");
        if (market == null || economyManager == null)
        {
            Debug.LogError("Market or EconomyManager reference not set!");
            return;  // Return early to prevent null reference exception
        }

        // 木材の購入
        if (economyManager.priceWood < 10.0f && funds >= economyManager.priceWood)
        {
            CreateOffer(0, economyManager.priceWood);
        }

        // 鉄の購入
        if (economyManager.priceIron < 30.0f && funds >= economyManager.priceIron)
        {
            CreateOffer(1, economyManager.priceIron);
        }
    }

    public void CreateOffer(int itemId, float price)
    {
        TradeOffer newOffer = new TradeOffer(itemId, price, this);
        market.AddOffer(newOffer);
    } 
}
