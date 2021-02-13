using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingHandler : MonoBehaviour
{
    public GameObject player;

    public GameObject apple;

    public GameObject currentThrowing;

    public void EquipApple()
    {
        GameObject go = Instantiate(apple, new Vector3(player.transform.position.x + 2f, player.transform.position.y, player.transform.position.z), Quaternion.identity);
        currentThrowing = go;
    }

    public void ThrowFruit()
    {
        currentThrowing.GetComponent<Rigidbody>().useGravity = true;
        currentThrowing.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10f, -9f), ForceMode.Impulse);
    }
}
