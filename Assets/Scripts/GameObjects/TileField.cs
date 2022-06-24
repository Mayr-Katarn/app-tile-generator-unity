using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileField : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab, _tileGeneratorPoint;
    [SerializeField] private float _rows, _columns;

    private Vector3 _tileScaleSize;

    private void Start()
    {
        _tileScaleSize = _tilePrefab.transform.localScale;
    }

    private void OnEnable()
    {
        EventManager.OnGenerateField.AddListener(GenerateField);
    }

    private void GenerateField(TileProperty tileProperty)
    {
        DestroyAllTiles();

        (float offsetBetweenTiles, float tilesAngle, float rowOffset) = tileProperty;
        Transform transform = _tileGeneratorPoint.GetComponent<Transform>();
        transform.localEulerAngles = new Vector3(0, 0, tilesAngle);

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                float offset = MetricMeasureConverter.ConvertMillimetersToScale(offsetBetweenTiles);
                float xRowOffset = MetricMeasureConverter.ConvertMillimetersToScale(i % 2 == 0 ? rowOffset : 0);
                float x = j * (_tileScaleSize.x + offset) + xRowOffset;
                float y = i * (_tileScaleSize.y + offset);

                GameObject tile = Instantiate(_tilePrefab, transform);
                tile.transform.localPosition = new Vector2(x, y);
                tile.GetComponent<Tile>().SetGridPosition(j, i);
            }
        }
    }

    private void DestroyAllTiles()
    {
        Tile[] tiles = FindObjectsOfType<Tile>();
        foreach (Tile tile in tiles) tile.Destroy();
    }
}
