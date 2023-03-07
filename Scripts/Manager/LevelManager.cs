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
        mission = new string[6, 5] { { "���丮 1000�� �ܷ�", "D��� ������ 2�� ���", "�ü� ��� 1�� ��ġ", "ũ��Ƽ�� 3�� ����", "�ڱ� �鸸�� Ȯ��" },
                                     { "���丮 5000�� �ܷ�", "C��� ������ 2�� ���", "�ü� ��� 2�� ��ġ", "ũ��Ƽ�� 5�� ����", "�ڱ� �̹鸸�� Ȯ��" },
                                     { "���丮 10000�� �ܷ�", "B��� ������ 2�� ���", "�ü� ��� 3�� ��ġ", "ũ��Ƽ�� 7�� ����", "�ڱ� ��鸸�� Ȯ��" },
                                     { "���丮 15000�� �ܷ�", "A��� ������ 2�� ���", "�ü� ��� 4�� ��ġ", "ũ��Ƽ�� 9�� ����", "�ڱ� õ���� Ȯ��" },
                                     { "���丮 20000�� �ܷ�", "A��� ������ 5�� ���", "�ü� ��� 5�� ��ġ", "ũ��Ƽ�� 12�� ����", "�ڱ� ��õ���� Ȯ��" },
                                     { "��� �̼��� Ŭ���� �߽��ϴ� !", "", "", "", "" }};
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
