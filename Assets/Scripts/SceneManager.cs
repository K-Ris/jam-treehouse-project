using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    UIManager um;

    bool firstBuilder = false;

    public Players activePlayer = Players.PLAYER1;

    void Start()
    {
        um = this.GetComponent<UIManager>();

        //Start Process
        //Throw Coin
        //Player 1 Fortify
        //Player 2 Fortify

        //Turn Loop
        //Throw Coin
        //Player 1 Throwing
        //Player 2 Throwing
        //...

        Time.timeScale = 1.5f;

        activePlayer = Players.PLAYER1;

        um.SetFortifyUI("Player 1");
    }

    public void StartBuilding()
    {
        um.SetBuildingUI(activePlayer);
    }

    public void FinishBuilding()
    {
        if (!firstBuilder)
        {
            switch (activePlayer)
            {
                case Players.PLAYER1:
                    activePlayer = Players.PLAYER2;
                    break;
                case Players.PLAYER2:
                    activePlayer = Players.PLAYER1;
                    break;
            }

            firstBuilder = true;
            um.SetBuildingUI(activePlayer);
        }
        else
        {
            //start throwing loop
            ThrowingTurn();
        }
        
    }

    public void ThrowingTurn()
    {

        switch (activePlayer)
        {
            case Players.PLAYER1:
                activePlayer = Players.PLAYER2;
                break;
            case Players.PLAYER2:
                activePlayer = Players.PLAYER1;
                break;
        }

        um.SetThrowingUI(activePlayer);

    }


    #region enum

    public enum Players
    {
        PLAYER1,
        PLAYER2
    }

    #endregion
}
