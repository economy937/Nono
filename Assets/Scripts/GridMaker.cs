using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMaker : MonoBehaviour
{
    public GameObject cellPrefab;  
    public int rows = 5;           
    public int columns = 5;        

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {

        GridLayoutGroup gridLayout = GetComponent<GridLayoutGroup>();
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = columns;

        for (int i = 0; i < rows * columns; i++)
        {
            GameObject cell = Instantiate(cellPrefab, transform);
            cell.name = "Cell_" + i;
            cell.AddComponent<CellController>();
        }
    }

}
