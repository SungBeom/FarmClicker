using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFood : MonoBehaviour
{
    public Text foodCount;

    private int addCount;
    public int AddCount
    {
        get { return addCount; }
        set { addCount = value; }
    }

    CreateMenu.Ingredient[] ingredients;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);

        ingredients = transform.parent.gameObject.GetComponent<CreateMenu>().ingredients;
        if (ingredients.Length > 5)
            System.Array.Resize(ref ingredients, 5);
    }

    void ButtonClick()
    {
        if (IsIngredientEnough())
        {
            int count;
            int.TryParse(foodCount.text.Substring(1), out count);

            Cook();

            count += addCount;
            foodCount.text = "x" + count.ToString();
        }
        else
        {
            // 음식을 만들 수 없을 경우
        }
    }

    bool IsIngredientEnough()
    {
        for (int i = 0; i < ingredients.Length; i++)
            if (GameManager.Instance.CropCount[(int)ingredients[i].ingredientCategory][ingredients[i].ingredientIndex]
                < ingredients[i].ingredientCount)
                return false;

        return true;
    }

    void Cook()
    {
        for (int i = 0; i < ingredients.Length; i++)
            GameManager.Instance.CropCount[(int)ingredients[i].ingredientCategory][ingredients[i].ingredientIndex]
                -= ingredients[i].ingredientCount;
    }
}
