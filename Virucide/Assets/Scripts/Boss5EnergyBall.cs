using UnityEngine;
using System.Collections;

public class Boss5EnergyBall : Basic {

    public float speed;
    public bool vanish;
    public bool colorBall;
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite yellow;
    public GameObject explosion;
    SpriteRenderer sR;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody")
        {
            if (sR.sprite == red && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (sR.sprite == blue && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (sR.sprite == green && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (sR.sprite == yellow && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (col.gameObject.tag == "Player")
        {
            c.a = 1.0f;
            GetComponent<SpriteRenderer>().color = c;
        }
    }

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        c = GetComponent<SpriteRenderer>().color;
        RandomColor();
        InvokeRepeating("ChangeSize", 0, 0.2f);
    }

	void FixedUpdate () 
    {
        if (transform.position.y <= -13.0f)
            Destroy(gameObject);
        Move();
        Vanish();
	}

    void Move()
    {
        transform.Translate(new Vector2(0, speed));
    }

    void Vanish()
    {
        if(vanish)
        {
            if (c.a > 0)
            {
                c.a -= 0.04f;
                GetComponent<SpriteRenderer>().color = c;
            }
            else
            {
                vanish = false;
            }
        }
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

    void RandomColor()
    {
        if (colorBall)
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
}
