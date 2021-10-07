using UnityEngine;
using System.Collections;

public class Ice2 : MonoBehaviour {

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spiked")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
