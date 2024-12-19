using UnityEngine;

public class BallDropper : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        // Obținem componenta Rigidbody atașată obiectului
        rb = GetComponent<Rigidbody>();

        // Dezactivăm gravitatea la început (opțional)
        rb.useGravity = false;
    }

    void Update()
    {
        // Verificăm dacă tasta Space este apăsată
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Activăm gravitatea pe Rigidbody pentru a lăsa obiectul să cadă
            rb.useGravity = true;
        }
    }
}