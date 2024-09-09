using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.UI;


public class MenuUIScript : MonoBehaviour
{    
    public Button startBattle;
    public GameObject TeamsContainer;
    public List<Button> SelectATeamButtons;
    public Button TeamBtn;
    int teamId;

    private void Start()
    {
        teamId = 0;
        SelectATeamButtons = new List<Button>();
        startBattle.onClick.AddListener(LoadGame);
        InitializeTeamContainer();
    }

    /// <summary>
    /// Get The payer input to start a game 
    /// </summary>
    void LoadGame()
    {
        Gamemanager.Instance.StartABattle(teamId);
    }

    /// <summary>
    /// Set Which team has been chosen
    /// </summary>
    /// <param name="teamID"></param>
    public void ChooseATeam(int teamID)
    {
        this.teamId = teamID;
        foreach(Button button in SelectATeamButtons)
        {
            button.GetComponentInChildren<TMP_Text>(true).fontStyle = FontStyles.Normal;
        }
        SelectATeamButtons[teamID].GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Bold;
    }

    /// <summary>
    /// Initialize The Team Menu
    /// </summary>
    void InitializeTeamContainer()  
    {
        int teamCount = Gamemanager.Instance.Opponent.Count;
        int index = 0;
        float height = (teamCount + 1) * 80 < 600 ? 600 : (teamCount + 1) * 80;
        TeamsContainer.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(350, height);
        while (index < teamCount) 
        {
            Button btn = Instantiate(TeamBtn);
            btn.transform.SetParent(TeamsContainer.transform.GetChild(0));
            int id = index;
            btn.onClick.AddListener(() => ChooseATeam(id));
            btn.GetComponentInChildren<TMP_Text>().text = "Team " + (index + 1);
            SelectATeamButtons.Add(btn);
            index++;
        }
    }
}
