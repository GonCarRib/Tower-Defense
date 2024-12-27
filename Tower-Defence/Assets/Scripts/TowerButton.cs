using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    public GameObject TorreB;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
       
        button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        UIJogador.Torre = TorreB;
    }
}
