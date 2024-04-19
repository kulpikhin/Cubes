using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSelecter : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Cube _cubePrefab;

    private float _maxRayLength = 100f;
    private int _minCLone = 2;
    private int _maxCLone = 6;
    private int _maxChanceClone = 101;

    private void Update()
    {
        SelecetCube();
    }

    private void SelecetCube()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxRayLength, ~layerMask))
            {
                if (hit.collider.CompareTag("Cube"))
                {
                    SelectAction(hit.collider.GetComponent<Cube>());
                }
            }
        }
    }

    private void CreatCubes(Cube cubeParent)
    {
        int cloneCount = Random.Range(_minCLone, _maxCLone + 1);

        for (int i = 0; i < cloneCount; i++)
        {
            Cube cube = Instantiate(_cubePrefab, cubeParent.transform.position, Quaternion.identity);
            cube.OnSpawn(cubeParent.Scale);
        }
    }

    private void SelectAction(Cube cube)
    {
        if (Random.Range(0, _maxChanceClone) <= cube.ChanceClone)        
            CreatCubes(cube);
        else
            cube.Explosion.StartExplosion();

        Destroy(cube.gameObject);
    }
}
