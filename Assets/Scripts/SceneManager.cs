using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Players activePlayer = Players.PLAYER1;

    void Start()
    {
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

    }

    public enum Players
    {
        PLAYER1,
        PLAYER2
    }

}
