using UnityEngine;      // Provides access to Unity-specific classes
using UnityEngine.UI;  // Add this to access the UI elements
using TMPro;          // Provides support for TextMeshProUGUI
public class CountdownTimer : MonoBehaviour
{
    public float timerDuration = 60f;  // Set timer for 2 minutes (120 seconds)
    public TextMeshProUGUI  timerText;              // Reference to the UI Text element

    private float timeRemaining;
    private bool timerIsRunning = false;

    void Start()
    {
        timeRemaining = timerDuration;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerText(timeRemaining);
                EndGame();  // Call method to stop or exit the game
            }
        }
    }

    void UpdateTimerText(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        Debug.Log("Time's up! Ending game.");
        // This will stop the editor play mode or quit the application if built
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}