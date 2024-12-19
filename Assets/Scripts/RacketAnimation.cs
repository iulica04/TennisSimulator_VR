using UnityEngine;

public class RacketAnimation : MonoBehaviour
{
    public float rotationAngle = 1f;  // Unghiul de rotație pe axa X
    public float rotationSpeed = 3f;   // Viteza de rotație (ajustabilă)

    private Quaternion initialRotation;  // Rotația inițială
    private bool isRotating = false;     // Flag pentru a urmări dacă animația de rotație este activă

    // Start is called before the first frame update
    private void Start()
    {
        // Salvează rotația inițială a rachetei
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        // Detectează click-ul stâng pe mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Începe animația de rotație
            isRotating = true;
        }

        // Animația de rotație
        if (isRotating)
        {
            // Rotește racheta cu un unghi ușor
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation * Quaternion.Euler(rotationAngle, 0f, 0f), Time.deltaTime * rotationSpeed);

           
            isRotating = false;

        }
    }
}
