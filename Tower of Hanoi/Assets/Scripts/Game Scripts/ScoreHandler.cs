using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    public string CurrentTime 
    {
        get 
        {
            int seconds = (int)(timer % 60);
            int minutes = (int)(timer / 60);

            string secondsString = seconds.ToString();
            if(secondsString.Length < 2)
            {
                return minutes + ":0" + seconds;
            }
            return minutes + ":" + seconds;
        }
    }

    public int CurrentMoves => moves;

    [SerializeField] private int moves = 0;
    [SerializeField] private float timer = 0;

    [SerializeField] private UnityEvent onTimerUpdate;

    private bool isTimerCounting = false;


    private void Update()
    {
        if(!isTimerCounting)
        {
            return;
        }

        timer += Time.deltaTime;
        onTimerUpdate.Invoke();
    }

    public void ResetScore()
    {
        moves = 0;
        timer = 0;
    }

    public void StartTimer()
    {
        if(isTimerCounting)
        {
            return;
        }

        isTimerCounting = true;
    }

    public void StopTimer()
    {
        if(!isTimerCounting)
        {
            return;
        }
        isTimerCounting = false;
    }

    public void IncrementMoveCounter() => moves++;
}