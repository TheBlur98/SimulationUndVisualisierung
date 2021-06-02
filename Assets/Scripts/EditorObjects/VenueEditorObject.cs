using Simulation.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorObjects
{
    public class VenueEditorObject : IEditorObject
    {

        private GameObject _gameObject;
        private Venue _runtimeVenue;
        private Vector3Int _relativePosition;
        private string _name;



        public GameObject EditorGameObject { get => _gameObject; set => _gameObject = value; }
        public Vector3Int RelativePosition { get => _relativePosition; set => _relativePosition = value; }
        public string UIName { get => _name; set => _name = value; }
        public Entity RuntimeEntity { get => _runtimeVenue; set => _runtimeVenue = (Venue)value; }

        public VenueEditorObject(GameObject gameObject, Venue runtimeVenue, Vector3Int relativePosition, string name)
        {
            _gameObject = gameObject;
            _runtimeVenue = runtimeVenue;
            _relativePosition = relativePosition;
            _name = name;
        }

        public void LoadUI()
        {
            throw new NotImplementedException();
        }

    }

}