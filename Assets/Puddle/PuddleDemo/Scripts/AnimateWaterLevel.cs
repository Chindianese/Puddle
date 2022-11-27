using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWaterLevel : MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float _animateSpeed = 0.2f;
    [Range(0,1)]
    [SerializeField]
    private float _maxDampness = 0.2f;
    [Range(0, 1)]
    [SerializeField]
    private float _dampnessOffset = 0.0f;
    [Range(0,1)]
    [SerializeField]
    private float _waterLevelOffset = 0.1f;

    private Material _mat;
    private float _currentWaterLevel = 0.0f;
    private float _currentDampness = 0.0f;
    // Start is called before the first frame update
    void Awake()
    {
        _mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float sin = (Mathf.Sin(_animateSpeed * Time.time) *(0.5f-_waterLevelOffset) + 0.5f + _waterLevelOffset);
        float sin2 = (Mathf.Sin(_animateSpeed * Time.time) *(0.5f + _dampnessOffset) + 0.5f+ _dampnessOffset);
        //Debug.Log(sin);
        _currentWaterLevel = sin;
        _currentDampness = Mathf.Min(sin2,_maxDampness);
        _mat.SetFloat("_WaterHeight", _currentWaterLevel);
        _mat.SetFloat("_Dampness", _currentDampness);
    }
}
