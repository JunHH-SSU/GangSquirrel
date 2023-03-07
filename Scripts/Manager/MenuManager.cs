using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject UIGameSet;
    public GameObject UIOptionSet;
    
    public Slider UISliderSfx;
    public Slider UISliderBgm;
    public Button newBtn;
    public Button continueBtn;
    public TMP_Text continueMonthText;
    public GameObject continueBtnEnableGroup;
    public GameObject continueBtnDisableGroup;
    public bool isExistSave;


    void Awake()
    {
        //#.Check Save Data Exist
        isExistSave = PlayerPrefs.HasKey("point");
        Debug.Log(isExistSave);
    }
    public void InitBtnState()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void GameBtnClick()
    {
         UIGameSet.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    public void OptionBtnClick()
    {
        UIOptionSet.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    public void ExitBtnClick()
    {
        if (UIGameSet.transform.localScale == Vector3.one)
        {
            UIGameSet.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack);
        }
        else if(UIOptionSet.transform.localScale == Vector3.one){
            UIOptionSet.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack);
        }
        else
            Application.Quit();
    }

    public void NewBtnClick()
    {
        InitSaveDate();
        Invoke("NextPrologueScene", 0.5f);
    }

    void ContinueBtnEnable(bool value)
    {
        if (value)
        {
            string yearStr= PlayerPrefs.GetInt("year").ToString();
            string monthStr= PlayerPrefs.GetInt("month").ToString("D2");
            continueMonthText.text = yearStr + "." + monthStr;
        }

        continueBtnEnableGroup.SetActive(value);
        continueBtnDisableGroup.SetActive(!value);
        continueBtn.enabled = isExistSave;
    }

    public void ContinueBtnClick()
    {
        Invoke("NextScene", 0.5f);
    }

    void NextPrologueScene()
    {
        SceneManager.LoadScene(1);
    }

    void NextScene()
    {
        SceneManager.LoadScene(2);
    }

    public void SfxSliderChange()
    {
        
    }
    public void BgmSliderChange()
    {
       
    }

    void InitSaveDate()
    {
        //#1.GameManager
        PlayerPrefs.SetInt("year", 2023);
        PlayerPrefs.SetInt("month", 1);
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("curExp", 0);
        PlayerPrefs.SetInt("point", 0);
        PlayerPrefs.SetInt("usedPoint", 0);
        PlayerPrefs.SetInt("gun", 0);
        PlayerPrefs.SetInt("acorn", 0);
        PlayerPrefs.SetInt("fame", 50);
        PlayerPrefs.SetInt("money", 3000000);
        PlayerPrefs.SetInt("gunRate", 3);
        PlayerPrefs.SetInt("acornRate", 1);
        PlayerPrefs.SetInt("acornPrice", 100);
        PlayerPrefs.SetInt("staffCost", 0);
        PlayerPrefs.SetInt("areaCost", 0);
        PlayerPrefs.SetInt("lossCount",0);

        //#2.StaffManager
        PlayerPrefs.SetInt("waitStaffCount0", 5);
        PlayerPrefs.SetInt("waitStaffCount1", 5);
        PlayerPrefs.SetInt("waitStaffCount2", 5);
        PlayerPrefs.SetInt("waitStaffCount3", 5);
        PlayerPrefs.SetInt("waitStaffCount4", 5);
        PlayerPrefs.SetInt("waitStaffCount5", 5);

        PlayerPrefs.SetInt("batchGunStaffCount0", 0);
        PlayerPrefs.SetInt("batchGunStaffCount1", 0);
        PlayerPrefs.SetInt("batchGunStaffCount2", 0);
        PlayerPrefs.SetInt("batchGunStaffCount3", 0);
        PlayerPrefs.SetInt("batchGunStaffCount4", 0);
        PlayerPrefs.SetInt("batchGunStaffCount5", 0);
        PlayerPrefs.SetInt("batchAcornStaffCount0",0);
        PlayerPrefs.SetInt("batchAcornStaffCount1", 0);
        PlayerPrefs.SetInt("batchAcornStaffCount2", 0);
        PlayerPrefs.SetInt("batchAcornStaffCount3", 0);
        PlayerPrefs.SetInt("batchAcornStaffCount4", 0);
        PlayerPrefs.SetInt("batchAcornStaffCount5", 0);
        PlayerPrefs.SetInt("batchFameStaffCount0", 0);
        PlayerPrefs.SetInt("batchFameStaffCount1", 0);
        PlayerPrefs.SetInt("batchFameStaffCount2", 0);
        PlayerPrefs.SetInt("batchFameStaffCount3", 0);
        PlayerPrefs.SetInt("batchFameStaffCount4", 0);
        PlayerPrefs.SetInt("batchFameStaffCount5", 0);

        //#3.SkillManager
        PlayerPrefs.SetInt("skillLevel0", 0);
        PlayerPrefs.SetInt("skillLevel1", 0);
        PlayerPrefs.SetInt("skillLevel2", 0);
        PlayerPrefs.SetInt("skillLevel3", 0);
        PlayerPrefs.SetInt("skillLevel4", 0);
        PlayerPrefs.SetInt("skillLevel5", 0);
        PlayerPrefs.SetInt("skillLevel6", 0);
        PlayerPrefs.SetInt("skillLevel7", 0);
        PlayerPrefs.SetInt("skillLevel8", 0);
        PlayerPrefs.SetInt("skillLevel9", 0);
        PlayerPrefs.SetInt("skillLevel10", 0);
        PlayerPrefs.SetInt("skillLevel11", 0);
        PlayerPrefs.SetInt("skillLevel12", 0);
        PlayerPrefs.SetInt("skillLevel13",0);
        PlayerPrefs.SetInt("skillLevel14", 0);

        //#4.AreaManager
        PlayerPrefs.SetInt("fitModuleGun0",  -1);
        PlayerPrefs.SetInt("fitModuleGun1", -1);
        PlayerPrefs.SetInt("fitModuleGun2",  -1);
        PlayerPrefs.SetInt("fitModuleGun3",  -1);
        PlayerPrefs.SetInt("fitModuleGun4", -1);

        PlayerPrefs.SetInt("fitModuleAcorn0",  -1);
        PlayerPrefs.SetInt("fitModuleAcorn1",  -1);
        PlayerPrefs.SetInt("fitModuleAcorn2",  -1);
        PlayerPrefs.SetInt("fitModuleAcorn3",  -1);
        PlayerPrefs.SetInt("fitModuleAcorn4", -1);

        PlayerPrefs.SetInt("fitModuleFame0",  -1);
        PlayerPrefs.SetInt("fitModuleFame1",  -1);
        PlayerPrefs.SetInt("fitModuleFame2",  -1);
        PlayerPrefs.SetInt("fitModuleFame3",  -1);
        PlayerPrefs.SetInt("fitModuleFame4",  -1);

        PlayerPrefs.SetInt("shopModule0",  -1);
        PlayerPrefs.SetInt("shopModule1", -1);
        PlayerPrefs.SetInt("shopModule2",  -1);
        PlayerPrefs.SetInt("shopModule3",  -1);
        PlayerPrefs.SetInt("shopModule4",  -1);
        PlayerPrefs.SetInt("shopModule5",  -1);

        //#5.LevelManager
        PlayerPrefs.SetInt("clearMission0", 0);
        PlayerPrefs.SetInt("clearMission1", 0);
        PlayerPrefs.SetInt("clearMission2", 0);
        PlayerPrefs.SetInt("clearMission3", 0);
        PlayerPrefs.SetInt("clearMission4", 0);

        PlayerPrefs.Save();
    }
}
