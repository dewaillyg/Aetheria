using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMenu : MonoBehaviour
{
    public RectTransform[] menuItems; 
    public float radius = 150f; 

    void Start()
    {
        ArrangeInCircle();
    }

    void ArrangeInCircle()
    {
        if (menuItems.Length == 0) return;

        float angleStep = 360f / menuItems.Length; 

        for (int i = 0; i < menuItems.Length; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad; 
            Vector3 position = new Vector3(
                Mathf.Cos(angle) * radius,
                Mathf.Sin(angle) * radius,
                0
            );
            menuItems[i].anchoredPosition = position; 
        }
    }
}
