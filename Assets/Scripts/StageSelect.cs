using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    public StageManager stageManager; 
    public GridMaker gridMaker;
    public Button nextStageButton;
    public TextMeshProUGUI resultText;


    CheckAnswerButton checkAnswerButton;

    void Start()
    {
        nextStageButton.onClick.AddListener(GoToNextStage);
    }

    public void GoToNextStage()
    {
        int nextStageIndex = stageManager.currentStage + 1;

        if (nextStageIndex <= stageManager.totalStage)
        {
            stageManager.SetStage(nextStageIndex);
            stageManager.currentStage++;
            gridMaker.GenerateGrid();
            resultText.text = "";
            gameObject.SetActive(false);
        }
        else
        {
            
        }
    }

}
