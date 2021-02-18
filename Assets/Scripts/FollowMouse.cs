﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
	bool isFollowing = false;
	
	float temps;

    // Start is called before the first frame update
    void Start()
    {
	    temps = Time.time; // initialising time
    }

    // Update is called once per frame
    void Update()
    {


        if (isFollowing)
        {
            Vector3 temp = Input.mousePosition;
            temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
            this.transform.position = new Vector3(this.transform.position.x, Camera.main.ScreenToWorldPoint(temp).y, Camera.main.ScreenToWorldPoint(temp).z);
        }

        if (Input.GetMouseButton(0))
        {
        	
        	
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        if (Physics.Raycast(ray, out hit, 200.0f))
            {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                if (hit.transform.CompareTag("Preview"))
                {
                	GameObject.FindGameObjectWithTag("SceneManager").GetComponent<BuildingHandler>().swipeblock = true;
                    isFollowing = true;
                }
                    
            }

            //if (!isFollowing)
            //{
            //    RaycastHit hit;
            //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    if (Physics.Raycast(ray, out hit, 100.0f))
            //    {
            //        Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            //        if (hit.transform.CompareTag("Preview"))
            //            isFollowing = true;
            //    }
            //}
            //Vector3 temp = Input.mousePosition;
            //temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
            //this.transform.position = new Vector3(0, Camera.main.ScreenToWorldPoint(temp).y, Camera.main.ScreenToWorldPoint(temp).z);
            //this.transform.localEulerAngles = Vector3.zero;
            //isFollowing = true;
        }
        
	    if(Input.GetMouseButtonDown(0)){
	    	temps = Time.time;
	    }
	    
	    //if( Input.GetMouseButtonUp(0) && (Time.time - temps) < 0.3f ){
	    //	GameObject.FindGameObjectWithTag("SceneManager").GetComponent<BuildingHandler>().RotateBlock();
	    //}

        if (Input.GetMouseButtonUp(0))
        {
	        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<BuildingHandler>().swipeblock = false;

            isFollowing = false;
            
        }
        

    }


    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
