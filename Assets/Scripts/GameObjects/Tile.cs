using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, ITile
{
    public int row, col;
    public bool isCuted = false;
    private Collider _field;

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

    public void Init(Vector2 position, GridPosition gridPosition, Collider field)
    {
        GetComponent<Transform>().localPosition = position;
        row = gridPosition.row;
        col = gridPosition.col;
        _field = field;
    }

    private void Update()
    {
        if (!isCuted) CheckFieldIntersect();
    }

    public Tile SetGridPosition(int row, int col)
    {
        this.row = row;
        this.col = col;
        return this;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void CheckFieldIntersect()
    {
        var isIntersect = _field.bounds.Intersects(GetComponent<Collider>().bounds);
        if (!isIntersect) Destroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border")) EventManager.SendCutTile(this);
    }
}
