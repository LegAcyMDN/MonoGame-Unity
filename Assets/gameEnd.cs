using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameEnd : MonoBehaviour
{
    public Camera playerCamera; // Référence à la caméra du personnage
    public Camera AnimCamera;
    public Animator gameEndAnimator; // Référence à l'Animator
    public Animation animFin; 
    public string animationTriggerName = "GameEnd"; // Nom du trigger pour lancer l'animation
    public Canvas healthbar;
    public Canvas text;

    // Méthode à appeler pour finir le jeu
    public void EndGame()
    {
        if (playerCamera != null)
        {
            // Désactiver la caméra du personnage et la bar de vie
            healthbar.enabled = false;
            playerCamera.enabled = false;
            text.enabled = true;
            //AnimCamera.enabled = true;
            Debug.Log("Caméra du personnage désactivée.");
        }
        else

        if (gameEndAnimator != null)
        {
            // Active le trigger de l'animation
            gameEndAnimator.Play("AnimeFin");
            Debug.Log("Trigger set: " + animationTriggerName);
        }
        else
        {
            Debug.LogError("Animator non assigné.");
        }

        // Autres logiques de fin de jeu ici
        Debug.Log("Le jeu est terminé. Lancement de l'animation de fin de jeu.");
    }

    // Exemple pour déclencher la fin du jeu
    void Update()
    {
        // Exemple de condition pour la fin du jeu (par exemple, un bouton pressé)
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Fin du jeu déclenchée par l'utilisateur.");
            EndGame();
        }
    }
}
