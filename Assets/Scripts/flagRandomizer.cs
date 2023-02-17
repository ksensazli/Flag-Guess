using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagRandomizer : MonoBehaviour
{
    [SerializeField] private List<RectTransform> _flags;

    private void OnEnable() 
    {
        for(int i=0; i<_flags.Count; i++)
        {
            int index = UnityEngine.Random.Range(0,_flags.Count);
            _flags[index].SetParent(null);
            _flags[index].SetParent(transform);
        }
    }
}
