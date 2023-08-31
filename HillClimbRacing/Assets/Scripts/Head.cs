using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private GameObject _pedals;
    [SerializeField] private GameObject _restart;

    public void TheEnd()
    {
        Debug.Log("Hahah");
        _pedals.SetActive(false);
        _restart.SetActive(true);
    }
}
