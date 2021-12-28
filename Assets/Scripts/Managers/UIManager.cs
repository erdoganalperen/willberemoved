using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject FinishPanel;
    private void Start()
    {
        GameManager.Instance.ONGameStateChange += UIChangeState;
    }

    public void ONClickStartGameButton()
    {
        GameManager.Instance.ChangeState(GameState.Playing);
    }
    public void ONClickNextLevelButton()
    {
        LevelManager.Instance.NextLevel();
    }
    public void UIChangeState(GameState state)
    {
        if (state == GameState.Playing)
        {
            CloseAllPanels();
        }
        else if(state == GameState.Finish)
        {
            FinishPanel.SetActive(true);
        }
    }
    public void CloseFinishPanel()
    {
        FinishPanel.SetActive(false);
    }
    public void CloseAllPanels()
    {
        StartPanel.SetActive(false);
        FinishPanel.SetActive(false);
    }
}
