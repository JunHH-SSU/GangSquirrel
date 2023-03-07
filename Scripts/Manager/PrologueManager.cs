using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PrologueManager : MonoBehaviour
{
    public Transform[] cartoons;
    public int page;

    public Button LeftBtn;
    public Button RightBtn;
    public Button InGameBtn;
    public Image fadeImg;

    private void Start()
    {
        LeftBtn.enabled = false;
    }

    public void LeftBtnClick()
    {
     
        page--;
        cartoons[page].DOMoveY(540, 0.5f).SetEase(Ease.OutBack);

      
        if (page == 3)
        {
            InGameBtn.gameObject.SetActive(false);
            RightBtn.gameObject.SetActive(true);
        }
        

        if (page == 0)
        {
            LeftBtn.enabled = false;
            return;
        }
        else
        {
            LeftBtn.enabled = true;
        }
    }

    public void RightBtnClick()
    {
      
        cartoons[page].DOMoveY(2000, 0.5f).SetEase(Ease.InBack);
        page++;
        LeftBtn.enabled = true;

        if (page == 4)
        {
            //End Btn Visible
            RightBtn.gameObject.SetActive(false);
            InGameBtn.gameObject.SetActive(true);
        }
    }

    public void InGameBtnClick()
    {
        fadeImg.gameObject.SetActive(true);
        fadeImg.DOFade(1, 1).SetEase(Ease.InQuad);
        Invoke("NextScene", 2);
    }

    void NextScene()
    {
        SceneManager.LoadScene(2);
    }
}
