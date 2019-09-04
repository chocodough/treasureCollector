using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{

    public GameObject Player;

    public float distance;
    public float height;
    public float dampTrace = 20.0f;

    private Quaternion v3RotationL = Quaternion.Euler(0f, 45f, 0f);  // 카메라 축을 회전시킬 각도 지정
    private Quaternion v3RotationR = Quaternion.Euler(0f, -45f, 0f);

    private Quaternion makeZ = Quaternion.Euler(0f, -90f, 0f);


    public static Vector3 MainX;
    public static Vector3 MainY;
    public static Vector3 MainZ;   //화면기준 좌표

    private Transform tr;

    public Text ttt;
    public Text tt;
    public Text t;

    bool value = false;

    // Use this for initialization
    void Start()
    {
        MainX = new Vector3(1, 0, 0);
        tr = GetComponent<Transform>();
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MainX = v3RotationL * MainX;  //카메라 왼쪽으로 회전
        }

        else if (Input.GetKeyDown(KeyCode.T))
        {
            MainX = v3RotationR * MainX;  //카메라 오른쪽을 회전
        }

        if (!value)
        {
            MainZ = makeZ * MainX;
            MainY = Vector3.up;


            tr.forward = MainZ;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!value)
        {
            tr.position = Player.GetComponent<Transform>().position + MainZ * -1.0f * distance + MainY * height;
            tr.LookAt(Player.GetComponent<Transform>().position);
        }
    }

    public void Looking_At(Vector3 A, int a)
    {
        Debug.Log(A);
        value = !value;
        if (value)
        {
            if (a == 1)
                ttt.enabled = true;
            else if (a == 2)
                tt.enabled = true;
            else
                t.enabled = true;

            tr.position = new Vector3(A.x - 1.5f, A.y + 1.5f, A.z - 1.5f);
            tr.LookAt(A);
            Invoke("valued", 2.0f);
        }
    }

    void valued()
    {
        t.enabled = false;
        tt.enabled = false;
        ttt.enabled = false;
        value = false;
    }
}
