using UnityEngine;
using System.Collections;

public class Spike1 : MonoBehaviour {

    public int colour;
    public float speed;
    public bool movingRight;
    float speedX;
    float speedY;

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody")
        {
            if (colour == 0 && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                speedX = 0;
                speedY = speed;
            }
            else if (colour == 1 && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                speedX = 0;
                speedY = speed;
            }
            else if (colour == 2 && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                speedX = 0;
                speedY = speed;
            }
            else if (colour == 3 && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                speedX = 0;
                speedY = speed;
            }
            else
            {
                speedX = 0;
                speedY = -speed;
            }
        }
    }

	void Start () 
    {
        speedX = speed;
        speedY = 0;
	}
	

	void FixedUpdate () 
    {
        if (transform.position.y >= 15.0f || transform.position.y <= -13.0f)
            Destroy(gameObject);
        Move();
	}

    void Move()
    {
        if(movingRight)
        {
             if(transform.position.x >= 16.0f)
            {
                Destroy(gameObject);
            }
            transform.Translate(new Vector2(speedX, speedY));
        }
        else
        {
            if (transform.position.x <= -16.0f)
            {
                Destroy(gameObject);
            }
            transform.Translate(new Vector2(-speedX, speedY));
        }
    }
}
