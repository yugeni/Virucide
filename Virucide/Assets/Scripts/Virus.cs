using UnityEngine;
using System.Collections;

public class Virus : Basic {

    public int colour;
    public int hp;
    public GameObject explosion;
    public float speed;
    public bool isMovingH;
    public bool isOrbit;
    public bool antiClockwise;
    public Transform pivot;
    public Vector3 pivotPos;
    public AudioSource audio1;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Antibody")
        {
            if(colour == 0 && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                Damage();
                audio1.Play();
                hp -= 1;
            }
            else if (colour == 1 && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                Damage();
                audio1.Play();
                hp -= 1;
            }
            else if (colour == 2 && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                Damage();
                audio1.Play();
                hp -= 1;
            }
            else if (colour == 3 && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                Damage();
                audio1.Play();
                hp -= 1;
            }
        }
        if(col.gameObject.tag == "Spiked")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public virtual void Start()
    {
        audio1 = GetComponent<AudioSource>();
        c = GetComponent<SpriteRenderer>().color;
        if (pivot != null)
        {
            pivotPos = pivot.position;
        }
    }

    public virtual void FixedUpdate()
    {
        if(hp <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            MoveHorizontal(isMovingH);
            Orbit(isOrbit);
        }
    }

    public virtual void MoveHorizontal(bool movingH)
    {
        if(movingH)
        {
            if(transform.position.x <= -4.75f || transform.position.x >= 4.75f)
            {
                speed = -speed;
            }
            transform.Translate(new Vector2(speed, 0f));
        }
    }

    public void Orbit(bool orbiting)
    {
        if(orbiting)
        {
            if(antiClockwise)
            {
                transform.RotateAround(pivotPos, Vector3.forward, speed);
                transform.rotation = Quaternion.identity;
            }
            else
            {
                transform.RotateAround(pivotPos, Vector3.back, speed);
                transform.rotation = Quaternion.identity;
            }
        }
    }

}
