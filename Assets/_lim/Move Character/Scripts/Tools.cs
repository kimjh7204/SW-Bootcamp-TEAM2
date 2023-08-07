using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public enum Type
    {
        Ammo,
        Coin,
        Heart,
        Weapon,
        Tool
    };

    public Type type;
    public int value;

}
