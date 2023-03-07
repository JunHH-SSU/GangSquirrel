using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public GameManager gameManager;
    public UIManager uiManager;
    public SaveManager saveManager;

    public ModuleVo[] moduleList;
    public ModuleVo[,] fitModules;
    public ModuleVo[] shopModules;
    public Sprite[] moduleIcons;
    public int[] moduleFuncValue;

    public bool isInitShop;

    void Awake()
    {
        moduleList = new ModuleVo[40];
        fitModules = new ModuleVo[3, 5];
        shopModules = new ModuleVo[7];
        moduleFuncValue = new int[40]{ 1, 2, 3, 4 ,5 
                                      ,1, 2, 3, 4 ,5
                                      ,3, 6, 9, 12 ,15
                                      ,10, 20, 30, 40 ,50
                                      ,1, 2, 3, 4 ,5
                                      ,5, 10, 15, 20 ,25
                                      ,21, 32, 11, 23 ,12
                                      ,5, 10, 15, 20 ,25 };
        Generate();
    }

    void Start()
    {
        RefreshShop();
    }

    void Generate()
    {
        for(int index=0;index< 40; index++)
        {
            ModuleVo module = new ModuleVo(index, 
                                            (ModuleVo.Name)(index / 5),
                                            moduleIcons[index], 
                                            (ModuleVo.Grade)(index % 5), 
                                            (ModuleVo.Type)(index / 5),
                                            moduleFuncValue[index],
                                            1000 * (index % 5+1), 
                                            20000 * (index % 5+1));
            moduleList[index] = module;
        }
       
    }

    void OnEnable()
    {
        fitModules[0,0] = saveManager.sFitModuleGun0 == -1 ? null : moduleList[saveManager.sFitModuleGun0];
        fitModules[0,1] = saveManager.sFitModuleGun1 == -1 ? null : moduleList[saveManager.sFitModuleGun1];
        fitModules[0,2] = saveManager.sFitModuleGun2 == -1 ? null : moduleList[saveManager.sFitModuleGun2];
        fitModules[0,3] = saveManager.sFitModuleGun3 == -1 ? null : moduleList[saveManager.sFitModuleGun3];
        fitModules[0,4] = saveManager.sFitModuleGun4 == -1 ? null : moduleList[saveManager.sFitModuleGun4];

        fitModules[1, 0] = saveManager.sFitModuleAcorn0 == -1 ? null : moduleList[saveManager.sFitModuleAcorn0];
        fitModules[1, 1] = saveManager.sFitModuleAcorn1 == -1 ? null : moduleList[saveManager.sFitModuleAcorn1];
        fitModules[1, 2] = saveManager.sFitModuleAcorn2 == -1 ? null : moduleList[saveManager.sFitModuleAcorn2];
        fitModules[1, 3] = saveManager.sFitModuleAcorn3 == -1 ? null : moduleList[saveManager.sFitModuleAcorn3];
        fitModules[1, 4] = saveManager.sFitModuleAcorn4 == -1 ? null : moduleList[saveManager.sFitModuleAcorn4];

        fitModules[2, 0] = saveManager.sFitModuleFame0 == -1 ? null : moduleList[saveManager.sFitModuleFame0];
        fitModules[2, 1] = saveManager.sFitModuleFame1 == -1 ? null : moduleList[saveManager.sFitModuleFame1];
        fitModules[2, 2] = saveManager.sFitModuleFame2 == -1 ? null : moduleList[saveManager.sFitModuleFame2];
        fitModules[2, 3] = saveManager.sFitModuleFame3 == -1 ? null : moduleList[saveManager.sFitModuleFame3];
        fitModules[2, 4] = saveManager.sFitModuleFame4 == -1 ? null : moduleList[saveManager.sFitModuleFame4];

        shopModules[0]=saveManager.sShopModule0 == -1 ? null : moduleList[saveManager.sShopModule0];
        shopModules[1]=saveManager.sShopModule1 == -1 ? null : moduleList[saveManager.sShopModule1];
        shopModules[2]=saveManager.sShopModule2 == -1 ? null : moduleList[saveManager.sShopModule2];
        shopModules[3]=saveManager.sShopModule3 == -1 ? null : moduleList[saveManager.sShopModule3];
        shopModules[4]=saveManager.sShopModule4 == -1 ? null : moduleList[saveManager.sShopModule4];
        shopModules[5]=saveManager.sShopModule5 == -1 ? null : moduleList[saveManager.sShopModule5];
    }

    public void RefreshShop()
    {
        //#0.Money Check
        if (isInitShop && gameManager.money < 10000)
        {
            uiManager.RefreshShop(shopModules, isInitShop);
            return;
        }

        //#1.Init Data
        for (int index = 0; index < 7; index++)
            shopModules[index] = null;

        //#2.ReSelect Data
        for (int index = 0; index < 7; index++)
        {
            if ((int)gameManager.grade + 3 > index)
            {
                while (true)
                {
                    int ranIndex = Random.Range(0, 40);
                    bool hasModule = false;

                    foreach (ModuleVo item in shopModules)
                    {
                        if (item == null)
                            break;

                        if (item.id == moduleList[ranIndex].id)
                        {
                            hasModule = true;
                            break;
                        }
                    }
                    if (!hasModule)
                    {
                        shopModules[index] = moduleList[ranIndex];
                        break;
                    }
                  
                }
            }
        }
        //#3.Cost Money
        if(isInitShop)
        gameManager.money -= 10000;

        //#4.ReSelect Data
        uiManager.RefreshShop(shopModules, isInitShop);

        //#5. Setting Flag
        isInitShop = true;

    }
}
