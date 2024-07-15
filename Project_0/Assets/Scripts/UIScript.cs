using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject[] spheres;

    public void reset()
    {
        spheres[0].GetComponent<BallScr_SetVelosity>().reset();
        spheres[1].GetComponent<BallScr_MovePosition>().reset();
        spheres[2].GetComponent<BallScr_AddForce>().reset();
        spheres[3].GetComponent<BallScr_Translate>().reset();
        spheres[4].GetComponent<BallScr_SetPosition>().reset();
    }

}
