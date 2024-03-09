using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpThings : MonoBehaviour
{
    public GameObject camera;
    public GameObject[] Things;
    public float distance = 15f;
    GameObject currentThing;
    bool canPickUp = false;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PickUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    void PickUp()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if(hit.transform.tag == "Thing")
            {
                if (canPickUp) Drop();

                currentThing = hit.transform.gameObject;
                currentThing.GetComponent<Rigidbody>().isKinematic = true;
                currentThing.GetComponent<Collider>().isTrigger = true;
                currentThing.transform.parent = transform;
                currentThing.transform.localPosition = Vector3.zero;
                if(currentThing == Things[2])
                    currentThing.transform.localEulerAngles = new Vector3(31.9534416f, 329.029602f, 324.282196f);
                else if(currentThing == Things[1])
                    currentThing.transform.localEulerAngles = new Vector3(0.357065827f, 291.087677f, 133.08049f);
                else
                    currentThing.transform.localEulerAngles = new Vector3(0.357083768f, 291.087646f, 349.179169f);
                canPickUp = true;
            }
        }

        
    }

    void Drop()
    {
        currentThing.transform.parent = null;
        currentThing.GetComponent<Rigidbody>().isKinematic = false;
        currentThing.GetComponent<Collider>().isTrigger = false;
        canPickUp = false;
        currentThing = null;
    }
}
