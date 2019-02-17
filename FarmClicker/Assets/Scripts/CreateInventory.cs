using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateInventory : MonoBehaviour
{
    Color backgroundColor;

    float cropHeight;

    int fontSize;

    Vector2 ciAnchorMax;
    Vector2 ccAnchorMin;

    void Awake()
    {
        backgroundColor = Color.white;
        backgroundColor.a = 75f / 255f;

        cropHeight = 200f;

        fontSize = 50;

        ciAnchorMax = new Vector2(0.5f, 1f);
        ccAnchorMin = new Vector3(0.5f, 0f);
    }

    void Start()
    {
        for (int i = 0; i < GameManager.Instance.plants.Length; i++)
        {
            // Create crop
            GameObject crop = new GameObject("Crop" + (i + 1));
            crop.layer = LayerMask.NameToLayer("UI");

            // Add image coponent to crop
            Image backgroundImage = crop.AddComponent<Image>();
            // backgroundImage.sprite =
            backgroundImage.color = backgroundColor;

            // Create crop image
            GameObject cropImage = new GameObject("Image");
            cropImage.layer = LayerMask.NameToLayer("UI");

            // Add image component to crop image
            Image image = cropImage.AddComponent<Image>();
            image.sprite = GameManager.Instance.plants[i];
            image.preserveAspect = true;

            // Create crop count
            GameObject cropCount = new GameObject("Text");
            cropCount.layer = LayerMask.NameToLayer("UI");

            // Add text component to crop count
            Text cropText = cropCount.AddComponent<Text>();
            cropText.text = "x" + GameManager.Instance.PlantCount[i];
            cropText.font = GameManager.Instance.mainFont;
            cropText.fontSize = fontSize;
            cropText.alignment = TextAnchor.MiddleCenter;
            cropText.color = Color.black;

            // Establish relationship between transforms
            cropImage.transform.SetParent(crop.transform, false);
            cropText.transform.SetParent(crop.transform, false);
            crop.transform.SetParent(transform, false);

            // Adjust crop transform
            crop.transform.position += new Vector3(0f, 0f, 90f);
            crop.transform.localScale = Vector3.one;
            RectTransform rt = crop.GetComponent<RectTransform>();
            crop.GetComponent<RectTransform>().sizeDelta = new Vector2(rt.sizeDelta.x, cropHeight);

            // Adjust crop image transform
            RectTransform cirt = cropImage.GetComponent<RectTransform>();
            cirt.anchorMin = Vector2.zero;
            cirt.anchorMax = ciAnchorMax;
            cirt.anchoredPosition = Vector3.zero;
            cirt.sizeDelta = Vector2.zero;

            // Adjust crop count transform
            RectTransform ccrt = cropCount.GetComponent<RectTransform>();
            ccrt.anchorMin = ccAnchorMin;
            ccrt.anchorMax = Vector2.one;
            ccrt.anchoredPosition = Vector3.zero;
            ccrt.sizeDelta = Vector2.zero;
        }

        GameManager.Instance.InventoryFlag = true;
    }
}
