using UnityEngine;
using System.Collections;

public class Virus2 : Virus 
{
    public GameObject projectile;
    public Sprite sprite1;
    public Sprite sprite2;
    public string targetTag;

    public override void Start()
    {
        audio1 = GetComponent<AudioSource>();
        c = GetComponent<SpriteRenderer>().color;
        InvokeRepeating("ShootProjectile", 2.0f, 2.0f);
        if (pivot != null)
        {
            pivotPos = pivot.position;
        }
    }

    void ShootProjectile()
    {
        if (GameObject.FindGameObjectWithTag(targetTag) != null)
        {
            ChangeSprite();
            Instantiate(projectile, new Vector2(transform.position.x, transform.position.y - 0.45f), Quaternion.identity);
        }
    }

    void ChangeSprite()
    {
        OpeningSprite();
        Invoke("OriginalSprite", 0.5f);
    }

    void OriginalSprite()
    {
        GetComponent<SpriteRenderer>().sprite = sprite1;
    }

    void OpeningSprite()
    {
        GetComponent<SpriteRenderer>().sprite = sprite2;
    }

}
