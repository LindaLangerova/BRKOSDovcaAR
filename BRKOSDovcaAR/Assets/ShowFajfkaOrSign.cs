using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFajfkaOrSign : MonoBehaviour {

    public GameObject Fajfka;
    public GameObject Sign;

    void Start() {
        Fajfka.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Sign.activeSelf) { Fajfka.SetActive(true);}
    }
}
