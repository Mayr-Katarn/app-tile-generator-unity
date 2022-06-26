using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public static UnityEvent<TileProperty> OnGenerateField = new();
    public static UnityEvent<Tile> OnCutTile = new();
    public static UnityEvent<float> OnShowResult = new();

    public static void SendGenerateField(TileProperty tileProperty) => OnGenerateField.Invoke(tileProperty);
    public static void SendCutTile(Tile tile) => OnCutTile.Invoke(tile);
    public static void SendShowResult(float result) => OnShowResult.Invoke(result);
}
