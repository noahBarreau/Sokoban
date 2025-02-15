using UnityEngine;

public class Win : MonoBehaviour
{
    public PopupManager popupManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("finish"))
        {
            popupManager.ShowPopup("Bravo, tu as marqu� + que le jeu");
        }
    }
}
