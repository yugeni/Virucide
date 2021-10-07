using UnityEngine;
using System.Collections;

public class EnergyBall : MonoBehaviour {

    public Sprite normal;
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite yellow;
    public GameObject explosion;
    bool countered;
    SpriteRenderer sR;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody")
        {
            if (sR.sprite == red && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                sR.sprite = normal;
                countered = true;
            }
            else if (sR.sprite == blue && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                sR.sprite = normal;
                countered = true;
            }
            else if (sR.sprite == green && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                sR.sprite = normal;
                countered = true;
            }
            else if (sR.sprite == yellow && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                sR.sprite = normal;
                countered = true;
            }
            else
            {
                sR.sprite = normal;
            }
        }
        if (col.gameObject.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


	void Start () 
    {
        countered = false;
        sR = GetComponent<SpriteRenderer>();
        RandomColor();
        InvokeRepeating("ChangeSize", 0, 0.2f);
	}
	

	void FixedUpdate () 
    {
        if (transform.position.y <= -13.0f)
            Destroy(gameObject);
        Move();
	}

    void RandomColor()
    {
        int random = Random.Range(0, 5);
        if (random == 0)
            sR.sprite = red;
        else if (random == 1)
            sR.sprite = blue;
        else if (random == 2)
            sR.sprite = green;
        else if (random == 3)
            sR.sprite = yellow;
        else
            sR.sprite = normal;
    }

    void Move()
    {
        if(countered)
            transform.Translate(new Vector2(0, 0.15f));
        else
            transform.Translate(new Vector2(0, -0.15f));
    }

    void ChangeSize()
    {
        Small();
        Invoke("Big", 0.1f);
    }

    void Small()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0);
    }

    void Big()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }
}
