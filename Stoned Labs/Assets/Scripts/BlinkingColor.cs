using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingColor : MonoBehaviour
{
    public Color blinkColor = Color.red;
    public float blinkInterval = 0.2f;
    public int blinkCount = 6;

    private Renderer objectRenderer;
    private Color originalColor;
    private bool isBlinking = false;

    void Start()
    {
        // Try to find a Renderer in this object or its children
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            objectRenderer = GetComponentInChildren<Renderer>();
        }

        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
        else
        {
            Debug.LogError("No Renderer found on this object or its children.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isBlinking && objectRenderer != null)
        {
            StartCoroutine(Blink());
        }
    }

    private System.Collections.IEnumerator Blink()
    {
        isBlinking = true;
        for (int i = 0; i < blinkCount; i++)
        {
            objectRenderer.material.color = blinkColor;
            yield return new WaitForSeconds(blinkInterval);
            objectRenderer.material.color = originalColor;
            yield return new WaitForSeconds(blinkInterval);
        }
        isBlinking = false;
    }
}
