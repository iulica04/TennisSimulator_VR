using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab-ul pentru minge
    public Transform spawnPoint; // Punctul de spawn al mingii
    public float throwForce = 15f; // Forța de aruncare (valoare mai mare pentru o viteză mai mare)
    public float angle = 80f; // Unghi mult mai mare pentru a arunca mult mai sus
    public float directionRange = 2f; // Range-ul aleatoriu pentru mișcarea pe axa X
    public float throwInterval = 3f; // Interval între aruncări

    private float timeSinceLastThrow = 0f; // Timp scurs de la ultima aruncare

    public void Update()
    {
        // Actualizează cronometru
        timeSinceLastThrow += Time.deltaTime;

        // Verifică dacă este timpul pentru o nouă aruncare
        if (timeSinceLastThrow >= throwInterval)
        {
            ThrowBall(); // Aruncă mingea
            timeSinceLastThrow = 0f; // Resetează cronometru
        }
    }

    private void ThrowBall()
    {
        // Creează o nouă minge
        var _ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);

        // Calculăm unghiul în radiani pentru trigonometrie
        float radianAngle = angle * Mathf.Deg2Rad;

        // Direcția ajustată: în față + variație aleatorie pe axa X
        float randomX = Random.Range(-directionRange * 2, -directionRange);

        // Calculăm direcția folosind funcțiile trigonometrice
        float yDirection = Mathf.Sin(radianAngle);  // Componenta pe axa Y (verticală)
        float zDirection = Mathf.Cos(radianAngle);  // Componenta pe axa Z (orizontală)

        Vector3 adjustedDirection = new Vector3(randomX, 0.4f, 1f);

        _ball.GetComponent<Rigidbody>().velocity = adjustedDirection * throwForce;
    }
}
