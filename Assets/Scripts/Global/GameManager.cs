using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletoneBase<GameManager>
{
    GameObject fadePrefab;
    GameObject fadeObj;

    public override void Init()
    {
        fadePrefab = Resources.Load<GameObject>("Prefabs/Fade_Canvas");
    }

    public void Ending()
    {
        Invoke(nameof(FadeOut), 2);
        Invoke(nameof(LoadEndingScene), 4f);
    }

    public void FadeOut()
    {
        if (fadeObj == null)
            fadeObj = Instantiate(fadePrefab, UIManager.Instance.UIObject.transform);

        fadeObj.SetActive(true);
        fadeObj.GetComponentInChildren<Image>().DOFade(1, 2f);
    }

    void LoadEndingScene()
    {
        SceneManager.LoadScene("EndingScene");
    }
}
