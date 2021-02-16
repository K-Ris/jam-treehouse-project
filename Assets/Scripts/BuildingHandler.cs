using System.Collections;
using System.Collections.Generic;
using Treehouse;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
	public GameObject wood;
	public GameObject sheet;
	public GameObject pillow;

    public GameObject currentBlock;

	SceneManager sm;
	UIManager um;


    void Start()
    {
	    sm = this.GetComponent<SceneManager>();
	    um = this.GetComponent<UIManager>();
    }

    public void BuildWood()
    {
        if (currentBlock != null)
            Destroy(currentBlock);

        float difX = 1;
        float difZ = 4;

        switch (sm.activePlayer)
        {
            case SceneManager.Players.PLAYER1:
                difX = 1;
	            difZ = 4;
                break;
            case SceneManager.Players.PLAYER2:
                difX = -1;
	            difZ = -4;
                break;
        }
        GameObject go = Instantiate(wood, new Vector3(difX, 6, 0), Quaternion.identity);
	    currentBlock = go;
    }
    
	public void BuilSheet()
	{
		if (currentBlock != null)
			Destroy(currentBlock);

		float difX = 1;
		float difZ = 4;

		switch (sm.activePlayer)
		{
		case SceneManager.Players.PLAYER1:
			difX = 1;
			difZ = 4;
			break;
		case SceneManager.Players.PLAYER2:
			difX = -1;
			difZ = -4;
			break;
		}
		GameObject go = Instantiate(sheet, new Vector3(difX, 6, 0), Quaternion.identity);
		currentBlock = go;
	}
	
	public void BuildPillow()
	{
		if (currentBlock != null)
			Destroy(currentBlock);

		float difX = 1;
		float difZ = 4;

		switch (sm.activePlayer)
		{
		case SceneManager.Players.PLAYER1:
			difX = 1;
			difZ = 4;
			break;
		case SceneManager.Players.PLAYER2:
			difX = -1;
			difZ = -4;
			break;
		}
		GameObject go = Instantiate(pillow, new Vector3(difX, 6, 0), Quaternion.identity);
		currentBlock = go;
	}
	

    public void RotateBlock()
    {
        currentBlock.transform.Rotate(90, 0, 0);
    }

    public void SetBlock()
	{
		if(currentBlock != null){
			
			switch (sm.activePlayer)
			{
			case SceneManager.Players.PLAYER1:
				switch(currentBlock.transform.GetComponent<BlockHandler>().blockType){
				case BlockHandler.BlockType.WOOD:
					sm.Player1_WoodCount--;
					break;
				case BlockHandler.BlockType.SHEET:
					sm.Player1_SheetCount--;
					break;
				case BlockHandler.BlockType.PILLOW:
					sm.Player1_PillowCount--;
					break;
				}
				break;
			case SceneManager.Players.PLAYER2:
				switch(currentBlock.transform.GetComponent<BlockHandler>().blockType){
				case BlockHandler.BlockType.WOOD:
					sm.Player2_WoodCount--;
					break;
				case BlockHandler.BlockType.SHEET:
					sm.Player2_SheetCount--;
					break;
				case BlockHandler.BlockType.PILLOW:
					sm.Player2_PillowCount--;
					break;
				}
				break;
			}
			
			currentBlock.gameObject.GetComponent<Rigidbody>().useGravity = true;
			//currentBlock.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			currentBlock.tag = "Block";
			currentBlock.GetComponent<FollowMouse>().enabled = false;
			currentBlock = null;
		}
		
		um.UpdateBuildingMaterialUI(sm.activePlayer);
		
    }
}
