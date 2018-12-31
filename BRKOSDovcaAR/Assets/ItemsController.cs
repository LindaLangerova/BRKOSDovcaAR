using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ItemsController : MonoBehaviour {

    public float RayLength;
    public LayerMask LayerMask;

    private Color _transparent = new Color(1, 1, 1, 0);
    private Color _notTransparent = new Color(1, 1, 1, 1);
    public NumberController NumberController;

    private UIcontroller _uicontroller;

    private List<ParametrizedItem> _heldItems;
    
    private Image _itemBoxImage1;
    private Image _itemBoxImage2;
    private Image _itemBoxImage3;
    private Image _itemBoxImage4;
    private Image _itemBoxImage5;
    private Image _itemBoxImage6;

    private bool _shouldGetKufr;
    private string _kufrPosition;

    // Start is called before the first frame update
    void Start() {
        _uicontroller = GameObject.Find("UIcontrollerComponent").GetComponent<UIcontroller>();
        _heldItems = new List<ParametrizedItem>();
        _itemBoxImage1 = GameObject.Find("ItemBoxImage1").GetComponent<Image>();
        _itemBoxImage2 = GameObject.Find("ItemBoxImage2").GetComponent<Image>();
        _itemBoxImage3 = GameObject.Find("ItemBoxImage3").GetComponent<Image>();
        _itemBoxImage4 = GameObject.Find("ItemBoxImage4").GetComponent<Image>();
        _itemBoxImage5 = GameObject.Find("ItemBoxImage5").GetComponent<Image>();
        _itemBoxImage6 = GameObject.Find("ItemBoxImage6").GetComponent<Image>();

        _shouldGetKufr = true;
        HandleItemChange();
    }

    // Update is called once per frame
    void Update() {
       
        if (_kufrPosition == Places.POKOJ && _heldItems.Contains(Items.KufrRozbaleny)) {
            _kufrPosition = "";
        }

        if (_shouldGetKufr) {
            Debug.Log("Should get kufr = " + _shouldGetKufr);
            _heldItems.Add(Items.KufrZabaleny);
            _shouldGetKufr = false;
            HandleItemChange();
        }

        switch (_uicontroller._actualPlace.Name) {
            case Places.SCHODY:
                if (_heldItems.Contains(Items.KufrRozbaleny))
                {
                    _heldItems.Remove(Items.KufrRozbaleny);
                    HandleItemChange();
                }
                break;

            case Places.K_POKOJUM:
                if (!_heldItems.Contains(Items.KufrRozbaleny) && _kufrPosition == Places.K_POKOJUM)
                {
                    _heldItems.Add(Items.KufrRozbaleny);
                    HandleItemChange();
                }
                break;

            case Places.CHODBA:
                if (!_heldItems.Contains(Items.KufrRozbaleny) && _kufrPosition == Places.CHODBA)
                {
                    _heldItems.Add(Items.KufrRozbaleny);
                    HandleItemChange();
                }
                break;
        }

        _kufrPosition = _heldItems.Contains(Items.KufrRozbaleny) ? _uicontroller._actualPlace.Name : _kufrPosition;
        Debug.Log("'Kufr position is: " + _kufrPosition);

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, RayLength, LayerMask)) {

                switch (hit.collider.name) {
                    case "PropiskaCollider":
                        GameObject.Find("PropiskaCollider").SetActive(false);
                        if (!_heldItems.Contains(Items.Propiska)) {
                            _heldItems.Add(Items.Propiska);
                            HandleItemChange();
                        }
                        
                        break;
                    case "KlicCollider":
                        GameObject.Find("KlicCollider").SetActive(false);
                        if (!_heldItems.Contains(Items.Klic)) {
                            _heldItems.Add(Items.Klic);
                            HandleItemChange();
                        }

                        break;
                    case "NuzkyCollider":
                        GameObject.Find("NuzkyCollider").SetActive(false);
                        if (!_heldItems.Contains(Items.Nuzky)) {
                            _heldItems.Add(Items.Nuzky);
                            HandleItemChange();
                        }

                        break;
                    case "SroubovakCollider":
                        GameObject.Find("SroubovakCollider").SetActive(false);
                        if (!_heldItems.Contains(Items.Sroubovak)) {
                            _heldItems.Add(Items.Sroubovak);
                            HandleItemChange();
                        }
                        break;

                    case "NumberOfDoc":
                        StartCoroutine(NumberController.ChangeNumberToKey());
                        break;

                    case "DocToSign":
                        if (_heldItems.Contains(Items.Propiska)) {
                            NumberController.SignDoc(hit.collider.gameObject);
                            hit.collider.gameObject.SetActive(false);
                        }
                        break;

                    case "TlacitkoUp":
                        if (_uicontroller._places.Vytah.State == 1) {
                            _uicontroller.ChangePlace(Places.VYTAH2);
                        }
                        break;

                    case "Hrad":
                        GameObject.Find("Hrad").SetActive(false);
                        _uicontroller.DestroyCastle();
                        break;

                    case "StvrzenkaUbytovani":
                        GameObject.Find("UbytovaniText").GetComponent<TextMesh>().text = "Stvrzeno";
                        _uicontroller.Ubytovat();
                        _heldItems.Remove(Items.KufrRozbaleny);
                        break;
                }
            }
        }
    }
    // This is really dump, I know, but I wasn't able to make array of Images cooperate 
    // with me in proper time so I decided to do it like this for now...
    private void HandleItemChange() {
        int i = 1;
        foreach (var item in _heldItems) {

            switch (i) {
                case 1:
                    _itemBoxImage1.sprite = item.ItemSprite;
                    _itemBoxImage1.color = _notTransparent;
                    break;
                case 2:
                    _itemBoxImage2.sprite = item.ItemSprite;
                    _itemBoxImage2.color = _notTransparent;
                    break;
                case 3:
                    _itemBoxImage3.sprite = item.ItemSprite;
                    _itemBoxImage3.color = _notTransparent;
                    break;
                case 4:
                    _itemBoxImage4.sprite = item.ItemSprite;
                    _itemBoxImage4.color = _notTransparent;
                    break;
                case 5:
                    _itemBoxImage5.sprite = item.ItemSprite;
                    _itemBoxImage5.color = _notTransparent;
                    break;
                case 6:
                    _itemBoxImage6.sprite = item.ItemSprite;
                    _itemBoxImage6.color = _notTransparent;
                    break;
            }
            i++;
        }
        for (int j = i; j <= 6; j++) { //Vymaze zbyle kolonky
            switch (j)
            {
                case 1:
                    _itemBoxImage1.sprite = null;
                    _itemBoxImage1.color = _transparent;
                    break;
                case 2:
                    _itemBoxImage2.sprite = null;
                    _itemBoxImage2.color = _transparent;
                    break;
                case 3:
                    _itemBoxImage3.sprite = null;
                    _itemBoxImage3.color = _transparent;
                    break;
                case 4:
                    _itemBoxImage4.sprite = null;
                    _itemBoxImage4.color = _transparent;
                    break;
                case 5:
                    _itemBoxImage5.sprite = null;
                    _itemBoxImage5.color = _transparent;
                    break;
                case 6:
                    _itemBoxImage6.sprite = null;
                    _itemBoxImage6.color = _transparent;
                    break;
            }
            j++;
        }
    }

    public void UseItem(Image itemImage) {
        var item = _heldItems.Find(image => image.ItemSprite == itemImage.sprite);

        var name = item == null ? "" : item.Name;
        switch (name) {
            case "Klíč":
                if (_uicontroller._actualPlace.Name == Places.CHODBA && _heldItems.Contains(Items.KufrRozbaleny)) {
                _uicontroller.MakePokojAvailable();
                _heldItems.Remove(item);
                HandleItemChange();
                }
                break;

            case "Šroubovák":
                if (_uicontroller._actualPlace.Name == Places.VYTAH)
                {
                    _uicontroller.RepairVytah();
                    _heldItems.Remove(item);
                    HandleItemChange();
                }
                break;

            case "Nůžky":
                if (_uicontroller._actualPlace.Name == Places.PRED_HOTELEM)
                {
                    _uicontroller.CutOutBags();
                    _heldItems.Remove(item);
                    
                    _heldItems.Remove(Items.KufrZabaleny);
                    _heldItems.Add(Items.KufrRozbaleny);

                    Debug.Log("Po odnuzkovani mame predmetu: " + _heldItems.Count);
                    foreach (var VARIABLE in _heldItems)
                    {
                        Debug.Log(VARIABLE.Name);
                    }
                    HandleItemChange();
                }
                break;
        }
    }

    public List<ParametrizedItem> GetHeldItems() {
        return _heldItems;
    }
}
