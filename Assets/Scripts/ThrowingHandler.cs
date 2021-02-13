using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingHandler : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject apple;

    public GameObject currentThrowing;

    SceneManager sm;

    void Start()
    {
        sm = this.GetComponent<SceneManager>();
    }

    public void EquipApple()
    {
        switch (sm.activePlayer)
        {
            case SceneManager.Players.PLAYER1:
                GameObject go1 = Instantiate(apple, new Vector3(player1.transform.position.x + -2f, player1.transform.position.y, player1.transform.position.z), Quaternion.identity);
                currentThrowing = go1;
                break;
            case SceneManager.Players.PLAYER2:
                GameObject go2 = Instantiate(apple, new Vector3(player2.transform.position.x + 2f, player2.transform.position.y, player2.transform.position.z), Quaternion.identity);
                currentThrowing = go2;
                break;
        }

    }

    public void ThrowFruit()
    {
        switch (sm.activePlayer)
        {
            case SceneManager.Players.PLAYER1:
                currentThrowing.GetComponent<Rigidbody>().useGravity = true;
                currentThrowing.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10f, -9f), ForceMode.Impulse);
                break;
            case SceneManager.Players.PLAYER2:
                currentThrowing.GetComponent<Rigidbody>().useGravity = true;
                currentThrowing.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10f, 9f), ForceMode.Impulse);
                break;
        }

    }
}
