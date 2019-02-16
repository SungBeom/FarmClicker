using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSeed : MonoBehaviour
{
    float seedSize;
    Vector2 imageSize;

    void Awake()
    {
        seedSize = 200f;
        imageSize = new Vector2(seedSize, seedSize);
    }

    void Start()
    {
        for (int i = 0; i < GameManager.Instance.plants.Length; i++)
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
            image.sprite = GameManager.Instance.plants[i];
            image.preserveAspect = true;

            // Establish relationship between transforms
            image.transform.SetParent(seed.transform, false);
            seed.transform.SetParent(transform, false);
            //image.transform.parent = seed.transform;
            //seed.transform.parent = transform;

            // Adjust seed transform
            seed.transform.position += new Vector3(0f, 0f, 90f);
            seed.transform.localScale = Vector3.one;

            // Adjust seed image transform
            seedImage.GetComponent<RectTransform>().sizeDelta = imageSize;
        }
    }
}
