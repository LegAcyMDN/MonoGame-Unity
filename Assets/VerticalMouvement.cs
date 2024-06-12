using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMouvement : MonoBehaviour
{
    //public float jumpForce = 5f; // La force de saut
    //private Rigidbody rb;
    //public float speed = 10f;
    //public float mouseSensitivity = 3f;
    //private float verticalRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }
    void FixedUpdate()
    {
      //   transform.Translate(Vector3.forward * 5f * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
    }
    void Update()
    {
    
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        //verticalRotation += mouseX;
        //verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

       // transform.rotation = Quaternion.Euler(0, verticalRotation, 0);
    }
}
