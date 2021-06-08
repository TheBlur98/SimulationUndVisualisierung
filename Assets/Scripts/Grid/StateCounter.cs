using System.Collections;
using System.Collections.Generic;
using Simulation.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Grid
{
    /// <summary>
    /// Class which implements a Counter which shows the amount of infected persons and not infected persons at a venue.
    /// </summary>
    class StateCounter : MonoBehaviour
    {

        private float _height = 4f;
        private float _eulerAngleX = 30f;
        //Reference to the counter which can be modified
        private GameObject _counterGameObject;
        private TextMeshProUGUI _counterText;
        private int _amountInfected;
        private int _amountNotInfected;

        public GameObject CounterGameObject { get => _counterGameObject; set => _counterGameObject = value; }
        public Venue Venue { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Test());
        }


        // Update is called once per frame
        void Update()
        {
            //TODO Getting values from Simulation Controller add modify text element of counter

            _amountInfected = 0;
            _amountNotInfected = 0;
            
            foreach (var person in Venue.GetPeopleAtVenue())
            {
                if (person.InfectionState.HasFlag(Person.InfectionStates.Infected))
                {
                    _amountInfected++;
                }
                else
                {
                    _amountNotInfected++;
                }
            }
            
            UpdateText();
        }

        /// <summary>
        /// Method to instinatiate the counter prefab above a venue model after its creation.
        /// </summary>
        /// <param name="VenueSpawnPosition"></param>
        public void InstantiateCounter()
        {
            GameObject counterPrefab = ModelSelector.Instance.CounterPrefab;
            CounterGameObject = Instantiate(counterPrefab, new Vector3(0, _height, 0), Quaternion.Euler(_eulerAngleX, 0, 0), gameObject.transform);
            CounterGameObject.name = "CounterCanvas";
            _counterText = CounterGameObject.GetComponentInChildren<TextMeshProUGUI>();   
        }

        //Testing counter with random values every four seconds
        private IEnumerator Test()
        {
            for (; ; )
            {
                if (CounterGameObject != null && _counterText != null)
                {
                    _amountInfected = Random.Range(0, 100);
                    _amountNotInfected = Random.Range(0, 100);
                    UpdateText();
                    yield return new WaitForSeconds(4f);
                }
            }
        }

        private void UpdateText()
        {
            string text = $"<color=green>{_amountNotInfected}</color>/<color=red>{_amountInfected}</color>";
            //Debug.Log(text);
            _counterText.SetText(text);
        }

    }
}