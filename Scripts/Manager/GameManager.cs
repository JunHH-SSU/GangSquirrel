using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public StaffManager staffManager;
    public UIManager uiManager;
    public SkillManager skillManager;
    public ObjectManager objectManager;
    public AreaManager areaManager;
    public SaveManager saveManager;

    public Transform player;
    public Animator playerAnim;
    public SpriteRenderer playerSprite;
    public ParticleSystem clickParticle;

    public enum Grade { E, D, C, B, A };
    public enum Type { Gun, Acorn, Fame, Exp };
    public Type curType;

    public float realTimePerMonth;
    public int year;
    public int month;

    public Grade grade;
    public int level;
    public int point;
    public int usedPoint;

    public int curExp;
    public int[] maxExp;

    public int gun;
    public int acorn;
    public int fame;
    public int gunRate;
    public int acornRate;
    public int money;
    public int lossCount;
    public int acornPrice; 

    public int[] clickCount;
    public int[] maxCount;

    public int decrementFame;
    public int decrementTick;

    public float staffMadeGun;
    public float staffMadeAcorn;
    public float staffMadeFame;

    public int staffCost;
    public int areaCost;

    public float time;
    public float timeMPS;

    float animSpeed=1f;
    float delay;

    void Awake()
    {
        GenerateExp();
     }
    void GenerateExp()
    {
        maxExp = new int[99];
        for (int level = 1; level <= 99; level++)
        {
            maxExp[level - 1] = level * Mathf.CeilToInt(level * 0.2f) * 10;
        }

        //#.Last Level Exp Addon
        maxExp[97] += 400;
        maxExp[98] = 0;
    }
    void OnEnable()
    {
        year = saveManager.sYear;
        month=saveManager.sMonth;
        level = saveManager.sLevel;
        curExp = saveManager.sCurExp;
        point = saveManager.sPoint;
        usedPoint = saveManager.sUsedPoint;
        gun = saveManager.sGun;
        acorn = saveManager.sAcorn;
        fame = saveManager.sFame;
        money = saveManager.sMoney;
        gunRate=saveManager.sGunRate;
        acornRate = saveManager.sAcornRate;
        acornPrice = saveManager.sAcornPrice;
        staffCost = saveManager.sStaffCost;
        areaCost = saveManager.sAreaCost;
        lossCount = saveManager.sLossCount;
    }


    void Update()
    {
        TimeFlow();
        StopClick();

    }

    void TimeFlow()
    {
        //#.Date Time Flow
        time += Time.deltaTime;
        timeMPS += Time.deltaTime;

        //#.Ad Decrement Tick
        if (decrementTick !=Mathf.RoundToInt(time / 15))
        {
            decrementTick = Mathf.RoundToInt(time / 15);
            fame = fame - decrementFame < 0 ? 0 : fame - decrementFame;
        }

        //#.Date Over
        if(time >= realTimePerMonth)
        {  //#.Date Flow
            if (month == 12)
            {
                year++;
                month = 1;
            }
            else
            {
                month++;
            }

            //#.Profit Money
            int sellAcorn = Mathf.RoundToInt(acorn * fame * 0.01f);
            money += sellAcorn * acornPrice;

            //#.Cost Money
            staffCost = 0;
            for(int areaIndex = 0; areaIndex < 3; areaIndex++)
            {
                for (int gradeIndex = 0; gradeIndex < 6; gradeIndex++)
                {
                    staffCost += staffManager.staffCount[areaIndex, gradeIndex] * staffManager.staffCost[gradeIndex];
                }
            }

            areaCost = 0;
            for (int areaIndex = 0; areaIndex < 3; areaIndex++)
            {
                for (int moduleIndex = 0; moduleIndex < 5; moduleIndex++)
                {
                    ModuleVo module = areaManager.fitModules[areaIndex, moduleIndex];
                    if(module != null){
                        areaCost += module.adminCost;
                    }
                    
                }
            }

            money -= staffCost + areaCost;
            money = 99999999 < money ? 99999999 : money;

            acorn = acorn-sellAcorn;
            time = 0;
            decrementTick = 0;

            //#.Staff Auto Resource Make
            if (timeMPS >= realTimePerMonth)
            {
                for (int index = 0; index < 6; index++)
                {
                    staffMadeGun += staffManager.staffCount[(int)Type.Gun, index] *
                                staffManager.staffMPS[(int)Type.Gun, index] *
                                skillManager.skillList[5]._func[skillManager.skillList[5]._level];
                    staffMadeAcorn += staffManager.staffCount[(int)Type.Acorn, index] *
                                  staffManager.staffMPS[(int)Type.Acorn, index] *
                                  skillManager.skillList[5]._func[skillManager.skillList[5]._level];
                    staffMadeFame += staffManager.staffCount[(int)Type.Fame, index] *
                                 staffManager.staffMPS[(int)Type.Fame, index] *
                                 skillManager.skillList[5]._func[skillManager.skillList[5]._level];
                }
            }
            //#.Auto Make Summary
            int acornStaffCount = 0;
            for(int index= 0; index < 6; index++)
            {
                acornStaffCount += staffManager.staffCount[(int)Type.Acorn, index];
            }

            //#.리소스 적용
            gun += (int)staffMadeGun;
            fame += (int)staffMadeFame;
            if (gun > acornStaffCount)
            {  //#.도토리 경우 총 소모(스태프 명당 효율 계산)
                acorn += (int)staffMadeAcorn;
                gun -= acornStaffCount;
            }
            //#.UI 적용
            uiManager.ResourceUpdateAnimation("Staff");

            //#. UI Alert (Time Flow)
            uiManager.Alert(UIManager.AlertMsgType.TimeFlow,UIManager.AlertType.Normal);

            //#.광고는 100%를 넘지 않음
            if (fame > 100) fame = 100;

            timeMPS = 0f;

            //#. 적자 확인
            if (money < 0)
            {
                lossCount--;

                //#.UI Alert (Money Loss)
                uiManager.Alert(UIManager.AlertMsgType.MoneyLoss, UIManager.AlertType.Negative);

                if(lossCount == 0)
                {
                    //#.Bad Ending
                    uiManager.BadEnding();
                }
                
            }
            else
            {
                lossCount = 3;
            }

            //#.Staff Auto Resource Init
            staffMadeGun = 0;
            staffMadeAcorn = 0;
            staffMadeFame = 0;

            //#.Auto Save Data
            saveManager.Save();

        }
    }

       

    void StopClick()
    {
        AnimatorStateInfo state = playerAnim.GetCurrentAnimatorStateInfo(0);
        if (state.IsName("Right Idle"))
        {
            delay += Time.deltaTime;
        }
        else
        {
            delay = 0f;
        }

        if (delay > 0.5f)
        {
            animSpeed = 1f;
            playerAnim.speed = animSpeed;
        }
    }
    public void PlayerClick()
    {

        //#1.First Check
        switch (curType)
        {
            case Type.Gun:
                break;
            case Type.Acorn:
                if (gun == 0) return;
                break;
            case Type.Fame:
                if (fame == 100) return;
                break;
        }

        //#2.Click Effect
        animSpeed += (animSpeed > 3f) ? 0f : 0.02f;
        int ran = Random.Range(0, 2);
        if (ran == 1)
        {
            playerSprite.flipX = !playerSprite.flipX;
        }
        playerAnim.SetTrigger("doWork");
        clickParticle.Play();

        //#3.Click Count Increment
        clickCount[(int)curType]++;


        //#4.Make Item
        switch (curType)
        {
            case Type.Gun:
                if (clickCount[(int)curType] == 5)
                {
                    MakeItem();
                    clickCount[(int)curType] = 0;
                }
                break;
            case Type.Acorn:
                if (clickCount[(int)curType] == 10)
                {
                    MakeItem();
                    clickCount[(int)curType] = 0;
                }
                break;
            case Type.Fame:
                if (clickCount[(int)curType] == 10)
                {
                    MakeItem();
                    clickCount[(int)curType] = 0;
                }
                break;
        }

        if (clickCount[(int)curType] == 10)
        {
            MakeItem();
            clickCount[(int)curType] = 0;
        }
    }

       public void MakeItem()
       {
        //#1. Use Gun for Acorn
        if (curType == Type.Acorn)
            gun--;

        bool critical = Random.Range(0, 3) == 0;
        uiManager.ResourceUpdateAnimation("Player");

        //#. Exp HeadUp Display
        GameObject instantExp = objectManager.GetItem(Type.Exp);
        if (instantExp != null)
        {
            instantExp.SetActive(true);
            instantExp.GetComponent<Animator>().SetTrigger("doStart");
            StartCoroutine(DisableExp(instantExp));
        }

        if(level< 99)
        {
            curExp += critical ? 10 : 1;
        }

        //#.Level Up
        if (curExp >= maxExp[level-1])
        {
            level++;
            point++;
            curExp = 0;

            //#. UI Alert (LevelUp)
            uiManager.Alert(UIManager.AlertMsgType.LevelUp, UIManager.AlertType.Positive);
        }


        if (critical)
        {
            for(int index=0;index<10;index++)
            {
                GenerateItem();
                
            }
            player.DOPunchScale(Vector3.one*3f, 0.3f,10,1).SetEase(Ease.OutBack);
        }
        else
        {
            GenerateItem();
        }

       }
    
    void GenerateItem()
    {
        //#.생산품 오브젝트 풀링 사용
        GameObject instantItem = objectManager.GetItem(curType);
        instantItem.transform.position = player.position;
        instantItem.SetActive(true);
      
        Rigidbody2D itemRigid = instantItem.GetComponent<Rigidbody2D>();
        Vector2 popVector = new Vector2(Random.Range(-4f, 6f), Random.Range(7f, 15f));
        itemRigid.AddForce(popVector, ForceMode2D.Impulse);

        switch (curType)
        {
            case Type.Gun:
                gun++;
                gun = 99999999 < gun ? 99999999 : gun;
                break;
            case Type.Acorn:
                acorn+=2;
                acorn = 99999999 < acorn ? 99999999 : acorn;
                break;
            case Type.Fame:
                fame++;
                fame=100 < fame ? 100 : fame;
                break;
        }

    }

    IEnumerator DisableExp(GameObject exp)
    {
        yield return new WaitForSeconds(3f);

        exp.SetActive(false);
    }


}
