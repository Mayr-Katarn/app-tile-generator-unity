using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalculateButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField _offsetBetweenTilesInput;
    [SerializeField] private TMP_InputField _tilesAngleInput;
    [SerializeField] private TMP_InputField _rowOffsetInput;


    public void OnClick()
    {
        TileProperty tileProperty = new TileProperty(
            ValidateText(_offsetBetweenTilesInput),
            ValidateText(_tilesAngleInput),
            ValidateText(_rowOffsetInput)
        );

        EventManager.SendGenerateField(tileProperty);
    }

    private float ValidateText(TMP_InputField input)
    {
        float.TryParse(input.text, out float output);
        return output;
    }
}
