using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class levelPassScript : MonoBehaviour
{
    public float time = 0;

    public float maxTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SocreText").GetComponent<TMP_Text>().SetText("Score: " + LoadData.Score);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > maxTime){
            SceneManager.LoadScene(0);
        }
    }
}
