using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class flagController : MonoBehaviour
{
    [SerializeField] private List<Button> _flags;
    [SerializeField] private GameObject _restartBtn;
    [SerializeField] private GameObject _mainMenuBtn;
    [SerializeField] private TMPro.TMP_Text _targetFlag;
    [SerializeField] private TMPro.TMP_Text _flagsText;
    [SerializeField] private int _targetFlagIndex;
    private List<int> _remainingFlags = new List<int>();

    private void OnEnable()
    {
        for (int i=0; i<_flags.Count; i++)
        {
            int index = i;
            _flags[index].onClick.AddListener(() =>
            {
                onButtonClick(index);
            });
            _remainingFlags.Add(index);
        }
        randomFlagSelector();
    }

    private void randomFlagSelector()
    {
        if(_remainingFlags.Count.Equals(0))
        {
            _targetFlag.enabled = false;
            _flags[_targetFlagIndex].image.color = new Color(1f,1f,1f,0f);
            _flagsText.text = "Level Completed!";
            _restartBtn.SetActive(true);
            _mainMenuBtn.SetActive(true);
            return;
        }
        _targetFlagIndex = _remainingFlags[UnityEngine.Random.Range(0,_remainingFlags.Count)];
        _remainingFlags.Remove(_targetFlagIndex);
        _targetFlag.text = _flags[_targetFlagIndex].transform.name;
    }

    private void onButtonClick(int index)
    {
        if(index == _targetFlagIndex)
        {
            randomFlagSelector();
            _flags[index].image.color = new Color(1f,1f,1f,0f);
            _flags[index].enabled = false;
        }
        else
        {
            _flags[index].image.color = Color.red;
            DOVirtual.DelayedCall(2f, () => _flags[index].image.color = new Color(1f,1f,1f,1f));
        }
    }
}
