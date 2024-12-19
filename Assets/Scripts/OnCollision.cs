using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter called." + collision.gameObject.name);
    }
     public void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay occuring...");
    }
    public void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit called.");
    }
}
