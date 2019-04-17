using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowPlant : MonoBehaviour
{
    Transform[] plantImage;
    Transform vegetableImage;
    Text test;//

    Transform inventory;

    int category;
    int index;

    enum GrowState { CanGrow, Growing, CanHarvest };
    GrowState[] growState;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);

        plantImage = new Transform[2];
        plantImage[0] = transform.Find("VegetableImage");
        plantImage[1] = transform.Find("FruitImage");
        plantImage[0].GetComponent<Image>().enabled = false;
        plantImage[1].GetComponent<Image>().enabled = false;

        vegetableImage = transform.Find("VegetableImage");
        //vegetableImage = transform.Find("Image");
        vegetableImage.GetComponent<Image>().enabled = false;
        test = GetComponentInChildren<Text>();//

        inventory = GameObject.Find("Canvas").transform.Find("InventoryView").Find("Viewport").Find("Content");

        growState = new GrowState[2];
        growState[0] = GrowState.CanGrow;
        growState[1] = GrowState.CanGrow;
    }

    void ButtonClick()
    {
        // 현재 실제 카테고리를 변경하고 클릭해도 이전 카테고리가 유지되는 방식
        Debug.Log(category);

        if (growState[category] == GrowState.CanGrow) StartCoroutine("Growing");
        else if (growState[category] == GrowState.CanHarvest)
        {
            plantImage[category].GetComponent<Image>().sprite = null;
            plantImage[category].localScale = Vector3.one;
            plantImage[category].transform.position =
                new Vector3(plantImage[category].transform.position.x, 1.1458333333f, plantImage[category].transform.position.z);
            //new Vector3(vegetableImage.transform.position.x, 1100f / Screen.height, vegetableImage.transform.position.z);
            plantImage[category].GetComponent<Image>().enabled = false;

            GameManager.Instance.CropCount[category][index]++;
            // 일정 확률로 대성공(재료가 1개가 아닌 2개가 얻어짐)
            if (Random.Range(1, 100) / 100f < GameManager.Instance.HarvestRatio)
            {
                Debug.Log("수확 대성공!");
                GameManager.Instance.CropCount[category][index]++;
            }
            if (GameManager.Instance.InventoryFlag)
                inventory.transform.GetChild(category).GetChild(index).GetComponentInChildren<Text>().text = "x" + GameManager.Instance.CropCount[category][index];
            growState[category] = GrowState.CanGrow;
        }
    }

    IEnumerator Growing()
    {
        category = GameManager.Instance.Category;
        index = GameManager.Instance.Select[category];
        growState[category] = GrowState.Growing;

        plantImage[category].GetComponent<Image>().enabled = true;
        plantImage[category].GetComponent<Image>().sprite = GameManager.Instance.crops[category].cropSprites[index].Sprites[0];

        test.text = "Grow\n";//
        for (int i = 1; i < GameManager.Instance.crops[category].cropSprites[index].GrowTime; i++)
        {
            test.text += ".";//
            // 크기가 커지는 방식
            plantImage[category].localScale += new Vector3(0.1f, 0.1f, 0.1f);
            plantImage[category].Translate(0.0f, 20f / Screen.height, 0.0f);
            //vegetableImage.Translate(0.0f, 0.0104166667f/*20 / 1920(높이)*/, 0.0f);
            // AccelerationRatio를 이용해 식물이 자라는 속도를 증가시킴
            yield return new WaitForSeconds(GameManager.Instance.GrowSpeed / GameManager.Instance.AccelerationRatio);
        }
        plantImage[category].GetComponent<Image>().sprite = GameManager.Instance.crops[category].cropSprites[index].Sprites[1];
        test.text = "Test";//

        growState[category] = GrowState.CanHarvest;
    }
}
