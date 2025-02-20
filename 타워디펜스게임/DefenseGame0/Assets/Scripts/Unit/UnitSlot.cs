using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UnitSlot : MonoBehaviour
{

    public Sprite unitSprite; // 유닛 이미지

    public GameObject unitObject; // 유닛 객체

    public Image icon; // 유닛 이미지

    public int costco;

    public TextMeshProUGUI costText;

    // GameManager 스크립트
    private TileManager tileManager;

    // UnitStat 스크립트
    private UnitStat unitStat;

    public Cost Cost;

    private void Start()
    {
        tileManager =
            GameObject.Find("TileManager").GetComponent<TileManager>();
        
            GetComponent<Button>().onClick.AddListener(BuyUnit);

    }

    // 유닛 구매
    public void BuyUnit()
    {
        tileManager.BuyUnit(unitObject, unitSprite);
        Cost.totalCost -= costco;
    }




    public void OnValidate()
    {
        

        if(unitSprite) // Sprite가 있다면
        {
            icon.enabled = true;
            icon.sprite = unitSprite;
            costText.text = costco.ToString();
        }
        else
        {
            icon.enabled = false;
        }
    }


    public void SetUnitStat(UnitStat unitStat)
    {
        this.unitStat = unitStat;
    }

    
}
