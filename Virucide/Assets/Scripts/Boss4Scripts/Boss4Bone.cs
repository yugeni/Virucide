using UnityEngine;
using System.Collections;

public class Boss4Bone : MonoBehaviour {

    public Sprite normal;
    public Sprite bright;

    public void Flash()
    {
        Bright();
        Invoke("Normal", 1.0f);
    }

    void Bright()
    {
        GetComponent<SpriteRenderer>().sprite = bright;
    }

    void Normal()
    {
        GetComponent<SpriteRenderer>().sprite = normal;
    }
}
