using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public AudioSource PlayerSound;
    public AudioClip JumpSound;
    public AudioClip CoinSound;
    public AudioClip DieSound;
    public AudioClip BoxopenSound;
    public AudioClip TreasureSound;
    public AudioClip CollectSound;
    public AudioClip SwingSound;

    public ParticleSystem RunDust;
    public GameObject Weapon;
    public GameObject[] Inventory;
    public GameObject[] RevivePoints;
    public GameObject RevivePosition; //부활 위치
    public int CollectedCoin = 0;
    public bool Clear = false;
    public GameObject StageClearManager;

    public enum PlayerState 
    {
        idle = 0,
        walk ,
        run ,
        jump,
        dead,
        attack,
        hammerattack,
        fall
    }   
    public PlayerState ps = PlayerState.idle;  // 플레이어의 상태 변수

    public enum CurrentWeapon
    {
        hand,
        sword,
        hammer
    }

    public CurrentWeapon cw = CurrentWeapon.hand;  // 현재 무기 변수


    public bool GetSword = false;
    public bool GetHammer = false;  //새 무기들을 얻었는지 확인

    public Animator PlayerAC;

    public float h;
    public float v;
    public bool IsOnGround;  //지면 위에 있는지 확인
    public Quaternion direction;  //플레이어의 방향


    // Use this for initialization
    void Start () {
        Inventory[0].SetActive(true);
        Inventory[1].SetActive(false);
        Inventory[2].SetActive(false);
        Weapon = Inventory[0];

        RunDust.enableEmission = false;
        
    }

    void OnTriggerEnter(Collider col)
    {
        IsOnGround = true;
        PlayerAC.SetBool("IsJumping", false);
        PlayerAC.SetBool("IsFalling", false);

    }

    void OnTriggerStay(Collider col)
    {
            IsOnGround = true;
            PlayerAC.SetBool("IsJumping", false);
            PlayerAC.SetBool("IsFalling", false);
    }

    void OnTriggerExit(Collider col)
    {
            IsOnGround = false;
    }

    // Update is called once per frame
    void Update () {

        if(Clear)
        {
            StageClearManager.SendMessage("Clear");
        }

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (h != 0 || v != 0)
            PlayerAC.SetBool("IsMoving", true);
        else
            PlayerAC.SetBool("IsMoving", false);

        if (Input.GetKey(KeyCode.LeftShift))
            PlayerAC.SetBool("LSisDown",true);
        else
            PlayerAC.SetBool("LSisDown", false);    // Shift 눌려있음 확인




        if (Input.GetKeyDown(KeyCode.Space))  //점프
        {
            if (IsOnGround)
            {

                if (!PlayerAC.GetBool("IsAttacking")&&!PlayerAC.GetBool("IsJumping")&&!PlayerAC.GetBool("IsDead"))
                {
                    PlayerSound.clip = JumpSound;
                    PlayerAC.SetBool("StartJump", true);
                    GetComponent<Rigidbody>().AddForce(0, 170, 0);
                    PlayerSound.Play();
                    
                }
            }
        }

        if (!IsOnGround && GetComponent<Rigidbody>().velocity.y < -1.5f && !PlayerAC.GetBool("IsFalling") && !PlayerAC.GetBool("IsJumping")) //추락 시작 
            PlayerAC.SetBool("StartFall", true);

        if (Input.GetKeyDown(KeyCode.Y))  // 죽음
        {            
            PlayerAC.SetBool("LifeIs0", true);
        }
        if (Input.GetKeyDown(KeyCode.H))  //부활
        {            
            PlayerAC.SetBool("Healed", true);
            PlayerAC.SetBool("LifeIs0", false);

        }

        if (Input.GetKeyDown(KeyCode.LeftControl))  // 공격
        {
            CheckingWeapon();
            if(ps == PlayerState.idle || ps == PlayerState.run || ps == PlayerState.walk)
                PlayerAC.SetBool("StartAttack", true);        

        }

        if(Input.GetKeyDown(KeyCode.G))  //무기교체
        {
            WeaponChange();
        }

        if (v !=0 || h != 0)
             direction = Quaternion.LookRotation(h * CameraControl.MainX + v*CameraControl.MainZ);   //방향 지정

       

    }

    void FixedUpdate()
    {

        if (PlayerAC.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Walk"))
            ps = PlayerState.walk;
        else if (PlayerAC.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Run"))
            ps = PlayerState.run;
        else if (PlayerAC.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Idle"))
            ps = PlayerState.idle;
        else if (PlayerAC.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Jump"))
            ps = PlayerState.jump;
        else if (PlayerAC.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Dead"))
            ps = PlayerState.dead;
        else if (PlayerAC.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Attack"))
            ps = PlayerState.attack;
        else if (PlayerAC.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Fall"))
            ps = PlayerState.fall;
        else if (PlayerAC.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.HammerAttack"))
            ps = PlayerState.hammerattack;

        switch (ps)
        {
            case PlayerState.walk:
                transform.rotation = direction;
                transform.Translate(Vector3.forward * 1f * Time.deltaTime);
              
                break;
            case PlayerState.run:
                transform.rotation = direction;
                transform.Translate(Vector3.forward * 2f * Time.deltaTime);
               

                break;
            case PlayerState.idle:
                PlayerAC.SetBool("IsReviving", false);
                PlayerAC.SetBool("Healed", false);
                PlayerAC.SetBool("IsDead", false);
               
                
                break;
            case PlayerState.jump:
                
              
                PlayerAC.SetBool("IsJumping", true);
                PlayerAC.SetBool("StartJump", false);

                if (PlayerAC.GetBool("IsMoving"))
                {                    
                        transform.rotation = direction;
                        transform.Translate(Vector3.forward * 1.5f * Time.deltaTime);                    
                }

                break;
            case PlayerState.dead:
                PlayerAC.SetBool("IsDead", true);
                break;
            case PlayerState.attack:
                
                break;
            case PlayerState.hammerattack:

                break;
            case PlayerState.fall:
               
                break;
            default:
                break;
        }
    }

    void WeaponChange() // 현재 무기 교체
    {        
        
        
        if (cw == CurrentWeapon.hand)
        {
            if (GetSword)
                cw = CurrentWeapon.sword;
            else if (GetHammer)
                cw = CurrentWeapon.hammer;
        }

        else if (cw == CurrentWeapon.sword)
        {
            if (GetHammer)
                cw = CurrentWeapon.hammer;
            else
                cw = CurrentWeapon.hand;
        }
        else if (cw == CurrentWeapon.hammer)
        {
            cw = CurrentWeapon.hand;
        }



        if (cw == CurrentWeapon.hand)
        {
            Inventory[0].SetActive(true);
            Inventory[1].SetActive(false);
            Inventory[2].SetActive(false);
            Weapon = Inventory[0];
        }
        if (cw == CurrentWeapon.sword)
        {
            Inventory[0].SetActive(false);
            Inventory[1].SetActive(true);
            Inventory[2].SetActive(false);
            Weapon = Inventory[1];
        }
        
        if (cw == CurrentWeapon.hammer)
        {
            Inventory[0].SetActive(false);
            Inventory[1].SetActive(false);
            Inventory[2].SetActive(true);
            Weapon = Inventory[2];
        }
        

        
        Debug.Log(cw);
    }


    void CheckingWeapon()
    {
        if(cw == CurrentWeapon.hand)
        {
            PlayerAC.SetInteger("CurrentWeapon", 0);
        }
        if (cw == CurrentWeapon.sword)
        {
            PlayerAC.SetInteger("CurrentWeapon", 1);
        }
        if (cw == CurrentWeapon.hammer)
        {
            PlayerAC.SetInteger("CurrentWeapon", 2);
        }
    }
}
