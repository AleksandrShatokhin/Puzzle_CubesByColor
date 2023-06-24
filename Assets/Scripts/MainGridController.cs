using UnityEngine;

public class MainGridController : MonoBehaviour
{
    [SerializeField] private GameObject cell_Prefab;
    [SerializeField] private Transform positionInHierarhy;
    [SerializeField] protected Parameters parametersComponent;

    private Color32 color_Red = new Color32(200, 60, 60, 255);
    private Color32 color_Green = new Color32(60, 180, 60, 255);
    private Color32 color_Yellow = new Color32(200, 180, 60, 255);
    private Color32 color_Black = Color.black;
    private Color32 color_Empty = new Color32(99, 99, 99, 255);

    protected GameObject[,] gridCells;
    protected float startPosition_X = -300.0f, startPosition_Y = 300.0f;
    protected float offset = 150.0f, inPlace = 0.0f;
    protected int resultSumChips = 15;

    protected void CreateCell(int i, int j)
    {
        gridCells[i, j] = Instantiate(cell_Prefab, new Vector2(startPosition_X, startPosition_Y), Quaternion.identity) as GameObject;
        gridCells[i, j].transform.SetParent(positionInHierarhy, false);
        gridCells[i, j].transform.gameObject.name = "Cell_" + i + "." + j;
        DefineFormatCellInGrid(i, j);
    }

    protected void DefineFormatCellInGrid(int i, int j)
    {
        if (i == parametersComponent.GreenParameter1.i && j == parametersComponent.GreenParameter1.j
            || i == parametersComponent.GreenParameter2.i && j == parametersComponent.GreenParameter2.j
            || i == parametersComponent.GreenParameter3.i && j == parametersComponent.GreenParameter3.j
            || i == parametersComponent.GreenParameter4.i && j == parametersComponent.GreenParameter4.j
            || i == parametersComponent.GreenParameter5.i && j == parametersComponent.GreenParameter5.j)
        {
            SetStartedParametersInCell(i, j, color_Green, StateCell.Green);
        }
        else
        if (i == parametersComponent.RedParameter1.i && j == parametersComponent.RedParameter1.j
            || i == parametersComponent.RedParameter2.i && j == parametersComponent.RedParameter2.j
            || i == parametersComponent.RedParameter3.i && j == parametersComponent.RedParameter3.j
            || i == parametersComponent.RedParameter4.i && j == parametersComponent.RedParameter4.j
            || i == parametersComponent.RedParameter5.i && j == parametersComponent.RedParameter5.j)
        {
            SetStartedParametersInCell(i, j, color_Red, StateCell.Red);
        }
        else
        if (i == parametersComponent.YellowParameter1.i && j == parametersComponent.YellowParameter1.j
            || i == parametersComponent.YellowParameter2.i && j == parametersComponent.YellowParameter2.j
            || i == parametersComponent.YellowParameter3.i && j == parametersComponent.YellowParameter3.j
            || i == parametersComponent.YellowParameter4.i && j == parametersComponent.YellowParameter4.j
            || i == parametersComponent.YellowParameter5.i && j == parametersComponent.YellowParameter5.j)
        {
            SetStartedParametersInCell(i, j, color_Yellow, StateCell.Yellow);
        }
        else
        if (i == parametersComponent.BlockParameter1.i && j == parametersComponent.BlockParameter1.j
            || i == parametersComponent.BlockParameter2.i && j == parametersComponent.BlockParameter2.j
            || i == parametersComponent.BlockParameter3.i && j == parametersComponent.BlockParameter3.j
            || i == parametersComponent.BlockParameter4.i && j == parametersComponent.BlockParameter4.j
            || i == parametersComponent.BlockParameter5.i && j == parametersComponent.BlockParameter5.j
            || i == parametersComponent.BlockParameter6.i && j == parametersComponent.BlockParameter6.j)
        {
            SetStartedParametersInCell(i, j, color_Black, StateCell.Block);
        }
        else
        {
            SetStartedParametersInCell(i, j, color_Empty, StateCell.Empty);
        }
    }

    protected void SetStartedParametersInCell(int i, int j, Color color, StateCell state) => gridCells[i, j].GetComponent<IWritable>().SetStartedParameters(color, state, i, j);
}