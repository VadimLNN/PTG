using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [Range(0.1f, 100f)]
    public float speed = 2;
    public Material hitMat;
    private Renderer ren;


    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ren.material = hitMat; // смена материала при столкновении 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
