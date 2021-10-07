using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Minigames : MonoBehaviour {

    public Button[] buttons;

	void Start () 
    {
        buttons[0].interactable = false;
        buttons[0].GetComponentInChildren<Text>().text = "Beat Lv 10 to unlock";
        buttons[1].interactable = false;
        buttons[1].GetComponentInChildren<Text>().text = "Beat Lv 20 to unlock";
        buttons[2].interactable = false;
        buttons[2].GetComponentInChildren<Text>().text = "Beat Lv 30 to unlock";
        buttons[3].interactable = false;
        buttons[3].GetComponentInChildren<Text>().text = "Beat Lv 40 to unlock";
        buttons[4].interactable = false;
        buttons[4].GetComponentInChildren<Text>().text = "Beat Lv 50 to unlock";
	}
	
	void Update () 
    {
        Unlocker();
	}

    void Unlocker()
    {
        if(PlayerPrefs.GetInt("Level") >= 10)
        {
            buttons[0].interactable = true;
            buttons[0].GetComponentInChildren<Text>().text = "Perfect Aim";
        }
        if (PlayerPrefs.GetInt("Level") >= 20)
        {
            buttons[1].interactable = true;
            buttons[1].GetComponentInChildren<Text>().text = "Anemia";
        }
        if (PlayerPrefs.GetInt("Level") >= 30)
        {
            buttons[2].interactable = true;
            buttons[2].GetComponentInChildren<Text>().text = "Spike Fall";
        }
        if (PlayerPrefs.GetInt("Level") >= 40)
        {
            buttons[3].interactable = true;
            buttons[3].GetComponentInChildren<Text>().text = "Endless Explosions";
        }
        if (PlayerPrefs.GetInt("Level") >= 50)
        {
            buttons[4].interactable = true;
            buttons[4].GetComponentInChildren<Text>().text = "Portal Pickle";
        }
    }
}
