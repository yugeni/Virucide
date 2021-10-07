using UnityEngine;
using System.Collections;

public class Boss5Core : Basic {

    public int hp;
    public bool tappable;
    AudioSource audio1;

	void Start () 
    {
        audio1 = GetComponent<AudioSource>();
        c = GetComponent<SpriteRenderer>().color;
        tappable = false;
	}
	

	void Update () 
    {
        if (Time.timeScale != 0)
        {
            if (hp <= 0)
                StopFlashing();
            Tapped();
        }
	}

    public void StartFlashing()
    {
        tappable = true;
        InvokeRepeating("FlashRed", 0, 0.2f);
    }

    public void StopFlashing()
    {
        tappable = false;
        CancelInvoke("FlashRed");
    }

    void Tapped()
    {
        if (Input.touchCount > 0 && tappable && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10.0f));
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                Damage();
                audio1.Play();
                hp -= 1;
            }
        }
    }
}
