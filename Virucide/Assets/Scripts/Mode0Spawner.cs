using UnityEngine;
using System.Collections;

public class Mode0Spawner : SpikeSpawner {

    public GameObject gray;

    public override void Spawn()
    {
        if((int)Time.timeSinceLevelLoad < 20)
        {
            Instantiate(RandomVirus(), new Vector2(-4.5f, 15.0f), Quaternion.identity);
            Instantiate(RandomVirus(), new Vector2(-1.5f, 15.0f), Quaternion.identity);
            Instantiate(RandomVirus(), new Vector2(1.5f, 15.0f), Quaternion.identity);
            Instantiate(RandomVirus(), new Vector2(4.5f, 15.0f), Quaternion.identity);
        }
        else if ((int)Time.timeSinceLevelLoad >= 20 && (int)Time.timeSinceLevelLoad < 40)
        {
            int random = Random.Range(0, 4);
            if (random == 0)
            {
                Instantiate(gray, new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else if (random == 1)
            {
                Instantiate(RandomVirus(), new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else if (random == 2)
            {
                Instantiate(RandomVirus(), new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else
            {
                Instantiate(RandomVirus(), new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
        }
        else if ((int)Time.timeSinceLevelLoad >= 40 && (int)Time.timeSinceLevelLoad < 60)
        {
            int random = Random.Range(0, 6);
            if (random == 0)
            {
                Instantiate(gray, new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else if(random == 1)
            {
                Instantiate(gray, new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else if (random == 2)
            {
                Instantiate(gray, new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else if (random == 3)
            {
                Instantiate(RandomVirus(), new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else if (random == 4)
            {
                Instantiate(RandomVirus(), new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else
            {
                Instantiate(RandomVirus(), new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
        }
        else
        {
            int random = Random.Range(0, 4);
            if(random == 0)
            {
                Instantiate(RandomVirus(), new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else if (random == 1)
            {
                Instantiate(gray, new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else if (random == 2)
            {
                Instantiate(gray, new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(4.5f, 15.0f), Quaternion.identity);
            }
            else
            {
                Instantiate(gray, new Vector2(-4.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(-1.5f, 15.0f), Quaternion.identity);
                Instantiate(gray, new Vector2(1.5f, 15.0f), Quaternion.identity);
                Instantiate(RandomVirus(), new Vector2(4.5f, 15.0f), Quaternion.identity);
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
