using UnityEngine;
using TMPro;

public class LmsCountdown : MonoBehaviour
{
    public float startTimeInSeconds = 113f;
    public TextMeshProUGUI timerText;

    float currentTime;

    void Start()
    {
        currentTime = startTimeInSeconds;
        UpdateDisplay();
    }

    void Update()
    {
        if (currentTime <= 0f) return;

        currentTime -= Time.unscaledDeltaTime;
        if (currentTime < 0f) currentTime = 0f;

        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
