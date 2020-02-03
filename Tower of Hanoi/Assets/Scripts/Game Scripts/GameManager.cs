using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Game Properties")]
    [SerializeField] private GameSettings gameSettings = null;

    [SerializeField] private bool hasGameStarted = false;

    [Header("References")]
    [Space(10)]
    [SerializeField] private RodHandler goalRod = null;

    [Header("Game Events")]
    [Space(10)]
    [SerializeField] private UnityEvent onGameStart = null;
    [SerializeField] private UnityEvent onGameWin = null;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (!hasGameStarted)
        {
            return;
        }


        if (CheckWinCondition())
        {
            onGameWin.Invoke();
            EndGame();
        }
    }

    private bool CheckWinCondition() => goalRod.RingCount >= gameSettings.NumberOfRings;

    public void StartGame()
    {
        if (hasGameStarted)
        {
            return;
        }

        hasGameStarted = true;
        onGameStart.Invoke();
    }

    public void EndGame()
    {
        // Do win condition here
        hasGameStarted = false;
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
