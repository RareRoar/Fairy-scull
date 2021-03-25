
public class Pair
{
    private int x;
    private int y;

    public Pair()
    {
        x = 0;
        y = 0;
    }

    public Pair(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void Move(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int X
    {
        get
        {
            return x;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }
    }

    public void MoveRight()
    {
        y++;
    }

    public void MoveLeft()
    {
        y--;
    }

    public void MoveUp()
    {
        x--;
    }

    public void MoveDown()
    {
        x++;
    }
}

