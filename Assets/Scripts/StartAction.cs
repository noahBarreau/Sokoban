using UnityEngine;

public class StartAction : MonoBehaviour
{
    public GameObject popupPanel;

    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}
