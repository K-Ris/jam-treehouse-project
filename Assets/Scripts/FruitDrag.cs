using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Treehouse;

public class FruitDrag : MonoBehaviour
{
    public float ThrowPower;
    public Rigidbody rb;

    public Vector3 minimumpower;
    public Vector3 maximumpower;
    public LineRenderer line;

    Camera camera;
    Vector3 throwforce;
    Vector3 startpoint;
    Vector3 endpoint;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startpoint = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 currentpoint = camera.ScreenToWorldPoint(Input.mousePosition);
            DrawLine(startpoint, currentpoint);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endpoint = camera.ScreenToWorldPoint(Input.mousePosition);

            SceneManager sm = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
            if (sm.activePlayer == SceneManager.Players.PLAYER2)
            {
                this.transform.position = new Vector3(sm.Player2.transform.position.x + 2f, this.transform.position.y, this.transform.position.z);
            }

            sm.PlayThrowAnimation();

            StartCoroutine(StartThrow());
        }
    }

    IEnumerator StartThrow()
    {
        yield return new WaitForSeconds(0.4f);

        throwforce = new Vector3(
                0,
                Mathf.Clamp(startpoint.y - endpoint.y, minimumpower.y, maximumpower.y),
                Mathf.Clamp(startpoint.z - endpoint.z, minimumpower.z, maximumpower.z));
        rb.AddForce(throwforce * ThrowPower, ForceMode.Impulse);
        rb.useGravity = true;
        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().ThrowFruit(this.GetComponent<FruitHandler>().fruitType);
        EndLine();
    }

    public void DrawLine(Vector3 startpoint, Vector3 endpoint)
    {
        startpoint.x = -15;
        endpoint.x = -15;

        line.positionCount = 2;
        Vector3[] allpoints = new Vector3[2];
        allpoints[0] = startpoint;
        allpoints[1] = endpoint;
        line.SetPositions(allpoints);
    }

    public void EndLine()
    {
        line.positionCount = 0;

        this.GetComponent<FruitDrag>().enabled = false;
    }
}
