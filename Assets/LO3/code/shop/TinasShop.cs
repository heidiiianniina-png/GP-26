using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class TinasShop : MonoBehaviour
{
    public int Coin;
    public int Drink;
    public Text Coin_text;
    public Text Drink_text;
    void Start()
    {
        Coin = 100;
        Coin_text.text = Coin.ToString();

    }
    public void BuyDrink()
    {
        if (Coin <= 5)
        {
            Coin -= 5;
            Coin_text.text = Coin.ToString();

            Drink += 1;
            Drink_text.text = Drink.ToString();
        }
        else
        {
            Debug.Log("Not enough coins");
        }


    }
}
