using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    public int blockHealth = 50;
    public int blockHealth_cur = 50;

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
    }
}
