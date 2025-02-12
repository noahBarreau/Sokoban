using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneralAction : MonoBehaviour
{
    public PopupManager popupManager;
    public Button startButton;
    public TMP_Text timerText;
    public GameObject chrono;
    public GameObject pausePanel;

    public float elapsedTime = 0f;
    public bool isTimerRunning = false;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void StartGame()
    {
        isTimerRunning = true;
        elapsedTime = 0f;
        chrono.SetActive(true);
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void UpdateTimerText()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void ClosePause()
    {
        pausePanel.SetActive(false);

        Time.timeScale = 1f;
    }
}
