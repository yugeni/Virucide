using UnityEngine;
using System.Collections;

public class Boss2Feeler : Basic {

    bool tappable;
     AudioSource audio1;

	void Start () 
    {
        c = GetComponent<SpriteRenderer>().color;
        audio1 = GetComponent<AudioSource>();
        tappable = false;
	}
	
	void FixedUpdate () 
    {
        Tapped();
	}

    public void StartFlashing()
    {
        tappable = true;
        InvokeRepeating("FlashRed", 0, 0.2f);
        Invoke("StopFlashing", 1.0f);
    }

    void StopFlashing()
    {
        tappable = false;
        CancelInvoke("FlashRed");
    }

    void Tapped()
    {
        if (Input.touchCount > 0 && tappable)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10.0f));
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                GetComponentInParent<Boss2>().Damage();
                audio1.Play();
                GetComponentInParent<Boss2>().hp2 -= 1;
                StopFlashing();
            }
        }
    }
}

