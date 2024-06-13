using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameEnd : MonoBehaviour
{
    public Camera playerCamera; // R�f�rence � la cam�ra du personnage
    public Camera AnimCamera;
    public Animator gameEndAnimator; // R�f�rence � l'Animator
    public Animation animFin; 
    public string animationTriggerName = "GameEnd"; // Nom du trigger pour lancer l'animation
    public Canvas healthbar;
    public Canvas text;

    // M�thode � appeler pour finir le jeu
    public void EndGame()
    {
        if (playerCamera != null)
        {
            // D�sactiver la cam�ra du personnage et la bar de vie
            healthbar.enabled = false;
            playerCamera.enabled = false;
            text.enabled = true;
            AnimCamera.enabled = true;
            Debug.Log("Cam�ra du personnage d�sactiv�e.");
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
            Debug.LogError("Animator non assign�.");
        }

        // Autres logiques de fin de jeu ici
        Debug.Log("Le jeu est termin�. Lancement de l'animation de fin de jeu.");
    }

    // Exemple pour d�clencher la fin du jeu
    void Update()
    {
        // Exemple de condition pour la fin du jeu (par exemple, un bouton press�)
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Fin du jeu d�clench�e par l'utilisateur.");
            EndGame();
        }
    }
}
