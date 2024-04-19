using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private int _chanceClone = 100;
    private int _scale = 1;
    private int _scaleMultiplier = 2;

    private Renderer _renderer;
    private Explode _explosion;

    public Explode Explosion { get { return _explosion; } }
    public int Scale { get { return _scale; } }
    public int ChanceClone { get { return _chanceClone; } }

    private void Awake()
    {
        _explosion = GetComponent<Explode>();
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        ChangeColor();
    }

    public void OnSpawn(int scaleParent)
    {
        _scale = scaleParent * _scaleMultiplier;
        transform.localScale /= _scale;
        _chanceClone /= _scale;
    }

    private void ChangeColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        _renderer.material.color = randomColor;
    }
}
