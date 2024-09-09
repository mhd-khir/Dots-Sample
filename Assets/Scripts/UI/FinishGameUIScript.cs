using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishGameUIScript : MonoBehaviour
{
    [SerializeField] TMP_Text GameText;
    [SerializeField] Button GoToMainMenu;

    private void Start()
    {
        GoToMainMenu.onClick.AddListener(GoToMainMenuOnCick);
    }
    private void OnEnable()
    {
        ShowGameState();
    }
    /// <summary>
    /// To Shw Main Menu
    /// </summary>
    void GoToMainMenuOnCick()
    {
        Gamemanager.Instance.GoToMenu();
    }
    private void ShowGameState()
    {
        GameText.text = string.Format("You {0}!", Gamemanager.Instance.State);
    }
}
