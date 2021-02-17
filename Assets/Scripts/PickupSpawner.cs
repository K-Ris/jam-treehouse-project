using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Treehouse;

public class PickupSpawner : MonoBehaviour
{
	public GameObject ApplePickup;
	public GameObject CherryPickup;
	public GameObject MelonPickup;
	
	public Transform PickupPos1;
	public Transform PickupPos2;
	
	GameObject currentPickup;
	
    
	public void SpawnRandomPickup(SceneManager.Players player){
		
		Transform PickupPos = PickupPos1;
		
		switch(player){
		case SceneManager.Players.PLAYER1:
			PickupPos = PickupPos1;
			break;
		case SceneManager.Players.PLAYER2:
			PickupPos = PickupPos2;
			break;
			
		}
		
		int rand = Random.Range(0, 8);
		
		if(rand == 2 || rand == 3 || rand == 4){
			currentPickup = Instantiate(ApplePickup, PickupPos.position, Quaternion.identity);
		}
		else if(rand == 5 || rand == 6){
			currentPickup = Instantiate(CherryPickup, PickupPos.position, Quaternion.identity);
		}
		else if(rand == 7){
			currentPickup = Instantiate(MelonPickup, PickupPos.position, Quaternion.identity);
		}
		else{
			RemovePickup();
		}
	}
	
	public void RemovePickup(){
		Destroy(currentPickup);
	}
}
