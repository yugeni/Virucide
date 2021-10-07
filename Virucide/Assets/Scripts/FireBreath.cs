using UnityEngine;
using System.Collections;

public class FireBreath : Basic {

    public GameObject explosion;
    public float speed;

	void Start () 
    {
        c = GetComponent<SpriteRenderer>().color;
        InvokeRepeating("FlashRed", 0, 0.2f);
	}
	
	void FixedUpdate () 
    {
        if (transform.position.y <= -12.0f)
            Destroy(gameObject);
        Tapped();
        Move();
	}

    void Tapped()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10.0f));
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    void Move()
    {
        transform.Translate(new Vector2(0, speed), Space.World);
    }
}
