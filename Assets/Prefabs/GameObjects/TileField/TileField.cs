using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileField : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private float _rows;
    [SerializeField] private float _columns;

    private void Start()
    {
        Debug.Log(_tilePrefab);
    }

    private void GenerateField(float offsetBetweenTiles = 4, float tilesAndle = 0, float rowOffset = 0)
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {

            }
        }
    }
}
