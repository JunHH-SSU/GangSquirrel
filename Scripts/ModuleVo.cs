using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleVo 
{
    public enum Name { 클릭효율, 클릭대성공, 프런트데스크, 캐스팅보드, 경험치증폭, 갱단업그레이드, 도토리단련기, 명성유지 };
    public enum Grade { E,D,C,B,A};
    public enum Type { ClickEff, ClickCri, StaffEff, StaffCap, Exp, GunEff, AcornRate, FameDef};

    public int id;
    public Name name;
    public Sprite icon;
    public Grade grade;
    public Type type;
    public float func;
    public int adminCost;
    public int buyCost;

    public ModuleVo(int ID, Name NAME, Sprite ICON, Grade GRADE, Type TYPE, float FUNC, int ADMINCOST, int BUYCOST)
    {
        id = ID;
        name = NAME;    
        icon = ICON;
        grade = GRADE;
        type = TYPE;
        func = FUNC;
        adminCost = ADMINCOST;
        buyCost = BUYCOST;
    }
}
