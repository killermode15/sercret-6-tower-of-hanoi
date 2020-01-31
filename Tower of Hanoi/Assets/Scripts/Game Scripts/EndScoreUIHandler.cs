using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScoreUIHandler : MonoBehaviour
{
    [SerializeField] private ScoreHandler scoreHandler = null;
    [SerializeField] private TextMeshProUGUI movesText = null;
    [SerializeField] private TextMeshProUGUI timerText = null;


    public void UpdateEndScoreUI()
    {
        movesText.text = scoreHandler.CurrentMoves.ToString();
        timerText.text = scoreHandler.CurrentTime.ToString();

    }


}
