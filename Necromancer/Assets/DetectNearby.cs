using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectNearby : MonoBehaviour {

    GameObject lastCollidedObject;
    bool collided;

	// Use this for initialization
	void Start () {
        collided = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object detected: " + other.gameObject.name);
        lastCollidedObject = other.gameObject;
        collided = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Object escaped: " + other.gameObject.name);
        collided = false;
    }

    public bool getCollided(){
        return collided;
    }

    public GameObject getCollidedObject(){
        return lastCollidedObject;
    }
}
