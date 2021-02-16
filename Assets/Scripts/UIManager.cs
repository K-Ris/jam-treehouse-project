﻿using System.Collections;
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
    [SerializeField] UIButton WoodContainer1;
    [SerializeField] Text WoodCountText1;
    [SerializeField] UIButton SheetContainer1;
    [SerializeField] Text SheetCountText1;
    [SerializeField] UIButton PillowContainer1;
    [SerializeField] Text PillowCountText1;

    [SerializeField] UIView BuildingPanel2;
    [SerializeField] UIButton WoodContainer2;
    [SerializeField] Text WoodCountText2;
    [SerializeField] UIButton SheetContainer2;
    [SerializeField] Text SheetCountText2;
    [SerializeField] UIButton PillowContainer2;
    [SerializeField] Text PillowCountText2;

    [SerializeField] UIView ThrowingPanel;
    [SerializeField] GameObject Player1Panel;
    [SerializeField] UIButton AppleContainer1;
    [SerializeField] Text AppleCount1;

    [SerializeField] GameObject Player2Panel;
    [SerializeField] UIButton AppleContainer2;
    [SerializeField] Text AppleCount2;

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
                UpdateBuildingMaterialUI(player);
                break;
            case SceneManager.Players.PLAYER2:
                BuildingPanel2.Show();
                BuildingPanel1.Hide();
                FortifyPlayerText.text = "Player 2";
                UpdateBuildingMaterialUI(player);
                break;
        }

        FortifyPanel.Hide();

    }

    public void UpdateBuildingMaterialUI(SceneManager.Players player)
    {
        SceneManager sm = this.GetComponent<SceneManager>();

        switch (player)
        {
            case SceneManager.Players.PLAYER1:
                WoodCountText1.text = "x" + sm.Player1_WoodCount.ToString();
                SheetCountText1.text = "x" + sm.Player1_SheetCount.ToString();
                PillowCountText1.text = "x" + sm.Player1_PillowCount.ToString();
                if (sm.Player1_WoodCount > 0)
                {
                    WoodContainer1.EnableButton();
                }
                else
                {
                    WoodContainer1.DisableButton();
                    WoodContainer1.StopNormalLoopAnimation();
                }
                if (sm.Player1_SheetCount > 0)
                {
                    SheetContainer1.EnableButton();
                }
                else
                {
                    SheetContainer1.DisableButton();
                    SheetContainer1.StopNormalLoopAnimation();
                }
                if (sm.Player1_PillowCount > 0)
                {
                    PillowContainer1.EnableButton();
                }
                else
                {
                    PillowContainer1.DisableButton();
                    PillowContainer1.StopNormalLoopAnimation();
                }
                break;
            case SceneManager.Players.PLAYER2:
                WoodCountText2.text = "x" + sm.Player2_WoodCount.ToString();
                SheetCountText2.text = "x" + sm.Player2_SheetCount.ToString();
                PillowCountText2.text = "x" + sm.Player2_PillowCount.ToString();
                if (sm.Player2_WoodCount > 0)
                {
                    WoodContainer2.EnableButton();
                }
                else
                {
                    WoodContainer2.DisableButton();
                    WoodContainer2.StopNormalLoopAnimation();
                }
                if (sm.Player2_SheetCount > 0)
                {
                    SheetContainer2.EnableButton();
                }
                else
                {
                    SheetContainer2.DisableButton();
                    SheetContainer2.StopNormalLoopAnimation();
                }
                if (sm.Player2_PillowCount > 0)
                {
                    PillowContainer2.EnableButton();
                }
                else
                {
                    PillowContainer2.DisableButton();
                    PillowContainer2.StopNormalLoopAnimation();
                }
                break;
        }
    }

    public void SetThrowingUI(SceneManager.Players player)
    {
        SceneManager sm = this.GetComponent<SceneManager>();

        BuildingPanel1.Hide();
        BuildingPanel2.Hide();

        ThrowingPanel.Show();

        UpdateFruitUI(player);
    }

    public void UpdateFruitUI(SceneManager.Players player)
    {

        SceneManager sm = this.GetComponent<SceneManager>();

        switch (player)
        {
            case SceneManager.Players.PLAYER1:
                FortifyPlayerText.text = "Player 1";
                Player1Panel.SetActive(true);
                Player2Panel.SetActive(false);
                AppleCount1.text = "x" + sm.Player1_AppleCount.ToString();
                if (sm.Player1_AppleCount > 0)
                {
                    AppleContainer1.EnableButton();
                }
                else
                {
                    AppleContainer1.DisableButton();
                }
                break;
            case SceneManager.Players.PLAYER2:
                FortifyPlayerText.text = "Player 2";
                Player1Panel.SetActive(false);
                Player2Panel.SetActive(true);
                AppleCount2.text = "x" + sm.Player2_AppleCount.ToString();
                if (sm.Player2_AppleCount > 0)
                {
                    AppleContainer2.EnableButton();
                }
                else
                {
                    AppleContainer2.DisableButton();
                }
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
        ThrowingPanel.Hide();

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
