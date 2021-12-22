using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Button button;
    void Start()
    {
        Time.timeScale=0;
        button.onClick.AddListener(runTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void runTime()
    {
        Time.timeScale=1;
        button.gameObject.SetActive(false);
    }
}
