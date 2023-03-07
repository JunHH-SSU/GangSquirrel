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
        SkillVo Skill0 = new SkillVo(0, skillIcons[0], "작업량 증가", 0, new int[] { 1, 3, 5, 7, 9 },
                                        new float[] { 1,2,3,4,5,6},
                                        new string[] { "작업량 증가+10%",
                                                       "작업량 증가+20%",
                                                       "작업량 증가+30%",
                                                       "작업량 증가+40%",
                                                       "작업량 증가+50%",
                                                       "작업량 증가+60%"},
                                        "클릭당 작업량 \n 효율 증가");
        SkillVo Skill1 = new SkillVo(1, skillIcons[1], "대성공 확률 증가", 0, new int[] { 2,4,6,8,10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "대성공 확률+1%",
                                                       "대성공 확률+2%",
                                                       "대성공 확률+3%",
                                                       "대성공 확률+4%",
                                                       "대성공 확률+5%",
                                                       "대성공 확률+6%"},
                                       "대성공 \n 확률 증가");
        SkillVo Skill2 = new SkillVo(2, skillIcons[2], "자원 배율 증가", 0, new int[] { 2, 4, 6, 8, 10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "자원 배율 증가+1%",
                                                       "자원 배율 증가+2%",
                                                       "자원 배율 증가+3%",
                                                       "자원 배율 증가+4%",
                                                       "자원 배율 증가+5%",
                                                       "자원 배율 증가+6%"},
                                       "대성공 자원 \n 배율 증가");
        SkillVo Skill3 = new SkillVo(3, skillIcons[3], "클릭 경험치 증가", 0, new int[] { 3,5,7,9,11 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "경험치 증가+10%",
                                                       "경험치 증가+20%",
                                                       "경험치 증가+30%",
                                                       "경험치 증가+40%",
                                                       "경험치 증가+50%",
                                                       "경험치 증가+60%"},
                                       "클릭 \n 경험치 증가");
        SkillVo Skill4 = new SkillVo(4, skillIcons[4], "신의 손가락", 0, new int[] { 4,6,8,10,12 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] { "더블 클릭 확률+1%",
                                                       "더블 클릭 확률+2%",
                                                       "더블 클릭 확률+3%",
                                                       "더블 클릭 확률+4%",
                                                       "더블 클릭 확률+5%",
                                                       "더블 클릭 확률+6%"},
                                       "더블 클릭 \n 확률 증가");

        SkillVo Skill5 = new SkillVo(5, skillIcons[5], "스태프 효율 증가", 0, new int[] { 1, 3, 5, 7, 9 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "효율 증가+10%",
                                                       "효율 증가+20%",
                                                       "효율 증가+30%",
                                                       "효율 증가+40%",
                                                       "효율 증가+50%",
                                                       "효율 증가+60%"},
                                       "스태프 \n 효율 증가");
        SkillVo Skill6 = new SkillVo(6, skillIcons[6], "관리비 축소", 0, new int[] { 2, 4, 6, 8, 10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "스태프 관리비 1%",
                                                       "스태프 관리비 2%",
                                                       "스태프 관리비 3%",
                                                       "스태프 관리비 4%",
                                                       "스태프 관리비 5%",
                                                       "스태프 관리비 6%"},
                                        "스태프 \n 관리비 축소");
        SkillVo Skill7 = new SkillVo(7, skillIcons[7], "심층 캐스팅", 0, new int[] { 2, 4, 6, 8, 10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "뽑기 확률 증가+1%",
                                                       "뽑기 확률 증가+2%",
                                                       "뽑기 확률 증가+3%",
                                                       "뽑기 확률 증가+4%",
                                                       "뽑기 확률 증가+5%",
                                                       "뽑기 확률 증가+6%"},
                                       "고급 뽑기 \n 확률 증가");
        SkillVo Skill8 = new SkillVo(8, skillIcons[8], "다중 계약", 0, new int[] { 3, 5, 7, 9, 11 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "상점 판매수 증가+1",
                                                       "상점 판매수 증가+2",
                                                       "상점 판매수 증가+3",
                                                       "상점 판매수 증가+4",
                                                       "상점 판매수 증가+5",
                                                       "상점 판매수 증가+6"},
                                       "상점 \n 판매수 증가");
        SkillVo Skill9 = new SkillVo(9, skillIcons[9], "효율적 관리", 0, new int[] { 4, 6, 8, 10, 12 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "모듈 관리비 1%",
                                                       "모듈 관리비 2%",
                                                       "모듈 관리비 3%",
                                                       "모듈 관리비 4%",
                                                       "모듈 관리비 5%",
                                                       "모듈 관리비 6%"},
                                       "모듈 \n 관리비 감소");

        SkillVo Skill10 = new SkillVo(10, skillIcons[10], "물가 방어", 0, new int[] { 1, 3, 5, 7, 9 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "물가 인상율 감소 0%",
                                                       "물가 인상율 감소 1%",
                                                       "물가 인상율 감소 1.5%",
                                                       "물가 인상율 감소 2%",
                                                       "물가 인상율 감소 2.5%",
                                                       "물가 인상율 감소 3%"},
                                       "매년 물가 \n 인상율 감소");
        SkillVo Skill11 = new SkillVo(11, skillIcons[11], "명성 감소 저항", 0, new int[] { 2, 4, 6, 8, 10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "명성 감소 1%",
                                                       "명성 감소 2%",
                                                       "명성 감소 3%",
                                                       "명성 감소 4%",
                                                       "명성 감소 5%",
                                                       "명성 감소 6%"},
                                       "명성 감소 \n 저항 증가");
        SkillVo Skill12 = new SkillVo(12, skillIcons[12], "퇴사 감소", 0, new int[] { 2, 4, 6, 8, 10 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "감소 1%",
                                                       "감소 2%",
                                                       "감소 3%",
                                                       "감소 4%",
                                                       "감소 5%",
                                                       "감소 6%"},
                                       "스태프 \n 퇴사 감소");
        SkillVo Skill13 = new SkillVo(13, skillIcons[13], "월말 보너스 증가", 0, new int[] { 3, 5, 7, 9, 11 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "월말 보너스 증가+1%",
                                                       "월말 보너스 증가+2%",
                                                       "월말 보너스 증가+3%",
                                                       "월말 보너스 증가+4%",
                                                       "월말 보너스 증가+5%",
                                                       "월말 보너스 증가+6%"},
                                       "월말 \n 보너스 증가");
        SkillVo Skill14 = new SkillVo(14, skillIcons[14], "도토리 보장", 0, new int[] { 4, 6, 8, 10, 12 },
                                       new float[] { 2, 5, 8, 11, 15, 20 },
                                       new string[] {  "도토리 최저가 0원",
                                                       "도토리 최저가 1000원",
                                                       "도토리 최저가 1500원",
                                                       "도토리 최저가 2000원",
                                                       "도토리 최저가 2500원",
                                                       "도토리 최저가 3000원"},
                                       "도토리 \n 최저가 보장");

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
