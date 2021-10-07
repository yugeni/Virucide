using UnityEngine;
using System.Collections;

public class Boss1 : Boss {

    public float speed;
    public float xSpeed;
    public float ySpeed;
    public GameObject fireBallO1;
    public GameObject fireBallO2;
    public GameObject fireRing;
    Animator anim;
    AudioSource[] audios;


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody")
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Boss1R") && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                Damage();
                audios[0].Play();
                hp -= 1;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Boss1B") && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                Damage();
                audios[0].Play();
                hp -= 1;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Boss1G") && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                Damage();
                audios[0].Play();
                hp -= 1;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Boss1Y") && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                Damage();
                audios[0].Play();
                hp -= 1;
            }
        }
    }

	void Start()
    {
        anim = GetComponent<Animator>();
        audios = GetComponents<AudioSource>();
    }

    public void Revert()
    {
        CancelInvoke("RandomColor");
        CancelInvoke("ShootFireBallO1");
        CancelInvoke("ShootFireBallO2");
        transform.position = new Vector2(0, 5.0f);
        anim.Play("Boss1");
    }

    public void ChangeColor()
    {
        if(hp < originalHp/4)
            InvokeRepeating("RandomColor", 0, 2.0f);
        else
            InvokeRepeating("RandomColor", 0, 5.0f);
    }

    void RandomColor()
    {
        int random = Random.Range(0, 4);
        if(random == 0)
            anim.Play("Boss1R");
        else if(random == 1)
            anim.Play("Boss1B");
        else if(random == 2)
            anim.Play("Boss1G");
        else
            anim.Play("Boss1Y");
    }

    public void Move1()
    {
        if (transform.position.x <= -4.0f || transform.position.x >= 4.0f)
        {
            speed = -speed;
        }
        transform.Translate(new Vector2(speed, 0f), Space.World);
    }

    public void FireRing()
    {
        GameObject fireRingLB = Instantiate(fireRing, transform.position, Quaternion.identity) as GameObject;
        fireRingLB.transform.parent = transform;
    }

    void ShootFireBallO1()
    {
        Instantiate(fireBallO1, transform.position, Quaternion.identity);
    }

    public void ShootFireBallsO1()
    {
        InvokeRepeating("ShootFireBallO1", 3.0f, 3.0f);
    }

    void ShootFireBallO2()
    {
        int random = Random.Range(0, 5);
        if(random == 0)
            Instantiate(fireBallO2, new Vector2(-4.0f, 12.0f), Quaternion.identity);
        else if(random == 1)
            Instantiate(fireBallO2, new Vector2(-2.0f, 12.0f), Quaternion.identity);
        else if(random == 2)
            Instantiate(fireBallO2, new Vector2(0, 12.0f), Quaternion.identity);
        else if(random == 3)
            Instantiate(fireBallO2, new Vector2(2.0f, 12.0f), Quaternion.identity);
        else
            Instantiate(fireBallO2, new Vector2(4.0f, 12.0f), Quaternion.identity);
    }

    public void ShootFireBallsO2()
    {
        InvokeRepeating("ShootFireBallO2", 0.5f, 0.5f);
    }

    public void DestroyMinions()
    {
        GameObject[] minions = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject minion in minions)
        { 
            if(minion != null)
                Destroy(minion);
        }
    }

    public void Bounce()
    {
        if (transform.position.x <= -4.0f || transform.position.x >= 4.0f)
        {
            audios[1].Play();
            xSpeed = -xSpeed;
        }
        if (transform.position.y <= -5.5f || transform.position.y >= 11.0f)
        { 
            audios[1].Play();
            ySpeed = -ySpeed;
        }
        transform.Translate(new Vector2(xSpeed, ySpeed), Space.World);
    }
}
