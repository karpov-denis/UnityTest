using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourseDisplay : MonoBehaviour
{
    [SerializeField] private PlayerResourses _playerResourses;
    [SerializeField] private Text _goldDisplay;
    [SerializeField] private Text _metalDisplay;
    // Start is called before the first frame update
    private void OnEnable()
    {
        _playerResourses.resourseGoldChanged += onGoldChanged;
        _playerResourses.resourseMetalChanged += onMetalChanged;
    }

    private void OnDisable()
    {
        _playerResourses.resourseGoldChanged -= onGoldChanged;
        _playerResourses.resourseMetalChanged -= onMetalChanged;

    }
    private void onMetalChanged(int Metal)
    {
        _metalDisplay.text = Metal.ToString();
    }
    private void onGoldChanged(int Gold)
    {
        _goldDisplay.text = Gold.ToString();
    }
}
