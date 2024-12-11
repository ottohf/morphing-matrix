using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinAnim : MonoBehaviour
{
    private Animator animator;
    private bool isDying;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isDying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDying)
        {
            animator.SetTrigger("coinDEATH");
        }
        
    }

    public void setDead()
    {
        this.isDying = true;
    }
}
