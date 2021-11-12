using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int highScore;

    #region Singleton

    private static ScoreManager _instace = null;

    public static ScoreManager Instance
    {
        get
        {
            if (_instace == null)
            {
                _instace = FindObjectOfType<ScoreManager>();

                if (_instace == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instace;
        }
    }

    #endregion

    public int tileRatio;
    public int comboRatio;

    public int HighScore { get { return highScore; } }
    public int CurrentScore { get { return currentScore; } }

    private int currentScore;

    private void Start()
    {
        ResetCurrentScore();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void IncrementCurrentScore(int tileCount, int comboCount)
    {
        currentScore += (tileCount * tileRatio) * (comboCount * comboRatio);
        SoundManager.Instance.PlayScore(comboCount > 1);
    }

    public void SetHighScore()
    {
        highScore = currentScore;
    }

}
