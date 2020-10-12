using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Loding : MonoBehaviour
{
    public string sceneName = "MainScene"; //게임씬의 이름
    public Image LodingBar; //로딩바 이미지

    void Start()
    {
        StartCoroutine(Loging());
    }

    IEnumerator Loging()
    {
        yield return null;
        //비동기적 코루틴을 이용한 로딩화면
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName); 
        op.allowSceneActivation = false; //장면이 다 준비가 되었는가?

        float timer = 0.0f;

        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (op.progress < 0.9f)
            {
                //로딩중!
                LodingBar.fillAmount = Mathf.Lerp(LodingBar.fillAmount, op.progress, timer);
                if (LodingBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                //로딩바가 100퍼가 되면 로딩완료상태로 전환 준비완료
                LodingBar.fillAmount = Mathf.Lerp(LodingBar.fillAmount, 1f, timer);
                if (LodingBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}