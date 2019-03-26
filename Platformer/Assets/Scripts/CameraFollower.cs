using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset;



    void LateUpdate()
    {
        SmoothCameraMovement();
    }

    private void SmoothCameraMovement()
    {

        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothPosition;

    }
}