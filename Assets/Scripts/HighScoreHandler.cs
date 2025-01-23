
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour

{
    public int highscore;

    private void Start()
    {
        SetLatestHighScore();
    }
    public void SetHighScoreIfGreater (int m_Points)
    {
        if (m_Points > highscore)
        {
            highscore = m_Points;
            SaveHighScore ();
        }
    }
    private void SaveHighScore ()
    {
        PlayerPrefs.SetInt ("Highscore", highscore);
    }


   private void SetLatestHighScore()
    {
        highscore = PlayerPrefs.GetInt ("Highscore");
    }

}