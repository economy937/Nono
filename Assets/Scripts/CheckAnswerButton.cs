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

        // 행 패턴 비교
        for (int i = 0; i < gridMaker.rows; i++)
        {
            List<int> playerRowCounts = gridMaker.GetRowFilledCounts(i);
            if (!IsPatternMatch(playerRowCounts, correctRowAnswer[i]))
            {
                isCorrect = false;
                break;
            }
        }

        // 열 패턴 비교
        if (isCorrect) // 행이 맞았을 때만 열 확인
        {
            for (int j = 0; j < gridMaker.columns; j++)
            {
                List<int> playerColumnCounts = gridMaker.GetColumnFilledCounts(j);
                if (!IsPatternMatch(playerColumnCounts, correctColumnAnswer[j]))
                {
                    isCorrect = false;
                    break;
                }
                nextBtn.SetActive(true);
            }
        }

        // 결과 표시
        resultText.text = isCorrect ? "정답입니다!" : "오답입니다!";
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
