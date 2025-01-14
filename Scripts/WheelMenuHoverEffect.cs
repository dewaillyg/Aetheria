using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelMenuHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleFactor = 1.2f; // Facteur de mise à l'échelle lorsque l'image est survolée
    public float transitionDuration = 0.2f; // Durée de la transition en secondes
    private Vector3 originalScale; // Échelle d'origine

    private void Start()
    {
        // Sauvegarde l'échelle originale de l'image
        originalScale = transform.localScale;
    }

    // Lorsque la souris entre dans l'image
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Applique une mise à l'échelle avec une transition
        LeanTween.scale(gameObject, originalScale * scaleFactor, transitionDuration).setEase(LeanTweenType.easeInOutSine);
    }

    // Lorsque la souris quitte l'image
    public void OnPointerExit(PointerEventData eventData)
    {
        // Restaure l'échelle d'origine avec une transition
        LeanTween.scale(gameObject, originalScale, transitionDuration).setEase(LeanTweenType.easeInOutSine);
    }
}
