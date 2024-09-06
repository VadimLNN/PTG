using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    // ссылка на камеру и объект хранения модели лабиринта
    public Camera cam;
    public GameObject mazeHandler;

    // шаблон ячейки и её размер
    public Cell cellPrefab;
    public Vector2 CellsSize = new Vector2(1, 1);

    // размеры лабиринта
    public int width = 10;
    public int height = 10;


    public Slider slider;

    // создание генератора
    Generator generator = new Generator();

    //хранение модели лабиринта 
    Maze maze = new Maze();

    // вызов метода генерации лабиринта 
    public void GenerateMaze()
    {
        // очистка лабиринта
        foreach (Transform child in mazeHandler.transform)
            GameObject.Destroy(child.gameObject);
        maze = new Maze();

        //получение логической модели лабиринта
        maze = generator.GenerateMaze(width, height, (int)slider.value);

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int z = 0; z < maze.cells.GetLength(1); z++)
            {
                // создание и размезение визуального представления ячеек лабиринта
                Cell c = Instantiate(cellPrefab, new Vector3(x * CellsSize.x, 0, z * CellsSize.y), Quaternion.identity);

                c.distance.text = maze.cells[x, z].numInside.ToString();

                if (maze.cells[x, z].start == true)
                    Destroy(c.floor);

                // удаление стен ячеек в соответсии с логической моделью
                //UpW RightW BottomW LeftW
                if (maze.cells[x, z].UpW == false)
                    Destroy(c.UpW);
                if (maze.cells[x, z].RightW == false)
                    Destroy(c.RightW);
                if (maze.cells[x, z].BottomW == false)
                    Destroy(c.BottomW);
                if (maze.cells[x, z].LeftW == false)
                    Destroy(c.LeftW);

                // добавление ячейки в объект хранения лабиринта
                c.transform.parent = mazeHandler.transform;
            }
        }

        // установка камеры над лабиринтом
        cam.transform.position = new Vector3((width * CellsSize.x) / 5f, Mathf.Max(width, height) * 4, (height * CellsSize.y) / 2.2f);
    }

    public void FindAllPath()
    {
        //generator.findPath(maze.cells);
    }
}
