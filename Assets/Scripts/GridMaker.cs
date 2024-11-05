using System.Collections.Generic;
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
    private CellController[,] cellGrid; 

    void Start()
    {
        gridLayout = GetComponent<GridLayoutGroup>();
        SetupGridLayout();
        GenerateGrid();
    }

    void Update()
    {
        // 'F' 키를 눌렀을 때 연속된 Filled 셀 수를 출력
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Row Filled Counts:");
            for (int i = 0; i < rows; i++)
            {
                List<int> rowCounts = GetRowFilledCounts(i);
                string rowDebug = $"Row {i}: " + string.Join(", ", rowCounts);
                Debug.Log(rowDebug);
            }

            Debug.Log("Column Filled Counts:");
            for (int j = 0; j < columns; j++)
            {
                List<int> columnCounts = GetColumnFilledCounts(j);
                string columnDebug = $"Column {j}: " + string.Join(", ", columnCounts);
                Debug.Log(columnDebug);
            }
        }
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
        cellGrid = new CellController[rows, columns]; 

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject cell = Instantiate(cellPrefab, transform);
                cell.name = $"Cell_{i}_{j}";

                CellController cellController = cell.GetComponent<CellController>();
                cellGrid[i, j] = cellController;
            }
        }
    }

    // 연속된 Filled 셀의 수를 계산
    public List<int> GetRowFilledCounts(int row)
    {
        List<int> filledCounts = new List<int>();
        int count = 0;

        for (int j = 0; j < columns; j++)
        {
            if (cellGrid[row, j].IsFilled())
            {
                count++;
            }
            else
            {
                if (count > 0) filledCounts.Add(count);
                count = 0;
            }
        }

        if (count > 0) filledCounts.Add(count); 

        return filledCounts;
    }

    public List<int> GetColumnFilledCounts(int column)
    {
        List<int> filledCounts = new List<int>();
        int count = 0;

        for (int i = 0; i < rows; i++)
        {
            if (cellGrid[i, column].IsFilled())
            {
                count++;
            }
            else
            {
                if (count > 0) filledCounts.Add(count);
                count = 0;
            }
        }

        if (count > 0) filledCounts.Add(count); 

        return filledCounts;
    }

    void ClearGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
