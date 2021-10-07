using UnityEngine;
using System.Collections;

public class Boss2 : Boss {

    public int hp2;
    public float xSpeed;
    public float ySpeed;
    public GameObject minion;
    public GameObject projectile;
    public GameObject eye1;
    public GameObject eye2;
    public GameObject feeler1;
    public GameObject feeler2;
    Vector3 originalPos;
    Vector3 targetPos;
    float x;
    float y;
    bool attacking;
    bool retreating;

    void Start()
    {
        attacking = false;
        retreating = false;
    }

    void FixedUpdate()
    {
        Attacking();
        Retreat();
    }

    void SummonMinion()
    {
        float random = Random.Range(-4.0f, 4.0f);
        Instantiate(minion, new Vector2(random, 4.0f), Quaternion.identity);
    }

    public void SummonMinions()
    {
        InvokeRepeating("SummonMinion", 1.0f, 1.0f);
    }

    public void Move1()
    {
        if (transform.position.x <= -4.0f || transform.position.x >= 4.0f)
        {
            xSpeed = -xSpeed;
        }
        transform.Translate(new Vector2(xSpeed, ySpeed), Space.World);
    }

    public void Revert()
    {
        CancelInvoke("SummonMinion");
        CancelInvoke("ShootProjectile");
        CancelInvoke("Attack");
        CancelInvoke("FlashFeeler");
        CancelInvoke("StartAttacking");
        EyeGray();
        transform.position = new Vector2(0, 6.0f);
    }

    void ShootProjectile()
    {
        for(float i = -0.2f; i <= 0.2f; i = i + 0.1f)
        {
            GameObject projectileO = Instantiate(projectile, new Vector2(transform.position.x, transform.position.y - 3.0f), Quaternion.identity) as GameObject;
            projectileO.GetComponent<Projectile>().setSpeed(i, -0.15f);
        }
    }

    public void ShootProjectiles()
    {
        InvokeRepeating("ShootProjectile", 1.0f, 2.0f);
    }

    public void RandomAttack()
    {
        if (hp2 > 0)
        {
            float random = Random.Range(1.0f, 3.0f);
            Invoke("Attack", random);
        }
    }

    void Attack()
    {
        x = xSpeed;
        y = ySpeed;
        xSpeed = 0;
        ySpeed = 0;
        targetPos = new Vector2(transform.position.x, -2.0f);
        originalPos = transform.position;
        Invoke("StartAttacking", 0.5f);
    }

    void StartAttacking()
    {
        attacking = true;
    }

    void Attacking()
    {
        if(attacking)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.5f);
            if(transform.position == targetPos)
            {
                retreating = true;
                attacking = false;
            }
        }
    }

    void Retreat()
    {
        if(retreating)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, 0.5f);
            if (transform.position == originalPos)
            {
                xSpeed = x;
                ySpeed = y;
                RandomAttack();
                retreating = false;
            }
        }
    }

    void FlashFeeler()
    {
        int random = Random.Range(0, 2);
        if (random == 0)
            feeler1.GetComponent<Boss2Feeler>().StartFlashing();
        else
            feeler2.GetComponent<Boss2Feeler>().StartFlashing();
    }

    public void FlashFeelers()
    {
        InvokeRepeating("FlashFeeler", 0, 2.0f);
    }

    public void EyeColor()
    {
        eye1.GetComponent<Boss2Eye>().ChangeColor();
        eye2.GetComponent<Boss2Eye>().ChangeColor();
    }

    void EyeGray()
    {
        eye1.GetComponent<Boss2Eye>().Gray();
        eye2.GetComponent<Boss2Eye>().Gray();
    }
}
