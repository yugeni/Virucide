using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float xSpeed;
    public float ySpeed;

	void Start () {
	
	}
	

	void FixedUpdate () 
    {
        if (transform.position.y <= -12.0f)
            Destroy(gameObject);
        transform.Translate(new Vector2(xSpeed, ySpeed), Space.World);
        Spin();
	}

    public void setSpeed(float x, float y)
    {
        xSpeed = x;
        ySpeed = y;
    }

    void Spin()
    {
        transform.Rotate(Vector3.back, 5.0f);
    }
}
