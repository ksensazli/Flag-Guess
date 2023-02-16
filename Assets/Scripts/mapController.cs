using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class mapController : MonoBehaviour
{
    [SerializeField] private List<Button> _cities;
    [SerializeField] private GameObject _restartBtn;
    [SerializeField] private GameObject _mainMenuBtn;
    [SerializeField] private GameObject _blackoutEffect;
    [SerializeField] private TMPro.TMP_Text _targetCity;
    [SerializeField] private TMPro.TMP_Text _clickedText;
    [SerializeField] private TMPro.TMP_Text _plateName;
    [SerializeField] private int _targetCityIndex;
    private List<int> _remainingCities = new List<int>();

    private void OnEnable()
    {
        for (int i=0; i<_cities.Count; i++)
        {
            int index = i;
            _cities[index].onClick.AddListener(() =>
            {
                onButtonClick(index);
            });
            _remainingCities.Add(index);
        }
        randomCitySelector();
    }

    private void randomCitySelector()
    {
        if (_remainingCities.Count.Equals(0))
        {
            _targetCity.fontSize = 36;
            _targetCity.text = "Level Completed!";
            _plateName.enabled = false;
            _restartBtn.SetActive(true);
            _mainMenuBtn.SetActive(true);
            _blackoutEffect.SetActive(true);
            _clickedText.enabled = false;
            return;
        }
        _targetCityIndex = _remainingCities[UnityEngine.Random.Range(0, _remainingCities.Count)];
        _remainingCities.Remove(_targetCityIndex);
        _targetCity.text = (_targetCityIndex + 1).ToString();
    }

    private void onButtonClick(int index)
    {
        _clickedText.text = _cities[index].transform.name;
        if(index == _targetCityIndex)
        {
            randomCitySelector();
            _cities[index].image.color = Color.green;
            _cities[index].enabled = false;
        }
        else
        {
            _cities[index].image.color = Color.red;
            _cities[index].enabled = false;
            DOVirtual.DelayedCall(2f, () => _cities[index].enabled = true);
            DOVirtual.DelayedCall(2f, () => _cities[index].image.color = new Color(0.945098f,0.9333333f,0.8666667f));
        }
    }
}
