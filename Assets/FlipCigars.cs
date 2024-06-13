using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCigars : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitFiveSecAndPrint());
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.localRotation.eulerAngles.y);

    }

    IEnumerator WaitFiveSecAndPrint()
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(4);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
        StartCoroutine(WaitASecAndPrint());

    }

    IEnumerator WaitASecAndPrint()
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(0.6f);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

}
