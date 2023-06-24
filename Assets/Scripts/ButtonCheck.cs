using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    [SerializeField] private int finalyResult;
    [SerializeField] private Image lightIndicator;

    public void CheckGrid(GameObject listChips)
    {
        if (GetResultPositionCells(listChips) == finalyResult)
        {
            OutputMessageToPlayerOnIndikator(true);
        }
        else
        {
            OutputMessageToPlayerOnIndikator(false);
        }
    }

    private void OutputMessageToPlayerOnIndikator(bool value)
    {
        if (value == true)
        {
            StartCoroutine(ColorBlink(Color.green));
        }
        else
        {
            StartCoroutine(ColorBlink(Color.red));
        }
    }

    private float GetResultPositionCells(GameObject listChips)
    {
        List<GameObject> allRedChips = new List<GameObject>();
        List<GameObject> allGreenChips = new List<GameObject>();
        List<GameObject> allYellowChips = new List<GameObject>();

        foreach (Transform go in listChips.transform)
        {
            if (go.GetComponent<ITransmittable>().GetCurrentState() == StateCell.Red)
                allRedChips.Add(go.gameObject);

            if (go.GetComponent<ITransmittable>().GetCurrentState() == StateCell.Green)
                allGreenChips.Add(go.gameObject);

            if (go.GetComponent<ITransmittable>().GetCurrentState() == StateCell.Yellow)
                allYellowChips.Add(go.gameObject);
        }

        int result_Red = 0, result_Green = 0, result_Yellow = 0;

        foreach (GameObject go in allYellowChips)
            if (go.GetComponent<ITransmittable>().GetPoint_J() == 0)
                result_Yellow++;

        foreach (GameObject go in allGreenChips)
            if (go.GetComponent<ITransmittable>().GetPoint_J() == 2)
                result_Green++;

        foreach (GameObject go in allRedChips)
            if (go.GetComponent<ITransmittable>().GetPoint_J() == 4)
                result_Red++;

        float sum = result_Red + result_Green + result_Yellow;

        Debug.Log(sum);

        return sum;
    }

    private IEnumerator ColorBlink(Color color, float delayBlink = 0.3f)
    {
        Color defaultColor = lightIndicator.color;
        int counter = 0;

        while (counter < 3)
        {
            if (lightIndicator.color == defaultColor)
            {
                lightIndicator.color = color;
            }
            else
            {
                lightIndicator.color = defaultColor;
            }

            counter++;

            yield return new WaitForSeconds(delayBlink);
        }

        lightIndicator.color = defaultColor;
    }
}
