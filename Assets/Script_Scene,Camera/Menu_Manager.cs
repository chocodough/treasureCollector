using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour {

    GameObject player;
    public Button[] Menubuttons;
    public Image black;
    public Image weapon;
    public Sprite[] weapons;
    public Text a;
    int b = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        a.text = b.ToString();

        b = player.GetComponent<PlayerControl>().CollectedCoin;


            if (player.GetComponent<PlayerControl>().cw == PlayerControl.CurrentWeapon.hand)
                weapon.sprite = weapons[0];

            if (player.GetComponent<PlayerControl>().cw == PlayerControl.CurrentWeapon.sword)
                weapon.sprite = weapons[1];

        if (player.GetComponent<PlayerControl>().cw == PlayerControl.CurrentWeapon.hammer)
            weapon.sprite = weapons[2];


    }

    public void menu()
    {
        Time.timeScale = 0;
        black.enabled = true;
        En_dis_able(Menubuttons, true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        black.enabled = false;
        En_dis_able(Menubuttons, false);
    }

    public void To_Main()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    void En_dis_able(Button[] buttons, bool value)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = value;
            buttons[i].image.enabled = value;
        }
    }
}
