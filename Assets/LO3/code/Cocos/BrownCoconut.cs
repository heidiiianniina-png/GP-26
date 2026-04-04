public class BrownCoconut : Coconut
{
    protected override void OnCollected(PlayerInventory playerInventory)
    {
        playerInventory.CollectCoconut(CoconutType.Brown);
    }
}