using UnityEngine;
using System.Collections;

public class PlasmaBoy : MonoBehaviour {

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Boss" || col.gameObject.tag == "Spiked" || col.gameObject.tag == "Enemy3" || col.gameObject.tag == "Enemy4")
        {
            GameObject.Find("Main Camera").GetComponent<GameManager>().GameOver();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


	void Start () {
	
	}
	

	void FixedUpdate () {
	
	}
}
