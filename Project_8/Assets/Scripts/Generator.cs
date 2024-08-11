// класс генератор, отвечающий за создание логической модели лабиринта
using System.Collections.Generic;

public class Generator
{
    // размеры лабиринта 
    int width = 10;
    int height = 10;

    // 
    public Maze GenerateMaze(int width, int height)
    {
        this.width = width;
        this.height = height;

        // метод генерации
        MazeCell[,] cells = new MazeCell[width, height];

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new MazeCell { X = x, Y = y };
            }
        }

        // удаление стен
        removeWalls(cells);

        // создание лабиринта 
        Maze maze = new Maze();

        maze.cells = cells;

        return maze;
    }

    private void removeWalls(MazeCell[,] maze)
    {
        // стартова€ €чейка 
        MazeCell current = maze[0, 0];
        current.visited = true;

        // очередь посещЄнных €чеек 
        Stack<MazeCell> stack = new Stack<MazeCell>();
    
        do
        {
            // список не посещЄнных соседей
            List<MazeCell> unvisitedNeighbours = new List<MazeCell>();

            int x = current.X;
            int y = current.Y;

            // добавление непосещЄнных соседей в список
            if (x > 0 && !maze[x - 1, y].visited) unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if(x < width - 1 && !maze[x + 1, y].visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if(y < height - 1 && !maze[x, y + 1].visited) unvisitedNeighbours.Add(maze[x, y + 1]);

            // если есть непосещЄнные соседи 
            if (unvisitedNeighbours.Count > 0)
            {
                // выбор случайного соседа
                MazeCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                // удаление стен между текущей и выбранной €чейками
                RemoveWall(current, chosen);

                // отметка о посещении и добавлени выбранной в список посещЄнных
                chosen.visited = true;
                stack.Push(chosen);

                // переход к выбранной €чейке
                current = chosen;

            }
            else // возврат по очереди если нет не посещЄнных 
               current = stack.Pop();
          //  
        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeCell a, MazeCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y)          // если происходит удаление стен с €чейкой выше
            {
                a.BottomW = false;
                b.UpW = false;
            }
            else                    // если происходит удаление стен с €чейкой ниже
            {
                b.BottomW = false;
                a.UpW = false;
            }
        }
        else
        {
            if(a.X > b.X)           // если происходит удаление стен с €чейкой левее
            { 
                a.LeftW = false;
                b.RightW = false;
            }
            else                    // если происходит удаление стен с €чейкой правее
            {
                b.LeftW = false;
                a.RightW = false;
            }
        }
    }
}
