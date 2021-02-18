using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    public int blockHealth = 50;
	public int blockHealth_cur = 50;
	public int breakingHealth = 25;
	
	public MeshRenderer meshRend;
	public Material brokenMat;
    
	public BlockType blockType;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Fruit"))
    //    {
    //        //Debug.Log(this.transform.name);
    //        //Debug.Log(player);
    //        int damage = collision.transform.GetComponent<FruitHandler>().fruitDamage;

    //        blockHealth_cur -= damage;

    //        if(blockHealth_cur <= 0)
    //        {
    //            Destroy(this.gameObject);
    //        }

    //        Destroy(collision.transform.gameObject);
    //    }
    //}

    public void damageBlock(int damage)
    {
        blockHealth_cur -= damage;

        if (blockHealth_cur <= 0)
        {
            Destroy(this.gameObject);
        }
        
	    if(blockHealth_cur < breakingHealth){
        	
        	if(brokenMat != null){
        		Material [] materials = meshRend.materials;
        		materials[0] = brokenMat;
        		meshRend.materials = materials;
        	}
        }
    }
    
	public enum BlockType{
		WOOD,
		SHEET,
		PILLOW
	}
}
