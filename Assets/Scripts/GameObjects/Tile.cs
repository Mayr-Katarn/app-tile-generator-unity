using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ITile
{
    public int row, col;

    public TileSize TileSize
    {
        get
        {
            Vector3 scale = GetComponent<Transform>().localScale;
            return MetricMeasureConverter.ConvertScaleToMeters(scale);
        }
    }

    public float Square
    {
        get => TileSize.lenght * TileSize.width;
    }

    public void SetGridPosition(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
