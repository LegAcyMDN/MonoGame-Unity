using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColinAction : MonoBehaviour
{
    public static bool win = false;
    public bool cigarSpawned = false;
    private Animator animator;
    // Start is called before the first frame update
    public Canvas canva; // <-- Assign your GUITexture to this.
    public CigarSpawner spawnCigarScript;
    private GameObject phasmeObj;

    void OnTriggerEnter(Collider trigger)
    {
        Debug.Log("aaaaa");
        Debug.Log(win);
        if (trigger.gameObject.CompareTag("Player"))
        {
            canva.enabled = true;
            if (!cigarSpawned)
            {
                spawnCigarScript.SpawnCigars();
                cigarSpawned=true;
            }
            
            if (!win)
            {
                animator.SetTrigger("Angry");
            }
            else
            {
                animator.SetTrigger("Win");
                
                phasmeObj.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            canva.enabled = false;
        }
    }
    void Start()
    {
        canva.enabled = false;
        win = false;
        animator = GetComponent<Animator>();
        phasmeObj = GameObject.FindGameObjectWithTag("Phasme");
        phasmeObj.SetActive(false);
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
