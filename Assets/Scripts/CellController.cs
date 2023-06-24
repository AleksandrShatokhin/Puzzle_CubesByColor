using UnityEngine;

public class CellController : MainGameController
{
    [SerializeField] private string currentStateText;
    public string GetCurrentStateText() => currentStateText;


    [SerializeField] private int point_i, point_j;
    public int GetPoint_I() => point_i;
    public int GetPoint_J() => point_j;

    public void SetParameters(string state) => currentStateText = state;
    public void SetParameters(int point_i, int point_j)
    {
        this.point_i = point_i;
        this.point_j = point_j;
    }

    public void MouseClick()
    {
        if (this.currentStateText == state_Block)
        {
            return;
        }

        SwapPlacesChip();
    }

    private void SwapPlacesChip()
    {
        if (SelectedCell.IsCurrentSelectedCell())
        {
            ActionFirstPressMouse();
        }
        else
        {
            ActionSecondPressMouse();
        }
    }

    private void ActionFirstPressMouse()
    {
        if (this.currentStateText != state_Empty)
        {
            SelectedCell.SetCurrentSelectedCell(this.gameObject);
        }
    }

    private void ActionSecondPressMouse()
    {
        if (IsClickFreeCell() && this.currentStateText == state_Empty && this.currentStateText != state_Block)
        {
            Vector3 valuePosition = SelectedCell.currentSelectedCell.transform.position;

            int valuePoint_i = SelectedCell.currentSelectedCell.GetComponent<CellController>().GetPoint_I();
            int valuePoint_j = SelectedCell.currentSelectedCell.GetComponent<CellController>().GetPoint_J();

            SelectedCell.currentSelectedCell.GetComponent<CellController>().SetParameters(this.point_i, this.point_j);
            this.point_i = valuePoint_i;
            this.point_j = valuePoint_j;

            SelectedCell.currentSelectedCell.transform.position = this.transform.position;
            this.transform.position = valuePosition;
            SelectedCell.DeselectCell();
        }
        else
        {
            SelectedCell.DeselectCell();
        }
    }

    private bool IsClickFreeCell()
    {
        int selectPoint_i = SelectedCell.currentSelectedCell.GetComponent<CellController>().GetPoint_I();
        int selectPoint_j = SelectedCell.currentSelectedCell.GetComponent<CellController>().GetPoint_J();

        if (selectPoint_i - this.point_i == 1 && selectPoint_j == this.point_j || this.point_i - selectPoint_i == 1 && selectPoint_j == this.point_j ||
            selectPoint_i == this.point_i && selectPoint_j - this.point_j == 1 || selectPoint_i == this.point_i && this.point_j - selectPoint_j == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}