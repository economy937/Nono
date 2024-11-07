using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<List<List<int>>> stageRowAnswers = new List<List<List<int>>>();
    public List<List<List<int>>> stageColumnAnswers = new List<List<List<int>>>();

    private int currentStage = 0;

    void Start()
    {
        stageRowAnswers.Add(new List<List<int>>
        {
            new List<int> { 1, 1, 1 },
            new List<int> {  },
            new List<int> { 1, 1,1 },
            new List<int> {  },
            new List<int> { 1, 1, 1 }
        });

        stageColumnAnswers.Add(new List<List<int>>
        {
            new List<int> { 1, 1, 1 },
            new List<int> {  },
            new List<int> { 1,1,1 },
            new List<int> {  },
            new List<int> { 1, 1, 1 }
        });

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
        if (stageIndex >= 0 && stageIndex < stageRowAnswers.Count)
        {
            currentStage = stageIndex;
        }
        else
        {
            Debug.LogWarning("Invalid stage index");
        }
    }
}
