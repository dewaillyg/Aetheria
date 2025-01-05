using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelMenuInteraction : MonoBehaviour
{
    public RectTransform[] menuItems;
    public Transform centerPoint;

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 direction = mousePosition - (Vector2)centerPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle < 0) angle += 360;

        int selectedIndex = Mathf.FloorToInt(angle / (360f / menuItems.Length));
        HighlightItem(selectedIndex);
    }

    void HighlightItem(int index)
    {
        for (int i = 0; i < menuItems.Length; i++)
        {
            if (i == index)
            {
                menuItems[i].GetComponent<UnityEngine.UI.Image>().color = Color.yellow; 
            }
            else
            {
                menuItems[i].GetComponent<UnityEngine.UI.Image>().color = Color.white; 
            }
        }
    }
}
