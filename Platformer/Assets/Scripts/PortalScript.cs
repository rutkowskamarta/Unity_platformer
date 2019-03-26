using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private PlayerHealth playerHealthScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !playerHealthScript.hasLost)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
