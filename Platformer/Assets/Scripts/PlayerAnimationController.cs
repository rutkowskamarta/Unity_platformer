using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {

    [SerializeField] private PlayerController playerControllerScript;

    private AudioSource audioSource;
    private Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
        SetAnimatorProperties();
	}

    private void SetAnimatorProperties()
    {
        animator.SetBool("IsJumping", playerControllerScript.IsJumping);
        animator.SetBool("IsHurt", playerControllerScript.IsHurt);
    }

    public void PlayJumpSound()
    {
        audioSource.Play();
    }
}
