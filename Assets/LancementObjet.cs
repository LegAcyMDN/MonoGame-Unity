using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancementObjet : MonoBehaviour
{
    public GameObject tirEnnemi;
    public Transform ShotPoint;
    public Transform phasme;
    public Transform target;
    public float throwForce = 800;
    public float spawnRate = 1f;
    private float nextSpawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            ThrowCube();
            nextSpawnTime = Time.time + spawnRate;
        }
    }
    void ThrowCube()
    {
        tirEnnemi.transform.localScale = new Vector3(1f, 1f, 1f);
        Instantiate(tirEnnemi, ShotPoint.position, ShotPoint.rotation);

        // Appliquer une force en direction de la cible
        Rigidbody rb = tirEnnemi.GetComponent<Rigidbody>();

        Vector3 direction = (target.position - phasme.position).normalized;
        rb.AddForce(direction * throwForce, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("tirEnnemi"))
        {
            Debug.Log("ca tape");
            Destroy(collision.gameObject);
        }

    }
}
