using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public StaffManager staffManager;
    public SkillManager skillManager;
    public AreaManager areaManager;
    public LevelManager levelManager;

    public RectTransform leftHeadUpSet;
    public RectTransform rightHeadUpSet;

    public enum AlertMsgType { TimeFlow, LevelUp, MoneyLoss };
    public enum AlertType { Positive, Normal, Negative };
    public RectTransform alertSet;
    public Image alertBackground;
    public Image alertImage;
    public TMP_Text alertText;
    public Sprite[] alertSprites;

    public Sprite[] gradeSprites;
    public Image gradeImage;
    public Image dateImage;
    public TMP_Text dateText;
    public TMP_Text levelText;
    public TMP_Text curExpText;
    public TMP_Text maxExpText;
    public TMP_Text pointText;
    public RectTransform expPanel;

    public TMP_Text gunText;
    public TMP_Text acornText;
    public TMP_Text fameText;
    public TMP_Text moneyText;
    public TMP_Text placeText;

    public Color GunColor;
    public Color AcornColor;
    public Color FameColor;

    public TMP_Text WaitStaff0Text;
    public TMP_Text WaitStaff1Text;
    public TMP_Text WaitStaff2Text;
    public TMP_Text WaitStaff3Text;
    public TMP_Text WaitStaff4Text;
    public TMP_Text WaitStaff5Text;

    public TMP_Text staff0Text;
    public TMP_Text staff1Text;
    public TMP_Text staff2Text;
    public TMP_Text staff3Text;
    public TMP_Text staff4Text;
    public TMP_Text staff5Text;

    public string[] placeNames;
    public Sprite[] placeIcons;
    public Color[] placeColors;
    public Image staffPlaceIcon;
    public Image staffPlaceBackground;
    public RectTransform staffCostPanel;
    public TMP_Text staffCostText;

    public RectTransform staffSet;
    public GameObject staffPlacePanel;
    public GameObject staffDrawPanel;
    public Button staffPlaceBtn;
    public Button staffDrawBtn;
    public Button staffDrawOpenBtn;
    public Button staffTenDrawOpenBtn;
    public Button staffRecuritBtn;
    public Button staffRecuritTenBtn;
    public Image staffFadeBlack;
    public Image fadeBlack;

    public TMP_Text[] ResourceStaffMadeText;
    public RectTransform ResourceStaffMadeSet;

    public RectTransform skillSet;
    public GameObject skillActivityPanel;
    public GameObject skillCompanyPanel;
    public GameObject skillEconomyPanel;
    public Button skillActivityBtn;
    public Button skillCompanyBtn;
    public Button skillEconomyBtn;

    public Image[] skillTreeIcons;
    public TMP_Text[] skillTreeLevel;

    public Image skillDescIcon;
    public RectTransform skillDescGroup;
    public TMP_Text skillDescName;
    public TMP_Text skillDescLevel;
    public TMP_Text skillDescPoint;
    public TMP_Text skillDescFunc;
    public TMP_Text skillDescContent;
    public RectTransform skillUpBtn;

    public RectTransform areaSet;
    public RectTransform areaScrollView;
    public Image[] areaModulesBackground;
    public GameObject[] areaModulesGroup;
    public GameObject[] areaModulesLockGroup;
    public RectTransform areaCostPanel;
    public TMP_Text areaCostText;

    public GameObject[] shopModules;
    public Button RefreshBtn;
    // public ColorBlock disableRefreshColors;
    // public ColorBlock enableRefreshColors;
    public ModuleVo[] shopModulesData;
    public Button[] buyBtns;
    public int selectModuleIndex;
    public RectTransform controlBtnGroup;
    public Button changeBtn;
    public Button removeBtn;

    public RectTransform levelSet;
    public Image nextGradeImg;
    public Sprite[] checkSprites;
    public Image[] checkImages;
    public TMP_Text[] missionTexts;
    public GameObject levelMissionPanel;
    public GameObject levelStatusPanel;
    public GameObject levelMissionBtn;
    public GameObject levelStatusBtn;
    public TMP_Text infoExchangeGunText;
    public TMP_Text infoExchangeAcornText;
    public TMP_Text infoAcornPriceText;
    public TMP_Text infoTotalCostText;
    public TMP_Text[] infoClickCount;
    public TMP_Text[] infoCriRate;
    public TMP_Text[] infoExp;
    public TMP_Text[] infoStaffAutoMake;

    public Image fadeWhite;
    public RectTransform endingSet;
    public RectTransform badEndText;
    public RectTransform badEndImage;
    public RectTransform badEndBtn;

    int preLevel;
    int prevDate;
    int prevGun;
    int prevAcorn;
    int prevFame;
    int prevMoney;


    void Start()
    {
        //#0. Display HeadUp UI
        UIDisplay("Left", true);
        UIDisplay("Right", true);
        UIDisplay("Staff", true);
        UIDisplay("Skill", true);
        UIDisplay("Area", true);
        UIDisplay("Level", true);

        //#.Batch Staff Update for Save Data
        BatchWorkStaff();

        //#. Skill Update for Save Data
        SkillInfoUpdate();

        //#.Module Shop Update for Save Data
       if (!areaManager.isInitShop)
        {
           areaManager.RefreshShop();
        }

        //#.Shop Module Update for Save Data
        FitModuleUpdate();

        //#. Level Tab UI Init
        UpdateMission();
    }


    void LateUpdate()
    {
        //0.Level UI
        levelText.text = gameManager.level.ToString();
        if (preLevel != gameManager.level)
        {
            levelText.transform.DOKill(this);
            levelText.transform.localScale = Vector3.one;
            levelText.transform.DOPunchScale(Vector3.one, 0.4f, 10, 0.2f).SetEase(Ease.OutQuad);

        }
        curExpText.text = gameManager.curExp.ToString();
        maxExpText.text = gameManager.maxExp[gameManager.level - 1].ToString();

        pointText.text = (gameManager.point - gameManager.usedPoint).ToString();

        //#1.Date UI
        dateImage.fillAmount = gameManager.time / gameManager.realTimePerMonth;
        dateText.text = gameManager.year + "." + string.Format("{0:d2}", gameManager.month);

        if (prevDate != gameManager.year * 10 + gameManager.month)
        {
            dateText.transform.DOKill(this);
            dateText.transform.localScale = Vector3.one;
            dateText.transform.DOPunchScale(Vector3.one, 0.2f, 10, 0.2f).SetEase(Ease.OutQuad);
        }

        //#2.Gun UI
        if (gameManager.gun > 10000)
        {
            gunText.text = string.Format("{0:n0}", gameManager.gun / 1000) + "k";
        }
        else
        {
            gunText.text = string.Format("{0:n0}", gameManager.gun);
        }


        //#3.Acorn UI
        if (gameManager.acorn > 10000)
        {
            acornText.text = string.Format("{0:n0}", gameManager.acorn / 1000) + "k";
        }
        else
        {
            acornText.text = string.Format("{0:n0}", gameManager.acorn);

        }

        //#4.Fame UI
        fameText.text = gameManager.fame + "%";


        //#5.Money UI
        moneyText.text = string.Format("{0:n0}", gameManager.money);

        if (prevMoney != gameManager.money)
        {
            moneyText.transform.DOKill(this);
            moneyText.transform.localScale = Vector3.one;
            moneyText.transform.DOPunchScale(Vector3.one, 0.2f, 10, 0.2f).SetEase(Ease.OutQuad);
        }

        //#.PrevDate Save For Animation
        preLevel = gameManager.level;
        prevDate = gameManager.year * 10 + gameManager.month;
        prevGun = gameManager.gun;
        prevAcorn = gameManager.acorn;
        prevFame = gameManager.fame;
        prevMoney = gameManager.money;

        //#.Staff UI
        WaitStaff0Text.text = string.Format("{0:n0}", staffManager.waitStaffCount[0]);
        WaitStaff1Text.text = string.Format("{0:n0}", staffManager.waitStaffCount[1]);
        WaitStaff2Text.text = string.Format("{0:n0}", staffManager.waitStaffCount[2]);
        WaitStaff3Text.text = string.Format("{0:n0}", staffManager.waitStaffCount[3]);
        WaitStaff4Text.text = string.Format("{0:n0}", staffManager.waitStaffCount[4]);
        WaitStaff5Text.text = string.Format("{0:n0}", staffManager.waitStaffCount[5]);

        int placeIndex = (int)gameManager.curType;
        staff0Text.text = string.Format("{0:n0}", staffManager.staffCount[placeIndex, 0]);
        staff1Text.text = string.Format("{0:n0}", staffManager.staffCount[placeIndex, 1]);
        staff2Text.text = string.Format("{0:n0}", staffManager.staffCount[placeIndex, 2]);
        staff3Text.text = string.Format("{0:n0}", staffManager.staffCount[placeIndex, 3]);
        staff4Text.text = string.Format("{0:n0}", staffManager.staffCount[placeIndex, 4]);
        staff5Text.text = string.Format("{0:n0}", staffManager.staffCount[placeIndex, 5]);

        BatchWorkStaff();
        staffPlaceIcon.sprite = placeIcons[placeIndex];
        staffPlaceBackground.sprite = placeIcons[placeIndex];


        //#.Area UI Part
        //RefreshBtn.colors = (gameManager.money >= 1000) ? enableRefreshColors : disableRefreshColors;

        if (shopModulesData != null)
        {
            for (int index = 0; index < 7; index++)
            {
                if (buyBtns[index].gameObject.activeSelf && shopModulesData[index] != null)
                {
                    
                    buyBtns[index].interactable = gameManager.money >= shopModulesData[index].buyCost;
                }
            }
        }

        //#.Mission UI Part
        for (int index = 0; index < 5; index++)
        {
            checkImages[index].sprite = checkSprites[levelManager.clearMission[index] ? 1 : 0];
        }
    }


    public void InitBtnState()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void UIDisplay(string dir, bool isDisplay)
    {
        if (dir == "Left")
        {
            leftHeadUpSet.DOKill(this);
            leftHeadUpSet.DOAnchorPosX(isDisplay ? 220 : -250, 0.5f).SetEase(Ease.OutQuad);
        }
        else if (dir == "Right")
        {
            rightHeadUpSet.DOKill(this);
            rightHeadUpSet.DOAnchorPosX(isDisplay ? -220 : 250, 0.5f).SetEase(Ease.OutQuad);
        }
        /*
        else if (dir == "Staff")
        {
            staffSet.DOKill(this);
            staffSet.DOAnchorPosY(isDisplay ? -740 : -850, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.5f);
        }
        else if (dir == "Skill")
        {
            skillSet.DOKill(this);
            skillSet.DOAnchorPosY(isDisplay ? -740 : -850, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.55f);
        }
        else if (dir == "Area")
        {
            areaSet.DOKill(this);
            areaSet.DOAnchorPosY(isDisplay ? -740 : -850, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.6f);
        }
        else if (dir == "Level")
        {
            levelSet.DOKill(this);
            levelSet.DOAnchorPosY(isDisplay ? -740 : -850, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.65f);
        }
        */
    }

    public void TypeBtnClick(string dir)
    {
        if (dir == "Right" && (int)gameManager.curType < 2)
        {
            gameManager.curType++;
            //gameManager.clickCount = 0;
        }
        else if (dir == "Left" && (int)gameManager.curType > 0)
        {
            gameManager.curType--;
            //gameManager.clickCount = 0;
        }

        switch (gameManager.curType)
        {
            case GameManager.Type.Gun:
                Camera.main.DOColor(GunColor, 0.5f);
                placeText.text = "갱 단";
                break;
            case GameManager.Type.Acorn:
                Camera.main.DOColor(AcornColor, 0.5f);
                placeText.text = "단 련";
                break;
            case GameManager.Type.Fame:
                Camera.main.DOColor(FameColor, 0.5f);
                placeText.text = "사 회";
                break;
        }

        //#.Place Batch Staff Update
        BatchWorkStaff();

        //#.Area Tab Reset
        ModuleShopBackBtnClick();

        //#.Area Fit Module Update
        FitModuleUpdate();
    }

    public void PanelBtn(string panelName)
    {
        if (panelName == "Staff")
        {
            if (staffSet.localPosition.y == -740)
            {
                staffSet.DOLocalMoveY(-84, 0.5f).SetEase(Ease.OutBack);
                staffCostPanel.DOKill(this);
                staffCostPanel.DOLocalMoveY(240, 0.25f).SetEase(Ease.OutBack);

                //#.Other UI Set Hide
                if (skillSet.localPosition.y > -740)
                {
                    skillSet.DOKill(this);
                    skillSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);

                    //#.Select Skill Remove
                    RemoveSelectedSkill();
                }
                else if (areaSet.localPosition.y > -740)
                {
                    areaSet.DOKill(this);
                    areaSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                    areaCostPanel.DOKill(this);
                    areaCostPanel.DOLocalMoveY(123, 0.25f).SetEase(Ease.InBack);
                }
                else if (levelSet.localPosition.y > -740)
                {
                    levelSet.DOKill(this);
                    levelSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                }
            }
            else if (staffSet.localPosition.y == -84)
            {
                staffSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                staffCostPanel.DOKill(this);
                staffCostPanel.DOLocalMoveY(123, 0.25f).SetEase(Ease.InBack);
            }
        }
        else if (panelName == "Skill")
        {
            if (skillSet.localPosition.y == -740)
            {
                skillSet.DOLocalMoveY(-84, 0.5f).SetEase(Ease.OutBack);

                //#.Other UI Set Hide
                if (staffSet.localPosition.y > -740)
                {
                    staffSet.DOKill(this);
                    staffSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                    staffCostPanel.DOKill(this);
                    staffCostPanel.DOLocalMoveY(123, 0.25f).SetEase(Ease.InBack);
                }
                else if (areaSet.localPosition.y > -740)
                {
                    areaSet.DOKill(this);
                    areaSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                    areaCostPanel.DOKill(this);
                    areaCostPanel.DOLocalMoveY(123, 0.25f).SetEase(Ease.InBack);
                }
                else if (levelSet.localPosition.y > -740)
                {
                    levelSet.DOKill(this);
                    levelSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                }
            }
            else if (skillSet.localPosition.y == -84)
            {
                skillSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);

                //#.Select Skill Remove
                RemoveSelectedSkill();
            }
        }
        else if (panelName == "Area")
        {
            if (areaSet.localPosition.y == -740)
            {
                areaSet.DOLocalMoveY(-84, 0.5f).SetEase(Ease.OutBack);
                areaCostPanel.DOKill(this);
                areaCostPanel.DOLocalMoveY(240, 0.25f).SetEase(Ease.OutBack);

                //#.Other UI Set Hide
                if (staffSet.localPosition.y > -740)
                {
                    staffSet.DOKill(this);
                    staffSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                    staffCostPanel.DOKill(this);
                    staffCostPanel.DOLocalMoveY(123, 0.25f).SetEase(Ease.InBack);
                }
                else if (skillSet.localPosition.y > -740)
                {
                    skillSet.DOKill(this);
                    skillSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);

                    //#.Select Skill Remove
                    RemoveSelectedSkill();
                }
                else if (levelSet.localPosition.y > -740)
                {
                    levelSet.DOKill(this);
                    levelSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                }
            }
            else if (areaSet.localPosition.y == -84)
            {
                areaSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                areaCostPanel.DOKill(this);
                areaCostPanel.DOLocalMoveY(123, 0.25f).SetEase(Ease.InBack);
            }
        }
        else if (panelName == "Level")
        {
            if (levelSet.localPosition.y == -740)
            {
                levelSet.DOLocalMoveY(-84, 0.5f).SetEase(Ease.OutBack);
                InfoUpdate();

                //#.Other UI Set Hide
                if (staffSet.localPosition.y > -740)
                {
                    staffSet.DOKill(this);
                    staffSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                    staffCostPanel.DOKill(this);
                    staffCostPanel.DOLocalMoveY(123, 0.25f).SetEase(Ease.InBack);
                }
                else if (skillSet.localPosition.y > -740)
                {
                    skillSet.DOKill(this);
                    skillSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);

                    //#.Select Skill Remove
                    RemoveSelectedSkill();
                }
                else if (areaSet.localPosition.y > -740)
                {
                    areaSet.DOKill(this);
                    areaSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
                    areaCostPanel.DOKill(this);
                    areaCostPanel.DOLocalMoveY(123, 0.25f).SetEase(Ease.InBack);
                }
            }
            else if (levelSet.localPosition.y == -84)
            {
                levelSet.DOLocalMoveY(-740, 0.25f).SetEase(Ease.InBack);
            }
        }
    }

    //#.All Tap Button
    public void TapStaffBtnClick(string tap)
    {

        if (tap == "Place")
        {
            staffPlacePanel.SetActive(true);
            staffDrawPanel.SetActive(false);
            staffDrawBtn.GetComponent<RectTransform>().SetSiblingIndex(0);
            staffPlaceBtn.GetComponent<RectTransform>().SetSiblingIndex(3);

            staffPlaceBtn.GetComponent<Image>().color = Color.white;
            staffDrawBtn.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
        }
        else if (tap == "Draw")
        {
            staffPlacePanel.SetActive(false);
            staffDrawPanel.SetActive(true);
            staffDrawBtn.GetComponent<RectTransform>().SetSiblingIndex(3);
            staffPlaceBtn.GetComponent<RectTransform>().SetSiblingIndex(0);

            staffPlaceBtn.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            staffDrawBtn.GetComponent<Image>().color = Color.white;
        }
        else if (tap == "Activity")
        {
            skillActivityPanel.SetActive(true);
            skillCompanyPanel.SetActive(false);
            skillEconomyPanel.SetActive(false);

            skillActivityBtn.GetComponent<RectTransform>().SetSiblingIndex(3);
            skillCompanyBtn.GetComponent<RectTransform>().SetSiblingIndex(1);
            skillEconomyBtn.GetComponent<RectTransform>().SetSiblingIndex(0);

            skillActivityBtn.GetComponent<Image>().color = Color.white;
            skillCompanyBtn.GetComponent<Image>().color = new Color32(126, 195, 84, 255);
            skillEconomyBtn.GetComponent<Image>().color = new Color32(91, 132, 217, 255);

            skillActivityBtn.GetComponentInChildren<TMP_Text>().color = new Color32(49, 45, 47, 255);
            skillCompanyBtn.GetComponentInChildren<TMP_Text>().color = Color.white;
            skillEconomyBtn.GetComponentInChildren<TMP_Text>().color = Color.white;
        }
        else if (tap == "Company")
        {
            skillActivityPanel.SetActive(false);
            skillCompanyPanel.SetActive(true);
            skillEconomyPanel.SetActive(false);

            skillActivityBtn.GetComponent<RectTransform>().SetSiblingIndex(1);
            skillCompanyBtn.GetComponent<RectTransform>().SetSiblingIndex(3);
            skillEconomyBtn.GetComponent<RectTransform>().SetSiblingIndex(0);

            skillActivityBtn.GetComponent<Image>().color = new Color32(227, 108, 108, 255);
            skillCompanyBtn.GetComponent<Image>().color = Color.white;
            skillEconomyBtn.GetComponent<Image>().color = new Color32(91, 132, 217, 255);

            skillActivityBtn.GetComponentInChildren<TMP_Text>().color = Color.white;
            skillCompanyBtn.GetComponentInChildren<TMP_Text>().color = new Color32(49, 45, 47, 255);
            skillEconomyBtn.GetComponentInChildren<TMP_Text>().color = Color.white;
        }
        else if (tap == "Economy")
        {
            skillActivityPanel.SetActive(false);
            skillCompanyPanel.SetActive(false);
            skillEconomyPanel.SetActive(true);

            skillActivityBtn.GetComponent<RectTransform>().SetSiblingIndex(0);
            skillCompanyBtn.GetComponent<RectTransform>().SetSiblingIndex(1);
            skillEconomyBtn.GetComponent<RectTransform>().SetSiblingIndex(3);

            skillActivityBtn.GetComponent<Image>().color = new Color32(227, 108, 108, 255);
            skillCompanyBtn.GetComponent<Image>().color = new Color32(126, 195, 84, 255);
            skillEconomyBtn.GetComponent<Image>().color = Color.white;

            skillActivityBtn.GetComponentInChildren<TMP_Text>().color = Color.white;
            skillCompanyBtn.GetComponentInChildren<TMP_Text>().color = Color.white;
            skillEconomyBtn.GetComponentInChildren<TMP_Text>().color = new Color32(49, 45, 47, 255);
        }
        else if (tap == "Mission")
        {
            levelMissionPanel.SetActive(true);
            levelStatusPanel.SetActive(false);

            levelMissionBtn.GetComponent<RectTransform>().SetSiblingIndex(2);
            levelStatusBtn.GetComponent<RectTransform>().SetSiblingIndex(0);

            levelMissionBtn.GetComponent<Image>().color = Color.white;
            levelStatusBtn.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
        }
        else if (tap == "Status")
        {
            levelMissionPanel.SetActive(false);
            levelStatusPanel.SetActive(true);

            levelMissionBtn.GetComponent<RectTransform>().SetSiblingIndex(0);
            levelStatusBtn.GetComponent<RectTransform>().SetSiblingIndex(2);

            levelMissionBtn.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            levelStatusBtn.GetComponent<Image>().color = Color.white;
        }
    }

    //--------------------------------[ HeadUp Logic ]-----------------------------//
    public void ResourceUpdateAnimation(string sender)
    {
        if (sender =="Player")
        {
            switch (gameManager.curType)
            {
                case GameManager.Type.Gun:
                    gunText.transform.DOKill(this);
                    gunText.transform.localScale = Vector3.one;
                    gunText.transform.DOPunchScale(Vector3.one, 0.2f, 10, 0.2f).SetEase(Ease.OutQuad);
                    break;
                case GameManager.Type.Acorn:
                    acornText.transform.DOKill(this);
                    acornText.transform.localScale = Vector3.one;
                    acornText.transform.DOPunchScale(Vector3.one, 0.2f, 10, 0.2f).SetEase(Ease.OutQuad);
                    break;
                case GameManager.Type.Fame:
                    moneyText.transform.DOKill(this);
                    moneyText.transform.localScale = Vector3.one;
                    moneyText.transform.DOPunchScale(Vector3.one, 0.2f, 10, 0.2f).SetEase(Ease.OutQuad);
                    break;
            }
        }
        else if(sender == "Staff")
        {
            ResourceStaffMadeText[(int)GameManager.Type.Gun].text= "+" + string.Format("{0:n0}", gameManager.staffMadeGun);
            ResourceStaffMadeText[(int)GameManager.Type.Acorn].text= "+" + string.Format("{0:n0}", gameManager.staffMadeAcorn);
            ResourceStaffMadeText[(int)GameManager.Type.Fame].text= "+" + string.Format("{0:n0}", gameManager.staffMadeFame);
            ResourceStaffMadeText[3].text= "-" + string.Format("{0:n0}", gameManager.staffCost+gameManager.areaCost);
            ResourceStaffMadeSet.DOAnchorPosX(-670, 1f).SetEase(Ease.OutBack);
            ResourceStaffMadeSet.DOAnchorPosX(-220, 0.5f).SetEase(Ease.InBack).SetDelay(5.5f);
        }
        
    }
    public void ExpPanelAnimation(bool view)
    {
        if (view && gameManager.level < 99)
        {
            expPanel.DOKill(this);
            expPanel.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        }
        else
        {
            expPanel.DOKill(this);
            expPanel.DOScale(0f, 0.2f).SetEase(Ease.InBack);
        }
    }

    //--------------------------------[ Alert Logic ]-----------------------------//
    public void Alert(AlertMsgType msg, AlertType type)
    {
        //#.Position Init
        if (alertSet.anchoredPosition.y != 200)
        {
            alertSet.DOKill(this);
            alertSet.anchoredPosition = Vector2.up * 200;
        }

        //#.Data Setting
        switch (msg)
        {
            case AlertMsgType.TimeFlow:
                alertImage.sprite = alertSprites[0];
                alertText.text = gameManager.year + " 년 " + gameManager.month + " 월이 되었습니다.";
                break;
            case AlertMsgType.LevelUp:
                alertImage.sprite = alertSprites[1];
                alertText.text = "플레이어 레벨이 상승했습니다.\n ( " + (gameManager.level - 1) + " ▶ " + gameManager.level + " )";
                break;
            case AlertMsgType.MoneyLoss:
                alertImage.sprite = alertSprites[2];
                if(gameManager.lossCount==0)
                    alertText.text = "갱단이 파산했습니다";
                else
                    alertText.text = "갱단 운영자금이 부족합니다.\n ( 남은 기회 : " + gameManager.lossCount + " )";
                break;
        }

        //#.Type Setting
        switch (type)
        {
            case AlertType.Positive:
                alertText.color = Color.white;
                alertBackground.color = new Color32(71, 172, 255, 255);
                break;
            case AlertType.Normal:
                alertText.color = Color.black;
                alertBackground.color = Color.white;
                break;
            case AlertType.Negative:
                alertText.color = Color.white;
                alertBackground.color = new Color32(248, 93, 88, 255);
                break;
        }


        //#.Visible Animation
        alertSet.DOAnchorPosY(-95, 0.5f).SetEase(Ease.OutBack);
        alertSet.DOAnchorPosY(200, 0.3f).SetDelay(3).SetEase(Ease.InBack);

    }

    //--------------------------------[ Staff Logic ]-----------------------------//
    public void WaitStaffBtnClick(int grade)
    {
        if (staffManager.waitStaffCount[grade] == 0)
        {
            return;
        }
        staffManager.waitStaffCount[grade]--;
        int placeIndex = (int)gameManager.curType;
        staffManager.staffCount[placeIndex, grade]++;
    }

    public void StaffBtnClick(int grade)
    {
        int placeIndex = (int)gameManager.curType;
        if (staffManager.staffCount[placeIndex, grade] == 0)
        {
            return;
        }

        staffManager.staffCount[placeIndex, grade]--;

        staffManager.waitStaffCount[grade]++;

        BatchWorkStaff();
    }

    void BatchWorkStaff()
    {
        int totalStaffCost = 0;
        //#. Staff Employment Cost Text
        for(int index=0; index < 6; index++)
        {
            totalStaffCost += staffManager.staffCount[(int)gameManager.curType, index] * staffManager.staffCost[index];
        }
        staffCostText.text = string.Format("{0:n0}", totalStaffCost);
     
    }


    public void StaffDrawBtnClick(int num)
    {
        //#.Draw Cost Check
        if ((num == 1 && gameManager.money < 100000) ||
            (num == 10 && gameManager.money < 1000000))
            return;

        gameManager.money -= num == 1 ? 100000 : 1000000;

        //#.Draw Start
        staffFadeBlack.gameObject.SetActive(true);
        staffFadeBlack.DOFade(0.5f, 0.5f).SetEase(Ease.OutQuad);

        staffManager.StartDrawStaff(num);
        
        staffDrawOpenBtn.gameObject.SetActive(num==1);
        staffTenDrawOpenBtn.gameObject.SetActive(num==10);
    }

    public void StaffDrawOpenBtnClick(int num)
    {
        if (num == 1)
        {
            staffDrawOpenBtn.gameObject.SetActive(false);
            staffManager.DrawOpenStaff(1);
            staffRecuritBtn.enabled = true;
            staffRecuritBtn.transform.DOScale(Vector2.one, 1f).SetEase(Ease.OutBack).SetDelay(2.5f);
        }
        else if (num == 10)
        {
            staffTenDrawOpenBtn.gameObject.SetActive(false);
            staffManager.DrawOpenStaff(10);
            staffRecuritTenBtn.enabled = true;
            staffRecuritTenBtn.transform.DOScale(Vector2.one, 1f).SetEase(Ease.OutBack).SetDelay(2.5f);
        }
      
       
    }


    public void StaffRecuritBtnClick(int num)
    {
        staffFadeBlack.DOFade(0, 0.5f).SetEase(Ease.OutQuad);
        Invoke("DisableFadeBlack", 0.6f);

        if (num == 1)
        {
            staffRecuritBtn.transform.DOScale(Vector2.zero, 1f).SetEase(Ease.InBack);
            staffRecuritBtn.enabled = false;
            staffManager.Recurit(1);
        }
        else if (num == 10)
        {
            staffRecuritTenBtn.transform.DOScale(Vector2.zero, 1f).SetEase(Ease.InBack);
            staffRecuritTenBtn.enabled = false;
            staffManager.Recurit(10);
        }
    }

    public void DisableFadeBlack()
    {
        staffFadeBlack.gameObject.SetActive(false);
    }


    //--------------------------------[ Skill Logic ]-----------------------------//
    public void SelectSkill(int id)
    {
        SkillVo skill = skillManager.GetSkill(id);
        skillManager.selectedSkill = skill;
        bool isEnableUp = false;
        if(skill._level < 5)
        {
            isEnableUp = gameManager.point - gameManager.usedPoint >= skill._nextPoint[skill._level];
        }

        skillDescIcon.sprite = skill._icon;
        skillDescName.text = skill._name;
        skillDescLevel.text =skill._level==5 ? "Lv.Max" : "Lv." + (skill._level+1);
        skillDescPoint.text = skill._level == 5 ? " ":"필요SP " + skill._nextPoint[skill._level];
        skillDescPoint.color = isEnableUp ? new Color32(94, 121, 215, 255) : new Color32(248, 99, 83, 255);
        skillDescFunc.text = skill._funcDesc[skill._level == 5 ? skill._level-1 : skill._level];
        skillDescContent.text = skill._content;
        skillDescGroup.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutElastic);

        if (isEnableUp)
        {
            Vector3 uiPos = skillTreeIcons[id].GetComponent<RectTransform>().anchoredPosition;
            uiPos.y = skillUpBtn.anchoredPosition.y;
            skillUpBtn.anchoredPosition = uiPos;
            skillUpBtn.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        }
        else
        {
            skillUpBtn.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InBack);
        }
    }

    public void SkillUpBtnClick()
    {
        gameManager.usedPoint += skillManager.selectedSkill._nextPoint[skillManager.selectedSkill._level];
        skillManager.SkillUp(skillManager.selectedSkill._id);

        skillDescGroup.DOPunchScale(Vector3.one, 0.2f, 10, 0.2f).SetEase(Ease.OutQuad);
        SelectSkill(skillManager.selectedSkill._id);

        skillUpBtn.DOScale(Vector3.zero, 0.1f).SetEase(Ease.InBack).SetDelay(0.1f);
        SkillInfoUpdate();
        InitBtnState();
    }


    public void SkillInfoUpdate()
    {
        for (int index = 0; index <= 14; index++)
        {
            SkillVo skill = skillManager.GetSkill(index);
            skillTreeIcons[index].sprite = skill._icon;
            skillTreeLevel[index].text = "Lv." + skill._level;
        }

    }

    public void RemoveSelectedSkill()
    {
        skillDescGroup.DOScale(Vector3.zero, 0.3f).SetEase(Ease.OutQuad);
        skillUpBtn.DOScale(Vector3.zero, 0.5f).SetEase(Ease.OutQuad);
        skillManager.selectedSkill = null;
    }


    //--------------------------------[ Area Logic ]-----------------------------//
    public void ModuleBtnClick(int index)
    {
        selectModuleIndex = index;

        if (areaManager.fitModules[(int)gameManager.curType, index] != null)
        {
            float posX = areaModulesGroup[index].GetComponent<RectTransform>()
                .parent.GetComponent<RectTransform>().anchoredPosition.x;
            controlBtnGroup.DOAnchorPosX(posX, 0).SetEase(Ease.Linear);
            controlBtnGroup.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        }
        else
        {
            areaScrollView.DOAnchorPosY(-550, 0.7f).SetEase(Ease.OutBack);
        }
      
    }

    public void ChangeBtnClick()
    {
        areaScrollView.DOAnchorPosY(-550, 0.7f).SetEase(Ease.OutBack);
    }

    public void RemoveBtnClick()
    {
        areaModulesGroup[selectModuleIndex].SetActive(false);
        areaManager.fitModules[(int)gameManager.curType, selectModuleIndex] = null;

        controlBtnGroup.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack);

        //#.Calculate Total Module Management Admin Cost
        CalAreaCost();
    }

    public void ModuleShopBackBtnClick()
    {
        areaScrollView.DOAnchorPosY(0, 0.7f).SetEase(Ease.InBack);
    }

    public void RefreshShop(ModuleVo[] moduleData, bool isInit)
    {
        shopModulesData = moduleData;

        if (isInit && gameManager.money < 10000)
        {
            RefreshBtn.GetComponent<RectTransform>().DOPunchAnchorPos(Vector2.one, 0.5f);
            return;
        }


        for (int index=0;index<7; index++)
        {
            ModuleVo module = moduleData[index];
            GameObject shopModule = shopModules[index];

            //#.Active Shop Item by Player Grade (After Refresh Btn Click)
            UIShopModule shopMuduleObj= shopModule.GetComponent<UIShopModule>();
            shopMuduleObj.saleGroup.SetActive((int)gameManager.grade +3 > index);
            shopMuduleObj.notSaleGroup.SetActive(!((int)gameManager.grade + 3 > index));

            //#.Accept Module Data
            if (!((int)gameManager.grade + 3 > index))
                continue;

            Image uiIcon = shopModule.GetComponentsInChildren<Image>()[2];
            TMP_Text uiName = shopModule.GetComponentsInChildren<TMP_Text>()[0];
            TMP_Text uiGrade = shopModule.GetComponentsInChildren<TMP_Text>()[2];
            TMP_Text uiFunc = shopModule.GetComponentsInChildren<TMP_Text>()[4];
            TMP_Text uiAdmin = shopModule.GetComponentsInChildren<TMP_Text>()[6];
            TMP_Text uiCost = shopModule.GetComponentsInChildren<TMP_Text>()[7];

            uiIcon.sprite = module.icon;
            uiName.text = module.name.ToString();
            uiGrade.text = module.grade.ToString();
            uiFunc.text = module.type.ToString();
            uiAdmin.text = string.Format("{0:n0}",module.adminCost);
            uiCost.text = string.Format("{0:n0}", module.buyCost);

            
        }
        InitBtnState();
    }


    public void RefreshModule(int index, ModuleVo module)
    {
        if (module == null)
        {
            areaModulesGroup[index].SetActive(false);
            return;
        }
        areaModulesGroup[index].SetActive(true);
        Image uiIcon = areaModulesGroup[index].GetComponentsInChildren<Image>()[1];
        TMP_Text uiName = areaModulesGroup[index].GetComponentsInChildren<TMP_Text>()[0];
        TMP_Text uiGrade = areaModulesGroup[index].GetComponentsInChildren<TMP_Text>()[1];
        TMP_Text uiFunc = areaModulesGroup[index].GetComponentsInChildren<TMP_Text>()[2];
        TMP_Text uiAdmin = areaModulesGroup[index].GetComponentsInChildren<TMP_Text>()[3];

        uiIcon.sprite = module.icon;
        uiName.text = module.name.ToString();
        uiGrade.text=module.grade.ToString();
        uiFunc.text = module.type.ToString();
        uiAdmin.text = string.Format("{0:n0}", module.adminCost);
    }

    public void BuyBtnClick(int shopIndex)
    {

        //#1. Accept By Module Date
        ModuleVo buyModule = shopModulesData[shopIndex];
        areaManager.fitModules[(int)gameManager.curType, selectModuleIndex] = buyModule;

        //#2. Area Module UI Update
        areaModulesGroup[selectModuleIndex].SetActive(true);
        Image uiIcon = areaModulesGroup[selectModuleIndex].GetComponentsInChildren<Image>()[1];
        TMP_Text uiName = areaModulesGroup[selectModuleIndex].GetComponentsInChildren<TMP_Text>()[0];
        TMP_Text uiGrade = areaModulesGroup[selectModuleIndex].GetComponentsInChildren<TMP_Text>()[1];
        TMP_Text uiFunc = areaModulesGroup[selectModuleIndex].GetComponentsInChildren<TMP_Text>()[2];
        TMP_Text uiAdmin = areaModulesGroup[selectModuleIndex].GetComponentsInChildren<TMP_Text>()[3];

        uiIcon.sprite = buyModule.icon;
        uiName.text = buyModule.name.ToString();
        uiGrade.text = buyModule.grade.ToString();
        uiFunc.text = buyModule.type.ToString();
        uiAdmin.text = string.Format("{0:n0}", buyModule.adminCost);

        //#3. Cost Money
        gameManager.money -= buyModule.buyCost;

        //#4. Back UI
        ModuleShopBackBtnClick();

        //#5.Empty Shop Module Date
        areaManager.shopModules[shopIndex] = null;
        GameObject uishopModule = shopModules[shopIndex];
        UIShopModule shopModuleObj = uishopModule.GetComponent<UIShopModule>();
        shopModuleObj.saleGroup.SetActive(false);
        shopModuleObj.notSaleGroup.SetActive(true);

        //#6.Calculate Total Module Management Admin Cost
        CalAreaCost();
    }

    public void AddModuleSocket()
    {
        if ((int)gameManager.grade == 5)
            return;

        GameObject nextLock = areaModulesLockGroup[(int)gameManager.grade];
        Image nextSocket = areaModulesBackground[(int)gameManager.grade];
        Button nextSocketBtn= nextSocket.gameObject.GetComponent<Button>();

        nextLock.SetActive(false);
        nextSocket.enabled = true;
        nextSocketBtn.interactable = true;
    }

    public void CalAreaCost()
        {
            int totalModuleCost = 0;
            for (int index = 0; index < 5; index++)
            {
                ModuleVo module = areaManager.fitModules[(int)gameManager.curType, index];
                if (module != null)
                {
                    totalModuleCost += module.adminCost;
                }

            }
            areaCostText.text = string.Format("{0:n0}", totalModuleCost);
        
        }

    public void FitModuleUpdate()
    {
        for(int index=0; index < 5; index++)
        {
            RefreshModule(index, areaManager.fitModules[(int)gameManager.curType, index]);
        }
    }


    //--------------------------------[ Level Logic ]-----------------------------//

    public void UpdateMission()
    {
        for(int index=0; index < 5; index++)
        {
            checkImages[index].sprite = checkSprites[0];
            missionTexts[index].text = levelManager.mission[(int)gameManager.grade,index];
        }
    }

    public void GradeUpdate()
    {
        gradeImage.sprite = gradeSprites[(int)gameManager.grade];
        if ((int)gameManager.grade + 1 < 5)
        {
            nextGradeImg.sprite = gradeSprites[(int)gameManager.grade + 1];
        }
       
        UpdateMission();
    }

    public void GradeAcceptBtnClick()
    {
        if (gameManager.grade == GameManager.Grade.A)
            StartCoroutine(Ending(true));
    }

    public void InfoUpdate()
    {
        //#1.Exchange Rate Text
        infoExchangeGunText.text = gameManager.gunRate.ToString();
        infoExchangeAcornText.text=gameManager.acornRate.ToString();

        //#2.Acorn Price
        infoAcornPriceText.text = string.Format("{0:n0}", gameManager.acornPrice)+ "원";

        //#3.Total Admin Cost
        int staffCost = 0;
        int moduleCost = 0;
        for (int areaIndex = 0; areaIndex < 3; areaIndex++)
        {
            //#3-1.Staff Cost
            for (int gradeIndex = 0; gradeIndex < 6; gradeIndex++)
            {
                staffCost += staffManager.staffCount[areaIndex, gradeIndex] * staffManager.staffCost[gradeIndex];
            }

            //#3-2.Module Cost
            for (int moduleIndex = 0; moduleIndex < 5; moduleIndex++)
            {
                ModuleVo module = areaManager.fitModules[areaIndex, moduleIndex];
                if (module != null)
                {
                    moduleCost += module.adminCost;
                }

            }
        }

        int totalCost = staffCost + moduleCost;
        infoTotalCostText.text= string.Format("{0:n0}", totalCost) + "원";

        //#4.Grid Set
        for(int areaIndex = 0; areaIndex < 3; areaIndex++)
        {
            //#5.Click Count (Skill Effect)
            float clickEffect = 1;
            clickEffect += (int)skillManager.skillList[0]._func[skillManager.skillList[0]._level];
            for(int index=0; index < 5; index++)
            {
                if(areaManager.fitModules[areaIndex, index] != null)
                if (areaManager.fitModules[areaIndex, index].type == ModuleVo.Type.ClickEff)
                    clickEffect += areaManager.fitModules[areaIndex, index].func;
            }
            
            infoClickCount[areaIndex].text = (1.0f / gameManager.maxCount[areaIndex]).ToString("F2");

            //#6.Critical Rate
            float criRate = (int)skillManager.skillList[1]._func[skillManager.skillList[1]._level];
            for(int index=0; index<5; index++)
            {
                if (areaManager.fitModules[areaIndex, index] != null)
                {
                    if (areaManager.fitModules[areaIndex, index].type == ModuleVo.Type.ClickCri)
                        criRate += areaManager.fitModules[areaIndex, index].func;
                }
            }
            infoCriRate[areaIndex].text = criRate + "%";

            //#7.Earn Exp
            float exp = 1;
            for (int index = 0; index < 5; index++)
            {
                if (areaManager.fitModules[areaIndex, index] != null)
                {
                    if (areaManager.fitModules[areaIndex, index].type == ModuleVo.Type.Exp)
                        exp += areaManager.fitModules[areaIndex, index].func;
                }
            }
            infoExp[areaIndex].text = exp.ToString();

            //#8.Staff Auto Making
            float staffMadeGun = 0;
            float staffMadeAcorn = 0;
            float staffMadeFame = 0;

            for (int index = 0; index < 6; index++)
            {
                staffMadeGun += staffManager.staffCount[0, index] *
                            staffManager.staffMPS[0, index]*
                            skillManager.skillList[5]._func[skillManager.skillList[5]._level];
                staffMadeAcorn += staffManager.staffCount[1, index] *
                              staffManager.staffMPS[1, index] *
                              skillManager.skillList[5]._func[skillManager.skillList[5]._level];
                staffMadeFame += staffManager.staffCount[2, index] *
                             staffManager.staffMPS[2, index] *
                             skillManager.skillList[5]._func[skillManager.skillList[5]._level];
            }
            infoStaffAutoMake[0].text = staffMadeGun.ToString("F0");
            infoStaffAutoMake[1].text = staffMadeAcorn.ToString("F0");
            infoStaffAutoMake[2].text = staffMadeFame.ToString("F0");
        }
    }

    //--------------------------------[ Etc Logic ]-----------------------------//
   
    public void BadEnding()
    {
        StartCoroutine(Ending(false));
    }
    
    IEnumerator Ending(bool isClear)
    {
        yield return new WaitForSeconds(0.5f);

        if (isClear)
        {
            //#.Happy Ending
            // SceneManager.LoadScene("4Ending");
        }
        else
        {
            //#.Bad Ending
            fadeBlack.gameObject.SetActive(true);
            fadeBlack.DOFade(1f, 1f);
            endingSet.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);
            
            badEndText.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutBack);
            badEndImage.DOLocalMoveY(-330, 0.5f).SetEase(Ease.OutBack).SetDelay(0.5f);
            badEndBtn.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).SetDelay(2f);
            
        }
    }
    public void BadEndBtnClick()
    {
        StartCoroutine(ReturnMenu());
    }

    IEnumerator ReturnMenu()
    {
        badEndBtn.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack);
        badEndText.DOLocalMoveY(390, 0.5f).SetEase(Ease.InBack);
        badEndImage.DOLocalMoveY(400, 0.5f).SetEase(Ease.InBack).SetDelay(0.1f);
        fadeWhite.DOFade(1f, 1.5f).SetDelay(0.3f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("1Menu");
    }

}
