using UnityEngine;

public abstract class Coconut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            OnCollected(playerInventory);
            gameObject.SetActive(false);
        }
    }

    protected abstract void OnCollected(PlayerInventory playerInventory);
}