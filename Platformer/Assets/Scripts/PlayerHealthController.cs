using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private float resetTime = 0.5f;
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private float fadeTime = 0.5f;
    [SerializeField] private PlayerHealth playerHealthScript;
    [SerializeField] private float recoveryTime = 1f;
    [SerializeField] private PlayerController playerController;

    private float lastHitTime;

    private const float maxColor = 1f;
    private const float minColor = 0f;

    private Vector2 initialPosition;
    private Transform playersBodyTransform;


    private void Awake()
    {
        playersBodyTransform = transform.parent;
        lastHitTime = -recoveryTime;
    }

    void Start()
    {
        initialPosition = playersBodyTransform.position;
        
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playersBodyTransform.position = initialPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water" && !playerHealthScript.hasLost)
        {
            StartCoroutine(RestartGame());
        }
        if(collision.tag == "Spikes")
        {
            TakeDamage();
           
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }
    }


    private void TakeDamage()
    {
        if (lastHitTime + recoveryTime < Time.time)
        {
            lastHitTime = Time.time;
            playerHealthScript.TakeDamage();
            playerController.IsHurt = true;
        }
    }

    public void HurtAnimationEnd()
    {
        playerController.IsHurt = false;
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(resetTime);
        playersBodyTransform.position = initialPosition;

    }



}
