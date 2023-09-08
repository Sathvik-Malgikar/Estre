using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwitchColour : MonoBehaviour
{
    // private TMP_Text tmpText;
    // private Color originalColor;
    // public Color newColorOnClick;

    public GameObject GOColourST ;

    // private void Start()
    // {
    //     tmpText = GetComponent<TMP_Text>();
    //     originalColor = tmpText.color;
    // }

    // private void OnMouseDown()
    // {
    //     tmpText.color = newColorOnClick;

    // }

    public void swcclr()
    {
        // tmpText.color = originalColor;
        ColourST cst = GOColourST.GetComponent<ColourST>();
        Debug.Log(gameObject.name+"Clicked!");
        cst.setMaterial(gameObject.name);
    }
}
