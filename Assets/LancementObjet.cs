using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancementObjet : MonoBehaviour
{
    public GameObject test_cigar;
    public Transform target; 
    public float throwForce = 10f; 
    public float spawnRate = 1f;
    private float nextSpawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        test_cigar.transform.localScale = new Vector3(5f, 5f, 5f);
        Instantiate(test_cigar, transform.position, transform.rotation);
        // Assigner la cible s'il n'est pas déjà fait
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        if (target == null)
        {
            Debug.LogError("Target not assigned'");
        }
        if (test_cigar == null)
        {
            Debug.LogError("Cube Prefab is not assigned");
        }
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
        GameObject thrownObject = Instantiate(test_cigar, transform.position, transform.rotation);

        // Mettre à jour l'échelle de l'objet instancié
        thrownObject.transform.localScale = new Vector3(5f, 5f, 5f);

        // Appliquer une force en direction de la cible
        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();
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
}
