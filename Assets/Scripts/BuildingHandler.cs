using System.Collections;
using System.Collections.Generic;
using Treehouse;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    public GameObject wood;

    public GameObject currentBlock;

    SceneManager sm;


    void Start()
    {
        sm = this.GetComponent<SceneManager>();
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

    public void RotateBlock()
    {
        currentBlock.transform.Rotate(90, 0, 0);
    }

    public void SetBlock()
    {
        currentBlock.gameObject.GetComponent<Rigidbody>().useGravity = true;
        //currentBlock.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        currentBlock.tag = "Block";
        currentBlock.GetComponent<FollowMouse>().enabled = false;
        currentBlock = null;
    }
}
