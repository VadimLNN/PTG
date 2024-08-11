using UnityEngine;
using UnityEngine.UI;

// класс описывающий €чейку лабиринта 
public class Cell : MonoBehaviour
{
    // ссылки на стены 
    public GameObject UpW;
    public GameObject RightW;
    public GameObject BottomW;
    public GameObject LeftW;

    // ссылка на текст в €чейке
    public Text distance;
}
