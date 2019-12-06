using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour {

    public void Rotate(int rotateAngle) {
        transform.Rotate(0f,0f,rotateAngle);
    }
}
