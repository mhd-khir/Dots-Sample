using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour 
{
    public static Gamemanager Instance;
    public Configurations Player;
    public List<Configurations> Opponent;
    [SerializeField] MenuUIScript Menu;
    
    /// <summary>
    /// Holds Battle state "Win" or "Lose"
    /// </summary>
    public string State
    {
        private set;
        get;
    }
    
    public int TeamID
    {
        private set;
        get;
    }
    /// <summary>
    /// Get A Team Data from Config file
    /// </summary>
    /// <param name="TeamIndex"></param>
    /// <param name="UnitIndex"></param>
    /// <returns></returns>
    internal UnitData GetData(bool isPlayer, int unitIndex)
    {
        if (isPlayer)
            return Player.Team.UnitData[unitIndex];
        else
            return Opponent[TeamID].Team.UnitData[unitIndex];
    }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    /// <summary>
    /// Show Finish window
    /// </summary>
    /// <param name="state"></param>
    private void FinishGame(string state)
    {
        State = state;
    }
    /// <summary>
    /// Go To Menu
    /// </summary>
    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    /// <summary>
    /// Start A Battle with setting up opponent
    /// </summary>
    /// <param name="teamID"></param>
    public void StartABattle(int teamID)
    {
        TeamID = teamID;
        Menu.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync("Game");
    }
}
