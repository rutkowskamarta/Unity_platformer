using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovablePlatform : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float offset;
    [SerializeField] private bool isVertical;

    private Vector2 initialPosition;
    private bool isMovingTowardsPositive = false;

    private Rigidbody2D platformsRigidBody;

    void Start()
    {
        platformsRigidBody = GetComponent<Rigidbody2D>();
        initialPosition = transform.localPosition;
        
    }


    void FixedUpdate()
    {
        MovePlatform();
    }


    private void MovePlatform()
    {
        if (isVertical)
        {
            if (isMovingTowardsPositive)
            {
                platformsRigidBody.velocity = new Vector2(0, speed);
                if(transform.localPosition.y >= initialPosition.y + offset)
                {
                    isMovingTowardsPositive = !isMovingTowardsPositive;
                }
            }
            else
            {
                platformsRigidBody.velocity = new Vector2(0, - speed);
                if (transform.localPosition.y <= initialPosition.y - offset)
                {
                    isMovingTowardsPositive = !isMovingTowardsPositive;
                }

            }
        }
        else
        {
            if (isMovingTowardsPositive)
            {
                platformsRigidBody.velocity = new Vector2(speed, 0);

                if (transform.localPosition.x >= initialPosition.x + offset)
                {
                    isMovingTowardsPositive = !isMovingTowardsPositive;
                }
            }
            else
            {
                platformsRigidBody.velocity = new Vector2( - speed, 0);

                if (transform.localPosition.x <= initialPosition.x - offset)
                {
                    isMovingTowardsPositive = !isMovingTowardsPositive;
                }

            }
        }
    }

}
