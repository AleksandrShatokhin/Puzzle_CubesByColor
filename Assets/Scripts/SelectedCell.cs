using UnityEngine;

public static class SelectedCell
{
    public static GameObject currentSelectedCell { get; private set; }

    public static bool IsCurrentSelectedCell() => currentSelectedCell == null;

    public static void SetCurrentSelectedCell(GameObject cell) => currentSelectedCell = cell;

    public static void DeselectCell() => currentSelectedCell = null;
}