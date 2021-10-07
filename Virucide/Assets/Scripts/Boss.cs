using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public int hp;
    public int originalHp;
    public GameObject explosion;
    public float explosionXY;
    public float yPos;

    public void Death()
    {
        InvokeRepeating("Damage", 0, 0.2f);
        InvokeRepeating("Explosion", 0, 0.5f);
        Invoke("DestroySelf", 5.0f);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void Appear()
    {
        Color c = GetComponent<SpriteRenderer>().color;
        c.a = 1.0f;
        GetComponent<SpriteRenderer>().color = c;
    }

    public void Disappear()
    {
        Color c = GetComponent<SpriteRenderer>().color;
        c.a = 0.0f;
        GetComponent<SpriteRenderer>().color = c;
    }

    public void Damage()
    {
        Disappear();
        Invoke("Appear", 0.1f);
    }

    public void Explosion()
    {
        int random = Random.Range(0, 4);
        float random2 = Random.Range(0, explosionXY);
        if(random == 0)
            Instantiate(explosion, new Vector2(transform.position.x - random2, transform.position.y + random2), Quaternion.identity);
        else if(random == 1)
            Instantiate(explosion, new Vector2(transform.position.x + random2, transform.position.y + random2), Quaternion.identity);
        else if(random == 2)
            Instantiate(explosion, new Vector2(transform.position.x - random2, transform.position.y - random2), Quaternion.identity);
        else
            Instantiate(explosion, new Vector2(transform.position.x + random2, transform.position.y - random2), Quaternion.identity);
    }

}
