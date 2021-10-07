using UnityEngine;
using System.Collections;

public class Boss3 : Boss {

    public float speed;
    public GameObject icicle1;
    public GameObject icicle2;
    public GameObject ice;
    public GameObject lazerBall;
    public GameObject lazer;
    public GameObject eye;
    Vector3 targetPos;
    float originalSpeed;
    bool move2;
    bool move3;

	void Start () 
    {
        originalSpeed = speed;
        move2 = false;
        move3 = false;
	}

    public void Move()
    {
        if (transform.position.x <= -5.0f || transform.position.x >= 5.0f)
        {
            speed = -speed;
        }
        transform.Translate(new Vector2(speed, 0), Space.World);
    }

    public void Revert()
    {
        DestroyMinions();
        CancelInvoke("SummonIce");
        CancelInvoke("DropIcicle1");
        CancelInvoke("DropIcicle2");
        CancelInvoke("LazerBall");
        EyeGray();
        speed = originalSpeed;
        transform.position = new Vector2(0, 6.0f);
    }

    public void DestroyIce()
    {
        GameObject[] iceBlocks = GameObject.FindGameObjectsWithTag("Ice");
        foreach(GameObject iceblock in iceBlocks)
        {
            Destroy(iceblock);
        }
    }

    public void DestroyMinions()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    void SummonIce()
    {
        DestroyIce();
        for(float i = -2.5f; i <= 2.5f; i = i + 2.5f)
        {
            for(float j = -5.0f; j <= 5.0f; j = j + 2.5f)
            {
                Instantiate(ice, new Vector2(j, i), Quaternion.identity);
            }
        }
    }

    public void SummonIces()
    {
        InvokeRepeating("SummonIce", 0, 20.0f);
    }

    void DropIcicle1()
    {
        Instantiate(icicle1, new Vector2(0, 8.0f), Quaternion.identity);
    }

    void DropIcicle2()
    {
        GameObject ici1 = Instantiate(icicle2, new Vector2(-4.0f, 16.0f), Quaternion.identity) as GameObject;
        GameObject ici2 = Instantiate(icicle2, new Vector2(-2.0f, 16.0f), Quaternion.identity) as GameObject;
        GameObject ici3 = Instantiate(icicle2, new Vector2(0f, 16.0f), Quaternion.identity) as GameObject;
        GameObject ici4 = Instantiate(icicle2, new Vector2(2.0f, 16.0f), Quaternion.identity) as GameObject;
        GameObject ici5 = Instantiate(icicle2, new Vector2(4.0f, 16.0f), Quaternion.identity) as GameObject;
        int num = Random.Range(0, 5);
        if (num == 0)
            Destroy(ici1);
        else if (num == 1)
            Destroy(ici2);
        else if (num == 2)
            Destroy(ici3);
        else if (num == 3)
            Destroy(ici4);
        else
            Destroy(ici5);
    }

    public void DropIcicles1()
    {
        InvokeRepeating("DropIcicle1", 0, 3.0f);
    }

    public void DropIcicles2()
    {
        InvokeRepeating("DropIcicle2", 0, 3.0f);
    }

    public void Move2()
    {
        if(move2)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.1f);
            if(transform.position == targetPos)
            {
                DestroyMinions();
                Lazer();
                move2 = false;
            }
        }
        if(move3)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.2f);
            if (transform.position == targetPos)
            {
                DestroyMinions();
                speed = originalSpeed;
                ShootLazer();
                move3 = false;
            }
        }
    }

    public void ShootLazer()
    {
        Invoke("LazerBall", 3.0f);
    }

    void LazerBall()
    {
        speed = 0;
        transform.position = new Vector2(0, 6.0f);
        GameObject ball = Instantiate(lazerBall, transform.position, Quaternion.identity) as GameObject;
        ball.transform.parent = transform;
        int random = Random.Range(0, 2);
        if(random == 0)
        {
            targetPos = new Vector2(-5.0f, 6.0f);
            move2 = true;
        }
        else
        {
            targetPos = new Vector2(5.0f, 6.0f);
            move2 = true;
        }
    }

    void Lazer()
    {
        GameObject lazer1 = Instantiate(lazer, new Vector2(transform.position.x, transform.position.y - 9.9f), Quaternion.identity) as GameObject;
        lazer1.transform.parent = transform;
        if(targetPos.x == -5.0f)
        {
            targetPos = new Vector2(2.5f, 6.0f);
            move3 = true;
        }
        else
        {
            targetPos = new Vector2(-2.5f, 6.0f);
            move3 = true;
        }
    }

    public void EyeColor()
    {
        eye.GetComponent<Boss3Eye>().ChangeColor();
    }

    void EyeGray()
    {
        if(hp > 0)
            eye.GetComponent<Boss3Eye>().Gray();
        else
            eye.GetComponent<Boss3Eye>().DeadEye();
    }

}
