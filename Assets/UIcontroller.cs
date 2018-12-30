using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Text Title;
    public Text MainText;
    
    public Environment _actualPlace;
    public Places _places;

    public void MakePokojAvailable() {
        _places.Pokoj.Availabile = true;
        _places.Chodba.Button1.GoTo = Places.POKOJ;
        _places.Chodba.Button1.Enabled = true;
        ChangePlace(Places.CHODBA);
    }

    public void RepairVytah() {
        _places.Vytah.State = 1;
        GameObject.Find("VytahText").GetComponent<TextMesh>().text = "";
        ChangePlace(_actualPlace.Name);
    }

    public void Ubytovat() {
        _places.Pokoj.State = 1;
        _places.Jidelna.State = 1;
        ChangePlace(_actualPlace.Name);
    }

    public void DestroyCastle() {
        _places.Plaz.State = 1;
        ChangePlace(_actualPlace.Name);
    }

    public void CutOutBags() {
        _places.PredHotelem.State = 1;
        _places.PredHotelem.Button3.Enabled = true;
        ChangePlace(_actualPlace.Name);
    }

    public void ChangePlace(string newPlace)
    {
        switch (newPlace)
        {
            case Places.VSTUPNI_HALA:
                _actualPlace = _places.VstupniHala;
                break;
            case Places.PRED_HOTELEM:
                _actualPlace = _places.PredHotelem;
                break;
            case Places.PLAZ:
                _actualPlace = _places.Plaz;
                break;
            case Places.ZASTAVKA:
                _actualPlace = _places.PrijezdovaZastavka;
                break;
            case Places.K_POKOJUM:
                _actualPlace = _places.KPokojum;
                break;
            case Places.SCHODY:
                _actualPlace = _places.Schody;
                break;
            case Places.VYTAH:
                _actualPlace = _places.Vytah;
                break;
            case Places.VYTAH2:
                _actualPlace = _places.Vytah2;
                break;
            case Places.CHODBA:
                _actualPlace = _places.Chodba;
                break;
            case Places.POKOJ:
                _actualPlace = _places.Pokoj;
                break;
            case Places.RECEPCE:
                _actualPlace = _places.Recepce;
                break;
            case Places.BAZEN:
                _actualPlace = _places.Bazen;
                break;
            case Places.JIDELNA:
                _actualPlace = _places.Jidelna;
                break;
            case Places.BAR:
                _actualPlace = _places.Bar;
                break;
            default: break;
        }
        
        Button1.onClick.RemoveAllListeners();
        Button1.onClick.AddListener(() => ChangePlace(_actualPlace.Button1.GoTo));
        GameObject.Find("Label1").GetComponent<Text>().text = _actualPlace.Button1.Label;
        Button1.interactable = _actualPlace.Button1.Enabled;
        
        Button2.onClick.RemoveAllListeners();
        Button2.onClick.AddListener(() => ChangePlace(_actualPlace.Button2.GoTo));
        GameObject.Find("Label2").GetComponent<Text>().text = _actualPlace.Button2.Label;
        Button2.interactable = _actualPlace.Button2.Enabled;

        Button3.onClick.RemoveAllListeners();
        Button3.onClick.AddListener(() => ChangePlace(_actualPlace.Button3.GoTo));
        GameObject.Find("Label3").GetComponent<Text>().text = _actualPlace.Button3.Label;
        Button3.interactable = _actualPlace.Button3.Enabled;

        Button4.onClick.RemoveAllListeners();
        Button4.onClick.AddListener(() => ChangePlace(_actualPlace.Button4.GoTo));
        GameObject.Find("Label4").GetComponent<Text>().text = _actualPlace.Button4.Label;
        Button4.interactable = _actualPlace.Button4.Enabled;

        Title.text = _actualPlace.Name;
        MainText.text = _actualPlace.Texts[_actualPlace.State];
    }

    // Start is called before the first frame update
    void Awake() {
        _actualPlace = new Environment();
        _places = new Places();
        ChangePlace(Places.PRED_HOTELEM);
    }

    // Update is called once per frame
    void Update() {
        this.enabled = true;
    }
}
