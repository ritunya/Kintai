using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetPoster : MonoBehaviour
{
    private const string postUrl = "AKfycbyncfubC-TmWYnVQhs86Kkc6JhOU4h2HjZeXHGCWsEV76PebZ7SIZMZiAJBEMCKk8h8";
    DateTime dt;

    [System.Serializable]
    public class Data
    {
        public string name;
        public string shukkin;
    }

    public Data dataToSend;

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

    IEnumerator PostData(string username, string time)
    {
        Debug.Log("データ送信開始・・・");
        var form = new WWWForm();
        form.AddField("name", username);
        form.AddField("shukkin", time);

        string jsonData = JsonUtility.ToJson(dataToSend);
        UnityWebRequest request = UnityWebRequest.Post(postUrl, form);
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Data sent successfully");
            Debug.Log("Name：" + username + "、shukkin：" + time);
        }
        else
        {
            Debug.LogError("Failed to send data: " + request.error);
        }
    }
}
