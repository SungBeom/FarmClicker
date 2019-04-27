using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSeed : MonoBehaviour
{
    GameObject[] cropSeed;

    int lrPadding, tbPadding;
    Vector2 cellSize, spacing;

    float seedSize;

    int fontSize;

    Vector2 siAnchorMin;
    Vector2 spAnchorMax;

    void Awake()
    {
        // 버튼이 총 2개
        cropSeed = new GameObject[2];
        cropSeed[0] = transform.Find("VegetableSeed").gameObject;
        cropSeed[1] = transform.Find("FruitSeed").gameObject;

        lrPadding = 54;
        tbPadding = 48;
        cellSize = new Vector2(200f, 200f);
        spacing = new Vector2(lrPadding, tbPadding);

        seedSize = 200f;

        fontSize = 40;

        siAnchorMin = new Vector2(0f, 0.2f);
        spAnchorMax = new Vector2(1f, 0.2f);
    }

    void Start()
    {
        // Fix grid layout group component to crop seed
        for (int i = 0; i < FarmManager.Instance.crops.Length; i++)
        {
            GridLayoutGroup sLayout = cropSeed[i].GetComponent<GridLayoutGroup>();
            sLayout.padding = new RectOffset(lrPadding, lrPadding, tbPadding, tbPadding);
            sLayout.cellSize = cellSize;
            sLayout.spacing = spacing;
        }

        for (int i = 0; i < FarmManager.Instance.crops.Length; i++)
        {
            for (int j = 0; j < FarmManager.Instance.crops[i].cropSprites.Length; j++)
            {
                // Create seed
                GameObject seed = new GameObject("SeedBtn" + (j + 1));
                seed.layer = LayerMask.NameToLayer("UI");

                // Add image component to seed
                Image backgroundImage = seed.AddComponent<Image>();

                // Add button component to seed
                Button seedBtn = seed.AddComponent<Button>();

                // Add layout element component to seed
                LayoutElement seedLayout = seed.AddComponent<LayoutElement>();
                seedLayout.preferredWidth = seedSize;
                seedLayout.preferredHeight = seedSize;

                // Add select vegetable script to seed
                SelectCrop sc = seed.AddComponent<SelectCrop>();
                sc.PlantIndex = j;

                // Create seed image
                GameObject seedImage = new GameObject("Image");
                seedImage.layer = LayerMask.NameToLayer("UI");

                // Add image component to seed image
                Image image = seedImage.AddComponent<Image>();
                image.sprite = FarmManager.Instance.crops[i].cropSprites[j].Sprites[0];
                image.preserveAspect = true;

                // Create seed price
                GameObject seedPrice = new GameObject("Price");
                seedPrice.layer = LayerMask.NameToLayer("UI");

                // Add text component to seed price
                Text text = seedPrice.AddComponent<Text>();
                text.text = FarmManager.Instance.crops[i].cropSprites[j].Price + "원";
                text.font = FarmManager.Instance.mainFont;
                text.fontSize = fontSize;
                text.alignment = TextAnchor.MiddleCenter;
                text.color = Color.black;

                // Establish relationship between transforms
                seedImage.transform.SetParent(seed.transform, false);
                seedPrice.transform.SetParent(seed.transform, false);
                seed.transform.SetParent(cropSeed[i].transform, false);

                // Adjust seed transform
                seed.transform.localScale = Vector3.one;

                // Adjust seed image transform
                RectTransform sirt = seedImage.GetComponent<RectTransform>();
                sirt.anchorMin = siAnchorMin;
                sirt.anchorMax = Vector2.one;
                sirt.sizeDelta = Vector2.zero;

                // Adjust seed price transform
                RectTransform sprt = seedPrice.GetComponent<RectTransform>();
                sprt.anchorMin = Vector2.zero;
                sprt.anchorMax = spAnchorMax;
                sprt.sizeDelta = Vector2.zero;
            }
        }

        // 초기에 채소가 보여지므로, 채소의 개수에 맞게 viewport의 content 크기 초기화
        transform.GetComponent<RectTransform>().sizeDelta =
            new Vector2(transform.GetComponent<RectTransform>().sizeDelta.x,
            Mathf.Round((FarmManager.Instance.crops[0].cropSprites.Length + 0.5f) / 4.0f) * (cellSize.y + tbPadding) + tbPadding);
    }
}
