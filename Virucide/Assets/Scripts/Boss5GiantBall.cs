using UnityEngine;
using System.Collections;

public class Boss5GiantBall : Basic {

    public int hp;
    public Sprite normal;
    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite yellow;
    public GameObject explosion;
    SpriteRenderer sR;
    AudioSource audio1;
    bool move;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody")
        {
            if (sR.sprite == red && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                audio1.Play();
                Damage();
                hp -= 1;
                RandomColor();
            }
            else if (sR.sprite == blue && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                audio1.Play();
                Damage();
                hp -= 1;
                RandomColor();
            }
            else if (sR.sprite == green && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                audio1.Play();
                Damage();
                hp -= 1;
                RandomColor();
            }
            else if (sR.sprite == yellow && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                audio1.Play();
                Damage();
                hp -= 1;
                RandomColor();
            }
            else
            {
                hp += 1;
            }
        }
    }

	void Start () 
    {
        move = false;
        sR = GetComponent<SpriteRenderer>();
        c = GetComponent<SpriteRenderer>().color;
        audio1 = GetComponent<AudioSource>();
        RandomColor();
        InvokeRepeating("ChangeSize", 0, 0.2f);
	}
	

	void FixedUpdate () 
    {
        if (hp <= 0)
        {
            GetComponentInParent<Boss5>().defeated = true;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            if (transform.localScale.x < 5.5f || transform.localScale.y < 5.5f)
            {
                Grow();
            }
            else
            {
                sR.sprite = normal;
                move = true;
            }
            Move();
        }
	}

    void Grow()
    {
        transform.localScale += new Vector3(0.005f, 0.005f, 0);
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

    void Move()
    {
        if(move)
            transform.Translate(new Vector2(0, -0.5f));
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
