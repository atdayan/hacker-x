using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactCollision : MonoBehaviour
{
    public Material materialTrigger;
    void OnTriggerEnter(Collider collider) {
        Debug.Log(collider.GetComponent<Renderer>().material.name);
        Debug.Log(materialTrigger.name);
        // if(x.Equals(materialTrigger.name)) {
        //     FindObjectOfType<GameManager>().EndGame();
        // }
    }
}
