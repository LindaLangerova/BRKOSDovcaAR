using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWin : MonoBehaviour {

    public GameObject WinWindow;
    public UIcontroller Uicontroller;

    // Update is called once per frame
    void Update()
    {
        if (Uicontroller._actualPlace.Name == Places.JIDELNA && Uicontroller._actualPlace.State == 1) {
            WinWindow.SetActive(true);
        }
    }
}
