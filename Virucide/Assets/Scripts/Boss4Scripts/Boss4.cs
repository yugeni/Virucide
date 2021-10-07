using UnityEngine;
using System.Collections;

public class Boss4 : Boss {

    public int hp2;
    public float speed;
    public GameObject HandCentre;
    public GameObject Hand1;
    public GameObject Hand2;
    public GameObject Bone1;
    public GameObject Bone2;
    public GameObject bone;
    public GameObject crack;
    public GameObject eyes;
    public GameObject mouth;
    public Sprite deadeyes;
    int num;

    void Start()
    {
        int random = Random.Range(0, 2);
        if (random == 1)
            speed = -speed;
    }

    public void HandBall()
    {
        Hand1.GetComponent<Boss4Hand>().ShootBalls();
        Hand2.GetComponent<Boss4Hand>().ShootBalls();
    }

    public void ReviveHands()
    {
        Hand1.GetComponent<Boss4Hand>().Revive();
        Hand2.GetComponent<Boss4Hand>().Revive();
    }

    void DropBone()
    {
        int random = Random.Range(0, 3);
        num = random;
        if(random == 0)
        {
            Bone1.GetComponent<Boss4Bone>().Flash();
            Invoke("Bone", 1.0f);
            
        }
        else if (random == 1)
        {
            Bone2.GetComponent<Boss4Bone>().Flash();
            Invoke("Bone", 1.0f);
        }
        else
        {
            Bone1.GetComponent<Boss4Bone>().Flash();
            Bone2.GetComponent<Boss4Bone>().Flash();
            Invoke("Bone", 1.0f);
        }
    }

    void Bone()
    {
        if(num == 0)
            Instantiate(bone, new Vector2(-3.0f, 15.0f), Quaternion.Euler(new Vector3(0, 0, 90.0f)));
        else if(num == 1)
            Instantiate(bone, new Vector2(3.0f, 15.0f), Quaternion.Euler(new Vector3(0, 0, 90.0f)));
        else
            Instantiate(bone, new Vector2(0, 15.0f), Quaternion.Euler(new Vector3(0, 0, 90.0f)));
    }

    void FlashCrack()
    {
        crack.GetComponent<Boss4Crack>().StartFlashing();
    }

    public void MoveHandCentre()
    {
        if (HandCentre.transform.position.x <= -4.0f || HandCentre.transform.position.x >= 4.0f)
            speed = -speed;
        HandCentre.transform.Translate(new Vector2(speed, 0));
    }

    public void ShootLazer()
    {
        Hand1.GetComponent<Boss4Hand>().LazerBall();
        Hand2.GetComponent<Boss4Hand>().LazerBall();
    }

    public void Defeat()
    {
        Hand1.GetComponent<Boss4Hand>().Death();
        Hand2.GetComponent<Boss4Hand>().Death();
        eyes.GetComponent<SpriteRenderer>().sprite = deadeyes;
        mouth.GetComponent<Animator>().Play("Boss4MouthDead");
    }

    public void CrackColor()
    {
        crack.GetComponent<Boss4Crack>().ChangeColor();
    }

    public void CrackGray()
    {
        crack.GetComponent<Boss4Crack>().Gray();
    }
}
