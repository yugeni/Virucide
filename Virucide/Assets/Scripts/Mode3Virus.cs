using UnityEngine;
using System.Collections;

public class Mode3Virus : Virus2 {

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spiked")
        {
            Destroy(col.gameObject);
            Damage();
            audio1.Play();
            GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().AddScore();
        }
    }
}
