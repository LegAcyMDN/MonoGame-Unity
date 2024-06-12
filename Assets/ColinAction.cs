using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColinAction : MonoBehaviour
{
    public bool win;
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
        // V�rifie si le joueur entre en collision avec un autre joueur
        if (collision.gameObject.CompareTag("Player")&&win==false)
        {
            Debug.Log("non");
            animator.SetTrigger("Angry");
        }
        if (collision.gameObject.CompareTag("Player")&&win==true)
        {
            Debug.Log("oui");
            animator.SetTrigger("Win");
        }
    }
}
