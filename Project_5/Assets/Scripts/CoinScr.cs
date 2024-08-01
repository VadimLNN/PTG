using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }

    public void takeDamage()
    {
        Debug.Log("Coin has been received");
        Destroy(this.gameObject, 0.2f);                // уничтожение объекта через 2 секунды
    }
}
