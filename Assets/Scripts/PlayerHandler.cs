using System.Collections;
using System.Collections.Generic;
using Treehouse;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public SceneManager.Players player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Fruit"))
        {
            //Debug.Log(this.transform.name);
            //Debug.Log(player);
            int damage = collision.transform.GetComponent<FruitHandler>().fruitDamage;
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().DamagePlayer(player, damage);

            Destroy(collision.transform.gameObject);
        }
    }
}
