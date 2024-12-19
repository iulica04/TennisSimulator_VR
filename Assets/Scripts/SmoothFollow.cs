using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target; // Controller-ul
    public float positionSmoothSpeed = 10f;
    public float rotationSmoothSpeed = 10f;

    void Update()
    { 
        // Pozitie
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * positionSmoothSpeed);


        // Rotatie
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * rotationSmoothSpeed);
    }
}
