using UnityEngine;
using System.Collections;

public class Virus4 : Virus {

    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite yellow;
    public GameObject explosionR;
    public GameObject explosionB;
    public GameObject explosionG;
    public GameObject explosionY;

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody")
        {
            if (colour == 0 && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                Damage();
                audio1.Play();
                hp -= 1;
                ChangeColor();
            }
            else if (colour == 1 && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                Damage();
                audio1.Play();
                hp -= 1;
                ChangeColor();
            }
            else if (colour == 2 && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                Damage();
                audio1.Play();
                hp -= 1;
                ChangeColor();
            }
            else if (colour == 3 && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                Damage();
                audio1.Play();
                hp -= 1;
                ChangeColor();
            }
        }
        if (col.gameObject.tag == "Spiked")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void ChangeColor()
    {
        if (hp > 0)
        {
            int random = Random.Range(0, 4);
            if (random == 0)
            {
                GetComponent<SpriteRenderer>().sprite = red;
                colour = 0;
                explosion = explosionR;
            }
            else if (random == 1)
            {
                GetComponent<SpriteRenderer>().sprite = blue;
                colour = 1;
                explosion = explosionB;
            }
            else if (random == 2)
            {
                GetComponent<SpriteRenderer>().sprite = green;
                colour = 2;
                explosion = explosionG;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = yellow;
                colour = 3;
                explosion = explosionY;
            }
        }
    }
}
