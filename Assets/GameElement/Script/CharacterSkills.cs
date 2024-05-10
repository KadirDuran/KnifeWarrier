using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSkills : MonoBehaviour
{
    int healt = 100;
    int playerHealt = 100;
    int gold = 0;
    public TextMeshProUGUI txtGold,txtKnifePrice,txtSpeedPrice,txtHealt;
    public KnifeCenter knifeCenter;
    public Slider slider;
     void Start()
    {
     knifeCenter = GetComponent<KnifeCenter>();
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
    public void LowHealt()
    {
        slider.value -= 0.05f;
        playerHealt -= 5;
        txtHealt.text = playerHealt.ToString();
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
