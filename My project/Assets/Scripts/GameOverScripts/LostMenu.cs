using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LostMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text text = GameObject.Find("SocreText").GetComponent<TMP_Text>();
        text.SetText("Score: " + LoadData.Score);
    }

    void ReplayButton(){

        LoadData.Score = 0;

        SceneManager.LoadScene(0);
    }



}
