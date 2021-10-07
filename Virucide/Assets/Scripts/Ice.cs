using UnityEngine;
using System.Collections;

public class Ice : Basic {

    public int hp;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public GameObject explosion;
    public AudioSource audio1;
    int originalHp;

	void Start () 
    {
        originalHp = hp;
        audio1 = GetComponent<AudioSource>();
        c = GetComponent<SpriteRenderer>().color;
        InvokeRepeating("FlashRed", 0, 0.2f);
	}
	
	void Update () 
    {
        if (Time.timeScale != 0)
        {
            Degrade();
            Tapped();
        }
	}

    void Degrade()
    {
        if(hp <= originalHp * 2/3 && hp > originalHp * 1/3)
        {
            GetComponent<SpriteRenderer>().sprite = Sprite2;
        }
        else if(hp <= originalHp * 1/3 && hp > 0)
        {
            GetComponent<SpriteRenderer>().sprite = Sprite3;
        }
        else if(hp <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    void Tapped()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10.0f));
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                Damage();
                audio1.Play();
                hp -= 1;
            }
        }
    }
}
