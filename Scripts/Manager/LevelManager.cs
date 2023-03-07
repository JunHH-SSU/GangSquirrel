using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public UIManager uiManager;
    public SaveManager saveManager;

    public string[,] mission;
    public bool[] clearMission;

    void Awake()
    {
        Generate();
    }

    void Generate()
    {
        mission = new string[6, 5] { { "도토리 1000개 단련", "D등급 스태프 2명 고용", "시설 모듈 1개 설치", "크리티컬 3번 성공", "자금 백만원 확보" },
                                     { "도토리 5000개 단련", "C등급 스태프 2명 고용", "시설 모듈 2개 설치", "크리티컬 5번 성공", "자금 이백만원 확보" },
                                     { "도토리 10000개 단련", "B등급 스태프 2명 고용", "시설 모듈 3개 설치", "크리티컬 7번 성공", "자금 삼백만원 확보" },
                                     { "도토리 15000개 단련", "A등급 스태프 2명 고용", "시설 모듈 4개 설치", "크리티컬 9번 성공", "자금 천만원 확보" },
                                     { "도토리 20000개 단련", "A등급 스태프 5명 고용", "시설 모듈 5개 설치", "크리티컬 12번 성공", "자금 이천만원 확보" },
                                     { "모든 미션을 클리어 했습니다 !", "", "", "", "" }};
    }

    void OnEnable()
    {
        clearMission[0] = saveManager.sClearMission0;
        clearMission[1] = saveManager.sClearMission1;
        clearMission[2] = saveManager.sClearMission2;
        clearMission[3] = saveManager.sClearMission3;
        clearMission[4] = saveManager.sClearMission4;
    }

    void Update()
    {
        CheckMission();
        CheckGrade();
    }

    void CheckMission()
    {
        switch (gameManager.grade)
        {
            case GameManager.Grade.E:
                if(gameManager.acorn >= 1000)
                {
                    clearMission[0] = true;
                }
                if (gameManager.money >= 1000000)
                {
                    clearMission[4] = true;
                }
                break;
            case GameManager.Grade.D:
                break;
            case GameManager.Grade.C:
                break;
            case GameManager.Grade.B:
                break; 
        }
    }

    void CheckGrade()
    {
        int clearCount = 0;
        for(int index=0; index<5; index++)
        {
            if (clearMission[index])
            {
                clearCount++;
            }
        }

        if (clearCount == 5)
        {
            //#.Upgrade
            gameManager.grade++;
            uiManager.GradeUpdate();
            uiManager.AddModuleSocket();

            //#.Next Mission Init
            for (int index = 0; index < 5; index++)
            {
                clearMission[index] = false;
            }
            CheckMission();
        }
    }
}
