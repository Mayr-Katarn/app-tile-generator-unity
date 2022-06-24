using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TileProperty
{
    public TileProperty(float offsetBetweenTiles, float tilesAngle, float rowOffset)
    {
        this.offsetBetweenTiles = offsetBetweenTiles;
        this.tilesAngle = tilesAngle;
        this.rowOffset = rowOffset;
    }

    public float offsetBetweenTiles, tilesAngle, rowOffset;

    internal void Deconstruct(out float offsetBetweenTiles, out float tilesAngle, out float rowOffset)
    {
        offsetBetweenTiles = this.offsetBetweenTiles;
        tilesAngle = this.tilesAngle;
        rowOffset = this.rowOffset;
    }
}
