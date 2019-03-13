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
    Vector2 imageSize;

    void Awake()
    {
        cropSeed = new GameObject[2];
        cropSeed[0] = transform.Find("VegetableSeed").gameObject;
        cropSeed[1] = transform.Find("FruitSeed").gameObject;

        lrPadding = 54;
        tbPadding = 48;
        cellSize = new Vector2(200f, 200f);
        spacing = new Vector2(lrPadding, tbPadding);

        seedSize = 200f;
        imageSize = new Vector2(seedSize, seedSize);
    }

    void Start()
    {
        // Fix grid layout group component to crop seed
        for (int i = 0; i < GameManager.Instance.crops.Length; i++)
        {
            GridLayoutGroup sLayout = cropSeed[i].GetComponent<GridLayoutGroup>();
            sLayout.padding = new RectOffset(lrPadding, lrPadding, tbPadding, tbPadding);
            sLayout.cellSize = cellSize;
            sLayout.spacing = spacing;
        }

        for (int i = 0; i < GameManager.Instance.crops.Length; i++)
        {
            for (int j = 0; j < GameManager.Instance.crops[i].cropSprites.Length; j++)
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
                image.sprite = GameManager.Instance.crops[i].cropSprites[j].sprites[0];
                //image.sprite = GameManager.Instance.crops[i].cropSprites[j];
                // image.sprite = GameManager.Instance.plants[i];
                image.preserveAspect = true;

                // Establish relationship between transforms
                image.transform.SetParent(seed.transform, false);
                seed.transform.SetParent(cropSeed[i].transform, false);

                // Adjust seed transform
                seed.transform.localScale = Vector3.one;

                // Adjust seed image transform
                seedImage.GetComponent<RectTransform>().sizeDelta = imageSize;
            }
        }
    }
}
