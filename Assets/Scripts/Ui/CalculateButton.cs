using System;
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
    [SerializeField] private TMP_Text _resultText;

    private void OnEnable()
    {
        EventManager.OnShowResult.AddListener(ShowResult);
    }

    public void OnClick()
    {
        TileProperty tileProperty = new(
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

    private void ShowResult(float result) => _resultText.text = $"{Math.Round(result, 2)}";
}
