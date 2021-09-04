using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerResourses))]
public class Player : MonoBehaviour
{
    private PlayerResourses _playerResourses;
    [SerializeField] private PlaceTarget _placeTarget;
    // Start is called before the first frame update
    private void Start()
    {
        _playerResourses = GetComponent<PlayerResourses>();
        _placeTarget.TargetDown += OnTargetDefeated;
    }
    public void OnTargetDefeated(Target target)
    {
        _playerResourses.AddTargetProfit(new Loot(target.GoldProfit, target.MetalProfit, target.UraniumProfit, target.PlatinumProfit, target.GasProfit));
    }
    public bool isEnoughtResourses(Loot price)
    {
        return _playerResourses.GoldAmount >= price.Gold && _playerResourses.MetalAmount >= price.Metal && _playerResourses.PlatinumAmount >= price.Platinum && _playerResourses.UraniumAmount >= price.Uranium && _playerResourses.GasAmount >= price.Gas;
    }
}
