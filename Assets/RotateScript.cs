using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {

    private bool rotate;

    public void Rotate(float turnSpeed) {
        rotate = true;
        while (rotate) {
            transform.Rotate(Vector3.forward, turnSpeed);
            int angulo = (int) Mathf.Round(transform.rotation.eulerAngles.z);
            //print(angulo);
            if (angulo == 0 || angulo == 270 || angulo == 90 || angulo == 180) {
                rotate = false;
            }
        }        
    }
}
