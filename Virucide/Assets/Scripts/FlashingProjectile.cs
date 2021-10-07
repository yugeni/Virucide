using UnityEngine;
using System.Collections;

public class FlashingProjectile : Basic {

    public GameObject explosion;
    public float speed;
    public string targetTag;
    public bool tappable;
    public bool spinning;
    GameObject target;
    Vector3 targetPos;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag(targetTag) != null)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
            int random = Random.Range(0, targets.Length);
            target = targets[random];
            targetPos = target.transform.position;
        }
        c = GetComponent<SpriteRenderer>().color;
        InvokeRepeating("FlashRed", 0, 0.2f);
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            Tapped();
            Spin(spinning);
            Move();
        }
    }

    void Tapped()
    {
        if (Input.touchCount > 0 && tappable)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10.0f));
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    void Move()
    {
        if (target != null)
        {
            targetPos = target.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);
        }
    }

    void Spin(bool isSpinning)
    {
        if(isSpinning)
            transform.Rotate(Vector3.back, 5.0f);
    }
}
