using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class ScoreKeeper : MonoBehaviour {

    public Text bestText;
    public Text scoreText;
    public int type;
    public string scoreName;
    int time;
    public int score;

	void Start ()
    {
        bestText.text = "Best Score: " + PlayerPrefs.GetInt(scoreName);
        scoreText.text = "Score: " + 0;
        time = 0;
        score = 0;
	}
	

	void Update () 
    {
        if (Time.timeScale != 0)
        {
            Timer();
            ScoreTracker();
        }
        ScoreUpdater();
    }

    public void AddScore()
    {
        score++;
    }

    void Timer()
    {
        time = (int)Time.timeSinceLevelLoad;
    }

    void ScoreTracker()
    {
        bestText.text = "Best Score: " + PlayerPrefs.GetInt(scoreName);
        if(type == 0)
            scoreText.text = "Score: " + time;
        else if(type == 1)
            scoreText.text = "Score: " + score;
    }

    void ScoreUpdater()
    {
        if(type == 0)
        {
            if (PlayerPrefs.GetInt(scoreName) < time)
            {
                PlayerPrefs.SetInt(scoreName, time);
                PlayerPrefs.Save();
                PostScore();
            }
        }
        else if(type == 1)
        {
            if (PlayerPrefs.GetInt(scoreName) < score)
            {
                PlayerPrefs.SetInt(scoreName, score);
                PlayerPrefs.Save();
                PostScore();
            }
        }
    }

    void PostScore()
    {
        #if UNITY_ANDROID
        if (Social.localUser.authenticated)
        {
            if (scoreName == "Mode0")
            {
                Social.ReportScore(PlayerPrefs.GetInt(scoreName), "CgkI_Jmw1_sTEAIQBQ", (bool success) =>
                {
                });
            }
            else if (scoreName == "Mode1")
            {
                Social.ReportScore(PlayerPrefs.GetInt(scoreName), "CgkI_Jmw1_sTEAIQBg", (bool success) =>
                {
                });
            }
            else if (scoreName == "Mode2")
            {
                Social.ReportScore(PlayerPrefs.GetInt(scoreName), "CgkI_Jmw1_sTEAIQBw", (bool success) =>
                {
                });
            }
            else if (scoreName == "Mode3")
            {
                Social.ReportScore(PlayerPrefs.GetInt(scoreName), "CgkI_Jmw1_sTEAIQCA", (bool success) =>
                {
                });
            }
            else if (scoreName == "Mode4")
            {
                Social.ReportScore(PlayerPrefs.GetInt(scoreName), "CgkI_Jmw1_sTEAIQCQ", (bool success) =>
                {
                });
            }
            else if (scoreName == "Mode5")
            {
                Social.ReportScore(PlayerPrefs.GetInt(scoreName), "CgkI_Jmw1_sTEAIQCg", (bool success) =>
                {
                });
            }
        }
        #endif
    }
}
