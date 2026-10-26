using UnityEngine;
using TMPro;



public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float elapsedTime = 0f;
    private int lastDisplayedSecond = -1;
    private bool isRunning = true;


    void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;
        int currentSecond = Mathf.FloorToInt(elapsedTime);

    
        if (currentSecond != lastDisplayedSecond)
        {
            lastDisplayedSecond = currentSecond;
            if(lastDisplayedSecond % 10 == 0 && lastDisplayedSecond != 0)
                Score.Instance.changeScore(-10);
            UpdateTimerDisplay(currentSecond);
        }
    }

    private int getTime() => lastDisplayedSecond;

    private void UpdateTimerDisplay(int totalSeconds)
    {
        timerText.text = $"{totalSeconds}";
    }

    public void PauseTimer() => isRunning = false;
    public void ResumeTimer() => isRunning = true;

    public void ResetTimer()
    {
        elapsedTime = 0f;
        lastDisplayedSecond = -1;
        UpdateTimerDisplay(0);
    }

    public int GetTotalSeconds() => Mathf.FloorToInt(elapsedTime);
}
