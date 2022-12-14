using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Rounds : MonoBehaviour
{
    public static int P1W = 0;
    public static int P2W = 0;
    [SerializeField] TextMeshProUGUI P1Wins;
    [SerializeField] TextMeshProUGUI P2Wins;
    void Start()
    {
        if(P1W >= 5)
        {
            //Go to P1 win screen
        }
        if(P2W >= 5)
        {
            SceneManager.LoadScene("LeonWinScene", LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void Update()
    {
        P1Wins.text = P1W.ToString();
        P2Wins.text = P2W.ToString();
    }
}
