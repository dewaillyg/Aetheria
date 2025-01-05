using UnityEngine;
using UnityEngine.UI; // N'oubliez pas d'importer pour accéder aux éléments UI

public class WheelMenuToggle : MonoBehaviour
{
    public GameObject wheelMenu; // Référence à l'objet WheelMenu
    public Image selectedItemImage; // Référence à l'image dans le HUD qui affichera l'élément sélectionné

    // Pour chaque image du menu, vous devez passer l'image correspondante
    public Sprite[] menuImages; // Tableau des sprites de vos images de menu

    void Update()
    {
        // Vérifiez si la touche 'E' est pressée
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleMenu();
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
}