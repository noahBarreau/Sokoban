using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel;
    public Button closeButton;

    private void Start()
    {
        popupPanel.SetActive(false);
    }

    public void ShowPopup(string message)
    {
        popupPanel.SetActive(true);

        Time.timeScale = 0f; 
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false);

        Time.timeScale = 1f;
    }


}
