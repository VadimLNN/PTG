using UnityEngine;
using UnityEngine.UI;

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


    public Slider slider;

    // �������� ����������
    Generator generator = new Generator();

    //�������� ������ ��������� 
    Maze maze = new Maze();

    // ����� ������ ��������� ��������� 
    public void GenerateMaze()
    {
        // ������� ���������
        foreach (Transform child in mazeHandler.transform)
            GameObject.Destroy(child.gameObject);
        maze = new Maze();

        //��������� ���������� ������ ���������
        maze = generator.GenerateMaze(width, height, (int)slider.value);

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int z = 0; z < maze.cells.GetLength(1); z++)
            {
                // �������� � ���������� ����������� ������������� ����� ���������
                Cell c = Instantiate(cellPrefab, new Vector3(x * CellsSize.x, 0, z * CellsSize.y), Quaternion.identity);

                c.distance.text = maze.cells[x, z].numInside.ToString();

                if (maze.cells[x, z].start == true)
                    Destroy(c.floor);

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
        cam.transform.position = new Vector3((width * CellsSize.x) / 5f, Mathf.Max(width, height) * 4, (height * CellsSize.y) / 2.2f);
    }

    public void FindAllPath()
    {
        //generator.findPath(maze.cells);
    }
}
