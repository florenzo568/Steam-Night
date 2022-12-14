using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LeonWin : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI WinQuote;
    public string Quote1;
    public string Quote2;
    public float i;
    void Start()
    {
        i = Random.Range(1f,2f);
        if(i <= 1.5f)
        {
            WinQuote.text = Quote1;
        }
        if(i > 1.5f)
        {
            WinQuote.text = Quote2;
        }
    }

    // Update is called once per frame
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu Scene", LoadSceneMode.Single);
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credits Scene", LoadSceneMode.Single);
    }
}
