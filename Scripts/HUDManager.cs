using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hudText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHUDText(string newText)
    {
        if (hudText != null)
        {
            hudText.text = newText;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
