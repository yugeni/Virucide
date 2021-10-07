using UnityEngine;
using System.Collections;

public class Boss4Hand : Basic {

    public int hp;
    public GameObject ball;
    public GameObject lazerBall;
    public GameObject lazer;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spiked")
        {
            Damage();
            hp -= 1;
        }
    }

	void Start () 
    {
        c = GetComponent<SpriteRenderer>().color;
        hp = 3;
	}
	

	void FixedUpdate () 
    {
        if (hp <= 0)
            Defeat();
	}

    public void ShootBalls()
    {
        InvokeRepeating("ShootBall", 0, 3.0f);
    }

    void ShootBall()
    {
        Instantiate(ball, new Vector2(transform.position.x, transform.position.y - 0.9f), Quaternion.identity);
    }

    void Defeat()
    {
        CancelInvoke("ShootBall");
        c.a = 0;
        GetComponent<SpriteRenderer>().color = c;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Revive()
    {
        hp = 3;
        c.a = 1;
        GetComponent<SpriteRenderer>().color = c;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void LazerBall()
    {
        GameObject lB = Instantiate(lazerBall, new Vector2(transform.position.x, transform.position.y - 0.9f), Quaternion.identity) as GameObject;
        lB.transform.parent = transform;
        Invoke("Lazer", 3.0f);
    }

    void Lazer()
    {
        GameObject lazer1 = Instantiate(lazer, new Vector2(transform.position.x, transform.position.y - 10.8f), Quaternion.identity) as GameObject;
        lazer1.transform.parent = transform;
    }
}
