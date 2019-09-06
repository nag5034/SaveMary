using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resetGame : MonoBehaviour {

    public Button restartBtn;

    // Use this for initialization
    void Start()
    {
        Button restart = restartBtn.GetComponent<Button>();
        restart.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Restart()
    {
        SceneManager.LoadScene("scene1", LoadSceneMode.Single);
        //maryRunning.instance.Restart();
    }
}
