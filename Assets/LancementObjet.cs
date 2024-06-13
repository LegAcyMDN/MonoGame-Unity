using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancementObjet : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform target; 
    public float throwForce = 10f; 
    public float spawnRate = 1f;
    private float nextSpawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // Assigner la cible s'il n'est pas déjà fait
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        if (target == null)
        {
            Debug.LogError("Target not assigned and no GameObject found with tag 'Target'");
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
        // Créer un nouveau cube à la position du personnage
        GameObject cube = Instantiate(cubePrefab, transform.position, transform.rotation);

        // Appliquer une force en direction de la cible
        Rigidbody rb = cube.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("oui on rentre la aussi");
            Vector3 direction = (target.position - transform.position).normalized;
            rb.AddForce(direction * throwForce, ForceMode.Impulse);
        }
    }
}
