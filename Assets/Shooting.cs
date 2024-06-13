using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody _bulletPrefab;
    public Rigidbody _bulletEmitter;
    public float speed = 20;
    public Camera Camera;
    public Canvas baseBar;
    public Canvas healthBar;


    public int compteur=0;
    public UnityEngine.Rigidbody bullet;
    // Use this for initialization
    void Start()
    {


        // Create a ray from the camera going through the middle of your screen
        Ray ray = Camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        // Check whether your are pointing to something so as to adjust the direction
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(1000);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            // Create a ray from the camera going through the middle of your screen
            Ray ray = Camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0F));
            RaycastHit hit ;

            // Check whether your are pointing to something so as to adjust the direction
            Vector3 targetPoint ;
            if (Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint( 1000 ) ;

            // Create the bullet and give it a velocity according to the target point computed before
            bullet = Instantiate(_bulletPrefab, _bulletEmitter.transform.position, _bulletEmitter.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = (targetPoint - _bulletEmitter.transform.position).normalized * speed;
            Physics.IgnoreCollision(_bulletEmitter.transform.GetComponent<Collider>(), bullet.GetComponent<Collider>());
            compteur++;

            Destroy(bullet.gameObject,2f);
        }



    }
}
