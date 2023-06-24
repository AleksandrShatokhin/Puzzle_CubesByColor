using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
    // переменные для разделения фишек по состояниям
    protected const string state_Block = "State Block", state_Empty = "State Empty", state_Red = "State Red", state_Green = "State Green", state_Yellow = "State Yellow";

    // переменные для разделения фишек по цветам
    private Color32 color_Red = new Color32(200, 60, 60, 255);
    private Color32 color_Green = new Color32(60, 180, 60, 255);
    private Color32 color_Yellow = new Color32(200, 180, 60, 255);

    // переменные для работы с созданием и работы с сеткой фишек
    protected GameObject[,] gridCells;
    protected float startPosition_X = -300.0f, startPosition_Y = 300.0f;
    protected float offset = 150.0f, inPlace = 0.0f;
    protected int resultSumChips = 15;


    protected void CreateCell(int i, int j, GameObject prefab, Transform positionInHierarchy)
    {
        gridCells[i, j] = Instantiate(prefab, new Vector2(startPosition_X, startPosition_Y), Quaternion.identity) as GameObject;
        gridCells[i, j].transform.SetParent(positionInHierarchy, false);
        gridCells[i, j].GetComponent<CellController>().SetParameters(state_Empty);
        gridCells[i, j].GetComponent<CellController>().SetParameters(i, j);
        gridCells[i, j].transform.gameObject.name = "Cell_" + i + "." + j;
    }

    protected void FillChipsColumn(int i, int j)
    {
        if (i == 0 && j == 0 || i == 3 && j == 0 || i == 3 && j == 2 || i == 0 && j == 4 || i == 1 && j == 4)
        {
            SetColorsForChips(i, j, color_Green, state_Green);
        }

        if (i == 1 && j == 0 || i == 4 && j == 0 || i == 2 && j == 2 || i == 4 && j == 2 || i == 2 && j == 4)
        {
            SetColorsForChips(i, j, color_Red, state_Red);
        }

        if (i == 2 && j == 0 || i == 0 && j == 2 || i == 1 && j == 2 || i == 3 && j == 4 || i == 4 && j == 4)
        {
            SetColorsForChips(i, j, color_Yellow, state_Yellow);
        }
    }

    protected void SetColorsForChips(int i, int j, Color color, string state)
    {
        gridCells[i, j].GetComponent<Image>().color = color;
        gridCells[i, j].GetComponent<CellController>().SetParameters(state);
    }

    protected void SetBlockToCells(int i, int j)
    {
        if (i == 0 && j == 1 || i == 0 && j == 3 || i == 2 && j == 1 || i == 2 && j == 3 || i == 4 && j == 1 || i == 4 && j == 3)
        {
            SetColorsForChips(i, j, Color.black, state_Block);
        }
    }
}