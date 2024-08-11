public class MazeCell
{
    // координаты 
    public int X;
    public int Y;

    // наличие стен
    public bool UpW = true;
    public bool RightW = true;
    public bool BottomW = true;
    public bool LeftW = true;

    // состояние посещённости
    public bool visited = false;
}
