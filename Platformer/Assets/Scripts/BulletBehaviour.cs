using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float sceneLifeTime = 2f;
    [SerializeField] private float lifeTime = 5f;


    private float startTime;
    
    private void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        DestroyBullet();
    }


    private void DestroyBullet()
    {

        if (Time.time > startTime + sceneLifeTime)
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        }
        else if(Time.time > startTime + lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
