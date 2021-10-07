using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {


	void Start () 
    {
        PlayerPrefs.SetInt("GameOverCount", 0);
        PlayerPrefs.SetInt("GameOverCounter", 0);
        Invoke("MainMenu", 3.0f);
	}

    void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
