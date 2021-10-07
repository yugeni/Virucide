using UnityEngine;
using System.Collections;

public class SpikeSpawner : MonoBehaviour {

    public GameObject red;
    public GameObject blue;
    public GameObject green;
    public GameObject yellow;
    public bool right;
    public float repeatRate;

	public void Start () 
    {
        InvokeRepeating("Spawn", 0, repeatRate);
	}
	
    public virtual void Spawn()
    {
        int random = Random.Range(0, 4);
        if(random == 0)
        {
            GameObject spike = Instantiate(red, transform.position, Quaternion.identity) as GameObject;
            if (right)
                spike.GetComponent<Spike1>().movingRight = true;
            else
                spike.GetComponent<Spike1>().movingRight = false;
        }
        else if (random == 1)
        {
            GameObject spike = Instantiate(blue, transform.position, Quaternion.identity) as GameObject;
            if (right)
                spike.GetComponent<Spike1>().movingRight = true;
            else
                spike.GetComponent<Spike1>().movingRight = false;
        }
        else if (random == 2)
        {
            GameObject spike = Instantiate(green, transform.position, Quaternion.identity) as GameObject;
            if (right)
                spike.GetComponent<Spike1>().movingRight = true;
            else
                spike.GetComponent<Spike1>().movingRight = false;
        }
        else
        {
            GameObject spike = Instantiate(yellow, transform.position, Quaternion.identity) as GameObject;
            if (right)
                spike.GetComponent<Spike1>().movingRight = true;
            else
                spike.GetComponent<Spike1>().movingRight = false;
        }
    }

}
