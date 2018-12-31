using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningAround : MonoBehaviour {
    private Transform _transform;
    // Start is called before the first frame update
    void Start() {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Rotate(0,-2,0);
    }
}
