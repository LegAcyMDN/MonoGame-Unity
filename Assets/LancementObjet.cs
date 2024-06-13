using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancementObjet : MonoBehaviour
{
    public GameObject boiteCigar;
    public Transform target;
    public float throwForce = 100f;
    public float spawnRate = 1f;
    private float nextSpawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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

        Vector3 direction = (target.position - transform.position).normalized;
         rb.AddForce(direction * throwForce, ForceMode.Impulse);



    }
    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ca tape");
        }

    }
}
