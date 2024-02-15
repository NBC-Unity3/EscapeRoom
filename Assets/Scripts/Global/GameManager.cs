using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletoneBase<GameManager>
{
    GameObject fadeObj;

    public override void Init()
    {
        GameObject fadePrefab = Resources.Load<GameObject>("Prefabs/Fade_Canvas");
        fadeObj = Instantiate(fadePrefab, UIManager.Instance.UIObject.transform);
        fadeObj.SetActive(false);
    }

    public void Ending()
    {
        Invoke(nameof(FadeOut), 2);
        Invoke(nameof(LoadEndingScene), 4f);
    }

    public void FadeOut()
    {
        fadeObj.SetActive(true);
        fadeObj.GetComponentInChildren<Image>().DOFade(1, 2f);
    }

    void LoadEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
