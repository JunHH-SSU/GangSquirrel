using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public SaveManager saveManager;

    public Sprite[] skillIcons;
    public SkillVo selectedSkill;
    public SkillVo[] skillList;
   
    void Awake()
    {
        skillList = new SkillVo[15];
        Generate();
    }

    public SkillVo GetSkill(int id)
    {
        return skillList[id] ;
    }

    public void SkillUp(int id)
    {
        skillList[id]._level++;
    }

    void Generate()
    {
        SkillVo Skill0 = new SkillVo(0, skillIcons[0], "�۾��� ����", 0, new int[] { 1, 3, 5, 7, 9 },
                                        new float[] { 1,2,3,4,5,6},
                                        new string[] { "�۾��� ����+10%",
                                                       "�۾��� ����+20%",
                                                       "�۾��� ����+30%",
                                                       "�۾��� ����+40%",
                                                       "�۾��� ����+50%",
                                                       "�۾��� ����+60%"},
                                        "Ŭ���� �۾��� \n ȿ�� ����");
        SkillVo Skill1 = new SkillVo(1, skillIcons[1], "�뼺�� Ȯ�� ����", 0, new int[] { 2,4,6,8,10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "�뼺�� Ȯ��+1%",
                                                       "�뼺�� Ȯ��+2%",
                                                       "�뼺�� Ȯ��+3%",
                                                       "�뼺�� Ȯ��+4%",
                                                       "�뼺�� Ȯ��+5%",
                                                       "�뼺�� Ȯ��+6%"},
                                       "�뼺�� \n Ȯ�� ����");
        SkillVo Skill2 = new SkillVo(2, skillIcons[2], "�ڿ� ���� ����", 0, new int[] { 2, 4, 6, 8, 10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "�ڿ� ���� ����+1%",
                                                       "�ڿ� ���� ����+2%",
                                                       "�ڿ� ���� ����+3%",
                                                       "�ڿ� ���� ����+4%",
                                                       "�ڿ� ���� ����+5%",
                                                       "�ڿ� ���� ����+6%"},
                                       "�뼺�� �ڿ� \n ���� ����");
        SkillVo Skill3 = new SkillVo(3, skillIcons[3], "Ŭ�� ����ġ ����", 0, new int[] { 3,5,7,9,11 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "����ġ ����+10%",
                                                       "����ġ ����+20%",
                                                       "����ġ ����+30%",
                                                       "����ġ ����+40%",
                                                       "����ġ ����+50%",
                                                       "����ġ ����+60%"},
                                       "Ŭ�� \n ����ġ ����");
        SkillVo Skill4 = new SkillVo(4, skillIcons[4], "���� �հ���", 0, new int[] { 4,6,8,10,12 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] { "���� Ŭ�� Ȯ��+1%",
                                                       "���� Ŭ�� Ȯ��+2%",
                                                       "���� Ŭ�� Ȯ��+3%",
                                                       "���� Ŭ�� Ȯ��+4%",
                                                       "���� Ŭ�� Ȯ��+5%",
                                                       "���� Ŭ�� Ȯ��+6%"},
                                       "���� Ŭ�� \n Ȯ�� ����");

        SkillVo Skill5 = new SkillVo(5, skillIcons[5], "������ ȿ�� ����", 0, new int[] { 1, 3, 5, 7, 9 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "ȿ�� ����+10%",
                                                       "ȿ�� ����+20%",
                                                       "ȿ�� ����+30%",
                                                       "ȿ�� ����+40%",
                                                       "ȿ�� ����+50%",
                                                       "ȿ�� ����+60%"},
                                       "������ \n ȿ�� ����");
        SkillVo Skill6 = new SkillVo(6, skillIcons[6], "������ ���", 0, new int[] { 2, 4, 6, 8, 10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "������ ������ 1%",
                                                       "������ ������ 2%",
                                                       "������ ������ 3%",
                                                       "������ ������ 4%",
                                                       "������ ������ 5%",
                                                       "������ ������ 6%"},
                                        "������ \n ������ ���");
        SkillVo Skill7 = new SkillVo(7, skillIcons[7], "���� ĳ����", 0, new int[] { 2, 4, 6, 8, 10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "�̱� Ȯ�� ����+1%",
                                                       "�̱� Ȯ�� ����+2%",
                                                       "�̱� Ȯ�� ����+3%",
                                                       "�̱� Ȯ�� ����+4%",
                                                       "�̱� Ȯ�� ����+5%",
                                                       "�̱� Ȯ�� ����+6%"},
                                       "��� �̱� \n Ȯ�� ����");
        SkillVo Skill8 = new SkillVo(8, skillIcons[8], "���� ���", 0, new int[] { 3, 5, 7, 9, 11 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "���� �Ǹż� ����+1",
                                                       "���� �Ǹż� ����+2",
                                                       "���� �Ǹż� ����+3",
                                                       "���� �Ǹż� ����+4",
                                                       "���� �Ǹż� ����+5",
                                                       "���� �Ǹż� ����+6"},
                                       "���� \n �Ǹż� ����");
        SkillVo Skill9 = new SkillVo(9, skillIcons[9], "ȿ���� ����", 0, new int[] { 4, 6, 8, 10, 12 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "��� ������ 1%",
                                                       "��� ������ 2%",
                                                       "��� ������ 3%",
                                                       "��� ������ 4%",
                                                       "��� ������ 5%",
                                                       "��� ������ 6%"},
                                       "��� \n ������ ����");

        SkillVo Skill10 = new SkillVo(10, skillIcons[10], "���� ���", 0, new int[] { 1, 3, 5, 7, 9 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "���� �λ��� ���� 0%",
                                                       "���� �λ��� ���� 1%",
                                                       "���� �λ��� ���� 1.5%",
                                                       "���� �λ��� ���� 2%",
                                                       "���� �λ��� ���� 2.5%",
                                                       "���� �λ��� ���� 3%"},
                                       "�ų� ���� \n �λ��� ����");
        SkillVo Skill11 = new SkillVo(11, skillIcons[11], "�� ���� ����", 0, new int[] { 2, 4, 6, 8, 10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "�� ���� 1%",
                                                       "�� ���� 2%",
                                                       "�� ���� 3%",
                                                       "�� ���� 4%",
                                                       "�� ���� 5%",
                                                       "�� ���� 6%"},
                                       "�� ���� \n ���� ����");
        SkillVo Skill12 = new SkillVo(12, skillIcons[12], "��� ����", 0, new int[] { 2, 4, 6, 8, 10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "���� 1%",
                                                       "���� 2%",
                                                       "���� 3%",
                                                       "���� 4%",
                                                       "���� 5%",
                                                       "���� 6%"},
                                       "������ \n ��� ����");
        SkillVo Skill13 = new SkillVo(13, skillIcons[13], "���� ���ʽ� ����", 0, new int[] { 3, 5, 7, 9, 11 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "���� ���ʽ� ����+1%",
                                                       "���� ���ʽ� ����+2%",
                                                       "���� ���ʽ� ����+3%",
                                                       "���� ���ʽ� ����+4%",
                                                       "���� ���ʽ� ����+5%",
                                                       "���� ���ʽ� ����+6%"},
                                       "���� \n ���ʽ� ����");
        SkillVo Skill14 = new SkillVo(14, skillIcons[14], "���丮 ����", 0, new int[] { 4, 6, 8, 10, 12 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "���丮 ������ 0��",
                                                       "���丮 ������ 1000��",
                                                       "���丮 ������ 1500��",
                                                       "���丮 ������ 2000��",
                                                       "���丮 ������ 2500��",
                                                       "���丮 ������ 3000��"},
                                       "���丮 \n ������ ����");

        skillList[0] = Skill0;
        skillList[1] = Skill1;
        skillList[2] = Skill2;
        skillList[3] = Skill3;
        skillList[4] = Skill4;
        skillList[5] = Skill5;
        skillList[6] = Skill6;
        skillList[7] = Skill7;
        skillList[8] = Skill8;
        skillList[9] = Skill9;
        skillList[10] = Skill10;
        skillList[11] = Skill11;
        skillList[12] = Skill12;
        skillList[13] = Skill13;
        skillList[14] = Skill14;
    }

    void OnEnable()
    {
        skillList[0]._level = saveManager.sSkillLevel0;
        skillList[1]._level = saveManager.sSkillLevel1;
        skillList[2]._level = saveManager.sSkillLevel2;
        skillList[3]._level = saveManager.sSkillLevel3;
        skillList[4]._level = saveManager.sSkillLevel4;
        skillList[5]._level = saveManager.sSkillLevel5;
        skillList[6]._level = saveManager.sSkillLevel6;
        skillList[7]._level = saveManager.sSkillLevel7;
        skillList[8]._level = saveManager.sSkillLevel8;
        skillList[9]._level = saveManager.sSkillLevel9;
        skillList[10]._level = saveManager.sSkillLevel10;
        skillList[11]._level = saveManager.sSkillLevel11;
        skillList[12]._level = saveManager.sSkillLevel12;
        skillList[13]._level = saveManager.sSkillLevel13;
        skillList[14]._level = saveManager.sSkillLevel14;
    }
}
