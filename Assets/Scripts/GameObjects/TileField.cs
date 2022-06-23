using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileField : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab, _tileGeneratorPoint;
    [SerializeField] private float _rows, _columns;

    //private Tile[] _tilesArray;
    private Vector3 _tileScaleSize;
    private TileSize _tileMeterSize;

    private void Start()
    {
        _tileScaleSize = _tilePrefab.transform.localScale;
        _tileMeterSize = _tilePrefab.GetComponent<Tile>().TileSize;

        Debug.Log(_tileScaleSize);
        Debug.Log(_tileMeterSize);
        Debug.Log(MetricMeasureConverter.ConvertMillimetersToScale(4000));    

        GenerateField();
    }

    private void GenerateField(float offsetBetweenTiles = 10, float tilesAngle = 0, float rowOffset = 0)
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                float offset = MetricMeasureConverter.ConvertMillimetersToScale(offsetBetweenTiles);
                float x = j * (_tileScaleSize.x + offset);
                float y = i * (_tileScaleSize.y + offset);

                GameObject tile = Instantiate(_tilePrefab, _tileGeneratorPoint.GetComponent<Transform>());
                tile.transform.localPosition = new Vector2(x, y);
                tile.GetComponent<Tile>().SetGridPosition(j, i);
                
            }
        }

        //GameObject.FindGameObjectsWithTag("Tile");
    }
}
