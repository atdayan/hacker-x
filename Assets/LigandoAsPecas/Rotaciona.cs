using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotaciona : MonoBehaviour {

    public float turnSpeed = 1f;
    bool rotate = false;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate){
            transform.Rotate(Vector3.forward, -turnSpeed);
            int angulo = (int)Mathf.Round(transform.rotation.eulerAngles.z);
            //print(angulo);
            if (angulo == 0 || angulo == 270 || angulo == 90 || angulo == 180){
                rotate = false;
            }
        }
    }

    void OnMouseDown(){
        rotate = true;
    }
}
