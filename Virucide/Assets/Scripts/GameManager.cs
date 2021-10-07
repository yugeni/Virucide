using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ChartboostSDK;

public class GameManager : MonoBehaviour {

    public int totalTime;
    public Text timer;
    public Button red;
    public Button blue;
    public Button green;
    public Button yellow;
    public Button pauseButton;
    public GameObject requirements;
    public GameObject gameOver;
    public GameObject clearLevel;
    public GameObject quitLevel;
    public GameObject pause;
    public bool bossLevel;
    public bool mode;
    int startTime;
    int totalLS = 5;
    int totalW = 1;
    int totalH = 4;
    int totalM = 1;
    AudioSource[] audios;

    void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            if (!requirements.activeInHierarchy)
            {
                Time.timeScale = 0;
                DisableColorButtons();
                pauseButton.interactable = false;
                pause.SetActive(true);
            }
        }
    }

	void Start () 
    {
        startTime = 0;
        if (timer != null)
        {
            timer.text = "Time: " + totalTime;
        }
        DisableColorButtons();
        requirements.SetActive(true);
        gameOver.SetActive(false);
        if (clearLevel != null)
        {
            clearLevel.SetActive(false);
        }
        quitLevel.SetActive(false);
        pause.SetActive(false);
        pauseButton.interactable = false;
        audios = GetComponents<AudioSource>();
        Time.timeScale = 0f;
	}
	
	void Update () 
    {
        ShowAds();
        if (Time.timeScale != 0)
        {
            TimeCounter();
            if (!mode)
            {
                Victory(bossLevel);
            }
        }
	}

    void Victory(bool isBoss)
    {
        if(isBoss)
        {
            if (GameObject.FindGameObjectWithTag("Boss") == null)
            {
                Invoke("ClearLevel", 3.0f);
            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                ClearLevel();
            }
        }
    }

    void TimeCounter()
    {
        if(timer != null)
        {
            if (totalTime - (int)Time.timeSinceLevelLoad <= 0)
            {
                timer.text = "Time: " + 0;
                GameOver();
            }
            else
            {
                if (startTime == (int)Time.timeSinceLevelLoad - 1)
                {
                    audios[1].Play();
                    startTime = (int)Time.timeSinceLevelLoad;
                }
                timer.text = "Time: " + (totalTime - (int)Time.timeSinceLevelLoad);
            }
        }
    }

    void ShowAds()
    {
        if(PlayerPrefs.GetInt("GameOverCounter") == PlayerPrefs.GetInt("GameOverCount") - 5)
        {
            Chartboost.showInterstitial(CBLocation.Default);
            PlayerPrefs.SetInt("GameOverCounter", PlayerPrefs.GetInt("GameOverCount"));
            PlayerPrefs.Save();
        }
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("GameOverCount", PlayerPrefs.GetInt("GameOverCount") + 1);
        if (mode)
        {
            audios[2].Play();
            Time.timeScale = 0f;
            DisableColorButtons();
            pauseButton.interactable = false;
            gameOver.SetActive(true);
        }
        else
        {
            if (!clearLevel.activeInHierarchy)
            {
                audios[2].Play();
                Time.timeScale = 0f;
                DisableColorButtons();
                pauseButton.interactable = false;
                gameOver.SetActive(true);
            }
        }
    }

    void ClearLevel()
    {
        if (!gameOver.activeInHierarchy)
        {
            if (bossLevel)
                audios[0].Stop();
            audios[3].Play();
            Time.timeScale = 0f;
            DisableColorButtons();
            pauseButton.interactable = false;
            clearLevel.SetActive(true);
            UnlockLevel();
        }
    }

    public void StartLevel()
    {
        audios[4].Play();
        requirements.SetActive(false);
        EnableColorButtons();
        pauseButton.interactable = true;
        Time.timeScale = 1.0f;
        if (bossLevel)
            audios[0].Play();
    }

    void DisableColorButtons()
    {
        red.interactable = false;
        blue.interactable = false;
        green.interactable = false;
        yellow.interactable = false;
    }

    void EnableColorButtons()
    {
        red.interactable = true;
        blue.interactable = true;
        green.interactable = true;
        yellow.interactable = true;
    }

    public void Pause()
    {
        audios[4].Play();
        Time.timeScale = 0;
        DisableColorButtons();
        pauseButton.interactable = false;
        pause.SetActive(true);
    }

    public void Resume()
    {
        audios[4].Play();
        Time.timeScale = 1.0f;
        EnableColorButtons();
        pauseButton.interactable = true;
        pause.SetActive(false);
    }

    public void Quit()
    {
        audios[4].Play();
        quitLevel.SetActive(true);
    }

    public void NoQuit()
    {
        audios[4].Play();
        quitLevel.SetActive(false);
    }

    public void Retry()
    {
        audios[4].Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelection(int num)
    {
        audios[4].Play();
        int index = (SceneManager.sceneCountInBuildSettings - 1) - (totalLS - num);
        SceneManager.LoadScene(index);
    }

    public void ModeSelection(int num)
    {
        audios[4].Play();
        int index = (SceneManager.sceneCountInBuildSettings - 1) - totalLS - totalW - totalH - (totalM - num);
        SceneManager.LoadScene(index);
    }

    void UnlockLevel()
    {
        if(PlayerPrefs.GetInt("Level") < SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
        if(bossLevel)
        {
            if(PlayerPrefs.GetInt("Area") < (SceneManager.GetActiveScene().buildIndex/10))
            {
                PlayerPrefs.SetInt("Area", (SceneManager.GetActiveScene().buildIndex / 10));
                PlayerPrefs.Save();
            }
        }
    }

}
