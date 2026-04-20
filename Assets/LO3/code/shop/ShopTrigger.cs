using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopUI;
    private bool playerInside = false;
    private bool shopOpen = false;

    void Update()
    {
        // Open / toggle with E
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            ToggleShop();
        }

        // Close with ESC (from anywhere)
        if (shopOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseShop();
        }
    }

    void ToggleShop()
    {
        shopOpen = !shopOpen;
        shopUI.SetActive(shopOpen);

        if (shopOpen)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            ResumeGame();
        }
    }

    void CloseShop()
    {
        shopOpen = false;
        shopUI.SetActive(false);
        ResumeGame();
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            CloseShop();
        }
    }
}