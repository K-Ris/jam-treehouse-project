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

        public GameObject Player1;
        public Animator Player1Anim;
        public GameObject Player2;
	    public Animator Player2Anim;
        
	    [Header("Building Timer")]
	    public int TimerTime = 40;
	    
	    [Header("Player 1 Health")]
        public int HealthPlayer1_max = 100;
	    public int HealthPlayer1_cur = 100;
        
	    [Header("Player 1 Materials")]
	    public int Player1_WoodCount = 6;
	    public int Player1_SheetCount = 3;
	    public int Player1_PillowCount = 2;
	    
	    [Header("Player 1 Fruits")]
	    public int Player1_AppleCount = 4;
	    public int Player1_CerryCount = 3;
	    public int Player1_MelonCount = 1;
	    
	    [Header("Player 2 Health")]
        public int HealthPlayer2_max = 100;
	    public int HealthPlayer2_cur = 100;
        
	    [Header("Player 2 Materials")]
	    public int Player2_WoodCount = 6;
	    public int Player2_SheetCount = 3;
	    public int Player2_PillowCount = 2;
	    
	    [Header("Player 2 Fruits")]
	    public int Player2_AppleCount = 4;
	    public int Player2_CerryCount = 3;
	    public int Player2_MelonCount = 1;

        private IEnumerator coroutineTimer;

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

            StartTimer();
        }

        public void FinishBuilding()
	    {
		    this.GetComponent<BuildingHandler>().SetBlock();
        	
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

                StartTimer();
            }
            else
            {
                //start throwing loop
                if (coroutineTimer != null)
                    StopCoroutine(coroutineTimer);

                ThrowingTurn();
            }

        }

        public void ThrowingTurn()
	    {
		    this.GetComponent<PickupSpawner>().RemovePickup();

        	
            switch (activePlayer)
            {
                case Players.PLAYER1:
                    activePlayer = Players.PLAYER2;
                    break;
                case Players.PLAYER2:
                    activePlayer = Players.PLAYER1;
                    break;
            }

		    if(HealthPlayer1_cur > 0 && HealthPlayer2_cur > 0){
			    this.GetComponent<PickupSpawner>().SpawnRandomPickup(activePlayer);
		    	
			    um.SetThrowingUI(activePlayer);

                switch (activePlayer)
                {
                    case Players.PLAYER1:
                        if(Player1_AppleCount < 1 && Player1_CerryCount < 1 && Player1_MelonCount < 1 && this.GetComponent<PickupSpawner>().currentPickup == null)
                        {
                            HitHandling();
                        }
                        break;
                    case Players.PLAYER2:
                        if (Player2_AppleCount < 1 && Player2_CerryCount < 1 && Player2_MelonCount < 1 && this.GetComponent<PickupSpawner>().currentPickup == null)
                        {
                            HitHandling();
                        }
                        break;
                }
            }

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

        public void StartTimer()
        {
            if (coroutineTimer != null)
                StopCoroutine(coroutineTimer);

            coroutineTimer = DoStartTimer();

            StartCoroutine(coroutineTimer);
        }

        IEnumerator DoStartTimer()
        {
            Debug.Log("Timer");

            for(int i = TimerTime; i > 0; i--)
            {
                //Debug.Log(i);

                um.SetTimerPanel(activePlayer, i);

                yield return new WaitForSecondsRealtime(1f);

            }

            FinishBuilding();
        }
        
	    public void ThrowFruit(FruitHandler.FruitType fruit){
	    	
	    	switch(activePlayer){
	    	case Players.PLAYER1:
		    	switch(fruit){
		    	case FruitHandler.FruitType.APPLE:
			    	Player1_AppleCount--;
			    	break;
		    	case FruitHandler.FruitType.CHERRY:
                    Player1_CerryCount--;
		    		break;
		    	case FruitHandler.FruitType.MELONE:
                    Player1_MelonCount--;
			    	break;
		    	
		    	}
		    	break;
	    	case Players.PLAYER2:
		    	switch(fruit){
		    	case FruitHandler.FruitType.APPLE:
			    	Player2_AppleCount--;
			    	break;
		    	case FruitHandler.FruitType.CHERRY:
                            Player2_CerryCount--;
		    		break;
		    	case FruitHandler.FruitType.MELONE:
                            Player2_MelonCount--;
			    	break;
		    	
		    	}
		    	break;
	    	}

            um.UpdateFruitUI(activePlayer);

	    }
        
	    public void AddFruit(FruitHandler.FruitType type){
	    	
	    	switch(activePlayer){
	    	case Players.PLAYER1:
		    	switch(type){
		    	case FruitHandler.FruitType.APPLE:
			    	Player1_AppleCount++;
			    	break;
		    	case FruitHandler.FruitType.CHERRY:
			    	Player1_CerryCount++;
			    	break;
		    	case FruitHandler.FruitType.MELONE:
			    	Player1_MelonCount++;
			    	break;
		    	}
		    	break;
	    	case Players.PLAYER2:
		    	switch(type){
		    	case FruitHandler.FruitType.APPLE:
			    	Player2_AppleCount++;
			    	break;
		    	case FruitHandler.FruitType.CHERRY:
			    	Player2_CerryCount++;
			    	break;
		    	case FruitHandler.FruitType.MELONE:
			    	Player2_MelonCount++;
			    	break;
		    	}
		    	break;
	    	}
	    	
	    	um.UpdateFruitUI(activePlayer);
	    }

        public void HitHandling()
        {
            StartCoroutine(HandleHitCo());
        }

        IEnumerator HandleHitCo()
        {
            yield return new WaitForSeconds(4);

            //remove fruit
            //end turn
            if (HealthPlayer1_cur > 0 && HealthPlayer2_cur > 0)
                ThrowingTurn();
        }

        public void PlayThrowAnimation()
        {
            switch (activePlayer)
            {
                case Players.PLAYER1:
                    Player1Anim.SetTrigger("Throw");
                    break;
                case Players.PLAYER2:
                    Player2Anim.SetTrigger("Throw");
                    break;
            }
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

