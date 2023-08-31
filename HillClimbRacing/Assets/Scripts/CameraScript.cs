using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] private GameObject _hero;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(_hero.transform.position.x+5, _hero.transform.position.y, -10);
    }
}
