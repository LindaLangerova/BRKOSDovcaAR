using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour {

    private Transform _numberRotator;
    private TextMesh _numberText;

    public GameObject Klic;

    private int _numberOfDocSigned = 0;

    // Start is called before the first frame update
    void Start() {
        _numberRotator = GetComponent<Transform>();
        _numberText = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        _numberRotator.Rotate(0, 1, 0);
        GetComponent<BoxCollider>().enabled = _numberOfDocSigned == 6;
    }

    public void  SignDoc(GameObject documentToSign) {
        
        if (_numberOfDocSigned >= 6) return; 
        _numberOfDocSigned++;
        _numberText.text = _numberOfDocSigned + "/6";

        if (_numberOfDocSigned == 6) {
            _numberText.color = new Color(1, 0.9f, 0.25f);
        }
    }

    public IEnumerator ChangeNumberToKey() {
        while (_numberText.color.a > 0) {
            _numberText.color = new Color(
                _numberText.color.r, 
                _numberText.color.g,
                _numberText.color.b,
                _numberText.color.a - 0.1f);
            yield return new WaitForSecondsRealtime(0.2f); 
        }
        Klic.SetActive(true);
        GameObject.Find("NumberOfDoc").SetActive(false);
    }
}
