using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Phasme : MonoBehaviour
{
        public Camera playerCamera; // Référence à la caméra du personnage
    public Camera AnimCamera;
    public Animator gameEndAnimator; // Référence à l'Animator
    public Animation animFin; 
    public string animationTriggerName = "GameEnd"; // Nom du trigger pour lancer l'animation
    public Canvas healthbar;
    public Canvas text;
    public float health=400f; 
    public float dommage=5;
    public GameObject stickbug; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
         void OnCollisionEnter(Collision trigger)
    {

        if (trigger.gameObject.CompareTag("bullet"))
        {


                // do something if it has that component on it!
                this.health-=playerScript.dommage;
                if(this.health<=0){
                    Destroy(stickbug);

                    EndGame();
                }
                
        }
        
    }
     public void EndGame()
 {
     if (playerCamera != null)
     {
         // Désactiver la caméra du personnage et la bar de vie
         healthbar.enabled = false;
         playerCamera.enabled = false;
         text.enabled = true;
         AnimCamera.enabled = true;
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

}
