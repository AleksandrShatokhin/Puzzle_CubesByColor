using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour, IWritable, ITransmittable
{
    [SerializeField] private StateCell currentState;
    StateCell ITransmittable.GetCurrentState() => currentState;


    [SerializeField] private int point_i, point_j;
    int ITransmittable.GetPoint_I() => point_i;
    int ITransmittable.GetPoint_J() => point_j;


    void IWritable.SetStartedParameters(Color color, StateCell state, int i, int j)
    {
        this.GetComponent<Image>().color = color;
        this.currentState = state;
        this.point_i = i;
        this.point_j = j;
    }

    void IWritable.SetUpdatedCoordinates(int point_i, int point_j)
    {
        this.point_i = point_i;
        this.point_j = point_j;
    }

    public void MouseClick()
    {
        if (this.currentState == StateCell.Block)
        {
            return;
        }

        SwapPlacesChips();
    }

    private void SwapPlacesChips()
    {
        if (SelectedCell.IsCurrentSelectedCell())
        {
            ActionFirstClick();
        }
        else
        {
            ActionSecondClick();
        }
    }

    private void ActionFirstClick()
    {
        if (this.currentState == StateCell.Empty)
        {
            return;
        }

        SelectedCell.SetCurrentSelectedCell(this.gameObject);
    }

    private void ActionSecondClick()
    {
        if (IsCellAdjacent() && this.currentState == StateCell.Empty && this.currentState != StateCell.Block)
        {
            Vector3 valuePosition = SelectedCell.currentSelectedCell.transform.position;

            int valuePoint_i = SelectedCell.currentSelectedCell.GetComponent<ITransmittable>().GetPoint_I();
            int valuePoint_j = SelectedCell.currentSelectedCell.GetComponent<ITransmittable>().GetPoint_J();

            SelectedCell.currentSelectedCell.GetComponent<IWritable>().SetUpdatedCoordinates(this.point_i, this.point_j);
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

    private bool IsCellAdjacent()
    {
        int selectPoint_i = SelectedCell.currentSelectedCell.GetComponent<ITransmittable>().GetPoint_I();
        int selectPoint_j = SelectedCell.currentSelectedCell.GetComponent<ITransmittable>().GetPoint_J();

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