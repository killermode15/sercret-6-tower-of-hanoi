using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseHandler : MonoBehaviour
{
    public bool IsPaused => isPaused;

    [SerializeField] private GameObject pausePanel = null;

    [SerializeField] private UnityEvent onGamePause = new UnityEvent();
    [SerializeField] private UnityEvent onGameUnpause = new UnityEvent();

    private bool isPaused = false;

    public void Pause()
    {
        if (isPaused)
        {
            return;
        }

        isPaused = true;
        pausePanel.SetActive(isPaused);
        onGamePause.Invoke();
    }

    public void Unpause()
    {
        if(!isPaused)
        {
            return;
        }

        isPaused = false;
        pausePanel.SetActive(isPaused);
        onGameUnpause.Invoke();
    }

}