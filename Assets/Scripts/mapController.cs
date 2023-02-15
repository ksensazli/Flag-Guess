using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class mapController : MonoBehaviour
{
    [SerializeField] private List<Button> _cities;
    [SerializeField] private TMPro.TMP_Text _targetCity;
    [SerializeField] private TMPro.TMP_Text _pointsText;
    [SerializeField] private TMPro.TMP_Text _plateName;
    private int _points = 0;
    [SerializeField] private int _targetCityIndex;
    private List<int> _remainingCities = new List<int>();

    private void OnEnable()
    {
        _pointsText.text = _points.ToString();
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
            return;
        }
        _targetCityIndex = _remainingCities[UnityEngine.Random.Range(0, _remainingCities.Count)];
        _remainingCities.Remove(_targetCityIndex);
        _targetCity.text = (_targetCityIndex + 1).ToString();
    }

    private void onButtonClick(int index)
    {
        Debug.Log((index + 1) + " " + _cities[index].transform.name + " " + (index == _targetCityIndex));
        if(index == _targetCityIndex)
        {
            randomCitySelector();
            _cities[index].image.color = Color.green;
            _cities[index].enabled = false;
            _points += 10;
            _pointsText.text = _points.ToString();
        }
        else
        {
            _cities[index].image.color = Color.red;
            _cities[index].enabled = false;
            _points -= 10;
            _pointsText.text = _points.ToString();
            DOVirtual.DelayedCall(2f, () => _cities[index].enabled = true);
            DOVirtual.DelayedCall(2f, () => _cities[index].image.color = new Color(0.945098f,0.9333333f,0.8666667f));
        }
    }
}
