using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{
    //My name is Brian
    //I am 24 year old
    //I am from korean
    //67114640470 Phattarapon Phaowarit
    public string name;  // Attribute
    public int hp;

    public Character(string n, int hp)  // Constructor
    {
        this.name = n;
        this.hp = hp;
    }
}

public class Gameplay : MonoBehaviour
{
    TextMeshProUGUI playerName;
    Image hpBar;
    Character player;

    void Start()
    {
        // ใช้ field player โดยตรง ไม่สร้างตัวแปรใหม่
        player = new Character("PicoChan", 100);

        playerName = GameObject.Find("PlayerName").GetComponent<TextMeshProUGUI>();
        hpBar = GameObject.Find("HP").GetComponent<Image>();

        playerName.text = player.name;
    }

    void Update()
    {
        // Cast int -> float เพื่อให้ได้ค่า 0.0 ถึง 1.0
        hpBar.fillAmount = (float)player.hp / 100f;
    }
}
