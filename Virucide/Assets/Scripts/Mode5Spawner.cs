using UnityEngine;
using System.Collections;

public class Mode5Spawner : SpikeSpawner {

    public GameObject gray;

    public override void Spawn()
    {
        if ((int)Time.timeSinceLevelLoad < 30)
        {
            GameObject v1 = Instantiate(RandomVirus(), new Vector2(-4.0f, 15.0f), Quaternion.identity) as GameObject;
            GameObject v2 = Instantiate(RandomVirus(), new Vector2(0, 15.0f), Quaternion.identity) as GameObject;
            GameObject v3 = Instantiate(RandomVirus(), new Vector2(4.0f, 15.0f), Quaternion.identity) as GameObject;
            v1.GetComponent<Icicle>().speed = -0.1f;
            v2.GetComponent<Icicle>().speed = -0.1f;
            v3.GetComponent<Icicle>().speed = -0.1f;
            v1.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            v2.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            v3.transform.localScale = new Vector3(1.5f, 1.5f, 0);
        }
        else if ((int)Time.timeSinceLevelLoad >= 30 && (int)Time.timeSinceLevelLoad < 60)
        {
            int random = Random.Range(0, 3);
            if(random == 0)
            {
                GameObject v1 = Instantiate(gray, new Vector2(-4.0f, 15.0f), Quaternion.identity) as GameObject;
                GameObject v2 = Instantiate(RandomVirus(), new Vector2(0, 15.0f), Quaternion.identity) as GameObject;
                GameObject v3 = Instantiate(RandomVirus(), new Vector2(4.0f, 15.0f), Quaternion.identity) as GameObject;
                v1.GetComponent<Icicle>().speed = -0.1f;
                v2.GetComponent<Icicle>().speed = -0.1f;
                v3.GetComponent<Icicle>().speed = -0.1f;
                v1.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v2.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v3.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            }
            else if (random == 1)
            {
                GameObject v1 = Instantiate(RandomVirus(), new Vector2(-4.0f, 15.0f), Quaternion.identity) as GameObject;
                GameObject v2 = Instantiate(gray, new Vector2(0, 15.0f), Quaternion.identity) as GameObject;
                GameObject v3 = Instantiate(RandomVirus(), new Vector2(4.0f, 15.0f), Quaternion.identity) as GameObject;
                v1.GetComponent<Icicle>().speed = -0.1f;
                v2.GetComponent<Icicle>().speed = -0.1f;
                v3.GetComponent<Icicle>().speed = -0.1f;
                v1.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v2.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v3.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            }
            else 
            {
                GameObject v1 = Instantiate(RandomVirus(), new Vector2(-4.0f, 15.0f), Quaternion.identity) as GameObject;
                GameObject v2 = Instantiate(RandomVirus(), new Vector2(0, 15.0f), Quaternion.identity) as GameObject;
                GameObject v3 = Instantiate(gray, new Vector2(4.0f, 15.0f), Quaternion.identity) as GameObject;
                v1.GetComponent<Icicle>().speed = -0.1f;
                v2.GetComponent<Icicle>().speed = -0.1f;
                v3.GetComponent<Icicle>().speed = -0.1f;
                v1.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v2.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v3.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            }
        }
        else
        {
            int random = Random.Range(0, 3);
            if (random == 0)
            {
                GameObject v1 = Instantiate(gray, new Vector2(-4.0f, 15.0f), Quaternion.identity) as GameObject;
                GameObject v2 = Instantiate(gray, new Vector2(0, 15.0f), Quaternion.identity) as GameObject;
                GameObject v3 = Instantiate(RandomVirus(), new Vector2(4.0f, 15.0f), Quaternion.identity) as GameObject;
                v1.GetComponent<Icicle>().speed = -0.1f;
                v2.GetComponent<Icicle>().speed = -0.1f;
                v3.GetComponent<Icicle>().speed = -0.1f;
                v1.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v2.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v3.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            }
            else if (random == 1)
            {
                GameObject v1 = Instantiate(gray, new Vector2(-4.0f, 15.0f), Quaternion.identity) as GameObject;
                GameObject v2 = Instantiate(RandomVirus(), new Vector2(0, 15.0f), Quaternion.identity) as GameObject;
                GameObject v3 = Instantiate(gray, new Vector2(4.0f, 15.0f), Quaternion.identity) as GameObject;
                v1.GetComponent<Icicle>().speed = -0.1f;
                v2.GetComponent<Icicle>().speed = -0.1f;
                v3.GetComponent<Icicle>().speed = -0.1f;
                v1.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v2.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v3.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            }
            else
            {
                GameObject v1 = Instantiate(RandomVirus(), new Vector2(-4.0f, 15.0f), Quaternion.identity) as GameObject;
                GameObject v2 = Instantiate(gray, new Vector2(0, 15.0f), Quaternion.identity) as GameObject;
                GameObject v3 = Instantiate(gray, new Vector2(4.0f, 15.0f), Quaternion.identity) as GameObject;
                v1.GetComponent<Icicle>().speed = -0.1f;
                v2.GetComponent<Icicle>().speed = -0.1f;
                v3.GetComponent<Icicle>().speed = -0.1f;
                v1.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v2.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                v3.transform.localScale = new Vector3(1.5f, 1.5f, 0);
            }
        }
    }

    GameObject RandomVirus()
    {
        int random = Random.Range(0, 4);
        if (random == 0)
            return red;
        else if (random == 1)
            return blue;
        else if (random == 2)
            return green;
        else
            return yellow;
    }
}
