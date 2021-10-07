using UnityEngine;
using System.Collections;

public class RedBloodCell : MonoBehaviour {

    public GameObject explosion;
    public float speed;
    public bool isMovingH;
    public bool isOrbit;
    public bool antiClockwise;
    public Transform pivot;
    Vector3 pivotPos;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody" || col.gameObject.tag == "Enemy2" || col.gameObject.tag == "Spiked" || col.gameObject.tag == "Enemy4")
        {
            GameObject.Find("Main Camera").GetComponent<GameManager>().GameOver();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

	void Start () 
    {
        if (pivot != null)
        {
            pivotPos = pivot.position;
        }
	}
	
	void FixedUpdate () 
    {
        MoveHorizontal(isMovingH);
        Orbit(isOrbit);
	}

    void MoveHorizontal(bool movingH)
    {
        if (movingH)
        {
            if (transform.position.x <= -4.8f || transform.position.x >= 4.8f)
            {
                speed = -speed;
            }
            transform.Translate(new Vector2(speed, 0f));
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
