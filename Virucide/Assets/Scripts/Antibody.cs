using UnityEngine;
using System.Collections;

public class Antibody : MonoBehaviour {

    public int colour;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Antibody" && col.gameObject.tag != "Portal")
        {
            Destroy(gameObject);
        }
    }

	void Start () 
    {

	}
	
	void FixedUpdate () 
    {
        if(transform.position.y >= 13.5f)
        {
            Destroy(gameObject);
        }
        transform.Translate(new Vector2(0f, 0.3f));
	}
}
