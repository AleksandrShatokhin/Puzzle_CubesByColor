using UnityEngine;

public class GridController : MainGameController
{
    [SerializeField] private GameObject cell_Prefab;

    private void Start()
    {
        CreateGridCells();
    }

    private GameObject[,] CreateGridCells(int n = 5)
    {
        gridCells = new GameObject[n, n];
        float resetPosition_X = startPosition_X;
        Transform gridSellsPosInHierarchy = this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // ������� ������
                CreateCell(i, j, cell_Prefab, gridSellsPosInHierarchy);
                startPosition_X += offset;

                // ����� ������� ��������� � ������������ � ������� �����
                FillChipsColumn(i, j);

                // ������������� ����� �� ������������ �������
                SetBlockToCells(i, j);
            }
            startPosition_Y -= offset;
            startPosition_X = resetPosition_X;
        }

        return gridCells;
    }
}
