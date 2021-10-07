using UnityEngine;
using System.Collections;

public class Boss1Eyes : MonoBehaviour {

    Quaternion originalRot;

	void Awake () 
    {
        originalRot = transform.rotation;
	}
	
    void FixedUpdate()
    {
        if (GetComponentInParent<Boss1>().hp <= 0)
            GetComponent<Animator>().Play("Boss1EyesDefeat");
    }

	void LateUpdate () 
    {
        transform.rotation = originalRot;
	}
}
