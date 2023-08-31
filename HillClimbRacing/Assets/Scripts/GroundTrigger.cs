using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private Head _head;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hero = collision.gameObject.tag;

        if (hero.Equals("Tire"))
            _hero.SetGround();

        if (hero.Equals("Head"))
            _head.TheEnd();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var hero = collision.gameObject.tag;

        if (hero.Equals("Tire"))
            _hero.SetAir();
    }
}
