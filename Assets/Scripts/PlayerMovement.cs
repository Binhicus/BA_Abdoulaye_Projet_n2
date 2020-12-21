using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    public Vector3 jump;
    public Vector3 velocity = Vector3.zero;
    public float jumpForce = 2.0f;
    //public float ultFloating = 2.0f;

    float horizontalInput;
    public float horizontalMultiplier = 2f;

    bool grounded;
    bool isLevitating = false;
    bool alive = true;

    private Animator anim;
    public Transform target;
    public GameObject plasmaR;
    public GameObject plasmaL;

    public float minModifier = 7f;
    public float maxModifier = 11f;

    public RagdollDeath rdDeath;
    public GameObject ultCollider;

    

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        //ult = new Vector3(0.0f, 2.0f, 0.0f);
        anim = GetComponent<Animator>();
        plasmaL.SetActive(false);
        plasmaR.SetActive(false);
    }
    private void OnCollisionStay ()
    {
        grounded = true;
        anim.SetBool("isGrounded", true);
        anim.SetBool("isUlting", false);
    }
    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(transform.position.x, -4.3f, 4.3f);
        //clampedPosition.y = Mathf.Clamp(transform.position.y, 0f, 2.85f);
        transform.position = clampedPosition;

        if (transform.position.y < -5)
        {
            Die();
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false;
            anim.SetBool("isGrounded", false);
            anim.SetTrigger("Jump");
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);           
        }

        Ulting();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(isLevitating == false)
            {
                rb.useGravity = false;
                anim.SetTrigger("Ult");
            }
            isLevitating = true;
            anim.SetBool("isUlting", true);
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;

        }
        else
        {
            ultCollider.SetActive(false);
            rb.useGravity = true;
            isLevitating = false;
            plasmaL.SetActive(false);
            plasmaR.SetActive(false);
            //anim.SetBool("isUlting", false);
        }
    }
    void Ulting()
    {
        if(isLevitating == true)
        {
            ultCollider.SetActive(true);
            plasmaL.SetActive(true);
            plasmaR.SetActive(true);
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, Time.deltaTime);
            //Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        }         
    }
    public void Die()
    {
        alive = false;
        rdDeath.ToggleRagdoll(true);
        //Restart le jeu
        Invoke("Restart", 2);
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
