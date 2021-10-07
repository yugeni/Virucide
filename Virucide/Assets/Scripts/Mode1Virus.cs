using UnityEngine;
using System.Collections;

public class Mode1Virus : Virus {

    public Sprite red;
    public Sprite blue;
    public Sprite green;
    public Sprite yellow;
    float multiplier;

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody")
        {
            if (colour == 0 && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                Damage();
                audio1.Play();
                GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().AddScore();
                ChangeColor();
            }
            else if (colour == 1 && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                Damage();
                audio1.Play();
                GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().AddScore();
                ChangeColor();
            }
            else if (colour == 2 && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                Damage();
                audio1.Play();
                GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().AddScore();
                ChangeColor();
            }
            else if (colour == 3 && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                Damage();
                audio1.Play();
                GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().AddScore();
                ChangeColor();
            }
        }
    }

    public override void FixedUpdate()
    {
        if (GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().score < 10)
            multiplier = 1.0f;
        else if (GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().score >= 10 && GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().score < 20)
            multiplier = 2.0f;
        else if (GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().score >= 20 && GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().score < 30)
            multiplier = 3.0f;
        else if (GameObject.Find("Main Camera").GetComponent<ScoreKeeper>().score >= 30)
            multiplier = 4.0f;
        MoveHorizontal(isMovingH);
    }

    public override void MoveHorizontal(bool movingH)
    {
        if (movingH)
        {
            if (transform.position.x <= -4.75f || transform.position.x >= 4.75f)
            {
                speed = -speed;
            }
            transform.Translate(new Vector2(speed, 0f)*multiplier);
        }
    }


    void ChangeColor()
    {
        if (hp > 0)
        {
            int random = Random.Range(0, 4);
            if (random == 0)
            {
                GetComponent<SpriteRenderer>().sprite = red;
                colour = 0;
            }
            else if (random == 1)
            {
                GetComponent<SpriteRenderer>().sprite = blue;
                colour = 1;
            }
            else if (random == 2)
            {
                GetComponent<SpriteRenderer>().sprite = green;
                colour = 2;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = yellow;
                colour = 3;
            }
        }
    }
}
