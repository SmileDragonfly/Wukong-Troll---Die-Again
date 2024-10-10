using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("Run");
        } 
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetTrigger("Jump");
        }
    }
}
