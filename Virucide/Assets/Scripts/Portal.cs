using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public int type;
    public GameObject destination;
    public float speed;

	void OnCollisionEnter2D(Collision2D col)
    {
        if(type == 0)
        {
            if(col.gameObject.tag == "Antibody" && destination != null)
            {
                col.gameObject.transform.position = destination.transform.position;
            }
        }
        else
        {
            if (col.gameObject.tag != "Antibody" && col.gameObject.tag != "Untagged" && destination != null)
            {
                col.gameObject.transform.position = destination.transform.position;
            }
        }
    }

	void FixedUpdate () 
    {
        Move();
	}

    void Move()
    {
        if (transform.position.x <= -4.75f || transform.position.x >= 4.75f)
        {
            speed = -speed;
        }
        transform.Translate(new Vector2(speed, 0f));
    }

}
