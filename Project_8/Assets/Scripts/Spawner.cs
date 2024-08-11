using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ������ �� ������ � ������ �������� ������ ���������
    public Camera cam;
    public GameObject mazeHandler;

    // ������ ������ � � ������
    public Cell cellPrefab;
    public Vector2 CellsSize = new Vector2(1, 1);

    // ������� ���������
    public int width = 10;
    public int height = 10;

    // ����� ������ ��������� ��������� 
    public void GenerateMaze()
    {
        // ������� ���������
        foreach(Transform child in mazeHandler.transform)
            GameObject.Destroy(child.gameObject);
    
        // �������� ���������� � ��������� ���������� ������ ���������
        Generator generator = new Generator();
        Maze maze = generator.GenerateMaze(width, height);

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int z = 0; z < maze.cells.GetLength(1); z++)
            {
                // �������� � ���������� ����������� ������������� ����� ���������
                Cell c = Instantiate(cellPrefab, new Vector3(x * CellsSize.x, 0, z * CellsSize.y), Quaternion.identity);

                // �������� ���� ����� � ���������� � ���������� �������
                //UpW RightW BottomW LeftW
                if (maze.cells[x, z].UpW == false)
                    Destroy(c.UpW);
                if (maze.cells[x, z].RightW == false)
                    Destroy(c.RightW);
                if (maze.cells[x, z].BottomW == false)
                    Destroy(c.BottomW);
                if (maze.cells[x, z].LeftW == false)
                    Destroy(c.LeftW);

                // ���������� ������ � ������ �������� ���������
                c.transform.parent = mazeHandler.transform;
            }
        }

        // ��������� ������ ��� ����������
        cam.transform.position = new Vector3((width*CellsSize.x)/2, Mathf.Max(width, height)*8,(height*CellsSize.y)/2);

    }
}
