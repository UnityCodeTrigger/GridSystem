using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{

    int width, height;
    float cellSize;
    Vector3 origin;

    // x , y 
    int[,] gridvalue;

    public Grid(int _width, int _height, float _cellSize, Vector3 _origin)
    {
        //Inicilizamos las variables
        width = _width;
        height = _height;
        cellSize = _cellSize;
        origin = _origin;

        gridvalue = new int[width,height];

        //Generamos la cuadricula
        for (int y = 0; y < gridvalue.GetLength(1); y++)
        {
            for (int x = 0; x < gridvalue.GetLength(0); x++)
            {

                Debug.Log($"X:{x} / Y:{y}");

                Debug.DrawLine(CellToWorldPoint(x, y), CellToWorldPoint(x + 1, y), Color.white, 999f);
                Debug.DrawLine(CellToWorldPoint(x, y), CellToWorldPoint(x, y + 1), Color.white, 999f);

            }
        }

        Debug.DrawLine(CellToWorldPoint(0, height), CellToWorldPoint(width, height), Color.white, 999f);
        Debug.DrawLine(CellToWorldPoint(width, 0), CellToWorldPoint(width, height), Color.white, 999f);

    }

    //Get Set Grid value functions
    public void SetGridValue(int x, int y,int value)
    {
        if(x >= 0 && x < gridvalue.GetLength(0) && y >= 0 && y < gridvalue.GetLength(1))
            gridvalue[x, y] = value;
    }

    public void SetGridValue(Vector3 position, int value)
    {
        int x, y;
        WorldToCellPosition(position, out x, out y);

        SetGridValue(x,y,value);
    }

    public int GetGridValue(int x, int y)
    {
        int value = 0;

        if (x >= 0 && x < gridvalue.GetLength(0) && y >= 0 && y < gridvalue.GetLength(1))
            value = gridvalue[x, y];

        return value;
    }

    public int GetGridValue(Vector3 position)
    {
        int value = 0;
        int x, y;
        WorldToCellPosition(position, out x, out y);

        value = GetGridValue(x, y);

        return value;
    }

    public void WorldToCellPosition(Vector3 pos, out int x, out int y)
    {
        x = Mathf.FloorToInt( (pos.x - origin.x) / cellSize);
        y = Mathf.FloorToInt( (pos.y - origin.y) / cellSize);
    }

    public Vector3 CellToWorldPoint(int x, int y)
    {
        Vector3 pos = Vector3.zero;

        pos.x = (x * cellSize) + origin.x;
        pos.y = (y * cellSize) + origin.y;

        return pos;
    }

}
