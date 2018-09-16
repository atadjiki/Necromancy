using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float speed;

    public List<GameObject> targets;
    private GameObject current;

    void Start()
    {
        current = targets[0];

        setColor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = current.transform.position;
            position.x--;
            current.transform.position = position;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)){

            Vector3 position = current.transform.position;
            position.x++;
            current.transform.position = position;
        }

        if(Input.GetKey(KeyCode.Alpha1)){switchTarget(0);}
        if(Input.GetKey(KeyCode.Alpha2)){switchTarget(1);}
        if(Input.GetKey(KeyCode.Alpha3)){switchTarget(2);}

    }

    public void switchTarget(int index){
        Debug.Log("Switching to Target: " + (index + 1));
        current = targets[index];
        setColor();
    }

    private void setColor(){

        foreach (GameObject obj in targets){

            obj.GetComponent<Renderer>().material.color = Color.white;
        }

        //Fetch the Renderer from the GameObject
        current.GetComponent<Renderer>().material.color = Color.green;
    }


}
