// класс жд€ описани€ логики €чейки
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

    // состо€ние посещЄнности
    public bool visited = false;
}
