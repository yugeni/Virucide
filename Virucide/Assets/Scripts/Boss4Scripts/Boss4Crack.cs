using UnityEngine;
using System.Collections;

public class Boss4Crack : Boss2Eye {

    public bool tappable;

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody")
        {
            if (sR.sprite == red && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss4>().hp -= 1;
            }
            else if (sR.sprite == blue && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss4>().hp -= 1;
            }
            else if (sR.sprite == green && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss4>().hp -= 1;
            }
            else if (sR.sprite == yellow && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss4>().hp -= 1;
            }
        }
    }

    public override void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        audio1 = GetComponent<AudioSource>();
        c = GetComponent<SpriteRenderer>().color;
        Gray();
        tappable = false;
    }

    void FixedUpdate()
    {
        Tapped();
    }

    public void StartFlashing()
    {
        tappable = true;
        InvokeRepeating("FlashRed", 0, 0.2f);
        Invoke("StopFlashing", 2.0f);
    }

    void StopFlashing()
    {
        tappable = false;
        CancelInvoke("FlashRed");
    }

    void Tapped()
    {
        if (Input.touchCount > 0 && tappable)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10.0f));
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
            {
                GetComponentInParent<Boss4>().Damage();
                audio1.Play();
                GetComponentInParent<Boss4>().hp2 -= 1;
                StopFlashing();
            }
        }
    }
}
