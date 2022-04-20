using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
    	if (other.tag == "LightObject")
    	{
    		other.GetComponent<Collider>().isTrigger = false;
    		//Debug.Log("coll on");
    	}
    	if (other.tag == "ShadowObject")
    	{
    		other.GetComponent<Collider>().isTrigger = true;
    	//	Debug.Log("coll off");
    	}

    }

    void OnTriggerExit(Collider other)
    {
    	if (other.tag == "LightObject")
    	{
    		other.GetComponent<Collider>().isTrigger = true;
    	//	Debug.Log("coll off");
    	}
    	if (other.tag == "ShadowObject")
    	{
    		other.GetComponent<Collider>().isTrigger = false;
    	//	Debug.Log("coll on");
    	}
    }
}
