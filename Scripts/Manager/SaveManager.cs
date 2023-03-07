using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public GameManager gameManager;
    public StaffManager staffManager;
    public SkillManager skillManager;
    public AreaManager areaManager;
    public LevelManager levelManager;

    //#.GameManager
    GameManager.Type sCurType;
    GameManager.Grade sGrade;
    public int sYear;
    public int sMonth;
    public int sLevel;
    public int sCurExp;
    public int sPoint;
    public int sUsedPoint;
    public int sGun;
    public int sAcorn;
    public int sFame;
    public int sMoney;
    public int sGunRate;
    public int sAcornRate;
    public int sAcornPrice;
    public int sStaffCost;
    public int sAreaCost;
    public int sLossCount;

    //#.StaffManager
    public int sWaitStaffCount0;
    public int sWaitStaffCount1;
    public int sWaitStaffCount2;
    public int sWaitStaffCount3;
    public int sWaitStaffCount4;
    public int sWaitStaffCount5;
    public int sBatchGunStaffCount0;
    public int sBatchGunStaffCount1;
    public int sBatchGunStaffCount2;
    public int sBatchGunStaffCount3;
    public int sBatchGunStaffCount4;
    public int sBatchGunStaffCount5;
    public int sBatchAcornStaffCount0;
    public int sBatchAcornStaffCount1;
    public int sBatchAcornStaffCount2;
    public int sBatchAcornStaffCount3;
    public int sBatchAcornStaffCount4;
    public int sBatchAcornStaffCount5;
    public int sBatchFameStaffCount0;
    public int sBatchFameStaffCount1;
    public int sBatchFameStaffCount2;
    public int sBatchFameStaffCount3;
    public int sBatchFameStaffCount4;
    public int sBatchFameStaffCount5;

    //#.SkillManager
    public int sSkillLevel0;
    public int sSkillLevel1;
    public int sSkillLevel2;
    public int sSkillLevel3;
    public int sSkillLevel4;
    public int sSkillLevel5;
    public int sSkillLevel6;
    public int sSkillLevel7;
    public int sSkillLevel8;
    public int sSkillLevel9;
    public int sSkillLevel10;
    public int sSkillLevel11;
    public int sSkillLevel12;
    public int sSkillLevel13;
    public int sSkillLevel14;

    //#.AreaManager
    public int sFitModuleGun0;
    public int sFitModuleGun1;
    public int sFitModuleGun2;
    public int sFitModuleGun3;
    public int sFitModuleGun4;
    public int sFitModuleAcorn0;
    public int sFitModuleAcorn1;
    public int sFitModuleAcorn2;
    public int sFitModuleAcorn3;
    public int sFitModuleAcorn4;
    public int sFitModuleFame0;
    public int sFitModuleFame1;
    public int sFitModuleFame2;
    public int sFitModuleFame3;
    public int sFitModuleFame4;
    public int sShopModule0;
    public int sShopModule1;
    public int sShopModule2;
    public int sShopModule3;
    public int sShopModule4;
    public int sShopModule5;

    //#.LevelManager
    public bool sClearMission0;
    public bool sClearMission1;
    public bool sClearMission2;
    public bool sClearMission3;
    public bool sClearMission4;


    void Awake()
    {
        Load();
    }

    void Load()
    {
        //#1.GameManager
        sYear=PlayerPrefs.GetInt("year");
        sMonth = PlayerPrefs.GetInt("month");
        sLevel = PlayerPrefs.GetInt("level");
        sCurExp = PlayerPrefs.GetInt("curExp");
        sPoint = PlayerPrefs.GetInt("point");
        sUsedPoint = PlayerPrefs.GetInt("usedPoint");
        sGun = PlayerPrefs.GetInt("gun");
        sAcorn = PlayerPrefs.GetInt("acorn");
        sFame = PlayerPrefs.GetInt("fame");
        sMoney = PlayerPrefs.GetInt("money");
        sGunRate = PlayerPrefs.GetInt("gunRate");
        sAcornRate = PlayerPrefs.GetInt("acornRate");
        sAcornPrice = PlayerPrefs.GetInt("acornPrice");
        sStaffCost = PlayerPrefs.GetInt("staffCost");
        sAreaCost = PlayerPrefs.GetInt("areaCost");
        sLossCount = PlayerPrefs.GetInt("lossCount");

        //#2.StaffManager
        sWaitStaffCount0 = PlayerPrefs.GetInt("waitStaffCount0");
        sWaitStaffCount1 = PlayerPrefs.GetInt("waitStaffCount1");
        sWaitStaffCount2 = PlayerPrefs.GetInt("waitStaffCount2");
        sWaitStaffCount3 = PlayerPrefs.GetInt("waitStaffCount3");
        sWaitStaffCount4 = PlayerPrefs.GetInt("waitStaffCount4");
        sWaitStaffCount5 = PlayerPrefs.GetInt("waitStaffCount5");

        sBatchGunStaffCount0 = PlayerPrefs.GetInt("batchGunStaffCount0");
        sBatchGunStaffCount1 = PlayerPrefs.GetInt("batchGunStaffCount1");
        sBatchGunStaffCount2 = PlayerPrefs.GetInt("batchGunStaffCount2");
        sBatchGunStaffCount3 = PlayerPrefs.GetInt("batchGunStaffCount3");
        sBatchGunStaffCount4 = PlayerPrefs.GetInt("batchGunStaffCount4");
        sBatchGunStaffCount5 = PlayerPrefs.GetInt("batchGunStaffCount5");
        sBatchAcornStaffCount0 = PlayerPrefs.GetInt("batchAcornStaffCount0");
        sBatchAcornStaffCount1 = PlayerPrefs.GetInt("batchAcornStaffCount1");
        sBatchAcornStaffCount2 = PlayerPrefs.GetInt("batchAcornStaffCount2");
        sBatchAcornStaffCount3 = PlayerPrefs.GetInt("batchAcornStaffCount3");
        sBatchAcornStaffCount4 = PlayerPrefs.GetInt("batchAcornStaffCount4");
        sBatchAcornStaffCount5 = PlayerPrefs.GetInt("batchAcornStaffCount5");
        sBatchFameStaffCount0 = PlayerPrefs.GetInt("batchFameStaffCount0");
        sBatchFameStaffCount1 = PlayerPrefs.GetInt("batchFameStaffCount1");
        sBatchFameStaffCount2 = PlayerPrefs.GetInt("batchFameStaffCount2");
        sBatchFameStaffCount3 = PlayerPrefs.GetInt("batchFameStaffCount3");
        sBatchFameStaffCount4 = PlayerPrefs.GetInt("batchFameStaffCount4");
        sBatchFameStaffCount5 = PlayerPrefs.GetInt("batchFameStaffCount5");

        //#3.SkillManager
        sSkillLevel0 = PlayerPrefs.GetInt("skillLevel0");
        sSkillLevel1 = PlayerPrefs.GetInt("skillLevel1");
        sSkillLevel2 = PlayerPrefs.GetInt("skillLevel2");
        sSkillLevel3 = PlayerPrefs.GetInt("skillLevel3");
        sSkillLevel4 = PlayerPrefs.GetInt("skillLevel4");
        sSkillLevel5 = PlayerPrefs.GetInt("skillLevel5");
        sSkillLevel6 = PlayerPrefs.GetInt("skillLevel6");
        sSkillLevel7 = PlayerPrefs.GetInt("skillLevel7");
        sSkillLevel8 = PlayerPrefs.GetInt("skillLevel8");
        sSkillLevel9 = PlayerPrefs.GetInt("skillLevel9");
        sSkillLevel10 = PlayerPrefs.GetInt("skillLevel10");
        sSkillLevel11 = PlayerPrefs.GetInt("skillLevel11");
        sSkillLevel12 = PlayerPrefs.GetInt("skillLevel12");
        sSkillLevel13 = PlayerPrefs.GetInt("skillLevel13");
        sSkillLevel14 = PlayerPrefs.GetInt("skillLevel14");

        //#4.AreaManager
        sFitModuleGun0 = PlayerPrefs.GetInt("fitModuleGun0");
        sFitModuleGun1 = PlayerPrefs.GetInt("fitModuleGun1");
        sFitModuleGun2 = PlayerPrefs.GetInt("fitModuleGun2");
        sFitModuleGun3 = PlayerPrefs.GetInt("fitModuleGun3");
        sFitModuleGun4 = PlayerPrefs.GetInt("fitModuleGun4");

        sFitModuleAcorn0 = PlayerPrefs.GetInt("fitModuleAcorn0");
        sFitModuleAcorn1 = PlayerPrefs.GetInt("fitModuleAcorn1");
        sFitModuleAcorn2 = PlayerPrefs.GetInt("fitModuleAcorn2");
        sFitModuleAcorn3 = PlayerPrefs.GetInt("fitModuleAcorn3");
        sFitModuleAcorn4 = PlayerPrefs.GetInt("fitModuleAcorn4");

        sFitModuleFame0 = PlayerPrefs.GetInt("fitModuleFame0");
        sFitModuleFame1 = PlayerPrefs.GetInt("fitModuleFame1");
        sFitModuleFame2 = PlayerPrefs.GetInt("fitModuleFame2");
        sFitModuleFame3 = PlayerPrefs.GetInt("fitModuleFame3");
        sFitModuleFame4 = PlayerPrefs.GetInt("fitModuleFame4");

        sShopModule0 = PlayerPrefs.GetInt("shopModule0");
        sShopModule1 = PlayerPrefs.GetInt("shopModule1");
        sShopModule2 = PlayerPrefs.GetInt("shopModule2");
        sShopModule3 = PlayerPrefs.GetInt("shopModule3");
        sShopModule4 = PlayerPrefs.GetInt("shopModule4");
        sShopModule5 = PlayerPrefs.GetInt("shopModule5");

        //#5.LevelManager
        sClearMission0 = PlayerPrefs.GetInt("clearMission0") == 1 ? true : false;
        sClearMission1 = PlayerPrefs.GetInt("clearMission1") == 1 ? true : false;
        sClearMission2 = PlayerPrefs.GetInt("clearMission2") == 1 ? true : false;
        sClearMission3 = PlayerPrefs.GetInt("clearMission3") == 1 ? true : false;
        sClearMission4 = PlayerPrefs.GetInt("clearMission4") == 1 ? true : false;

    }

    public void Save()
    {
        //#1.GameManager
        PlayerPrefs.SetInt("year",gameManager.year);
        PlayerPrefs.SetInt("month",gameManager.month);
        PlayerPrefs.SetInt("level",gameManager.level);
        PlayerPrefs.SetInt("curExp",gameManager.curExp);
        PlayerPrefs.SetInt("point", gameManager.point);
        PlayerPrefs.SetInt("usedPoint", gameManager.usedPoint);
        PlayerPrefs.SetInt("gun", gameManager.gun);
        PlayerPrefs.SetInt("acorn", gameManager.acorn);
        PlayerPrefs.SetInt("fame", gameManager.fame);
        PlayerPrefs.SetInt("money", gameManager.money);
        PlayerPrefs.SetInt("gunRate", gameManager.gunRate);
        PlayerPrefs.SetInt("acornRate", gameManager.acornRate);
        PlayerPrefs.SetInt("acornPrice", gameManager.acornPrice);
        PlayerPrefs.SetInt("staffCost", gameManager.staffCost);
        PlayerPrefs.SetInt("areaCost", gameManager.areaCost);
        PlayerPrefs.SetInt("lossCount", gameManager.lossCount);

        //#2.StaffManager
        PlayerPrefs.SetInt("waitStaffCount0", staffManager.waitStaffCount[0]);
        PlayerPrefs.SetInt("waitStaffCount1", staffManager.waitStaffCount[1]);
        PlayerPrefs.SetInt("waitStaffCount2", staffManager.waitStaffCount[2]);
        PlayerPrefs.SetInt("waitStaffCount3", staffManager.waitStaffCount[3]);
        PlayerPrefs.SetInt("waitStaffCount4", staffManager.waitStaffCount[4]);
        PlayerPrefs.SetInt("waitStaffCount5", staffManager.waitStaffCount[5]);

        PlayerPrefs.SetInt("batchGunStaffCount0", staffManager.staffCount[0,0]);
        PlayerPrefs.SetInt("batchGunStaffCount1", staffManager.staffCount[0,1]);
        PlayerPrefs.SetInt("batchGunStaffCount2", staffManager.staffCount[0,2]);
        PlayerPrefs.SetInt("batchGunStaffCount3", staffManager.staffCount[0,3]);
        PlayerPrefs.SetInt("batchGunStaffCount4", staffManager.staffCount[0,4]);
        PlayerPrefs.SetInt("batchGunStaffCount5", staffManager.staffCount[0,5]);
        PlayerPrefs.SetInt("batchAcornStaffCount0", staffManager.staffCount[1, 0]);
        PlayerPrefs.SetInt("batchAcornStaffCount1", staffManager.staffCount[1, 1]);
        PlayerPrefs.SetInt("batchAcornStaffCount2", staffManager.staffCount[1, 2]);
        PlayerPrefs.SetInt("batchAcornStaffCount3", staffManager.staffCount[1, 3]);
        PlayerPrefs.SetInt("batchAcornStaffCount4", staffManager.staffCount[1, 4]);
        PlayerPrefs.SetInt("batchAcornStaffCount5", staffManager.staffCount[1, 5]);
        PlayerPrefs.SetInt("batchFameStaffCount0", staffManager.staffCount[2, 0]);
        PlayerPrefs.SetInt("batchFameStaffCount1", staffManager.staffCount[2, 1]);
        PlayerPrefs.SetInt("batchFameStaffCount2", staffManager.staffCount[2, 2]);
        PlayerPrefs.SetInt("batchFameStaffCount3", staffManager.staffCount[2, 3]);
        PlayerPrefs.SetInt("batchFameStaffCount4", staffManager.staffCount[2, 4]);
        PlayerPrefs.SetInt("batchFameStaffCount5", staffManager.staffCount[2, 5]);

        //#3.SkillManager
        PlayerPrefs.SetInt("skillLevel0", skillManager.skillList[0]._level);
        PlayerPrefs.SetInt("skillLevel1", skillManager.skillList[1]._level);
        PlayerPrefs.SetInt("skillLevel2", skillManager.skillList[2]._level);
        PlayerPrefs.SetInt("skillLevel3", skillManager.skillList[3]._level);
        PlayerPrefs.SetInt("skillLevel4", skillManager.skillList[4]._level);
        PlayerPrefs.SetInt("skillLevel5", skillManager.skillList[5]._level);
        PlayerPrefs.SetInt("skillLevel6", skillManager.skillList[6]._level);
        PlayerPrefs.SetInt("skillLevel7", skillManager.skillList[7]._level);
        PlayerPrefs.SetInt("skillLevel8", skillManager.skillList[8]._level);
        PlayerPrefs.SetInt("skillLevel9", skillManager.skillList[9]._level);
        PlayerPrefs.SetInt("skillLevel10", skillManager.skillList[10]._level);
        PlayerPrefs.SetInt("skillLevel11", skillManager.skillList[11]._level);
        PlayerPrefs.SetInt("skillLevel12", skillManager.skillList[12]._level);
        PlayerPrefs.SetInt("skillLevel13", skillManager.skillList[13]._level);
        PlayerPrefs.SetInt("skillLevel14", skillManager.skillList[14]._level);

        //#4.AreaManager
        PlayerPrefs.SetInt("fitModuleGun0", areaManager.fitModules[0,0]!=null ? areaManager.fitModules[0,0].id : -1);
        PlayerPrefs.SetInt("fitModuleGun1", areaManager.fitModules[0,1]!=null ? areaManager.fitModules[0,1].id : -1);
        PlayerPrefs.SetInt("fitModuleGun2", areaManager.fitModules[0,2]!=null ? areaManager.fitModules[0,2].id : -1);
        PlayerPrefs.SetInt("fitModuleGun3", areaManager.fitModules[0,3]!=null ? areaManager.fitModules[0,3].id : -1);
        PlayerPrefs.SetInt("fitModuleGun4", areaManager.fitModules[0,4]!=null ? areaManager.fitModules[0,4].id : -1);

        PlayerPrefs.SetInt("fitModuleAcorn0", areaManager.fitModules[1, 0] != null ? areaManager.fitModules[1, 0].id : -1);
        PlayerPrefs.SetInt("fitModuleAcorn1", areaManager.fitModules[1, 1] != null ? areaManager.fitModules[1, 1].id : -1);
        PlayerPrefs.SetInt("fitModuleAcorn2", areaManager.fitModules[1, 2] != null ? areaManager.fitModules[1, 2].id : -1);
        PlayerPrefs.SetInt("fitModuleAcorn3", areaManager.fitModules[1, 3] != null ? areaManager.fitModules[1, 3].id : -1);
        PlayerPrefs.SetInt("fitModuleAcorn4", areaManager.fitModules[1, 4] != null ? areaManager.fitModules[1, 4].id : -1);

        PlayerPrefs.SetInt("fitModuleFame0", areaManager.fitModules[2, 0] != null ? areaManager.fitModules[2, 0].id : -1);
        PlayerPrefs.SetInt("fitModuleFame1", areaManager.fitModules[2, 1] != null ? areaManager.fitModules[2, 1].id : -1);
        PlayerPrefs.SetInt("fitModuleFame2", areaManager.fitModules[2, 2] != null ? areaManager.fitModules[2, 2].id : -1);
        PlayerPrefs.SetInt("fitModuleFame3", areaManager.fitModules[2, 3] != null ? areaManager.fitModules[2, 3].id : -1);
        PlayerPrefs.SetInt("fitModuleFame4", areaManager.fitModules[2, 4] != null ? areaManager.fitModules[2, 4].id : -1);

        PlayerPrefs.SetInt("shopModule0", areaManager.shopModules[0] != null ? areaManager.shopModules[0].id : -1);
        PlayerPrefs.SetInt("shopModule1", areaManager.shopModules[1] != null ? areaManager.shopModules[1].id : -1);
        PlayerPrefs.SetInt("shopModule2", areaManager.shopModules[2] != null ? areaManager.shopModules[2].id : -1);
        PlayerPrefs.SetInt("shopModule3", areaManager.shopModules[3] != null ? areaManager.shopModules[3].id : -1);
        PlayerPrefs.SetInt("shopModule4", areaManager.shopModules[4] != null ? areaManager.shopModules[4].id : -1);
        PlayerPrefs.SetInt("shopModule5", areaManager.shopModules[5] != null ? areaManager.shopModules[5].id : -1);

        //#5.LevelManager
        PlayerPrefs.SetInt("clearMission0", levelManager.clearMission[0] ? 1:0);
        PlayerPrefs.SetInt("clearMission1", levelManager.clearMission[1] ? 1:0);
        PlayerPrefs.SetInt("clearMission2", levelManager.clearMission[2] ? 1:0);
        PlayerPrefs.SetInt("clearMission3", levelManager.clearMission[3] ? 1:0);
        PlayerPrefs.SetInt("clearMission4", levelManager.clearMission[4] ? 1:0);

        PlayerPrefs.Save();
    }

}
