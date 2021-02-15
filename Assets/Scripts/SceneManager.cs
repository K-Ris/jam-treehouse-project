using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Treehouse
{
    public class SceneManager : MonoBehaviour
    {
        UIManager um;

        bool firstBuilder = false;

        public Players activePlayer = Players.PLAYER1;

        public int HealthPlayer1_max = 100;
        public int HealthPlayer1_cur = 100;

        public int HealthPlayer2_max = 100;
        public int HealthPlayer2_cur = 100;

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

            um.SetFortifyUI();
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

        public void DamagePlayer(Players player, int damage)
        {
            switch (player)
            {
                case Players.PLAYER1:
                    HealthPlayer1_cur -= 20;
                    break;
                case Players.PLAYER2:
                    HealthPlayer2_cur -= 20;
                    break;
            }

            um.SetPlayerHealth();

            if (HealthPlayer1_cur <= 0)
            {
                um.ShowWinPanel(Players.PLAYER2);
            }
            else if (HealthPlayer2_cur <= 0)
            {
                um.ShowWinPanel(Players.PLAYER1);
            }
        }

        public void Replay()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }


        #region enum

        public enum Players
        {
            PLAYER1,
            PLAYER2
        }

        #endregion
    }
}

