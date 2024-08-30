using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardsScript : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    private Transform playerPos;
    [SerializeField] private Transform lightPos;

    [SerializeField] private GameObject player;

    [SerializeField] private ParticleSystem[] firework;

    private Vector3 cameraControll;

    private PlayerController playerController;

    private bool lightActive;

    [SerializeField] private Animator animator;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        cameraControll = new Vector3(0,3.5f,-4);
        playerPos = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lightActive)
            cameraPos.position = playerPos.position + cameraControll;
        else
        {
            playerPos.position = new Vector3(0, 1.5f, 25);
            cameraPos.position = Vector3.MoveTowards(cameraPos.position, new Vector3(0, 5, 17), Time.deltaTime);
        }
            

    }



    private void OnTriggerEnter(Collider other)
    {
        if (!lightActive)
        {
            playerPos.position = new Vector3(0, 1.5f, 25);
            lightPos.Rotate(190, 0, 0);
            lightActive = true;
            playerController.Active = false;
            animator.SetTrigger("Award");
            for (int i = 0; i < firework.Length; i++)
            {
                firework[i].Play();
            }
        }        
    }
}
