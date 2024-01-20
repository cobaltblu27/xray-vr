using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pieces;
    [SerializeField] private GameObject puzzleStartArea;
    [SerializeField] private UnityEvent onPuzzleSolved;
    private Vector3[] _originalPositions;
    private Quaternion[] _originalRotations;
    private bool[] _puzzlePieceSolved;
    private bool _puzzlePlaying = false;
    private const float snapThresholdPosition = 0.5f;
    private const float snapThresholdRotation = 15f;

    void Start()
    {
        _originalPositions = new Vector3[pieces.Length];
        _originalRotations = new Quaternion[pieces.Length];
        _puzzlePieceSolved = new bool[pieces.Length];
        
        for (var i = 0; i < pieces.Length; i++)
        {
            var piece = pieces[i];
            _originalPositions[i] = piece.transform.position;
            _originalRotations[i] = piece.transform.rotation;
            _puzzlePieceSolved[i] = false;
            TeleportObjectInsideCube(piece.transform);
        }

        _puzzlePlaying = true;
        Debug.Log(_originalRotations[6]);
    }

    void Update()
    {
        if (_puzzlePlaying)
        {
            CheckPuzzlePieces();
        }
    }

    void CheckPuzzlePieces()
    {
        for (var i = 0; i < pieces.Length; i++)
        {
            var piece = pieces[i];
            if (Quaternion.Angle(piece.transform.rotation, _originalRotations[i]) < snapThresholdRotation &&
                Vector3.Distance(piece.transform.position, _originalPositions[i]) < snapThresholdPosition)
            {
                Destroy(piece.GetComponent<Rigidbody>());
                Destroy(piece.GetComponent<XRGrabInteractable>());
                piece.transform.rotation = _originalRotations[i];
                piece.transform.position = _originalPositions[i];
                _puzzlePieceSolved[i] = true;
            }
        }

        if (_puzzlePieceSolved.All(s => s))
        {
            _puzzlePlaying = false;
            onPuzzleSolved.Invoke();
        }
    }
    
    void TeleportObjectInsideCube(Transform objectTransform)
    {
        var cubeTransform = puzzleStartArea.transform;
        Bounds bounds = new Bounds(cubeTransform.position, cubeTransform.localScale);
        
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        Vector3 randomPosition = new Vector3(x, y, z);
        
        float rotationX = Random.Range(0f, 360f);
        float rotationY = Random.Range(0f, 360f);
        float rotationZ = Random.Range(0f, 360f);
        Quaternion randomRotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
        
        objectTransform.position = randomPosition;
        objectTransform.rotation = randomRotation;
    }
}