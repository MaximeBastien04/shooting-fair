using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float startingTime = 30f;
    private float currentTime;
    private TextMeshPro timerText;
    private bool isRunning = true;

    void Start()
    {
        timerText = GetComponent<TextMeshPro>();
        currentTime = startingTime;
        UpdateTimerDisplay();
    }
    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();


            if (currentTime <= 0)
            {
                currentTime = 0;
                // Your Code Here
                isRunning = false;
                TimerEnded();
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60); // Convert total seconds to minutes
        int seconds = Mathf.FloorToInt(currentTime % 60); // Get remaining seconds

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format MM:SS
    }

    private void TimerEnded()
    {
        timerText.text = "00:00";
        Debug.Log("Time is up!");
    }
}