using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class scorescript : MonoBehaviour
{
    public enum Score
    {
        AiScore, PlayerScore
    }

    public Text AiScoreTxt, PlayerScoreTxt;
    public UiManager uiManager;

    public int MaxScore;
    
    #region Scores
    private int aiScore, playerScore;
    

    private int AiScore
    {
        get { return aiScore; }
        set
        {
            aiScore = value;
            if (value == MaxScore)
                uiManager.ShowRestartCanvas(true);
        }
    }

    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            playerScore = value;
            if (value == MaxScore)
                uiManager.ShowRestartCanvas(false);
        }
    }
    #endregion

    public void Increment(Score whichScore)
    {
        if (whichScore == Score.AiScore)
            AiScoreTxt.text = (++AiScore).ToString();
        else
            PlayerScoreTxt.text = (++PlayerScore).ToString();
    }
    public void ResetScores()
    {
        AiScore = PlayerScore = 0;
        AiScoreTxt.text = PlayerScoreTxt.text = "0";
    }
}