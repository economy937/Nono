using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<List<List<int>>> stageRowAnswers = new List<List<List<int>>>();
    public List<List<List<int>>> stageColumnAnswers = new List<List<List<int>>>();

    public int currentStage = 0;
    public int totalStage = 1;

    void Start()
    {
        InitializeStages(currentStage);
    }

    private void InitializeStages(int currentStage)
    {
        switch (currentStage)
        {
            case 0:
                // 스테이지 0
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
            new List<int> { 5 },
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
