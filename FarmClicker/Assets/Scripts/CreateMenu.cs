using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMenu : MonoBehaviour
{
    public Ingredient[] ingredients;
    [Range(1, 20)]
    public int addingFoodCount;

    Transform ingredientsHolder;
    Transform foodCountHolder;

    float ingredientWidth;
    Vector3 ingredientCountPosition;
    Vector2 ingredientCountSize;

    int fontSize;

    Vector3 foodCountPosition;
    Vector2 foodCountSize;

    void Awake()
    {
        ingredientWidth = 150f;
        ingredientCountPosition = new Vector3(0f, 40f, 0f);
        ingredientCountSize = new Vector2(50f, 40f);

        fontSize = 40;

        foodCountPosition = new Vector3(0f, 20f, 0f);
        foodCountSize = new Vector2(50f, 40f);
    }

    void Start()
    {
        // Resize ingredient array
        if (ingredients.Length > 5)
            System.Array.Resize(ref ingredients, 5);

        // Find Ingredients object
        ingredientsHolder = transform.Find("Ingredients");

        for (int i = 0; i < ingredients.Length; i++)
        {
            // Create ingredient
            GameObject ingredient = new GameObject("Ingredient" + (i + 1));
            ingredient.layer = LayerMask.NameToLayer("UI");

            // Add image component to ingredient
            //Image ingredientImage = ingredient.AddComponent<Image>();
            //ingredientImage.sprite = ingredients[i].ingredientImage;
            //ingredientImage.preserveAspect = true;
            Image ingredientImage = ingredient.AddComponent<Image>();
            ingredientImage.sprite = GameManager.Instance.crops[ingredients[i].cropIndex].cropSprites[ingredients[i].ingredientIndex].Sprites[0];
            ingredientImage.preserveAspect = true;

            // Add layout element component to ingredient
            LayoutElement ingredientLayout = ingredient.AddComponent<LayoutElement>();
            ingredientLayout.preferredWidth = ingredientWidth;
            ingredientLayout.preferredHeight = ingredientWidth;

            // Create ingredient count
            GameObject ingredientCount = new GameObject("Text");
            ingredientCount.layer = LayerMask.NameToLayer("UI");

            // Add text component to ingredient count
            Text ingredientText = ingredientCount.AddComponent<Text>();
            ingredientText.text = "x" + (ingredients[i].ingredientCount == 0 ? 1 : ingredients[i].ingredientCount);
            ingredientText.font = GameManager.Instance.mainFont;
            ingredientText.fontSize = fontSize;
            ingredientText.alignment = TextAnchor.MiddleCenter;
            ingredientText.color = Color.black;

            // Establish relationship between transforms
            ingredientCount.transform.SetParent(ingredient.transform, false);
            ingredient.transform.SetParent(ingredientsHolder, false);

            // Adjust ingredient transform
            ingredient.transform.localScale = Vector3.one;
            RectTransform rt = ingredient.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(ingredientWidth, rt.sizeDelta.y);

            // Adjust ingredient count transform
            RectTransform icrt = ingredientCount.GetComponent<RectTransform>();
            icrt.anchorMin = Vector2.right;
            icrt.anchorMax = Vector2.right;
            icrt.anchoredPosition = ingredientCountPosition;
            icrt.sizeDelta = ingredientCountSize;
        }

        // Find FoodBtn object
        foodCountHolder = transform.Find("FoodBtn");

        // Create food count
        GameObject foodCount = new GameObject("Text");
        foodCount.layer = LayerMask.NameToLayer("UI");

        // Add text component to food count
        Text foodText = foodCount.AddComponent<Text>();
        foodText.text = "x" + (addingFoodCount == 0 ? 1 : addingFoodCount);
        foodText.font = GameManager.Instance.mainFont;
        foodText.fontSize = fontSize;
        foodText.alignment = TextAnchor.MiddleCenter;
        foodText.color = Color.black;

        foodCountHolder.GetComponent<AddFood>().AddCount = (addingFoodCount == 0 ? 1 : addingFoodCount);

        // Establish relationship between transforms
        foodCount.transform.SetParent(foodCountHolder, false);

        // Adjust food count transform
        foodText.transform.localScale = Vector3.one;

        RectTransform fcrt = foodCount.GetComponent<RectTransform>();
        fcrt.anchorMin = Vector2.right;
        fcrt.anchorMax = Vector2.right;
        fcrt.anchoredPosition = foodCountPosition;
        fcrt.sizeDelta = foodCountSize;
    }

    [System.Serializable]
    public class Ingredient
    {
        // public Sprite ingredientImage;
        // enum으로 변경하여 inspector 뷰에서 선택할 수 있도록 변경
        public int cropIndex;
        // 범위 제한 방식 연구
        public int ingredientIndex;
        public int ingredientCount;
    }
}
