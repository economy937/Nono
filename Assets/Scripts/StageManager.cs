using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<List<List<int>>> stageRowAnswers = new List<List<List<int>>>();
    public List<List<List<int>>> stageColumnAnswers = new List<List<List<int>>>();

    public int currentStage = 0;
    [HideInInspector]
    public int totalStage = 1;

    GridMaker gridMaker;

    void Start()
    {
        gridMaker = FindObjectOfType<GridMaker>();
        InitializeStages(currentStage);
    }

    private void InitializeStages(int currentStage)
    {
        switch (currentStage)
        {
            case 0:
                // 스테이지 0
                gridMaker.rows = 5;
                gridMaker.columns = 5;
                stageRowAnswers.Add(new List<List<int>>
        {
            new List<int> { 1, 1, 1 },
            new List<int> {  },
            new List<int> { 1, 1, 1 },
            new List<int> {  },
            new List<int> { 1, 1, 1 }
        });
                stageColumnAnswers.Add(new List<List<int>>
        {
            new List<int> { 1, 1, 1 },
            new List<int> {  },
            new List<int> { 1, 1, 1 },
            new List<int> {  },
            new List<int> { 1, 1, 1 }
        });
                break;
            case 1:
                // 스테이지 1
                gridMaker.rows = 5;
                gridMaker.columns = 5;
                stageRowAnswers.Add(new List<List<int>>
        {
            new List<int> { 1 },
            new List<int> { 1 },
            new List<int> { 1 },
            new List<int> { 1 },
            new List<int> { 1 }
        });
                stageColumnAnswers.Add(new List<List<int>>
        {
            new List<int> {  },
            new List<int> {  },
            new List<int> { 5 },
            new List<int> {  },
            new List<int> {  }
        });
                break;
            case 2:
                // 스테이지 2
                gridMaker.rows = 6;
                gridMaker.columns = 6;
                stageRowAnswers.Add(new List<List<int>>
        {
            new List<int> { 1 },
            new List<int> { 1 },
            new List<int> { 1 },
            new List<int> { 1 },
            new List<int> { 1 },
            new List<int> { 1 }
        });
                stageColumnAnswers.Add(new List<List<int>>
        {
            new List<int> { 6 },
            new List<int> {  },
            new List<int> {  },
            new List<int> {  },
            new List<int> {  },
            new List<int> {  }
        });
                break;
        }
    }

    public List<List<int>> GetCurrentStageRowAnswer()
    {
        return stageRowAnswers[currentStage];
    }

    public List<List<int>> GetCurrentStageColumnAnswer()
    {
        return stageColumnAnswers[currentStage];
    }

    public void SetStage(int stageIndex)
    {
        if (stageIndex >= 0 && stageIndex <= totalStage)
        {
            InitializeStages(stageIndex);
        }
        else
        {
            Debug.Log("스테이지 더 없음");
        }
    }
}
