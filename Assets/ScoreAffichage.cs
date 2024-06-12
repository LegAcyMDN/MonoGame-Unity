using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAffichage : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        // Vérifier si l'objet touché a le tag "Collectible"
        if (collision.gameObject.CompareTag("Cigars"))
        {
            // Incrémenter le score
            score++;
            // Mettre à jour le score affiché
            UpdateScoreText();
            // Détruire l'objet touché
            Destroy(collision.gameObject);
        }
    }
    void UpdateScoreText()
    {
        Debug.Log("oui");
        // Mettre à jour le texte du score
        scoreText.text = "Score: " + score + "/30";
    }
}
