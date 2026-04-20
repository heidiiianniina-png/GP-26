using TMPro;
using UnityEngine;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TMP_Text PriceTxt;
    public TMP_Text QuantityTxt;
    public ShopManagerScript shop;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        PriceTxt.text = "Price: $" + shop.shopItems[2, ItemID].ToString();
        QuantityTxt.text = shop.shopItems[3, ItemID].ToString();
    }
}