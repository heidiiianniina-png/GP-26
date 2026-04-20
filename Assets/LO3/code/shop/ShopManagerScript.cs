using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public float coins;
    public TMP_Text CoinsTxt;
    public PlayerInventory inventory;

    void Start()
    {
        CoinsTxt.text = ":" + coins.ToString();

        // IDs
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        // Prices
        shopItems[2, 1] = 5;
        shopItems[2, 2] = 4;
        shopItems[2, 3] = 8;
        shopItems[2, 4] = 9;

        // Quantities
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;  
        shopItems[3, 4] = 0;
    }
   

    public void Buy()
    {
        GameObject buttonRef = EventSystem.current.currentSelectedGameObject;
        ButtonInfo info = buttonRef.GetComponent<ButtonInfo>();
        int id = info.ItemID;

        if (coins >= shopItems[2, id])
        {
            coins -= shopItems[2, id];
            shopItems[3, id]++;

            CoinsTxt.text = ":" + coins.ToString();
            info.UpdateUI();
        }
    }

    public void Sell()
    {
        GameObject buttonRef = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        ButtonInfo info = buttonRef.GetComponent<ButtonInfo>();

        int id = info.ItemID;

        if (id == 3 && inventory.NumberOfGreenCoconuts > 0)
        {
            inventory.RemoveCoconut(CoconutType.Green);
            coins += 5;
        }
        else if (id == 4 && inventory.NumberOfBrownCoconuts > 0)
        {
            inventory.RemoveCoconut(CoconutType.Brown);
            coins += 8;
        }

        CoinsTxt.text = ":" + coins.ToString();
    }
}