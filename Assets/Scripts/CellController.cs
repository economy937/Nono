using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    private enum CellState { Empty, Filled, Incorrect }
    private CellState currentState = CellState.Empty;

    private Image cellImage;
    public GameObject xMark;

    void Start()
    {
        cellImage = GetComponent<Image>();
        UpdateCellDisplay();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition))
            {
                CycleState();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition))
            {
                SetIncorrectState();
            }
        }
    }

    void CycleState()
    {
        if (xMark != null)
        {
            switch (currentState)
            {
                case CellState.Empty:
                    currentState = CellState.Filled;
                    break;
                case CellState.Filled:
                    currentState = CellState.Empty;
                    break;
                case CellState.Incorrect:
                    currentState = CellState.Empty;
                    break;
            }
            UpdateCellDisplay();
        }
    }

    void SetIncorrectState()
    {
        if (xMark != null)
        {
            currentState = CellState.Incorrect;
            UpdateCellDisplay();
        }
    }

    void UpdateCellDisplay()
    {
        if (xMark != null)
        {
            switch (currentState)
            {
                case CellState.Empty:
                    cellImage.color = Color.white;
                    xMark.SetActive(false);
                    break;
                case CellState.Filled:
                    cellImage.color = Color.black;
                    xMark.SetActive(false);
                    break;
                case CellState.Incorrect:
                    cellImage.color = Color.white;
                    xMark.SetActive(true);
                    break;
            }
        }
    }

    public bool IsFilled()
    {
        return currentState == CellState.Filled;
    }
}
