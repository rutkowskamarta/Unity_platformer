using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AreaEffector2D))]

public class SpikesBehaviour : MonoBehaviour
{
    [SerializeField] private float upSpeed = 1.0f;
    [SerializeField] private float downSpeed = 0.5f;
    [SerializeField] private float stopTime = 1f;

    [SerializeField] private float offset;

    private Rigidbody2D spikesRigidbody;
    private float initialPosition;

    private AreaEffector2D spikesAreaEffector;



    void Start()
    {
        spikesRigidbody = GetComponent<Rigidbody2D>();
        spikesAreaEffector = GetComponent<AreaEffector2D>();

        initialPosition = transform.localPosition.y;
        StartCoroutine(SpikesMovementUp());
    }

   
    private IEnumerator SpikesMovementUp()
    {
        while(transform.localPosition.y < initialPosition + offset)
        {
            spikesRigidbody.velocity = new Vector2(0, upSpeed);
            yield return null;
        }
        spikesRigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(stopTime);
        StartCoroutine(SpikesMovementDown());
    }

    private IEnumerator SpikesMovementDown()
    {
        while (transform.localPosition.y > initialPosition)
        {
            spikesRigidbody.velocity = new Vector2(0, -downSpeed);
            yield return null;

        }
        spikesRigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(stopTime);
        StartCoroutine(SpikesMovementUp());
    }
}
