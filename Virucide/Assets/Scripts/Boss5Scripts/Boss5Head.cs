using UnityEngine;
using System.Collections;

public class Boss5Head : Boss2Eye {

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Antibody")
        {
            if (sR.sprite == red && col.gameObject.GetComponent<Antibody>().colour == 0)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss5>().hp -= 1;
            }
            else if (sR.sprite == blue && col.gameObject.GetComponent<Antibody>().colour == 1)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss5>().hp -= 1;
            }
            else if (sR.sprite == green && col.gameObject.GetComponent<Antibody>().colour == 2)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss5>().hp -= 1;
            }
            else if (sR.sprite == yellow && col.gameObject.GetComponent<Antibody>().colour == 3)
            {
                Damage();
                audio1.Play();
                GetComponentInParent<Boss5>().hp -= 1;
            }
        }
    }
}
