using UnityEngine;

public class TransformOnHit : MonoBehaviour
{
   

    public GameObject particleEffectPrefab; // Prefab-ul pentru efectul de particule

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "golfBall")
        {     
            TransformIntoParticles();
        }
    }

    void TransformIntoParticles()
    {
        Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
