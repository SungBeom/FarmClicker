using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSeed : MonoBehaviour
{
    GameObject vegetableSeed;
    GameObject fruitSeed;

    int lrPadding, tbPadding;
    Vector2 cellSize, spacing;

    float seedSize;
    Vector2 imageSize;

    void Awake()
    {
        vegetableSeed = transform.Find("VegetableSeed").gameObject;
        fruitSeed = transform.Find("FruitSeed").gameObject;

        lrPadding = 54;
        tbPadding = 48;
        cellSize = new Vector2(200f, 200f);
        spacing = new Vector2(lrPadding, tbPadding);

        seedSize = 200f;
        imageSize = new Vector2(seedSize, seedSize);
    }

    void Start()
    {
        //// Create vegetable seed
        //vegetableSeed = new GameObject("VegetableSeed");
        //vegetableSeed.layer = LayerMask.NameToLayer("UI");

        //// Add rect transform component to vegetable seed
        //RectTransform vsrt = vegetableSeed.AddComponent<RectTransform>();
        //vsrt.offsetMin = Vector2.zero;
        //vsrt.offsetMax = Vector2.zero;
        //vsrt.anchorMin = Vector2.zero;
        //vsrt.anchorMax = Vector2.one;

        //// Add grid layout group component to vegetable seed
        //GridLayoutGroup vsLayout = vegetableSeed.AddComponent<GridLayoutGroup>();
        //vsLayout.padding = new RectOffset(lrPadding, lrPadding, tbPadding, tbPadding);
        //vsLayout.cellSize = cellSize;
        //vsLayout.spacing = spacing;

        // Fix grid layout group component to vegetable seed
        GridLayoutGroup vsLayout = vegetableSeed.GetComponent<GridLayoutGroup>();
        vsLayout.padding = new RectOffset(lrPadding, lrPadding, tbPadding, tbPadding);
        vsLayout.cellSize = cellSize;
        vsLayout.spacing = spacing;

        //// Create fruit seed
        //fruitSeed = new GameObject("FruitSeed");
        //fruitSeed.layer = LayerMask.NameToLayer("UI");

        //// Add rect transform component to fruit seed
        //RectTransform fsrt = fruitSeed.AddComponent<RectTransform>();
        //fsrt.offsetMin = Vector2.zero;
        //fsrt.offsetMax = Vector2.zero;
        //fsrt.anchorMin = Vector2.zero;
        //fsrt.anchorMax = Vector2.one;

        //// Add grid layout group component to fruit seed
        //GridLayoutGroup fsLayout = fruitSeed.AddComponent<GridLayoutGroup>();
        //fsLayout.padding = new RectOffset(lrPadding, lrPadding, tbPadding, tbPadding);
        //fsLayout.cellSize = cellSize;
        //fsLayout.spacing = spacing;

        // Fix grid layout group component to fruit seed
        GridLayoutGroup fsLayout = fruitSeed.GetComponent<GridLayoutGroup>();
        fsLayout.padding = new RectOffset(lrPadding, lrPadding, tbPadding, tbPadding);
        fsLayout.cellSize = cellSize;
        fsLayout.spacing = spacing;

        for (int i = 0; i < GameManager.Instance.crops[0].cropSprites.Length; i++)
        {
            // Create seed
            GameObject seed = new GameObject("SeedBtn" + (i + 1));
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
            SelectVegetable sv = seed.AddComponent<SelectVegetable>();
            sv.PlantIndex = i;

            // Create seed image
            GameObject seedImage = new GameObject("Image");
            seedImage.layer = LayerMask.NameToLayer("UI");

            // Add image component to seed image
            Image image = seedImage.AddComponent<Image>();
            image.sprite = GameManager.Instance.crops[0].cropSprites[i];
            // image.sprite = GameManager.Instance.plants[i];
            image.preserveAspect = true;

            // Establish relationship between transforms
            image.transform.SetParent(seed.transform, false);
            seed.transform.SetParent(vegetableSeed.transform, false);

            // Adjust seed transform
            seed.transform.localScale = Vector3.one;

            // Adjust seed image transform
            seedImage.GetComponent<RectTransform>().sizeDelta = imageSize;
        }

        for (int i = 0; i < GameManager.Instance.crops[1].cropSprites.Length; i++)
        {
            // Create seed
            GameObject seed = new GameObject("SeedBtn" + (i + 1));
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
            SelectVegetable sv = seed.AddComponent<SelectVegetable>();
            sv.PlantIndex = i;

            // Create seed image
            GameObject seedImage = new GameObject("Image");
            seedImage.layer = LayerMask.NameToLayer("UI");

            // Add image component to seed image
            Image image = seedImage.AddComponent<Image>();
            image.sprite = GameManager.Instance.crops[1].cropSprites[i];
            // image.sprite = GameManager.Instance.plants[i];
            image.preserveAspect = true;

            // Establish relationship between transforms
            image.transform.SetParent(seed.transform, false);
            seed.transform.SetParent(fruitSeed.transform, false);

            // Adjust seed transform
            seed.transform.localScale = Vector3.one;

            // Adjust seed image transform
            seedImage.GetComponent<RectTransform>().sizeDelta = imageSize;
        }

        //for (int i = 0; i < GameManager.Instance.plants.Length; i++)
        //{
        //    // Create seed
        //    GameObject seed = new GameObject("SeedBtn" + (i + 1));
        //    seed.layer = LayerMask.NameToLayer("UI");

        //    // Add image component to seed
        //    Image backgroundImage = seed.AddComponent<Image>();

        //    // Add button component to seed
        //    Button seedBtn = seed.AddComponent<Button>();

        //    // Add layout element component to seed
        //    LayoutElement seedLayout = seed.AddComponent<LayoutElement>();
        //    seedLayout.preferredWidth = seedSize;
        //    seedLayout.preferredHeight = seedSize;

        //    // Add select vegetable script to seed
        //    SelectVegetable sv = seed.AddComponent<SelectVegetable>();
        //    sv.PlantIndex = i;

        //    // Create seed image
        //    GameObject seedImage = new GameObject("Image");
        //    seedImage.layer = LayerMask.NameToLayer("UI");

        //    // Add image component to seed image
        //    Image image = seedImage.AddComponent<Image>();
        //    image.sprite = GameManager.Instance.plants[i];
        //    image.preserveAspect = true;

        //    // Establish relationship between transforms
        //    image.transform.SetParent(seed.transform, false);
        //    seed.transform.SetParent(transform, false);

        //    // Adjust seed transform
        //    seed.transform.localScale = Vector3.one;

        //    // Adjust seed image transform
        //    seedImage.GetComponent<RectTransform>().sizeDelta = imageSize;
        //}
    }
}
