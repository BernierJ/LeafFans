using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshPro timerText;
    float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        float hue = Mathf.Repeat(Time.time * 0.2f, 1f); // cycles hue smoothly
        Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f);

        timerText.color = rainbowColor;
    }
}
