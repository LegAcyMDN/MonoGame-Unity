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
    private GameObject portalObj;

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            canva.enabled = true;
            if (!cigarSpawned)
            {
                spawnCigarScript.SpawnCigars();
                cigarSpawned = true;
            }

            if (!win)
            {
                animator.SetTrigger("Angry");
            }
            else
            {
                animator.SetTrigger("Win");


                portalObj.SetActive(true);
                StartCoroutine(FaitSpawnPhasme());
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
        portalObj = GameObject.FindGameObjectWithTag("Portal");
        phasmeObj.SetActive(false);
        portalObj.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        // V�rifie si le joueur entre en collision avec un autre joueur

    }


    IEnumerator FaitSpawnPhasme()
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(3f);
        phasmeObj.SetActive(true);
        StartCoroutine(FaitDespawnPortal());
    }
    IEnumerator FaitDespawnPortal()
    {
        yield return new WaitForSeconds(3f);
        portalObj.SetActive(false);
    }
}