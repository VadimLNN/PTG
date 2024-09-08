// класс генератор, отвечающий за создание логической модели лабиринта
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class Generator
{
    // размеры лабиринта 
    int width = 10;
    int height = 10;

    MazeCell start;
    MazeCell[,] globalMaze;
    public Maze GenerateMaze(int width, int height, int v)
    {
        this.width = width;
        this.height = height;

        // метод генерации
        MazeCell[,] cells = new MazeCell[width, height];
        globalMaze = cells;

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new MazeCell { X = x, Y = y };
            }
        }

        // удаление стен + поиск путей
        if (v == 1)
            removeWallsOldosBroder(cells);
        else if (v == 2)
            removeWalls(cells);

        findPathsOldosBroder(cells);

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
        current.start = true;
        //current.numInside = 1;
        start = current;

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
                //chosen.numInside = current.numInside + 1;
                stack.Push(chosen);

                // переход к выбранной €чейке
                current = chosen;

            }
            else // возврат по очереди если нет не посещЄнных 
               current = stack.Pop();
          //  
        } while (stack.Count > 0);
    }

    private void removeWallsOldosBroder(MazeCell[,] maze)
    {
        MazeCell current = maze[Random.Range(0, width), Random.Range(0, height)];
        current.visited = true;
        current.numInside = 1;
        current.start = true;
        start = current;

        int unvisited = 1;

        while (unvisited < height * width)
        {
            MazeCell next = pickNeighbor(current, maze);
            if (next.visited == false)
            {
                next.visited = true;
                unvisited++;

                RemoveWall(current, next);
            }
            current = next;


        }
    }
    private MazeCell pickNeighbor(MazeCell current, MazeCell[,] maze)
    {
        int x = current.X, y = current.Y;

        // up down right left
        List<int[]> neighbors = new List<int[]>();

        if (x + 1 < width)
        {
            int[] temp = { x + 1, y };
            neighbors.Add(temp);

        }
        if (x - 1 >= 0)
        {
            int[] temp = { x - 1, y };
            neighbors.Add(temp);
        }
        if (y + 1 < height)
        {
            int[] temp = { x, y + 1 };
            neighbors.Add(temp);
        }
        if (y - 1 >= 0)
        {
            int[] temp = { x, y - 1 };
            neighbors.Add(temp);
        }

        int[] randNeighborCoordinates = neighbors[Random.Range(0, neighbors.Count)];

        x = randNeighborCoordinates[0];
        y = randNeighborCoordinates[1];

        MazeCell randNeighbor = maze[x, y];

        return randNeighbor;
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

    public void findPathsOldosBroder(MazeCell[,] maze)
    {
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y].visited = false;
            }
        }


        MazeCell current = start;
        current.numInside = 1;
        
        int unvisited = 0;

        while (unvisited < height * width)
        {
            List <MazeCell> freeNeighbors = pickFreeNeighbor(current);
            MazeCell next = freeNeighbors[Random.Range(0, freeNeighbors.Count)];
            if (next.visited == false)
            {
                next.visited = true;
                unvisited++;
                
                if (next != start)
                    next.numInside = minNeighborsNum(next)+1;
            }
            current = next;
        }
    }

    private List<MazeCell> pickFreeNeighbor(MazeCell current)
    {
        int x = current.X, y = current.Y;

        // up down right left
        List<MazeCell> neighbors = new List<MazeCell>();

        if (x > 0 && current.LeftW == false) neighbors.Add(globalMaze[x - 1, y]);
        if (y > 0 && current.BottomW == false) neighbors.Add(globalMaze[x, y - 1]);
        if (x < width - 1 && current.RightW == false) neighbors.Add(globalMaze[x + 1, y]);
        if (y < height - 1 && current.UpW == false) neighbors.Add(globalMaze[x, y + 1]);

        return neighbors;
    }

    private int minNeighborsNum(MazeCell current)
    {
        List<int> neighborsNums = new List<int>();

        foreach (MazeCell neighbor in pickFreeNeighbor(current))
            neighborsNums.Add(neighbor.numInside);

        int min = 100;
        foreach (int num in neighborsNums)
            if (num > 0 && num < min)
                min = num;

        return min;
    }
}
