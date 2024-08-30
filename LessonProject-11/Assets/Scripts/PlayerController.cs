using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] float maxVelocity;
    [SerializeField] float powerJump;

    private Rigidbody playerPos;
    private Animator animator;

    

    [SerializeField] private ParticleSystem death;

    public bool Active;


    void Awake()
    {
        animator = GetComponent<Animator>();
        playerPos = GetComponent<Rigidbody>();
        Active = true;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Active)
        {
            playerPos.AddForce(0, 0, power * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) && Active)
        {
            playerPos.AddForce(0, 0, -power * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) && Active)
        { 
            playerPos.AddForce(-power*Time.deltaTime,0,0);
        }

        if (Input.GetKey(KeyCode.D)&&Active)
        {
            playerPos.AddForce(power * Time.deltaTime, 0, 0);
        }               
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {            
            StartCoroutine(Loose());
        }

        if (collision.gameObject.CompareTag("Jumper"))
        {
            animator.SetBool("Jump", true);
            playerPos.AddForce(0, powerJump, 0, ForceMode.Impulse);
        }     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(Loose());
        }
        else if (other.gameObject.CompareTag("EndGame"))
        {
            Active = false;
        }
    }

    public void JumpEnd()
    {
        animator.SetBool("Jump", false);
    }

    IEnumerator Loose()
    {
        Active = false;
        yield return new WaitForSeconds(0.1f);
        death.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
