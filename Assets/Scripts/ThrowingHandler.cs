using System.Collections;
using System.Collections.Generic;
using Treehouse;
using UnityEngine;

public class ThrowingHandler : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

	public GameObject apple;
	public GameObject cherry;
	public GameObject melon;

    public GameObject currentThrowing;

	SceneManager sm;
	PickupSpawner ps;

    void Start()
    {
	    sm = this.GetComponent<SceneManager>();
	    ps = this.GetComponent<PickupSpawner>();
    }

	public void RemoveThrowable()
    {
		Destroy(currentThrowing);
		currentThrowing = null;
    }

    public void EquipApple()
	{
		ps.RemovePickup();
        switch (sm.activePlayer)
        {
            case SceneManager.Players.PLAYER1:
                GameObject go1 = Instantiate(apple, new Vector3(player1.transform.position.x + -2f, player1.transform.position.y, player1.transform.position.z), Quaternion.identity);
                currentThrowing = go1;
                break;
            case SceneManager.Players.PLAYER2:
                GameObject go2 = Instantiate(apple, new Vector3(player2.transform.position.x + -2f, player2.transform.position.y, player2.transform.position.z), Quaternion.identity);
                currentThrowing = go2;
                break;
        }
    }
    
	public void EquipCherry(){
		ps.RemovePickup();
		switch (sm.activePlayer)
		{
		case SceneManager.Players.PLAYER1:
			GameObject go1 = Instantiate(cherry, new Vector3(player1.transform.position.x + -2f, player1.transform.position.y, player1.transform.position.z), Quaternion.identity);
			currentThrowing = go1;
			break;
		case SceneManager.Players.PLAYER2:
			GameObject go2 = Instantiate(cherry, new Vector3(player2.transform.position.x + -2f, player2.transform.position.y, player2.transform.position.z), Quaternion.identity);
			currentThrowing = go2;
			break;
		}
	}
	
	public void EquipMelon(){
		ps.RemovePickup();
		switch (sm.activePlayer)
		{
		case SceneManager.Players.PLAYER1:
			GameObject go1 = Instantiate(melon, new Vector3(player1.transform.position.x + -2f, player1.transform.position.y + 0.5f, player1.transform.position.z), Quaternion.identity);
			currentThrowing = go1;
			break;
		case SceneManager.Players.PLAYER2:
			GameObject go2 = Instantiate(melon, new Vector3(player2.transform.position.x + -2f, player2.transform.position.y + 0.5f, player2.transform.position.z), Quaternion.identity);
			currentThrowing = go2;
			break;
		}
	}

    public void ThrowFruit()
    {
        switch (sm.activePlayer)
        {
            case SceneManager.Players.PLAYER1:
                currentThrowing.GetComponent<Rigidbody>().useGravity = true;
                currentThrowing.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10f, -9f), ForceMode.Impulse);
                break;
            case SceneManager.Players.PLAYER2:
                currentThrowing.GetComponent<Rigidbody>().useGravity = true;
                currentThrowing.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10f, 9f), ForceMode.Impulse);
                break;
        }

    }
}
