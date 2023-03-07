using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillVo
{
    public int _id;
    public Sprite _icon;
    public string _name;
    public int _level;
    public int[] _nextPoint;
    public float[] _func;
    public string[] _funcDesc;
    public string _content;

    public SkillVo(int id,Sprite icon,string name,int level, int[] nextPoint, float[] func, string[] funcDesc, string content)
    {
        _id = id;
        _icon = icon;
        _name = name;
        _level = level;
        _nextPoint = nextPoint;
        _func = func;
        _funcDesc = funcDesc;  
        _content = content;

    }
}
