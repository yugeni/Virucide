using UnityEngine;
using System.Collections;

public class Basic : MonoBehaviour {

    public Color c;

	void Start () 
    {
        c = GetComponent<SpriteRenderer>().color;
	}

    public void FlashRed()
    {
        Red();
        Invoke("Original", 0.1f);
    }

    void Red()
    {
        c.b = 0.0f;
        c.g = 0.0f;
        GetComponent<SpriteRenderer>().color = c;
    }

    void Original()
    {
        c.b = 1.0f;
        c.g = 1.0f;
        GetComponent<SpriteRenderer>().color = c;
    }

    public void Damage()
    {
        Disappear();
        Invoke("Appear", 0.1f);
    }

    void Appear()
    {
        c.a = 1.0f;
        GetComponent<SpriteRenderer>().color = c;
    }

    void Disappear()
    {
        c.a = 0;
        GetComponent<SpriteRenderer>().color = c;
    }
}
