using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricMeasureConverter
{
    private static readonly float meter = 0.4f;

    public static TileSize ConvertScaleToMeters(Vector3 scale)
    {
        return new TileSize()
        {
            lenght = scale.x * meter,
            width = scale.y * meter,
            height = scale.z * meter,
        };
    }

    public static float ConvertScaleToMeters(float scale) => scale * meter;

    public static float ConvertMillimetersToScale(float millimeters) => millimeters / 1000 / meter;
}
