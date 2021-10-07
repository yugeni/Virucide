using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

    public GameObject explosion;
    public int type;
    public float speed;
    public Transform pivot;
    Vector3 targetPos;

	void Start ()
    {
        targetPos = GameObject.Find("PlasmaBoy").transform.position;
	}

    void FixedUpdate()
    {
        Spin();
        Move(type);   
    }

    void Move(int num)
    {
        if(num == 1)
        {
            transform.RotateAround(pivot.position, Vector3.back, speed);
        }
        else if(num == 2)
        {
            if(transform.position.y <= -12.0f)
            {
                Destroy(gameObject);
            }
            transform.Translate(new Vector2(0f, -speed), Space.World);
        }
        else if(num == 3)
        {
            if(transform.position == targetPos)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
        }
    }

    void Spin()
    {
        transform.Rotate(Vector3.back, 10.0f);
    }
}
