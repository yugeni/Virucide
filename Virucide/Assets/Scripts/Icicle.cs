using UnityEngine;
using System.Collections;

public class Icicle : MonoBehaviour {

    public float speed;
    public int type;
    bool move;

	void Start () 
    {
        if (type == 0)
        {
            move = false;
            Invoke("StartMoving", 2.0f);
        }
        else
        {
            move = true;
        }
	}
	
	void FixedUpdate () 
    {
        if (transform.position.y <= -14.0f)
            Destroy(gameObject);
        Follow();
        Move();
	}

    void Move()
    {
        if(move)
            transform.Translate(new Vector2(0, speed), Space.World);
    }

    void StartMoving()
    {
        move = true;
    }

    void Follow()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null && !move)
        {
            transform.position = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, transform.position.y);
        }
    }
}
