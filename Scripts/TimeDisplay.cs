using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    public TMP_Text timeText; 
    public float timeMultiplier = 80f; 
    
    private DateTime simulatedTime; 
    private float elapsedTime = 0f; 

    void Start()
    {
        simulatedTime = DateTime.Now;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime * timeMultiplier;

        simulatedTime = simulatedTime.AddSeconds(elapsedTime);

        elapsedTime = 0;

        timeText.text = simulatedTime.ToString("dddd - HH:mm");
    }
}
