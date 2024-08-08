using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScr : MonoBehaviour
{
    // ссылки на аниматор, камеру, 
    public Animator anim;
    public Camera cam;
    Coroutine zoomCor;

    // состояние прицеливания 
    bool isAim = false;

    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            isAim = true;

            if (zoomCor != null)
                StopCoroutine(zoomCor);

            zoomCor = StartCoroutine(aimFieldOfView(cam, 30, 1f));
        }
        else
        {
            isAim = false;
        
            if (zoomCor != null)
                StopCoroutine(zoomCor);

            zoomCor = StartCoroutine(aimFieldOfView(cam, 60, 0.3f));
        }


       anim.SetBool("isAim", isAim);
    }

    IEnumerator aimFieldOfView(Camera targetCam, float toView, float duration)
    {
        float counter = 0;
        float fromView = targetCam.fieldOfView;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            float viewTime = counter / duration;

            targetCam.fieldOfView = Mathf.Lerp(fromView, toView, viewTime);

            yield return null;   
        }
    }
}
                                                                                                                                                                                            