using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteEstrela : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Contato"))
        {
            Debug.Log("bateu KKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
        }
    }
}
