using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    [SerializeField] [Range(1,10)] int width, height;
    [SerializeField] [Range(.1f,2f)] float cellsize;

    Grid grid;

    void Start()
    {
        grid = new Grid(width, height, cellsize, transform.position);
    }

    private void Update()
    {
        //Get value
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log( grid.GetGridValue(mousePos) );
        }

        //Add value
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            grid.SetGridValue(mousePos, grid.GetGridValue(mousePos) + 1);
        }
    }

    private void OnDrawGizmos()
    {
        if (grid == null)
            return;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float value = grid.GetGridValue(x, y);

                Color color = Color.HSVToRGB((value * 0.05f) % 1, 1, 1);
                Gizmos.color = color;
                Gizmos.DrawCube(grid.CellToWorldPoint(x, y) + Vector3.one * cellsize * 0.5f,Vector3.one * cellsize);
            }
        }

    }

}
