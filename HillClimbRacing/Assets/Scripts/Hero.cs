using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private List<Rigidbody2D> _movingRigidbody;
    [SerializeField] private List<Rigidbody2D> _breackingRigidbody;
    [SerializeField] private List<Rigidbody2D> _axisRigidbody; // This axes need to be going from back to front
    [SerializeField] private float _speed = 200f;
    [SerializeField] private float _coefficientBreak = 0.7f;
    [SerializeField] private float _forceUp = 1500.0f;

    private float _moveInput = 0;
    private bool _onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (_moveInput > 0)
        {
            foreach (var item in _movingRigidbody)
            {
                item.AddTorque(-_speed * Time.fixedDeltaTime);
            }

            double angle = Math.PI * (-gameObject.transform.rotation.z);
            var force = _forceUp * Time.fixedDeltaTime;
            if (!_onGround)
                gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(force * (float)Math.Sin(angle), force * (float)Math.Cos(angle)), _axisRigidbody.First().gameObject.transform.position);
            else
                gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(force * (float)Math.Sin(angle), force * (float)Math.Cos(angle)), _axisRigidbody.Last().gameObject.transform.position);
        }

        if (_moveInput < 0)
        {
            foreach (var item in _breackingRigidbody)
            {
                if (item.angularVelocity > 0)
                {
                    item.angularVelocity = -_speed * _coefficientBreak * Time.fixedDeltaTime;
                    double angle = Math.PI * (-gameObject.transform.rotation.z);
                    var force = _forceUp * Time.fixedDeltaTime;
                    if (!_onGround)
                        gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(force * 2.5f * (float)Math.Sin(angle), force * 2.5f * (float)Math.Cos(angle)), _axisRigidbody.Last().gameObject.transform.position);
                }
                if (item.angularVelocity < 0)
                    item.angularVelocity = 0;


                if (_onGround)
                {
                    if (item.angularVelocity > 0)
                        item.angularVelocity = -_speed * _coefficientBreak * Time.fixedDeltaTime;
                    if (item.angularVelocity < 0)
                        item.angularVelocity = 0;
                }
                else
                {

                }
            }
        }
    }

    public void SetAir() { _onGround = false; }
    public void SetGround() { _onGround = true; }

    public void OnLeftButtonDown()
    {
        if (_moveInput == 0)
            _moveInput = -1;
        if (_moveInput == 1)
            _moveInput = 0;
    }

    public void OnRightButtonDown()
    {
        if (_moveInput == 0)
            _moveInput = 1;
        if (_moveInput == -1)
            _moveInput = 0;
    }
    public void OnLeftButtonUp()
    {
        if (_moveInput == 0)
            _moveInput = 1;
        if (_moveInput == -1)
            _moveInput = 0;
    }

    public void OnRightButtonUp()
    {
        if (_moveInput == 0)
            _moveInput = -1;
        if (_moveInput == 1)
            _moveInput = 0;
    }
}
