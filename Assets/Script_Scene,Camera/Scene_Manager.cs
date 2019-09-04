using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour {

    //public Text tuto;
   
    public Button[] Mainbuttons;
    public Button[] Stagebuttons;
    
    public Button Returnbutton;
    
	public void startgame()
    {
       // tuto.enabled = false;
        En_dis_able(Stagebuttons, true);
        En_dis_able(Mainbuttons, false);
        En_dis_able(Returnbutton, true);
        //En_dis_able(YesNo, false);
    }


    public void To_Main()
    {
       // tuto.enabled = false;
        //Story.enabled = false;
        En_dis_able(Returnbutton, false);
        En_dis_able(Mainbuttons, true);
        En_dis_able(Stagebuttons, false);
        //En_dis_able(YesNo, false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    

    
    public void Stage1()
    {
        SceneManager.LoadScene("Forest");
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Lava");
    }

    public void Stage3()
    {
        SceneManager.LoadScene("forest3");
    }

    void En_dis_able(Button[] buttons, bool value)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = value;
            buttons[i].image.enabled = value;
        }
    }

    void En_dis_able(Button buttons, bool value)
    {
            buttons.enabled = value;
            buttons.image.enabled = value;
    }
}
