using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class AnimControll : MonoBehaviour
{
    private Animator animator;

    [SerializeField] bool trap;

    [SerializeField] private int min;
    [SerializeField] private int max;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        if(trap)
        {
            ChangeTrapAnimation();
        }
    }

    public void ChangeAnimation()
    {
        animator.SetInteger("NumOperation",Random.RandomRange(min,max));
    }

    public void ChangeTrapAnimation()
    {
        animator.SetBool("GoState", false);
        int a = Random.RandomRange(min,max);
        animator.SetInteger("State", a);        
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("GoState", true);
    }
}
