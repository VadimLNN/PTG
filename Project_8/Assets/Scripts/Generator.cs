// ����� ���������, ���������� �� �������� ���������� ������ ���������
using System.Collections.Generic;

public class Generator
{
    // ������� ��������� 
    int width = 10;
    int height = 10;

    // 
    public Maze GenerateMaze(int width, int height)
    {
        this.width = width;
        this.height = height;

        // ����� ���������
        MazeCell[,] cells = new MazeCell[width, height];

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new MazeCell { X = x, Y = y };
            }
        }

        // �������� ����
        removeWalls(cells);

        // �������� ��������� 
        Maze maze = new Maze();

        maze.cells = cells;

        return maze;
    }

    private void removeWalls(MazeCell[,] maze)
    {
        // ��������� ������ 
        MazeCell current = maze[0, 0];
        current.visited = true;

        // ������� ���������� ����� 
        Stack<MazeCell> stack = new Stack<MazeCell>();
    
        do
        {
            // ������ �� ���������� �������
            List<MazeCell> unvisitedNeighbours = new List<MazeCell>();

            int x = current.X;
            int y = current.Y;

            // ���������� ������������ ������� � ������
            if (x > 0 && !maze[x - 1, y].visited) unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if(x < width - 1 && !maze[x + 1, y].visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if(y < height - 1 && !maze[x, y + 1].visited) unvisitedNeighbours.Add(maze[x, y + 1]);

            // ���� ���� ������������ ������ 
            if (unvisitedNeighbours.Count > 0)
            {
                // ����� ���������� ������
                MazeCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                // �������� ���� ����� ������� � ��������� ��������
                RemoveWall(current, chosen);

                // ������� � ��������� � ��������� ��������� � ������ ����������
                chosen.visited = true;
                stack.Push(chosen);

                // ������� � ��������� ������
                current = chosen;

            }
            else // ������� �� ������� ���� ��� �� ���������� 
               current = stack.Pop();
          //  
        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeCell a, MazeCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y)          // ���� ���������� �������� ���� � ������� ����
            {
                a.BottomW = false;
                b.UpW = false;
            }
            else                    // ���� ���������� �������� ���� � ������� ����
            {
                b.BottomW = false;
                a.UpW = false;
            }
        }
        else
        {
            if(a.X > b.X)           // ���� ���������� �������� ���� � ������� �����
            { 
                a.LeftW = false;
                b.RightW = false;
            }
            else                    // ���� ���������� �������� ���� � ������� ������
            {
                b.LeftW = false;
                a.RightW = false;
            }
        }
    }
}
