// ����� ���������, ���������� �� �������� ���������� ������ ���������
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

        // �������� ��������� 
        Maze maze = new Maze();

        maze.cells = cells;

        return maze;
    }
}
