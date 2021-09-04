using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickerZone : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PlayerResourses _playerResourses;
    public event UnityAction<DamageTypes, int> Click;
    public void OnPointerClick(PointerEventData eventData)
    {
      //  Debug.Log("”дар на"+ _playerResourses.DamagePerTouch);
        Click?.Invoke(new DamageTypes(_playerResourses.Kinetic,_playerResourses.EM,_playerResourses.Laser,_playerResourses.Rocket),_playerResourses.DamagePerTouch);
    }
    void Update()
    {

    }
}
