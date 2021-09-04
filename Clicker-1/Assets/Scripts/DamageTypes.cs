using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTypes : ScriptableObject
{
    [SerializeField] private int _KineticPenetration;
    [SerializeField] private int _EMPenetration ;
    [SerializeField] private int _LaserPenetration;
    [SerializeField] private int _RocketPenetration;
    public enum DamageType
    {
        Kinetic,
        EM,
        Laser,
        Rocket
    }

    public int Kinetic => _KineticPenetration;
    public int EM => _EMPenetration;
    public int Laser => _LaserPenetration;
    public int Rocket => _RocketPenetration;

    public DamageTypes(int Kinetic, int EM, int Laser,int Rocket)
    {
        this._KineticPenetration = Kinetic;
        this._LaserPenetration = Laser;
        this._EMPenetration = EM;
        this._RocketPenetration = Rocket;
    }
}
