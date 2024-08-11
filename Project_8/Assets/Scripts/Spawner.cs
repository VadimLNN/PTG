using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ссылка на камеру и объект хранени€ модели лабиринта
    public Camera cam;
    public GameObject mazeHandler;

    // шаблон €чейки и еЄ размер
    public Cell cellPrefab;
    public Vector2 CellsSize = new Vector2(1, 1);

    // размеры лабиринта
    public int width = 10;
    public int height = 10;

    // вызов метода генерации лабиринта 
    public void GenerateMaze()
    {
        // очистка лабиринта
        foreach(Transform child in mazeHandler.transform)
            GameObject.Destroy(child.gameObject);
    
        // создание генератора и получение логической модели лабиринта
        Generator generator = new Generator();
        Maze maze = generator.GenerateMaze(width, height);

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int z = 0; z < maze.cells.GetLength(1); z++)
            {
                // создание и размезение визуального представлени€ €чеек лабиринта
                Cell c = Instantiate(cellPrefab, new Vector3(x * CellsSize.x, 0, z * CellsSize.y), Quaternion.identity);

                // удаление стен €чеек в соответсии с логической моделью
                //UpW RightW BottomW LeftW
                if (maze.cells[x, z].UpW == false)
                    Destroy(c.UpW);
                if (maze.cells[x, z].RightW == false)
                    Destroy(c.RightW);
                if (maze.cells[x, z].BottomW == false)
                    Destroy(c.BottomW);
                if (maze.cells[x, z].LeftW == false)
                    Destroy(c.LeftW);

                // добавление €чейки в объект хранени€ лабиринта
                c.transform.parent = mazeHandler.transform;
            }
        }

        // установка камеры над лабиринтом
        cam.transform.position = new Vector3((width*CellsSize.x)/2, Mathf.Max(width, height)*8,(height*CellsSize.y)/2);

    }
}
