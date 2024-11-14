using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountHits : MonoBehaviour
{
    private int hits = 0;
    public ScoreManager scoreManager; // Reference to the ScoreManager

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the ScoreManager is linked
        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager == null)
            {
                Debug.LogError("ScoreManager not found in the scene. Please ensure it is added.");
            }

        }
    }

     

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fairways")
        {
         
            hits++;

            scoreManager.UpdateScore();
        }
    }
}
