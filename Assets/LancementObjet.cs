using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancementObjet : MonoBehaviour
{
    public GameObject boiteCigar;
    public Transform target; 
    public float throwForce = 10f; 
    public float spawnRate = 1f;
    private float nextSpawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(target);
        if (Time.time >= nextSpawnTime && target != null)
        {
            Debug.Log("oui on rentre la");
            ThrowCube();
            nextSpawnTime = Time.time + spawnRate;
        }
    }
    void ThrowCube()
    {


        boiteCigar.transform.localScale = new Vector3(5f, 5f, 5f);
        Instantiate(boiteCigar, transform.position, transform.rotation);

        // Appliquer une force en direction de la cible
        Rigidbody rb = boiteCigar.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.AddForce(direction * throwForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("No Rigidbody attached to the boiteCigar prefab");
        }

    }
    void OnCollisionEnter(Collision collision)
    {
      /*  if (collision.boiteCigar.CompareTag("Player"))
        {
            
            Destroy(boiteCigar);
        }*/

    }
}
