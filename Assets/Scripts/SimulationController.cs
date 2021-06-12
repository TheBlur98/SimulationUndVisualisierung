﻿using System.Collections.Generic;
using System.Linq;
using RuntimeObjects;
using Simulation.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

class SimulationController : MonoBehaviour
{
    private const float SimulationInterval = 0.05f;

    [SerializeField]
    private EditorObjectsManager _editorObjectsManager;

    [SerializeField]
    private TMP_Text _simulationDateTime;

    private bool _isInitialized = false;
    private bool _isPaused = false;
    
    private Simulation.Runtime.SimulationController _controller;
    private float _lastSimulationUpdate;

    private bool IsRunning => _isInitialized && _isPaused == false;

    private void Awake()
    {
        Assert.IsNotNull(_editorObjectsManager);
        Assert.IsNotNull(_simulationDateTime);
    }

    public void Play()
    {
        if (_isInitialized == false)
        {
            List<Entity> entities = _editorObjectsManager.GetAllEditorObjects()
                .Select(RuntimeObjectFactory.Create)
                .ToList();

            _controller = new Simulation.Runtime.SimulationController();
            _controller.Initialize(entities);
        
            _isInitialized = true;    
        }
        else if (_isPaused == true)
        {
            _isPaused = false;
        }    
    }

    private void Update()
    {
        if (!IsRunning)
        {
            return;
        }

        if (Time.time - _lastSimulationUpdate >= SimulationInterval)
        {
            _controller.RunUpdate();
            _simulationDateTime.text =
                $"{_controller.SimulationDate.ToLongDateString()}\n{_controller.SimulationDate.ToShortTimeString()}";
            
            _lastSimulationUpdate = Time.time;
        }
    }

    public void Pause()
    {
        if (!IsRunning)
        {
            return;
        }

        _isPaused = true;
    }

    public void Stop()
    {
        if (_isInitialized == true)
        {
            //TODO: Reset Entity GameObjects to Editor State
            _isInitialized = false;
            _isPaused = false;
            _controller = null;   
        }
    }
    
    public void InfectRandomPerson()
    {
        if (!IsRunning)
        {
            return;
        }
        
        _controller.InfectRandomPerson();
    }  
}