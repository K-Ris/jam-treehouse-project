using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Treehouse;

public class PickupHandler : MonoBehaviour
{
	public FruitHandler.FruitType PickupType;

	public GameObject MainObject;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if(Input.GetMouseButtonDown(0)){
	    	RaycastHit hit;
		    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		    
		    if (Physics.Raycast(ray, out hit, 200.0f))
		    {
			    if (hit.transform.CompareTag("Pickup"))
			    {
				    GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().AddFruit(PickupType);
				    Destroy(MainObject);
			    }
		    }
	    }
    }
}
