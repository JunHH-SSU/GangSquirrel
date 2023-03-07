using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StaffManager : MonoBehaviour
{
    public SaveManager saveManager;

    public int[] waitStaffCount;
    public int[,] staffCount;
    public float[,] staffMPS; 
    public int[] staffCost;  //스태프 인건비

    //One
    public int DrawStaffGrade;
    public GameObject staffHidePrefabsOne;
    public GameObject[] staffDrawPrefabsOne;

    //Ten
    public int[] DrawTenStaffGrade;
    public GameObject staffHidePrefabsTen;
    public GameObject[] staffDrawPrefabsTen;

    void Awake()
    {
        waitStaffCount = new int[6] { 5, 5, 5, 5, 5, 5 };

        staffCount = new int[3,6] { { 0,0,0,0,0,0}, 
                                    { 0,0,0,0,0,0}, 
                                    { 0,0,0,0,0,0} };

        staffMPS = new float[3,6] { { 1,2,5,8,10,12},
                                     { 2,5,10,15,20,25},
                                     { 0.05f,0.01f,0.5f,0.1f,0.5f,1f} };

        staffCost=new int[6] { 1000, 2000, 4000, 6000, 8000, 10000 };

    }

    void OnEnable()
    {
        waitStaffCount[0] = saveManager.sWaitStaffCount0;
        waitStaffCount[1] = saveManager.sWaitStaffCount1;
        waitStaffCount[2] = saveManager.sWaitStaffCount2;
        waitStaffCount[3] = saveManager.sWaitStaffCount3;
        waitStaffCount[4] = saveManager.sWaitStaffCount4;
        waitStaffCount[5] = saveManager.sWaitStaffCount5;

        staffCount[0, 0] = saveManager.sBatchGunStaffCount0;
        staffCount[0, 1] = saveManager.sBatchGunStaffCount1;
        staffCount[0, 2] = saveManager.sBatchGunStaffCount2;
        staffCount[0, 3] = saveManager.sBatchGunStaffCount3;
        staffCount[0, 4] = saveManager.sBatchGunStaffCount4;

        staffCount[1, 0] = saveManager.sBatchAcornStaffCount0;
        staffCount[1, 1] = saveManager.sBatchAcornStaffCount1;
        staffCount[1, 2] = saveManager.sBatchAcornStaffCount2;
        staffCount[1, 3] = saveManager.sBatchAcornStaffCount3;
        staffCount[1, 4] = saveManager.sBatchAcornStaffCount4;

        staffCount[2, 0] = saveManager.sBatchFameStaffCount0;
        staffCount[2, 1] = saveManager.sBatchFameStaffCount1;
        staffCount[2, 2] = saveManager.sBatchFameStaffCount2;
        staffCount[2, 3] = saveManager.sBatchFameStaffCount3;
        staffCount[2, 4] = saveManager.sBatchFameStaffCount4;
    }

    public void StartDrawStaff(int num)
    {
        if (num == 1)
        {
            staffHidePrefabsOne.SetActive(true);
            staffHidePrefabsOne.transform.DORotate(Vector2.up * 150, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        }
        else
        {
            staffHidePrefabsTen.SetActive(true);
            staffHidePrefabsTen.transform.DORotate(Vector2.up * 150, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        }
       
    }

    public void DrawOpenStaff(int num)
    {
        if (num == 1)
        {
            //Random Staff Open
            int ran = Random.Range(0, 100);
            if (ran < 40)
            {
                DrawStaffGrade = 0;
            }
            else if (ran >= 40 && ran < 65)
            {
                DrawStaffGrade = 1;
            }
            else if (ran >= 65 && ran < 80)
            {
                DrawStaffGrade = 2;
            }
            else if (ran >= 80 && ran < 90)
            {
                DrawStaffGrade = 3;
            }
            else if (ran >= 90 && ran < 97)
            {
                DrawStaffGrade = 4;
            }
            else if (ran >= 97 && ran < 100)
            {
                DrawStaffGrade = 5;
            }

            StartCoroutine("DrawOpenOne");
        }
        else if (num == 10)
        {
            //Random Staff Open X 10
            for(int index = 0; index < 10; index++)
            {
                int ran = Random.Range(0, 100);
                if (ran < 40)
                {
                    DrawTenStaffGrade[index] = 0;
                }
                else if (ran >= 40 && ran < 65)
                {
                    DrawTenStaffGrade[index] = 1;
                }
                else if (ran >= 65 && ran < 80)
                {
                    DrawTenStaffGrade[index] = 2;
                }
                else if (ran >= 80 && ran < 90)
                {
                    DrawTenStaffGrade[index] = 3;
                }
                else if (ran >= 90 && ran < 97)
                {
                    DrawTenStaffGrade[index] = 4;
                }
                else if (ran >= 97 && ran < 100)
                {
                    DrawTenStaffGrade[index] = 5;
                }

                StartCoroutine("DrawOpenTen");
            }
        }
       

       
    }

    IEnumerator DrawOpenOne()
    {
        staffHidePrefabsOne.transform.DOKill(this);
        staffHidePrefabsOne.transform.DORotate(Vector2.up * 400, 0.15f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        yield return new WaitForSeconds(2f);

        staffHidePrefabsOne.transform.DOKill(this);
        staffHidePrefabsOne.SetActive(false);
        staffDrawPrefabsOne[DrawStaffGrade].SetActive(true);

        yield return new WaitForSeconds(0.5f);

    }

    IEnumerator DrawOpenTen()
    {
        staffHidePrefabsTen.transform.DOKill(this);
        staffHidePrefabsTen.transform.DORotate(Vector2.up * 400, 0.15f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        yield return new WaitForSeconds(2f);

        staffHidePrefabsTen.transform.DOKill(this);
        staffHidePrefabsTen.SetActive(false);

        for (int index = 0; index < 10; index++)
        {
            staffDrawPrefabsTen[index*6 + DrawTenStaffGrade[index]].SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);

    }

    public void Recurit(int num)
    {
        if (num == 1)
        {
            staffDrawPrefabsOne[DrawStaffGrade].transform.DOScale(Vector2.zero, 1f).SetEase(Ease.InBack);
            StartCoroutine("DisableImage", -1);
            waitStaffCount[DrawStaffGrade]++;
        }
        else if (num == 10)
        {
            for (int index = 0; index < 10; index++)
            {
                staffDrawPrefabsTen[index * 6 + DrawTenStaffGrade[index]].transform.DOScale(Vector2.zero, 1f).SetEase(Ease.InBack);
                StartCoroutine("DisableImage", index);
                waitStaffCount[DrawTenStaffGrade[index]]++;
            }
          
        }
        
    }

    IEnumerator DisableImage(int index)
    {
        yield return new WaitForSeconds(1.5f);

        if (index == -1)//단차
        {
            staffDrawPrefabsOne[DrawStaffGrade].SetActive(false);
            staffDrawPrefabsOne[DrawStaffGrade].transform.localScale = Vector2.one;
        }
        else //연차
        {
            staffDrawPrefabsTen[index * 6 + DrawTenStaffGrade[index]].SetActive(false);
            staffDrawPrefabsTen[index * 6 + DrawTenStaffGrade[index]].transform.localScale = Vector2.one;
        }
      
    }
}
