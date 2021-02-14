using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public SceneManager.Players player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Fruit"))
        {
            Debug.Log(this.transform.name);
            Debug.Log(player);
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().DamagePlayer(player);
        }
    }
}
