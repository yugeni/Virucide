using UnityEngine;
using System.Collections;

public class JellySpawner : SpikeSpawner {

    public override void Spawn()
    {
        GameObject spike = Instantiate(red, transform.position, Quaternion.identity) as GameObject;
        if (right)
            spike.GetComponent<Jelly>().movingRight = true;
        else
            spike.GetComponent<Jelly>().movingRight = false;
    }
	
}
