using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float jumpForce = 5f; // La force de saut
    private bool isGrounded= true; // Pour vérifier si le joueur est au sol
    private Rigidbody rb;
    public float speed = 5f;
    public float mouseSensitivity = 2f;
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
            Debug.Log(isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true )
        {
            Jump();
        }
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0, mouseX, 0);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 5f * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * 5f * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
        
    }
    void Jump()
    {
        // Applique une force verticale au Rigidbody du joueur
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; // Le joueur n'est plus au sol après le saut
    }

   void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le joueur touche le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Le joueur est au sol
        }
    }

}
