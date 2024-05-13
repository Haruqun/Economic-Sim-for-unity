using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshProの名前空間を追加


public class EconomyManager : MonoBehaviour
{
    public float funds;
    public int resourceWood;
    public int resourceIron;
    public float priceWood;
    public float priceIron;


    public TextMeshProUGUI fundsText; // ファンド表示用のTextMeshPro
    public TextMeshProUGUI woodPriceText; // 木材価格表示用のTextMeshPro
    public TextMeshProUGUI ironPriceText; // 鉄価格表示用のTextMeshPro

    public TextMeshProUGUI resourceWoodText;
    public TextMeshProUGUI resourceIronText;

    void Start()
    {
        funds = 1000f; // 初期資金
        resourceWood = 100;
        resourceIron = 50;
        priceWood = 5.0f;
        priceIron = 20.0f;
    }

    void Update()
    {
        // 市場価格の更新ロジック
        UpdateMarketPrices();
        // UIテキストの更新
        fundsText.text = "Funds: $" + funds.ToString("F2");
        woodPriceText.text = "Wood Price: $" + priceWood.ToString("F2");
        ironPriceText.text = "Iron Price: $" + priceIron.ToString("F2");
        resourceWoodText.text = "Wood: " + resourceWood;
        resourceIronText.text = "Iron: " + resourceIron;

    }

    public void UpdateMarketPrices()
    {
        // 価格は、資源の在庫量に応じて変動する
        // 初期在庫に対して現在の在庫数が減っている場合、減っている割合に対して価格を上昇させる
        // 逆に、在庫が増えている場合は価格を下げる
        float woodRatio = (float)resourceWood / 100.0f;
        float ironRatio = (float)resourceIron / 50.0f;

        priceWood = 5.0f + 5.0f * woodRatio;
        priceIron = 20.0f + 10.0f * ironRatio;


        // 価格が下がりすぎないように最低価格を設定
        if (priceWood < 1.0f)
        {
            priceWood = 1.0f;
        }
        if (priceIron < 5.0f)
        {
            priceIron = 5.0f;
        } 

    }
}
