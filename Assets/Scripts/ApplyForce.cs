using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	    //applyForce();
	    Time.timeScale = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
	    if(Input.GetMouseButtonDown(0))
		    applyForce();
    }
    
	void applyForce(){
		this.GetComponent<Rigidbody>().AddForce(new Vector3(0,10,6), ForceMode.Impulse);
	}
}
