using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class GetTime : MonoBehaviour
{
    [SerializeField] private string accessKey = "AKfycbyncfubC-TmWYnVQhs86Kkc6JhOU4h2HjZeXHGCWsEV76PebZ7SIZMZiAJBEMCKk8h8";
    DateTime dt;

    public void OnClick() //出勤
    {
        dt = DateTime.Now;
        //コンソールに表示
        Debug.Log(dt);
        string date0 = dt.ToString();
        StartCoroutine(PostData("watanabe", date0));
    }
    public void OnClick1() //退勤
    {
        dt = DateTime.Now;
        //コンソールに表示
        Debug.Log(dt);
        string date1 = dt.ToString();
        StartCoroutine(PostData("watanabe", date1));
    }
    private IEnumerator PostData(string username, string time)
    {
        Debug.Log("データ送信開始・・・");
        var form = new WWWForm();
        form.AddField("name", username);
        form.AddField("shukkin", time);

        var request = UnityWebRequest.Post(accessKey, form);

        yield return request.SendWebRequest();
        //yield return null;

        if (request.result == UnityWebRequest.Result.Success)
        {
            if (request.responseCode == 200)
            {
                //var records = JsonUtility.FromJson<Records>(request.downloadHandler.text).records;
                Debug.Log("データ送信成功！");
                //foreach (var record in records)
                {
                    Debug.Log("Name：" + username + "、shukkin：" + time);
                }
            }
            else
            {
                Debug.LogError("データ送信失敗" + request.responseCode);
            }
        }
        else
        {
            Debug.Log("データ送信失敗だよ。。" + request.result);
        }
    }
}