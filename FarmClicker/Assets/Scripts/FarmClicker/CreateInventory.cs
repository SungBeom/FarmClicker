using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateInventory : MonoBehaviour
{
    GameObject[] cropInventory;

    Vector2 cellSize;

    Color backgroundColor;

    Vector2 outlineSize;

    float cropHeight;

    int fontSize;

    Vector2 ciAnchorMax;
    Vector2 ccAnchorMin;

    void Awake()
    {
        // 버튼이 총 2개
        cropInventory = new GameObject[2];
        cropInventory[0] = transform.Find("VegetableInventory").gameObject;
        cropInventory[1] = transform.Find("FruitInventory").gameObject;

        cellSize = new Vector2(540f, 192f);

        backgroundColor = Color.white;
        backgroundColor.a = 150f / 255f;

        outlineSize = new Vector2(4f, -3f);

        fontSize = 50;

        ciAnchorMax = new Vector2(0.5f, 1f);
        ccAnchorMin = new Vector3(0.5f, 0f);
    }

    void OnEnable()
    {
        if (FarmManager.Instance.InventoryFlag)
        {
            for (int i = 0; i < FarmManager.Instance.crops.Length; i++)
                for (int j = 0; j < FarmManager.Instance.crops[i].cropSprites.Length; j++)
                    transform.GetChild(i).GetChild(j).GetComponentInChildren<Text>().text = "x" + FarmManager.Instance.CropCount[i][j];
        }
    }

    void Start()
    {
        // Fix grid layout group component to crop inventory
        for (int i = 0; i < FarmManager.Instance.crops.Length; i++)
        {
            GridLayoutGroup sLayout = cropInventory[i].GetComponent<GridLayoutGroup>();
            sLayout.cellSize = cellSize;
        }

        for (int i = 0; i < FarmManager.Instance.crops.Length; i++)
        {
            for (int j = 0; j < FarmManager.Instance.crops[i].cropSprites.Length; j++)
            {
                // Create crop
                GameObject crop = new GameObject("Crop" + (j + 1));
                crop.layer = LayerMask.NameToLayer("UI");

                // Add image component to crop
                Image backgroundImage = crop.AddComponent<Image>();
                backgroundImage.color = backgroundColor;

                // Add outline component to crop
                Outline outline = crop.AddComponent<Outline>();
                outline.effectDistance = outlineSize;

                // Create crop image
                GameObject cropImage = new GameObject("Image");
                cropImage.layer = LayerMask.NameToLayer("UI");

                // Add image component to crop image
                Image image = cropImage.AddComponent<Image>();
                image.sprite = FarmManager.Instance.crops[i].cropSprites[j].Sprites[0];
                image.preserveAspect = true;

                // Create crop count
                GameObject cropCount = new GameObject("Text");
                cropCount.layer = LayerMask.NameToLayer("UI");

                // Add text component to crop count
                Text cropText = cropCount.AddComponent<Text>();
                cropText.text = "x" + FarmManager.Instance.CropCount[i][j];
                cropText.font = FarmManager.Instance.mainFont;
                cropText.fontSize = fontSize;
                cropText.alignment = TextAnchor.MiddleCenter;
                cropText.color = Color.black;

                // Establish relationship between transforms
                cropImage.transform.SetParent(crop.transform, false);
                cropText.transform.SetParent(crop.transform, false);
                crop.transform.SetParent(cropInventory[i].transform, false);

                // Adjust crop transform
                crop.transform.localScale = Vector3.one;

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
        }

        // 초기에 채소가 보여지므로, 채소의 개수에 맞게 viewport의 content 크기 초기화
        transform.GetComponent<RectTransform>().sizeDelta =
            new Vector2(transform.GetComponent<RectTransform>().sizeDelta.x,
            Mathf.Round((FarmManager.Instance.crops[0].cropSprites.Length + 0.5f) / 2.0f) * cellSize.y);

        FarmManager.Instance.InventoryFlag = true;
    }
}
