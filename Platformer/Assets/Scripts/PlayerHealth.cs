using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject heartUIPrefab;
    [SerializeField] private float offset;
    [SerializeField] private int healthPoints = 3;
    [SerializeField] private UnityEvent gameOverEvent;

    private Vector2 positionOnScreen = Vector2.zero;
    private List<GameObject> healthUIGameObjects;
    private float heartWidth;

    public bool hasLost { get; set; } = false;

    private void OnValidate()
    {
        if (healthPoints < 1)
            healthPoints = 1;

        if (offset < 0)
            offset = 1f;
    }
    
    private void Start()
    {
        RectTransform heartRect = heartUIPrefab.GetComponent<RectTransform>();
        heartWidth = heartRect.rect.size.x*heartRect.localScale.x;
        GenerateInitialHealthBar();
    }

    private void GenerateInitialHealthBar()
    {
        healthUIGameObjects = new List<GameObject>();
        
        for (int i = 0; i < healthPoints; i++)
        {
            healthUIGameObjects.Add(Instantiate(heartUIPrefab, transform));
            healthUIGameObjects[i].transform.localPosition = positionOnScreen;
            positionOnScreen = new Vector2(positionOnScreen.x + heartWidth + offset, positionOnScreen.y);
        }
    }

    public void TakeDamage()
    {
        if(healthUIGameObjects.Count > 0)
        {
            Destroy(healthUIGameObjects[healthUIGameObjects.Count - 1]);
            healthUIGameObjects.RemoveAt(healthUIGameObjects.Count - 1);
        }
        if(healthUIGameObjects.Count == 0)
        {
            hasLost = true;
            gameOverEvent.Invoke();
        }
    }
}
