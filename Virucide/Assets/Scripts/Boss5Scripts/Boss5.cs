using UnityEngine;
using System.Collections;

public class Boss5 : Boss {

    public GameObject barrier;
    public GameObject head;
    public GameObject energyBall1;
    public GameObject energyBall2;
    public GameObject core;
    public GameObject giantBall;
    public float speed;
    public bool defeated;

	void Start () 
    {
        defeated = false;
	}

    public void Revert()
    {
        transform.position = new Vector2(0, 6.0f);
    }

    public void Move()
    {
        if (transform.position.x <= -5.0f || transform.position.x >= 5.0f)
        {
            speed = -speed;
        }
        transform.Translate(new Vector2(speed, 0), Space.World);
    }

    public void ReleaseBall()
    {
        giantBall.SetActive(true);
    }

    public void ActivateBarrier()
    {
        barrier.SetActive(true);
    }

    public void ReviveBarrier()
    {
        barrier.GetComponent<Boss5Barrier>().Revive();
    }

    void EnergyBall1A()
    {
        int random = Random.Range(0, 4);
        if (random == 0)
            Instantiate(energyBall1, new Vector2(-4.5f, 15.0f), Quaternion.identity);
        else if (random == 1)
            Instantiate(energyBall1, new Vector2(-1.5f, 15.0f), Quaternion.identity);
        else if (random == 2)
            Instantiate(energyBall1, new Vector2(1.5f, 15.0f), Quaternion.identity);
        else
            Instantiate(energyBall1, new Vector2(4.5f, 15.0f), Quaternion.identity);
    }

    void EnergyBall1B()
    {
        GameObject ball1 = Instantiate(energyBall1, new Vector2(-4.5f, 15.0f), Quaternion.identity) as GameObject;
        GameObject ball2 = Instantiate(energyBall1, new Vector2(-1.5f, 15.0f), Quaternion.identity) as GameObject;
        GameObject ball3 = Instantiate(energyBall1, new Vector2(1.5f, 15.0f), Quaternion.identity) as GameObject;
        GameObject ball4 = Instantiate(energyBall1, new Vector2(4.5f, 15.0f), Quaternion.identity) as GameObject;
        int random = Random.Range(0, 4);
        if (random == 0)
            Destroy(ball1);
        else if (random == 1)
            Destroy(ball2);
        else if (random == 2)
            Destroy(ball3);
        else
            Destroy(ball4);
    }

    void EnergyBall2()
    {
        for(float i = -4.5f; i <= 4.5f; i = i + 3.0f)
        {
            Instantiate(energyBall2, new Vector2(i, 15.0f), Quaternion.identity);
        }
    }

    public void HeadColor()
    {
        head.GetComponent<Boss5Head>().ChangeColor();
    }

    public void HeadGray()
    {
        head.GetComponent<Boss5Head>().Gray();
    }

    public void FlashCore()
    {
        core.GetComponent<Boss5Core>().StartFlashing();
    }

    public void StopCore()
    {
        core.GetComponent<Boss5Core>().StopFlashing();
    }

    public void RestoreHp()
    {
        hp = originalHp;
    }
}
