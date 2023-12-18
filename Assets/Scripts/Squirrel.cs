using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            animator.SetInteger("State", 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Food")
        {
            animator.SetInteger("State", 0);
        }
    }
}
