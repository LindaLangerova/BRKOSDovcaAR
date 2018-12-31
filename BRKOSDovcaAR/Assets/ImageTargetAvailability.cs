using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetAvailability : MonoBehaviour {

    public UIcontroller UIController;
    public GameObject ImageTargetA;
    public GameObject ImageTargetB;
    public GameObject ImageTargetC;
    public GameObject ImageTargetDocToSign;
    public GameObject ImageTargetD;
    public GameObject ImageTargetE;
    public GameObject ImageTargetF;
    public GameObject ImageTargetG;

    private string _currentActivePlace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (_currentActivePlace != UIController._actualPlace.Name) {
            _currentActivePlace = UIController._actualPlace.Name;

            ImageTargetA.SetActive(false);
            ImageTargetB.SetActive(false);
            //ImageTargetC.SetActive(false);
            ImageTargetD.SetActive(false);
            ImageTargetF.SetActive(false);
            ImageTargetG.SetActive(false);

            switch (_currentActivePlace)
            {
                case Places.CHODBA:
                    ImageTargetA.SetActive(true);
                    break;

                case Places.RECEPCE:
                    ImageTargetB.SetActive(true);
                    break;

                case Places.POKOJ:
                    ImageTargetC.SetActive(true);
                    break;

                case Places.VYTAH:
                    ImageTargetD.SetActive(true);
                    break;

                case Places.VYTAH2:
                    ImageTargetD.SetActive(true);
                    break;

                case Places.ZASTAVKA:
                    ImageTargetF.SetActive(true);
                    break;

                case Places.PLAZ:
                    ImageTargetG.SetActive(true);
                    break;
            }
        }
    }
}
