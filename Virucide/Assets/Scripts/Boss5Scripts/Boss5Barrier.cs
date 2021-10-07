using UnityEngine;
using System.Collections;

public class Boss5Barrier : Basic {

    public int hp;
    AudioSource[] audios;
    AudioSource audio1;
    AudioSource audio2;
    AudioSource audio3;
    bool tappable;

	void Start () 
    {
        audios = GetComponents<AudioSource>();
        audio1 = audios[0];
        audio2 = audios[1];
        audio3 = audios[2];
        tappable = true;
        c = GetComponent<SpriteRenderer>().color;
        InvokeRepeating("FlashRed", 0, 0.2f);
	}
	
	void Update () 
    {
        if (Time.timeScale != 0)
        {
            if (hp <= 0)
            {
                Defeat();
                c.a = 0;
                GetComponent<SpriteRenderer>().color = c;
            }
            Tapped();
        }
	}

    void Tapped()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && tappable)
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

    void Defeat()
    {
        if (tappable)
        {
            CancelInvoke("FlashRed");
            audio2.Play();
            GetComponent<CircleCollider2D>().enabled = false;
            tappable = false;
        }
    }

    public void Revive()
    {
        audio3.Play();
        InvokeRepeating("FlashRed", 0, 0.2f);
        hp = 30;
        c.a = 1;
        GetComponent<SpriteRenderer>().color = c;
        GetComponent<CircleCollider2D>().enabled = true;
        tappable = true;
    }
}
