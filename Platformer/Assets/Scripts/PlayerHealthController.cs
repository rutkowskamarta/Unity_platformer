using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private float resetTime = 0.5f;
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private float fadeTime = 0.5f;
    [SerializeField] private SpriteRenderer hurtMaskSprite;
    [SerializeField] private PlayerHealth playerHealthScript;
    [SerializeField] private float recoveryTime = 1f;


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
            if (lastHitTime + recoveryTime < Time.time)
            {
                lastHitTime = Time.time;
                playerHealthScript.TakeDamage();
                HurtColorChange();
            }
        }
    }

  
    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(resetTime);
        playersBodyTransform.position = initialPosition;

    }

    public void HurtColorChange()
    {
        StartCoroutine(FadeHurtVisualisation(maxColor, fadeSpeed));
        StartCoroutine(RestoreNormalLook());

    }

    private IEnumerator FadeHurtVisualisation(float alphaValue, float duration)
    {
        float alpha = hurtMaskSprite.color.a;
        for (float t = 0.0f; t < duration; t += Time.deltaTime / fadeTime)
        {
            Color newColor = new Color(hurtMaskSprite.color.r, hurtMaskSprite.color.g, hurtMaskSprite.color.g, Mathf.Lerp(alpha, alphaValue, t));
            hurtMaskSprite.color = newColor;
            yield return null;
        }
    }
    
    private IEnumerator RestoreNormalLook()
    {
        yield return new WaitForSeconds(fadeTime);
        StartCoroutine(FadeHurtVisualisation(minColor, fadeSpeed));
    }

}
