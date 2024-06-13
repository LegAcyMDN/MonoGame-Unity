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

        /*tirEnnemi.transform.localScale = new Vector3(1f, 1f, 1f);
        Instantiate(tirEnnemi, ShotPoint.position, Quaternion.identity);
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log("target x : " + playerObj.transform.position.x);

        // Appliquer une force en direction de la cible
        Rigidbody rb = tirEnnemi.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Vector3 direction = new Vector3(playerObj.transform.position.x - ShotPoint.position.x, playerObj.transform.position.y - ShotPoint.position.y, playerObj.transform.position.z - ShotPoint.position.z);
        rb.velocity = direction * throwForce;*/


        /*
        Vector3 direction = (ShotPoint.position - target.position).normalized;
        rb.AddForce(direction * throwForce, ForceMode.Impulse);
        Debug.Log("target"+target.position);
        Debug.Log("shotpoint" + ShotPoint.position);*/

        tirEnnemi.transform.localScale = new Vector3(1f, 1f, 1f);
        GameObject newTirEnnemi = Instantiate(tirEnnemi, ShotPoint.position, Quaternion.identity);

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            // Apply a force in the direction of the target
            Rigidbody rb = newTirEnnemi.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 ajustePourTaillePlayer = new Vector3(0f,1.5f,0f);
                Vector3 direction = ((playerObj.transform.position - ShotPoint.position) + ajustePourTaillePlayer).normalized;
                rb.velocity = direction * throwForce;
            }
        }







    }
    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("tirEnnemi"))
        {
            Debug.Log("ca tape");
            //Destroy(collision.gameObject);
        }

    }
}
