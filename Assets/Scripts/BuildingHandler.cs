using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    public GameObject wood;

    public GameObject currentBlock;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BuildWood()
    {
        GameObject go = Instantiate(wood, new Vector3(0, 4, 4), Quaternion.identity);
        currentBlock = go;
    }

    public void RotateBlock()
    {
        currentBlock.transform.Rotate(90, 0, 0);
    }

    public void SetBlock()
    {
        currentBlock.gameObject.GetComponent<Rigidbody>().useGravity = true;
        currentBlock.tag = "Block";
        currentBlock.GetComponent<FollowMouse>().enabled = false;
        currentBlock = null;
    }
}
