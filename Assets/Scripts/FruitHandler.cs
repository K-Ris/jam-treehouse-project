using System.Collections;
using System.Collections.Generic;
using Treehouse;
using UnityEngine;

public class FruitHandler : MonoBehaviour
{
	public int fruitDamage = 20;
    
	public FruitType fruitType;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Debug.Log(this.transform.name);
            //Debug.Log(player);
            int damage = this.GetComponent<FruitHandler>().fruitDamage;
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().DamagePlayer(collision.transform.GetComponent<PlayerHandler>().player, damage);
            collision.transform.GetComponent<PlayerHandler>().PlayHit();

            DestroyFruit();
        }
        else if (collision.transform.CompareTag("Block"))
        {
            //Debug.Log(this.transform.name);
            //Debug.Log(player);
            int damage = this.GetComponent<FruitHandler>().fruitDamage;

            collision.transform.GetComponent<BlockHandler>().damageBlock(fruitDamage);

            DestroyFruit();
        }
        else
        {
            DestroyFruit();
        }
    }
    
	public enum FruitType{
		APPLE,
		CHERRY,
		MELONE
	}

    private void DestroyFruit()
    {
        StartCoroutine(DoDestroyFruit());
    }

    IEnumerator DoDestroyFruit()
    {
	    yield return new WaitForSeconds(0.03f);

        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().HitHandling();
        Destroy(this.gameObject);
    }
}
