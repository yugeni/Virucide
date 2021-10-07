using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public float destroyTime;

	void Start ()
    {
        Invoke("DestroySelf", destroyTime);
	}
	
    void DestroySelf()
    {
        Destroy(gameObject);
    }
	
}
