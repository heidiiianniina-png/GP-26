using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfGreenCoconuts;
    public int NumberOfBrownCoconuts;

    [SerializeField] private InventoryUI inventoryUI;

    public void CollectCoconut(CoconutType type)
    {
        switch (type)
        {
            case CoconutType.Green:
                NumberOfGreenCoconuts++;
                break;

            case CoconutType.Brown:
                NumberOfBrownCoconuts++;
                break;
        }

        inventoryUI.UpdateCoconutText(this, type);
    }
    public void RemoveCoconut(CoconutType type)
    {
        switch (type)
        {
            case CoconutType.Green:
                NumberOfGreenCoconuts--;
                break;

            case CoconutType.Brown:
                NumberOfBrownCoconuts--;
                break;
        }

        inventoryUI.UpdateCoconutText(this, type);
    }
}