using UnityEngine;
using System.Collections;

public class Boss2Eye : Basic {

    public Sprite gray;
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite yellow;
    public AudioSource audio1;
    public SpriteRenderer sR;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody")
        {
            if (sR.sprite == red && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss2>().hp -= 1;
            }
            else if (sR.sprite == blue && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss2>().hp -= 1;
            }
            else if (sR.sprite == green && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss2>().hp -= 1;
            }
            else if (sR.sprite == yellow && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss2>().hp -= 1;
            }
        }
    }

	public virtual void Start () 
    {
        sR = GetComponent<SpriteRenderer>();
        audio1 = GetComponent<AudioSource>();
        c = GetComponent<SpriteRenderer>().color;
        Gray();
	}
	
    public void Gray()
    {
        sR.sprite = gray;
        CancelInvoke("RandomColor");
    }

    public void ChangeColor()
    {
        InvokeRepeating("RandomColor", 0, 3.0f);
    }

    void RandomColor()
    {
        int random = Random.Range(0, 4);
        if (random == 0)
            sR.sprite = red;
        else if (random == 1)
            sR.sprite = blue;
        else if (random == 2)
            sR.sprite = green;
        else
            sR.sprite = yellow;
    }
}
