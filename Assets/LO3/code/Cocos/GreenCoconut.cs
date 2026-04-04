public class GreenCoconut : Coconut
{
    protected override void OnCollected(PlayerInventory playerInventory)
    {
        playerInventory.CollectCoconut(CoconutType.Green);
    }
}