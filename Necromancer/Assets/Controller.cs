using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float speed;

    public GameObject necromancer;
    public List<GameObject> targets;
    private GameObject current;

    void Start()
    {
        current = targets[0];

        setColor();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = current.transform.position;
            position.x-=speed;
            current.transform.position = position;

            if(current != necromancer){
                position = necromancer.transform.position;
                position.x -= speed/5;
                necromancer.transform.position = position;
            }
        } else if (Input.GetKey(KeyCode.RightArrow)){

            Vector3 position = current.transform.position;
            position.x += speed;
            current.transform.position = position;
            if (current != necromancer)
            {
                position = necromancer.transform.position;
                position.x += speed/5;
                necromancer.transform.position = position;
            }
        }

        if (Input.GetKey(KeyCode.Alpha1)){switchNecromancer();}
        if(Input.GetKey(KeyCode.Alpha2)){switchTarget(0);}
        if(Input.GetKey(KeyCode.Alpha3)){switchTarget(1);}


        //check nearby minion candidates
        if(current.GetComponentInChildren<DetectNearby>() != null){
            bool colliding = current.GetComponentInChildren<DetectNearby>().getCollided();

            //if there is a nearby minion to be added
            if (current.GetComponentInChildren<DetectNearby>().getCollidedObject() != null)
            {
                GameObject collidedObj = current.GetComponentInChildren<DetectNearby>().getCollidedObject();
                if (colliding && collidedObj != null)
                {
                    if(collidedObj.gameObject.tag != "" && collidedObj.gameObject.tag == "DetectionRadius"){
                        setDetectColor(collidedObj);
                        if (Input.GetKey(KeyCode.Space))
                        {
                            //add the minion to our collection 
                            targets.Add(collidedObj);
                            collidedObj.gameObject.tag = "Untagged";
                            //now change control to new object
                            Debug.Log("New Target");
                            current = targets[targets.Count - 1];
                            setColor();
                        }
                    }

                }
                else if (!colliding && collidedObj != null)
                {
                    resetDetectColor(collidedObj);
                }
            }
        }



    }

    public void switchTarget(int index){

        if(index <= targets.Count){
            Debug.Log("Switching to Target: " + (index + 1));
            current = targets[index];
            setColor();
        }

    }

    public void switchNecromancer()
    {

        current = necromancer;
        setColor();

    }

    private void setColor(){

        foreach (GameObject obj in targets){

            obj.GetComponent<Renderer>().material.color = Color.white;
        }

        necromancer.GetComponent<Renderer>().material.color = Color.white;

        //Fetch the Renderer from the GameObject
        current.GetComponent<Renderer>().material.color = Color.green;
    }

    private void setDetectColor(GameObject obj){
        obj.GetComponentInParent<Renderer>().material.color = Color.yellow;
    }

    private void resetDetectColor(GameObject obj)
    {
        obj.GetComponentInParent<Renderer>().material.color = Color.white;
    }


}
