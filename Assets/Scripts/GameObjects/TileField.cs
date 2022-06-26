using UnityEngine;
using Parabox.CSG;
using System;

public class TileField : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab, _field;
    [SerializeField] private Transform _tileGeneratorPointTransform;
    [SerializeField] private float _rows, _cols;

    private Vector3 _tileScaleSize;

    private void Start()
    {
        _tileScaleSize = _tilePrefab.transform.localScale;
    }

    private void OnEnable()
    {
        EventManager.OnGenerateField.AddListener(GenerateField);
        EventManager.OnCutTile.AddListener(CutTile);
    }

    private void GenerateField(TileProperty tileProperty)
    {
        DestroyAllTiles();
        AlignField(true);

        (float offsetBetweenTiles, float tilesAngle, float rowOffset) = tileProperty;
        _tileGeneratorPointTransform.eulerAngles = new Vector3(0, 0, tilesAngle);
        Vector2 startPosition = StartPosition();

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                float offset = MetricMeasureConverter.ConvertMillimetersToScale(offsetBetweenTiles);
                float xRowOffset = MetricMeasureConverter.ConvertMillimetersToScale(i % 2 == 0 ? rowOffset : 0);
                float x = j * (_tileScaleSize.x + offset) + xRowOffset - startPosition.x;
                float y = i * (_tileScaleSize.y + offset) - startPosition.y;

                GameObject tile = Instantiate(_tilePrefab, _tileGeneratorPointTransform);
                tile.GetComponent<Tile>().Init(new Vector2(x, y), new GridPosition(i, j), _field.GetComponent<Collider>());
            }
        }

        Invoke(nameof(CalcResult), 0.1f);
    }

    private Vector2 StartPosition()
    {
        float x = (_cols / 2 * _tileScaleSize.x) - _tileScaleSize.x / 2;
        float y = (_rows / 2 * _tileScaleSize.y) - _tileScaleSize.y / 2;
        return new Vector2(x, y);
    }

    private void DestroyAllTiles()
    {
        Tile[] tiles = FindObjectsOfType<Tile>();
        foreach (Tile tile in tiles) tile.Destroy();
    }

    private void CutTile(Tile tile)
    {
        Model result = CSG.Intersect(tile.gameObject, _field);
        if (result == null) return;
        tile.Destroy();

        var cutTile = new GameObject("CutTile", typeof(MeshFilter), typeof(MeshRenderer), typeof(BoxCollider), typeof(Tile));
        cutTile.GetComponent<MeshFilter>().sharedMesh = result.mesh;
        cutTile.GetComponent<MeshRenderer>().sharedMaterials = result.materials.ToArray();
        cutTile.GetComponent<Tile>().isCuted = true;
        cutTile.transform.SetParent(_tileGeneratorPointTransform);
    }

    private void CalcResult()
    {
        float squareResult = 0;
        Tile[] tiles = FindObjectsOfType<Tile>();
        Tile[] uncutedTiles = Array.FindAll(tiles, el => !el.isCuted);

        foreach (Tile tile in uncutedTiles) squareResult += tile.Square;

        EventManager.SendShowResult(squareResult);
        AlignField(false);
    }

    private void AlignField(bool isAling)
    {
        Vector3 position = isAling ? new Vector3(0, 0, 0) : new Vector3(0, 0, 0.01f);
        _field.transform.localPosition = position;
    }
}
