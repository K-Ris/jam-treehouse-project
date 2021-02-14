using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject FortifyPanel;
    [SerializeField] Text FortifyPlayerText;

    [SerializeField] GameObject BuildingPanel1;
    [SerializeField] GameObject BuildingPanel2;
    [SerializeField] GameObject ThrowingPanel;

    [SerializeField] GameObject HealthPanel;
    [SerializeField] Image Player1Health;
    [SerializeField] Image Player2Health;


    public void SetFortifyUI(string player)
    {
        FortifyPlayerText.text = player;
        FortifyPanel.SetActive(true);
    }

    public void SetBuildingUI(SceneManager.Players player)
    {
        switch (player)
        {
            case SceneManager.Players.PLAYER1:
                BuildingPanel1.SetActive(true);
                BuildingPanel2.SetActive(false);
                FortifyPlayerText.text = "Player 1";
                break;
            case SceneManager.Players.PLAYER2:
                BuildingPanel2.SetActive(true);
                BuildingPanel1.SetActive(false);
                FortifyPlayerText.text = "Player 2";
                break;
        }

        FortifyPanel.SetActive(false);

    }

    public void SetThrowingUI(SceneManager.Players player)
    {
        BuildingPanel1.SetActive(false);
        BuildingPanel2.SetActive(false);

        ThrowingPanel.SetActive(true);

        switch (player)
        {
            case SceneManager.Players.PLAYER1:
                FortifyPlayerText.text = "Player 1";
                break;
            case SceneManager.Players.PLAYER2:
                FortifyPlayerText.text = "Player 2";
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
}
