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
	
	float clicked = 0;
	float clicktime = 0;
	float clickdelay = 0.5f;
	

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
	
	public bool swipeblock = false;

    void Start()
    {
	    sm = this.GetComponent<SceneManager>();
	    um = this.GetComponent<UIManager>();
    }
    
	private void Update()
	{
		//SwipeTouch();
		//Swipe();
		
		if(Input.GetMouseButtonDown(0)){
			
			clicked++;
			if (clicked == 1) clicktime = Time.time;
			
 
			if (clicked > 1 && Time.time - clicktime < clickdelay)
			{
				clicked = 0;
				clicktime = 0;
				SetBlock();
 
			}
		}
		
		if (clicked > 2 || Time.time - clicktime > (clickdelay + 0.1f)) clicked = 0;
 
	}
	
 
	//public void SwipeTouch()
	//{
	//	if(!swipeblock){
			
	//		if(Input.touches.Length > 0)
	//		{
	//			Touch t = Input.GetTouch(0);
	//			if(t.phase == TouchPhase.Began)
	//			{
	//				//save began touch 2d point
	//				firstPressPos = new Vector2(t.position.x,t.position.y);
	//			}
	//			if(t.phase == TouchPhase.Ended)
	//			{
	//				//save ended touch 2d point
	//				secondPressPos = new Vector2(t.position.x,t.position.y);
                           
	//				//create vector from the two points
	//				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
               
	//				//normalize the 2d vector
	//				currentSwipe.Normalize();
 
	//				//swipe left
	//				if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
	//				{
	//					Debug.Log("left swipe");
	//					RotateBlock();
	//				}
	//				//swipe right
	//				if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
	//				{
	//					Debug.Log("right swipe");
	//					RotateBlock();
	//				}
	//			}
	//		}
	//	}
	//}
 
	public void Swipe()
	{
		if(!swipeblock){
			if(Input.GetMouseButtonDown(0))
			{
				//save began touch 2d point
				firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			}
			if(Input.GetMouseButtonUp(0))
			{
				//save ended touch 2d point
				secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
       
				//create vector from the two points
				currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
           
				//normalize the 2d vector
				currentSwipe.Normalize();
 
				//swipe left
				if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					Debug.Log("left swipe");
					RotateBlockLeft();
				}
				//swipe right
				if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					Debug.Log("right swipe");
					RotateBlockRight();
				}
			}
		}
	}

    public void BuildWood()
    {
        if (currentBlock != null)
            Destroy(currentBlock);

        float difX = 1;
        //float difZ = 4;

        switch (sm.activePlayer)
        {
            case SceneManager.Players.PLAYER1:
                difX = 1;
	            //difZ = 4;
                break;
            case SceneManager.Players.PLAYER2:
                difX = -1;
	            //difZ = -4;
                break;
        }
	    GameObject go = Instantiate(wood, new Vector3(difX, 3, 0), Quaternion.identity);
	    currentBlock = go;
    }
    
	public void BuilSheet()
	{
		if (currentBlock != null)
			Destroy(currentBlock);

		float difX = 1;
		//float difZ = 4;

		switch (sm.activePlayer)
		{
		case SceneManager.Players.PLAYER1:
			difX = 1;
			//difZ = 4;
			break;
		case SceneManager.Players.PLAYER2:
			difX = -1;
			//difZ = -4;
			break;
		}
		GameObject go = Instantiate(sheet, new Vector3(difX, 3, 0), Quaternion.identity);
		currentBlock = go;
	}
	
	public void BuildPillow()
	{
		if (currentBlock != null)
			Destroy(currentBlock);

		float difX = 1;
		//float difZ = 4;

		switch (sm.activePlayer)
		{
		case SceneManager.Players.PLAYER1:
			difX = 1;
			//difZ = 4;
			break;
		case SceneManager.Players.PLAYER2:
			difX = -1;
			//difZ = -4;
			break;
		}
		GameObject go = Instantiate(pillow, new Vector3(difX, 2, 0), Quaternion.identity);
		currentBlock = go;
	}
	

	public void RotateBlockRight()
	{
		if(currentBlock != null)
			currentBlock.transform.Rotate(-90, 0, 0);
	}
    
	public void RotateBlockLeft(){
		if(currentBlock != null)
			currentBlock.transform.Rotate(90, 0, 0);
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
