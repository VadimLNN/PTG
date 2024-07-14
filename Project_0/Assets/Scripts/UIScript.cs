using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject sphere;

    public void reset()
    {
        sphere.GetComponent<BallScript>().reset();
    }

}
