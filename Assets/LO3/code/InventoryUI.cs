using UnityEngine;
using TMPro;
public enum CoconutType
{
    Green,
    Brown
}
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI greenCocoText;
    [SerializeField] private TextMeshProUGUI brownCocoText;

    public void UpdateCoconutText(PlayerInventory playerInventory, CoconutType type)
    {
        switch (type)
        {
            case CoconutType.Green:
                greenCocoText.text = playerInventory.NumberOfGreenCoconuts.ToString();
                break;

            case CoconutType.Brown:
                brownCocoText.text = playerInventory.NumberOfBrownCoconuts.ToString();
                break;
        }
    }
}