using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColinAction : MonoBehaviour
{
    public bool win;
    private Animator animator;
    // Start is called before the first frame update
    public Canvas canva; // <-- Assign your GUITexture to this.
    public CigarSpawner spawnCigarScript;

    void OnTriggerEnter(Collider other)
    {
        canva.enabled = true;
        spawnCigarScript.SpawnCigars();
        if (!win )
        {
            animator.SetTrigger("Angry");
        }
        else
        {
            Debug.Log("oui");
            animator.SetTrigger("Win");
        }

    }

    void OnTriggerExit(Collider other)
    {
        canva.enabled = false;
    }
    void Start()
    {
        canva.enabled = false;
        win = false;
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
 
    }
    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le joueur entre en collision avec un autre joueur

    }
}
