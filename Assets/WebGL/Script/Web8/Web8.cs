using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;
using UnityEngine.Networking;using UnityEngine.SceneManagement;
// vacation
public class Web8 : MonoBehaviour
{
    public InputField if_date, if_text;
    public Text t_news_ok;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClickExit(){SceneManager.LoadScene("Web");}
    public void ClickCreateVac(){StartCoroutine(CreateVac(if_date.text,if_text.text));}

    IEnumerator CreateVac(string date1, string text) {
        WWWForm form = new WWWForm();
        form.AddField("date1", date1);
        form.AddField("text", text);
        UnityWebRequest www = UnityWebRequest.Post("https://playklin.000webhostapp.com/yk/CreateVac.php", form);
        {yield return www.SendWebRequest();if (www.isNetworkError || www.isHttpError){Debug.Log(www.error);}else{
        //Debug.Log("" + www.downloadHandler.text);
        t_news_ok.text = "OK";SceneManager.LoadScene("Web8");}
        }
    }

    // Push notification

    //public InputField if_text;// if_subtext;
    public void ClickPush(){StartCoroutine(PushNot(if_text.text,"Вакансии ",""));}

    IEnumerator PushNot(string text, string subtext, string url){WWWForm form = new WWWForm(); 
        //form.AddField("id", id);
        form.AddField("text", text); form.AddField("subtext", subtext); form.AddField("url", url);
        //using (UnityWebRequest www = UnityWebRequest.Post("http://p905504y.beget.tech/notification1.php",form))
        using (UnityWebRequest www = UnityWebRequest.Post("https://playklin.000webhostapp.com/notificationYK.php",form))
        {yield return www.SendWebRequest(); if (www.isNetworkError || www.isHttpError) { Debug.Log(www.error);}else{
        //Debug.Log("" + www.downloadHandler.text);
        //t_debugLog.text = www.downloadHandler.text;
        }}
    }
}
