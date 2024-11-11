using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckAnswerButton : MonoBehaviour
{
    public GridMaker gridMaker; 
    public StageManager stageManager; 
    public TextMeshProUGUI resultText;
    public GameObject nextBtn;

    public void CheckAnswer()
    {
        List<List<int>> correctRowAnswer = stageManager.GetCurrentStageRowAnswer();
        List<List<int>> correctColumnAnswer = stageManager.GetCurrentStageColumnAnswer();

        bool isCorrect = true;

        for (int i = 0; i < gridMaker.rows && isCorrect; i++)
        {
            List<int> playerRowCounts = gridMaker.GetRowFilledCounts(i);
            if (!IsPatternMatch(playerRowCounts, correctRowAnswer[i]))
            {
                isCorrect = false;
                break;
            }

            List<int> playerColumnCounts = gridMaker.GetColumnFilledCounts(i);
            if (!IsPatternMatch(playerColumnCounts, correctColumnAnswer[i]))
            {
                isCorrect = false;
                break;
            }
        }

        resultText.text = isCorrect ? "정답입니다!" : "오답입니다!";
        nextBtn.SetActive(isCorrect);
    }

    private bool IsPatternMatch(List<int> playerPattern, List<int> correctPattern)
    {
        if (playerPattern.Count != correctPattern.Count)
            return false;

        for (int i = 0; i < playerPattern.Count; i++)
        {
            if (playerPattern[i] != correctPattern[i])
                return false;
        }
        return true;
    }
}
