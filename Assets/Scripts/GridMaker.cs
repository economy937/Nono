using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GridMaker : MonoBehaviour
{
    public GameObject cellPrefab;
    public int rows = 5;
    public int columns = 5;
    public Vector2 cellSpacing = new Vector2(5, 5);
    public Vector2 cellSize = new Vector2(50, 50);

    private GridLayoutGroup gridLayout;

    void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        SetupGridLayout();
        GenerateGrid();
    }

    void SetupGridLayout()
    {
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = columns;
        gridLayout.cellSize = cellSize;
        gridLayout.spacing = cellSpacing;
    }

    void GenerateGrid()
    {
        ClearGrid();

        for (int i = 0; i < rows * columns; i++)
        {
            GameObject cell = Instantiate(cellPrefab, transform);
            cell.name = "Cell_" + i;
        }
    }

    void ClearGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void OnValidate()
    {
        if (rows < 1) rows = 1;
        if (columns < 1) columns = 1;
    }
}
