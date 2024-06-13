using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // V�rifie si le joueur entre en collision avec un autre joueur
        if (collision.gameObject.tag=="Tree")
        Destroy(collision.gameObject);
    }
}
