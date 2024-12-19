using UnityEngine;

public class BallThrone : MonoBehaviour
{
    public float life = 20f;            // Durata de viață a mingii înainte să fie distrusă
    public float baseHitForce = 10f;    // Forța de bază de impact (ajustabilă pentru a controla puterea loviturii)
    public float speedFactor = 0.1f;    // Factorul care va mări forța în funcție de viteza mingii (ajustabil)
    public float directionFactor = 0.5f;  // Factor care va controla direcția de lovire

    private Rigidbody rb;
    private AudioSource audioSource;    // AudioSource pentru a reda sunetul

    // Funcție care se apelează când mingea lovește un alt obiect
    private void OnCollisionEnter(Collision collision)
    {
        // Verifică dacă obiectul cu care mingea colidează este racheta
        if (collision.gameObject.CompareTag("Racket"))
        {
            // Debug pentru a verifica tag-ul corect
            Debug.Log("Mingea a lovit racheta!");

            // Direcția de impact, adăugând forța corespunzătoare
            Vector3 hitDirection = collision.contacts[0].normal * -1; // Direcția opusă a coliziunii

            // Mărește forța în funcție de viteza mingii, dar cu un factor mai mic pentru a nu face mingea prea rapidă
            float currentSpeed = rb.velocity.magnitude; // Viteza curentă a mingii
            float dynamicHitForce = baseHitForce + currentSpeed * speedFactor; // Forță dinamică calculată

            // Calculăm direcția de aruncare (în direcția opusă față de coliziune)
            Vector3 throwDirection = hitDirection * directionFactor;

            // Inversează direcția față de coliziune pentru a arunca mingea în direcția opusă
            throwDirection = -throwDirection; // Direcția opusă

            // Aplică forța pe rigidbody-ul mingii, în direcția calculată
            rb.AddForce(throwDirection * dynamicHitForce, ForceMode.Impulse);

            // Afișează în Debug pentru a verifica direcția și forța
            Debug.Log("Mingea a fost lovită de rachetă. Forța aplicată: " + dynamicHitForce);
            Debug.Log("Direcția de aruncare: " + throwDirection);

            // Redă sunetul doar atunci când mingea lovește racheta
            audioSource.Play();
        }
    }

    // Verifică și inițializează Rigidbody-ul și AudioSource-ul la început
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Obține componentul AudioSource atașat mingii

        // Dacă Rigidbody nu este găsit, afișează un mesaj de eroare
        if (rb == null)
        {
            Debug.LogError("Rigidbody-ul nu a fost găsit pe acest obiect!");
        }

        // Dacă AudioSource nu este găsit, afișează un mesaj de eroare
        if (audioSource == null)
        {
            Debug.LogError("AudioSource nu a fost găsit pe acest obiect! Asigură-te că ai atașat un AudioSource la mingea ta.");
        }
    }
}
