using UnityEngine;
using UnityEngine.UI; // N'oubliez pas d'importer pour accéder aux éléments UI
using UnityEngine.EventSystems; // Nécessaire pour gérer le survol et les clics

public class WheelMenuToggle : MonoBehaviour
{
    public GameObject wheelMenu; // Référence à l'objet WheelMenu
    public Image selectedItemImage; // Référence à l'image dans le HUD qui affichera l'élément sélectionné

    // Pour chaque image du menu, vous devez passer l'image correspondante
    public Sprite[] menuImages; // Tableau des sprites de vos images de menu

    private int selectedIndex = -1; // Index de l'élément sélectionné, initialisé à -1 (aucune sélection)

    public float scaleFactor = 1.2f; // Facteur de mise à l'échelle lors de la sélection
    public float transitionDuration = 0.2f; // Durée de la transition de mise à l'échelle

    private void Update()
    {
        // Vérifiez si la touche 'E' est pressée
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleMenu();
        }

        // Gestion de la sélection avec les touches 1, 2, 3, 4
        if (wheelMenu.activeSelf) // Si le menu est ouvert
        {
            // Vérifie si une des touches 1, 2, 3, ou 4 est pressée
            if (Input.GetKeyDown(KeyCode.Alpha1)) { SelectItem(0); }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { SelectItem(1); }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { SelectItem(2); }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { SelectItem(3); }

            // Sélectionne l'élément actuel avec la touche "Entrée"
            if (Input.GetKeyDown(KeyCode.Return) && selectedIndex >= 0)
            {
                CloseMenu(selectedIndex);
            }
        }
    }

    void ToggleMenu()
    {
        // Active ou désactive le menu (l'afficher ou le masquer)
        wheelMenu.SetActive(!wheelMenu.activeSelf);
    }

    // Cette méthode est appelée lorsque l'utilisateur clique sur une image du menu
    public void CloseMenu(int imageIndex)
    {
        // Fermer le menu
        wheelMenu.SetActive(false);

        // Afficher l'image cliquée dans le HUD
        DisplaySelectedItem(imageIndex);
    }

    // Afficher l'image sélectionnée dans le coin supérieur droit du HUD
    void DisplaySelectedItem(int imageIndex)
    {
        // Vérifier que l'index est valide
        if (imageIndex >= 0 && imageIndex < menuImages.Length)
        {
            selectedItemImage.sprite = menuImages[imageIndex]; // Changez l'image de l'élément HUD
            selectedItemImage.gameObject.SetActive(true); // Assurez-vous que l'image est visible
        }
    }

    // Sélectionner un élément du menu
    void SelectItem(int index)
    {
        // Vérifie que l'index est valide
        if (index >= 0 && index < menuImages.Length)
        {
            selectedIndex = index; // Met à jour l'index de l'élément sélectionné
            AnimateItemSelection(index); // Applique l'effet de transition de mise à l'échelle
        }
    }

    // Animation de la mise à l'échelle de l'élément sélectionné
    void AnimateItemSelection(int index)
    {
        // Trouve l'image du menu correspondante
        Transform itemTransform = wheelMenu.transform.GetChild(index); // Suppose que les éléments sont des enfants directs du menu

        // Applique l'animation de mise à l'échelle
        LeanTween.scale(itemTransform.gameObject, itemTransform.localScale * scaleFactor, transitionDuration).setEase(LeanTweenType.easeInOutSine);

        // Restaure l'échelle après l'animation (facultatif)
        LeanTween.scale(itemTransform.gameObject, itemTransform.localScale, transitionDuration).setEase(LeanTweenType.easeInOutSine).setDelay(transitionDuration);
    }
}
