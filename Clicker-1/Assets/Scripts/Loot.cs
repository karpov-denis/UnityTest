using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New TargetLoot", menuName = "Target Data", order = 51)]
public class Loot : ScriptableObject
{
    [SerializeField] private int gold;
    [SerializeField] private int metal;

    [SerializeField] private int uranium;
    [SerializeField] private int platinum;
    [SerializeField] private int gas;

    public Loot(int a, int b, int c, int d, int e)
    {
        this.gold = a;
        this.metal = b;
        this.uranium = c;
        this.platinum = d;
        this.gas = e;
    }

    public int Gold
    {
        get
        {
            return gold;
        }
    }
    public int Metal
    {
        get
        {
            return metal;
        }
    }
    public int Uranium
    {
        get
        {
            return uranium;
        }
    }
    public int Platinum
    {
        get
        {
            return platinum;
        }
    }
    public int Gas
    {
        get
        {
            return gas;
        }
    }
    // Start is called before the first frame update
}
