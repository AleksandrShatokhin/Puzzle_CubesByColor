using UnityEngine;

public class GridController : MainGridController
{
    private void Start()
    {
        CreateGridCells();
    }

    private GameObject[,] CreateGridCells(int n = 5)
    {
        gridCells = new GameObject[n, n];
        float resetPosition_X = startPosition_X;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                CreateCell(i, j);
                startPosition_X += offset;
            }

            startPosition_Y -= offset;
            startPosition_X = resetPosition_X;
        }

        return gridCells;
    }
}
