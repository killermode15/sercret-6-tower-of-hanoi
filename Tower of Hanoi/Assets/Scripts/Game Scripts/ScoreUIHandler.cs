using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI movesText;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private ScoreHandler scoreHandler;
    
    // Update is called once per frame
    public void UpdateUI()
    {
        movesText.text = scoreHandler.CurrentMoves.ToString();
        timerText.text = scoreHandler.CurrentTime.ToString();
    }
}
