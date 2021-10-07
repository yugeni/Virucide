using UnityEngine;
using System.Collections;

public class SpikedBall : MonoBehaviour {

    public bool released;

	void Start () 
    {
        released = false;
	}
	
	void FixedUpdate () 
    {
        if (transform.position.y <= -12.0f)
            Destroy(gameObject);
        Fall();
	}

    void Fall()
    {
        if(released)
        {
            transform.parent = null;
            transform.Translate(new Vector2(0, -0.3f));
        }
    }
}
