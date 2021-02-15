using System.Collections;
using System.Collections.Generic;
using Treehouse;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Engine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIView FortifyPanel;
    [SerializeField] Text FortifyPlayerText;

    [SerializeField] GameObject ActivePlayerPanel;

    [SerializeField] UIView BuildingPanel1;
    [SerializeField] UIView BuildingPanel2;

    [SerializeField] UIView ThrowingPanel;
    [SerializeField] GameObject Player1Panel;
    [SerializeField] GameObject Player2Panel;

    [SerializeField] GameObject HealthPanel;
    [SerializeField] Image Player1Health;
    [SerializeField] Image Player2Health;

    [SerializeField] UIView WinPanel;
    [SerializeField] Text WinnerText;


    public void SetFortifyUI()
    {
	    FortifyPanel.Show();
    }

    public void SetBuildingUI(SceneManager.Players player)
    {
        FortifyPanel.Hide();

        switch (player)
        {
            case SceneManager.Players.PLAYER1:
                BuildingPanel1.Show();
                BuildingPanel2.Hide();
                FortifyPlayerText.text = "Player 1";
                break;
            case SceneManager.Players.PLAYER2:
                BuildingPanel2.Show();
                BuildingPanel1.Hide();
                FortifyPlayerText.text = "Player 2";
                break;
        }

	    FortifyPanel.Hide();

    }

    public void SetThrowingUI(SceneManager.Players player)
    {
        BuildingPanel1.Hide();
        BuildingPanel2.Hide();

        ThrowingPanel.Show();

        switch (player)
        {
            case SceneManager.Players.PLAYER1:
                FortifyPlayerText.text = "Player 1";
                Player1Panel.SetActive(true);
                Player2Panel.SetActive(false);
                break;
            case SceneManager.Players.PLAYER2:
                FortifyPlayerText.text = "Player 2";
                Player1Panel.SetActive(false);
                Player2Panel.SetActive(true);
                break;
        }
    }

    public void SetPlayerHealth()
    {
        int health1 = this.GetComponent<SceneManager>().HealthPlayer1_max;
        int health1cur = this.GetComponent<SceneManager>().HealthPlayer1_cur;

        int health2 = this.GetComponent<SceneManager>().HealthPlayer2_max;
        int health2cur = this.GetComponent<SceneManager>().HealthPlayer2_cur;

        float fill1 = (float)health1cur / (float)health1;
        float fill2 = (float)health2cur / (float)health2;

        Debug.Log(fill1);
        Debug.Log(fill2);

        Player1Health.fillAmount = fill1;
        Player2Health.fillAmount = fill2;
    }

    public void ShowWinPanel(SceneManager.Players player)
    {
	    FortifyPanel.Hide();
        BuildingPanel1.Hide();
        BuildingPanel2.Hide();
        HealthPanel.SetActive(false);
        ThrowingPanel.Hide();
        ActivePlayerPanel.SetActive(false);

        switch (player)
        {
            case SceneManager.Players.PLAYER1:
                WinnerText.text = player + " is the winner!";
                break;
            case SceneManager.Players.PLAYER2:
                WinnerText.text = player + " is the winner!";
                break;
        }

        WinPanel.Show();
    }
}
