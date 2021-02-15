using System.Collections;
using System.Collections.Generic;
using Treehouse;
using UnityEngine;

public class FruitHandler : MonoBehaviour
{
    public int fruitDamage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log(this.transform.name);
            //Debug.Log(player);
            int damage = this.GetComponent<FruitHandler>().fruitDamage;
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().DamagePlayer(collision.transform.GetComponent<PlayerHandler>().player, damage);
            collision.transform.GetComponent<PlayerHandler>().PlayHit();
            Destroy(this.gameObject);
        }
        else if (collision.transform.CompareTag("Block"))
        {
            //Debug.Log(this.transform.name);
            //Debug.Log(player);
            int damage = this.GetComponent<FruitHandler>().fruitDamage;

            collision.transform.GetComponent<BlockHandler>().damageBlock(fruitDamage);

            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
