using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StageClear_Manager : MonoBehaviour {

    static int Forest = 0;
    static int Lava = 0;

    GameObject player;
    public Button[] Menubuttons;
    public Image black;
    // public Image weapon;
    // public Sprite[] weapons;
    public Text scoretext;
    public Text a;  // 동전개수를 찍어줄 텍스트
    int b = 0;  //동전개수
    float Timer;
    bool value = true;
    public GameObject PauseCanvas;

    void Start()
    {

        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        //a.text = b.ToString();
        a.text = (b * 100 + (300 - (int)Timer)).ToString();

        b = player.GetComponent<PlayerControl>().CollectedCoin;

        if(value)
            Timer += Time.deltaTime;
    }

    void Clear()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
            Forest = 1;

        else
            Lava = 1;

        if (Forest == 1 && Lava == 1)
        {
            Invoke("Ending", 1.5f);
        }

        value = false;
        black.enabled = true;
        PauseCanvas.SetActive(false);
        a.enabled = true;
        scoretext.enabled = true;
        En_dis_able(Menubuttons, true);
    }
   
    public void Ending()
    {
        SceneManager.LoadScene("Ending");
    }

    public void Continue()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene("Lava");

        if (SceneManager.GetActiveScene().buildIndex == 2)
            SceneManager.LoadScene("Forest");

    }

    public void To_Main()
    {
        //Time.timeScale = 1;
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
