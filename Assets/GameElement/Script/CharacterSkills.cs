using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkills : MonoBehaviour
{
    int healt = 100;
    float playerHealt = 100;
    int gold = 0;
    int puan = 0;
    
    public TextMeshProUGUI txtGold,txtKnifePrice,txtSpeedPrice,slideText,txtLevel;
    public KnifeCenter knifeCenter;
    public Slider slider,sliderPuan;
     void Start()
    {
     knifeCenter = GetComponent<KnifeCenter>();
        PlayerPrefs.SetInt("Level", 0);
        txtLevel.text = "Level : 0"; 
    }
    public void AddPuan(int xp)
    {
        puan += xp;
        slideText.text = puan.ToString();
        sliderPuan.value +=float.Parse((xp/1000.0).ToString());
        if(sliderPuan.value==1)
        {
           sliderPuan.value = 0;
            int level = PlayerPrefs.GetInt("Level") + 1;
            PlayerPrefs.SetInt("Level", level);
            txtLevel.text = "Level : " + level;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Gold")
        {
            gold += 50;
            Destroy(collision.gameObject);
            txtGold.text = gold.ToString();
        }
        else if (collision.gameObject.tag == "BonusKnife")
        {
            Destroy(collision.gameObject);
            knifeCenter.AddKnifes(1);
        }

    }
    public void LowHealt(float damage)
    {
        slider.value -= damage;
        playerHealt -= damage*100;
    }
    public void BuySkil(int skilNo) //SkilNo:1 Speed, SkilNo:2 Knife
    {
        int sP = int.Parse(txtSpeedPrice.text);
        int kP = int.Parse(txtKnifePrice.text);

        if (skilNo == 1 && sP <= gold)
        {
            txtSpeedPrice.text = (sP * 2).ToString();
            gold -= sP;
            knifeCenter.turnSpeed += 0.5f;
        }
        else
        {
            txtSpeedPrice.color = Color.red;
            txtSpeedPrice.color = new Color32(5, 15, 32, 255); 
        }
        if (skilNo == 2 && kP <= gold)
        {
            txtKnifePrice.text = (kP * 2).ToString();
            gold -= kP;
            knifeCenter.AddKnifes(1);
        }
        else
        {
            txtKnifePrice.color = Color.red;
            txtKnifePrice.color = new Color32(5, 15, 32, 255);
        }
        txtGold.text=gold.ToString();
    }
  
}
