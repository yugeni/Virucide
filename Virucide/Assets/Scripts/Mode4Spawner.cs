using UnityEngine;
using System.Collections;

public class Mode4Spawner : SpikeSpawner {

    public override void Spawn()
    {
        Instantiate(red, new Vector2(Random.Range(-5.0f, 5.0f), 14.0f), Quaternion.identity);
    }
}