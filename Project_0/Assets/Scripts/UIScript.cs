using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject[] spheres;

    public void reset()
    {
        foreach (GameObject sphere in spheres) 
        {
            sphere.GetComponent<BallScript>().reset(); 
        }

    }

}
