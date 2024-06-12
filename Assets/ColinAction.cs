using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColinAction : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le joueur entre en collision avec un autre joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Angry");
        }
    }
}
