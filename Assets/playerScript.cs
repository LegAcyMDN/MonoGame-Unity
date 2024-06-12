using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float jumpForce = 5f; // La force de saut
   // private bool isGrounded= true; // Pour vérifier si le joueur est au sol
    private Rigidbody rb;
    public float speed = 10f;
    public float mouseSensitivity = 3f;
    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      /*  Debug.Log(isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true )
        {
            Jump();
        }*/
        //mouvement souris cam
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation += mouseX;
        horizontalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -360f, 360f);
        horizontalRotation = Mathf.Clamp(horizontalRotation, -90f, 90f);
       // Debug.Log(horizontalRotation);
        //Debug.Log(verticalRotation);
        transform.rotation = Quaternion.Euler(horizontalRotation, verticalRotation, 0);
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 5f * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * 5f * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
        
    }
    /*void Jump()
    {
        isGrounded = false;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

   void OnCollisionEnter(Collision collision)
    {
        Debug.Log("on rentre dans la fonction");
        // Vérifie si le joueur touche le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Oe");
            isGrounded = true; // Le joueur est au sol
        }
    }*/

}
