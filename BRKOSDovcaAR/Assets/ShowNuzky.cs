using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNuzky : MonoBehaviour {

    public GameObject Nuzky;
    public GameObject Hrouda;
    public GameObject Hrad;
    

    // Update is called once per frame
    void Update()
    {
        if (!Hrad.activeSelf && !Hrouda.activeSelf) {
            Nuzky.SetActive(true);
            Hrouda.SetActive(true);
        } 
    }
}
