using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{
    // ���������� 
    public int X;
    public int Y;

    // ������� ����
    public bool UpW = true;
    public bool RightW = true;
    public bool BottomW = true;
    public bool LeftW = true;

    // ��������� ������������
    public bool visited = false;
}
