using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFood : MonoBehaviour
{
    // 실제 뷰를 가져와 뷰를 바꾸며 실제 데이터를 변경하는 방식
    // 실제 데이터를 변경하고 변경이 될 때, 뷰를 업데이트 하는 방식으로 변경해도 괜찮음
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
            FarmManager.Instance.FoodCount = (ulong)count;
            // 일정 확률로 대성공(고기가 2배로 얻어짐)
            if (Random.Range(1, 100) / 100f < FarmManager.Instance.CookRatio)
            {
                Debug.Log("요리 대성공!");
                count += addCount;
                FarmManager.Instance.FoodCount = (ulong)count;
            }
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
            if (FarmManager.Instance.CropCount[(int)ingredients[i].ingredientCategory][ingredients[i].ingredientIndex]
                < ingredients[i].ingredientCount)
                return false;

        return true;
    }

    void Cook()
    {
        for (int i = 0; i < ingredients.Length; i++)
            FarmManager.Instance.CropCount[(int)ingredients[i].ingredientCategory][ingredients[i].ingredientIndex]
                -= ingredients[i].ingredientCount;
    }
}
