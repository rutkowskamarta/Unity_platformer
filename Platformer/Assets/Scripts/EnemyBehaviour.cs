using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float verticalForce = 2.0f;
    [SerializeField] private float shootFrequency = 2.0f;
    [SerializeField] private float shootForceAmplifier = 1.5f;

    [SerializeField] private float bulletLifeTime = 5f;

    public bool IsPlayerNear { get; set; } = false;
    

    private float lastShootTime = 0;

    private void Start()
    {
        ShootBullet();
    }

    void Update()
    {
        LookAtPlayer();
        if (lastShootTime + shootFrequency < Time.time)
        {
            ShootBullet();
        }
    }

        private void LookAtPlayer()
    {
        if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    

    private void ShootBullet()
    {
        if (IsPlayerNear)
        {
            lastShootTime = Time.time;
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2((player.transform.position.x - transform.position.x) * shootForceAmplifier, verticalForce));

        }

    }

}
