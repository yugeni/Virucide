using UnityEngine;
using System.Collections;

public class Bomb : Basic {

    public GameObject explosion;
    public float speed;
    public bool isMovingH;
    public bool isMovingV;
    public bool isOrbit;
    public bool antiClockwise;
    public Transform pivot;
    public Vector3 pivotPos;

	void Start () 
    {
        c = GetComponent<SpriteRenderer>().color;
        InvokeRepeating("FlashRed", 0, 0.2f);
        if (pivot != null)
        {
            pivotPos = pivot.position;
        }
	}
	
	void FixedUpdate () 
    {
        Tapped();
        MoveHorizontal(isMovingH);
        MoveVertical(isMovingV);
        Orbit(isOrbit);
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

    void MoveHorizontal(bool movingH)
    {
        if (movingH)
        {
            if (transform.position.x <= -5.0f || transform.position.x >= 5.0f)
            {
                speed = -speed;
            }
            transform.Translate(new Vector2(speed, 0f));
        }
    }

    void MoveVertical(bool movingV)
    {
        if (movingV)
        {
            if (transform.position.y <= -3.5f || transform.position.y >= 10.5f)
            {
                speed = -speed;
            }
            transform.Translate(new Vector2(0, speed));
        }
    }

    void Orbit(bool orbiting)
    {
        if (orbiting)
        {
            if (antiClockwise)
            {
                transform.RotateAround(pivotPos, Vector3.forward, speed);
                transform.rotation = Quaternion.identity;
            }
            else
            {
                transform.RotateAround(pivotPos, Vector3.back, speed);
                transform.rotation = Quaternion.identity;
            }
        }
    }
}
