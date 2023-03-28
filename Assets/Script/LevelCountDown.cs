using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCountDown : MonoBehaviour
{
    [SerializeField]
    private float duration = 180f; // the duration of the countdown in seconds
    public TextMeshProUGUI countdownText; // the Text component that displays the countdown
    public GameObject lose;
    private float startTime; // the time when the countdown started
    bool called = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        float timeElapsed = Time.time - startTime; // calculate the time elapsed since the countdown started
        float timeRemaining = Mathf.Max(duration - timeElapsed, 0f); // calculate the time remaining, clamped at 0

        int minutes = Mathf.FloorToInt(timeRemaining / 60f); // calculate the number of minutes remaining
        int seconds = Mathf.FloorToInt(timeRemaining % 60f); // calculate the number of seconds remaining

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // update the Text component with the remaining time
        if (timeRemaining <= 0&& called==false)
        {
            called = true;
            lose.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
