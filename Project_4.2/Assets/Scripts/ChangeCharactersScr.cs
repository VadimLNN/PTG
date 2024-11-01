using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharactersScr : MonoBehaviour
{
    public Transform  [] characters;
    public GameObject [] panels; 
    public CamScr camScr;
    
    void Start()
    {
        camScr.changeTraget(characters[0]);
        panels[0].gameObject.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            camScr.changeTraget(characters[0]);
            camScr.camInFace = false;

            for (int i = 0; i < characters.Length; i++)
            {
                if (i == 0)
                {
                    characters[i].gameObject.SetActive(true);
                    panels[i].gameObject.SetActive(true);
                }
                else
                {
                    characters[i].gameObject.SetActive(false);
                    panels[i].gameObject.SetActive(false);
                }
                    
            } 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camScr.changeTraget(characters[1]);
            camScr.camInFace = true;

            for (int i = 0; i < characters.Length; i++)
            {
                if (i == 1)
                {
                    characters[i].gameObject.SetActive(true);
                    panels[i].gameObject.SetActive(true);
                }
                else
                {
                    characters[i].gameObject.SetActive(false);
                    panels[i].gameObject.SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camScr.changeTraget(characters[2]);
            camScr.camInFace = true;

            for (int i = 0; i < characters.Length; i++)
            {
                if (i == 2)
                {
                    characters[i].gameObject.SetActive(true);
                    panels[i].gameObject.SetActive(true);
                }
                else
                {
                    characters[i].gameObject.SetActive(false);
                    panels[i].gameObject.SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            camScr.changeTraget(characters[3]);
            camScr.camInFace = true;

            for (int i = 0; i < characters.Length; i++)
            {
                if (i == 3)
                {
                    characters[i].gameObject.SetActive(true);
                    panels[i].gameObject.SetActive(true);
                }
                else
                {
                    characters[i].gameObject.SetActive(false);
                    panels[i].gameObject.SetActive(false);
                }
            }
        }

    }
}
