using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject antibodyR;
    public GameObject antibodyB;
    public GameObject antibodyG;
    public GameObject antibodyY;
    public Sprite arrow;
    public Sprite arrowPressed;
    bool movingLeft;
    bool movingRight;

	void Start ()
    {
        movingLeft = false;
        movingRight = false;
	}
	
	void FixedUpdate () 
    {
        MoveLeftOrRight();
	}

    public void MoveLeftDown()
    {
        leftArrow.GetComponent<Image>().sprite = arrowPressed;
        movingLeft = true;
    }

    void MoveLeftOrRight()
    {
        if(movingLeft)
        {
            if(GameObject.Find("PlasmaBoy"))
            {
                if (GameObject.Find("PlasmaBoy").transform.position.x > -4.8f)
                    GameObject.Find("PlasmaBoy").transform.Translate(new Vector2(-0.2f, 0f));
            }
        }
        if(movingRight)
        {
            if (GameObject.Find("PlasmaBoy"))
            {
                if (GameObject.Find("PlasmaBoy").transform.position.x < 4.8f)
                    GameObject.Find("PlasmaBoy").transform.Translate(new Vector2(0.2f, 0f));
            }
        }
    }

    public void MoveLeftUp()
    {
        leftArrow.GetComponent<Image>().sprite = arrow;
        movingLeft = false;
    }

    public void MoveRightDown()
    {
        rightArrow.GetComponent<Image>().sprite = arrowPressed;
        movingRight = true;
    }

    public void MoveRightUp()
    {
        rightArrow.GetComponent<Image>().sprite = arrow;
        movingRight = false;
    }

    public void ShootRed()
    {
        if (GameObject.Find("PlasmaBoy"))
        {
            Instantiate(antibodyR, new Vector2(GameObject.Find("PlasmaBoy").transform.position.x, GameObject.Find("PlasmaBoy").transform.position.y + 1.8f), Quaternion.identity);
        }
    }

    public void ShootBlue()
    {
        if (GameObject.Find("PlasmaBoy"))
        {
            Instantiate(antibodyB, new Vector2(GameObject.Find("PlasmaBoy").transform.position.x, GameObject.Find("PlasmaBoy").transform.position.y + 1.8f), Quaternion.identity);
        }
    }

    public void ShootGreen()
    {
        if (GameObject.Find("PlasmaBoy"))
        {
            Instantiate(antibodyG, new Vector2(GameObject.Find("PlasmaBoy").transform.position.x, GameObject.Find("PlasmaBoy").transform.position.y + 1.8f), Quaternion.identity);
        }
    }

    public void ShootYellow()
    {
        if (GameObject.Find("PlasmaBoy"))
        {
            Instantiate(antibodyY, new Vector2(GameObject.Find("PlasmaBoy").transform.position.x, GameObject.Find("PlasmaBoy").transform.position.y + 1.8f), Quaternion.identity);
        }
    }
}
