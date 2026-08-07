using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private Text textStart;

    private float currentJumpTime;

    private Rigidbody2D rb2D;
    private AudioSource audioSource;
    private SpawnController spawnController;

    private bool grounded;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  
        spawnController = GameObject.Find("SpawnController").GetComponent<SpawnController>();
    }

    // 0.007
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && grounded == true)
        {
            if(spawnController.inGame == false)
            {
                spawnController.inGame = true; 
                textStart.enabled = false;
                spawnController.Create();
            }

            currentJumpTime = jumpTime;
            audioSource.Play();
        }
        else if(Input.GetButton("Fire1") && currentJumpTime > 0.0f)
        {
            currentJumpTime -= Time.deltaTime;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            currentJumpTime = 0.0f;
        }
    }

    // 0.02
    private void FixedUpdate()
    {
        if(currentJumpTime > 0.0f)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            grounded = true;    
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Cactus")
        {
            Destroy(gameObject);
        }
    }

}
