using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class LevelManager : MonoBehaviour {

    AudioSource[] audios;
    int totalLS = 5;
    int totalW = 1;
    int totalH = 4;
    int totalM = 1;
    int totalMG = 6;

    void Start()
    {
        audios = GetComponents<AudioSource>();
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    public void SignIn()
    {
        audios[1].Play();
        #if UNITY_ANDROID
        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Social.ShowLeaderboardUI();
                }
            });
        }
        else
        {
            Social.ShowLeaderboardUI();
        }
        #endif
    }

    public void MainMenu()
    {
        audios[1].Play();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Level(int num)
    {
        audios[1].Play();
        Time.timeScale = 0;
        SceneManager.LoadScene(num);
    }

    public void LevelSelection(int num)
    {
        audios[1].Play();
        Time.timeScale = 1.0f;
        int index = (SceneManager.sceneCountInBuildSettings - 1) - (totalLS - num);
        SceneManager.LoadScene(index);
    }

    public void WorldSelection(int num)
    {
        audios[1].Play();
        Time.timeScale = 1.0f;
        int index = (SceneManager.sceneCountInBuildSettings - 1) - totalLS - (totalW - num);
        SceneManager.LoadScene(index);
    }

    public void HelpSelection(int num)
    {
        audios[1].Play();
        Time.timeScale = 1.0f;
        int index = (SceneManager.sceneCountInBuildSettings - 1) - totalLS - totalW - (totalH - num);
        SceneManager.LoadScene(index);
    }

    public void ModeSelection(int num)
    {
        audios[1].Play();
        Time.timeScale = 1.0f;
        int index = (SceneManager.sceneCountInBuildSettings - 1) - totalLS - totalW - totalH - (totalM - num);
        SceneManager.LoadScene(index);
    }

    public void Mode(int num)
    {
        audios[1].Play();
        Time.timeScale = 0;
        int index = (SceneManager.sceneCountInBuildSettings - 1) - totalLS - totalW - totalH - totalM - (totalMG - num);
        SceneManager.LoadScene(index);
    }
}
