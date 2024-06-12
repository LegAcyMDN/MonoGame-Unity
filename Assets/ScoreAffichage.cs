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
        // V�rifier si l'objet touch� a le tag "Collectible"
        if (collision.gameObject.CompareTag("Cigars"))
        {
            // Incr�menter le score
            score++;
            // Mettre � jour le score affich�
            UpdateScoreText();
            // D�truire l'objet touch�
            Destroy(collision.gameObject);
        }
    }
    void UpdateScoreText()
    {
        Debug.Log("oui");
        // Mettre � jour le texte du score
        scoreText.text = "Score: " + score + "/30";
    }
}
