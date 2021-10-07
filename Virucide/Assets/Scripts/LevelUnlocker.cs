using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelUnlocker : MonoBehaviour {

    public GameObject[] buttons;
    public int type;
    public int area;

	void Start () 
    {
	
	}
	

	void Update () 
    {
        Unlocker();
	}

    void Unlocker()
    {
        if(type == 0)
        {
            for(int i = 0; i <= (PlayerPrefs.GetInt("Level") - area); i++)
            {
                if (i < buttons.Length)
                    buttons[i].SetActive(true);
            }
        }
        else if(type == 1)
        {
            for (int i = 0; i <= (PlayerPrefs.GetInt("Area")); i++)
            {
                if (i < buttons.Length)
                    buttons[i].SetActive(true);
            }
        }
    }
}
