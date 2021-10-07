using UnityEngine;
using System.Collections;

public class Jelly : Basic {

    public Sprite sprite2;
    public float speed;
    public bool movingRight;
    bool tappable;

	void Start () 
    {
        tappable = true;
        c = GetComponent<SpriteRenderer>().color;
        InvokeRepeating("FlashRed", 0, 0.2f);
	}
	
	void Update () 
    {
        if (Time.timeScale != 0)
        {
            Move();
            Tapped();
        }
	}

    void Tapped()
    {
        if (Input.touchCount > 0 && tappable)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10.0f));
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                GetComponent<SpriteRenderer>().sprite = sprite2;
                CancelInvoke("FlashRed");
                GetComponentInChildren<SpikedBall>().released = true;
                tappable = false;
            }
        }
    }

    void Move()
    {
        if (movingRight)
        {
            if (transform.position.x >= 16.0f)
            {
                Destroy(gameObject);
            }
            transform.Translate(new Vector2(speed, 0));
        }
        else
        {
            if (transform.position.x <= -16.0f)
            {
                Destroy(gameObject);
            }
            transform.Translate(new Vector2(-speed, 0));
        }
    }
}
