using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    //public static event Action<string> OnGenerateField;
    public static UnityEvent<TileProperty> OnGenerateField = new();

    public static void SendGenerateField(TileProperty tileProperty) => OnGenerateField.Invoke(tileProperty);
}
