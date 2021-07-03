using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using DialogBoxSystem;

public class SetInfectedPersonsHandler : MonoBehaviour
{
    public GameObject SetInfectedPersonsGameObject;
    public GameObject SimulationControllerGameObject;

    private SimulationController simulationController;

    [SerializeField]
    private Button _virusButton;

    public void LoadSetInfectedPersons()
    {
        simulationController = SimulationControllerGameObject.GetComponent<SimulationController>();
        if (!simulationController.IsRunning)
        {
            return;
        }
        else
        {
            simulationController.Pause();
            SetInfectedPersonsGameObject.SetActive(true);
            _virusButton.interactable = false;
        }
    }

    public void CloseSetInfectedPersons()
    {
        SetInfectedPersonsGameObject.SetActive(false);
        simulationController = SimulationControllerGameObject.GetComponent<SimulationController>();
        _virusButton.interactable = true;
        simulationController.Play();
    }

    public void ConfirmSetInfectedPersons()
    {      
        int personsToBeInfected;
        var correctInput = int.TryParse(SetInfectedPersonsGameObject.GetComponentInChildren<TMP_InputField>().text, out personsToBeInfected);
        //consider negative numbers

        if (personsToBeInfected > 0)
        {
            simulationController = SimulationControllerGameObject.GetComponent<SimulationController>();
            simulationController.InfectRandomPerson(personsToBeInfected);
            SetInfectedPersonsGameObject.SetActive(false);
            simulationController.Play();
        }
        else
        {
            //Problem DialogBox is behind SetInfectedPersonsMenu
            /*Debug.Log("Invalid entry");
            string msg = "Please make sure that there is a whole number in the input field.";
            string name = "Invalid entry";
            DialogBox dialogBox = new DialogBox(name, msg);
            dialogBox.HasCancelButton = false;
            DialogBoxManager.Instance.HandleDialogBox(dialogBox);*/
        }
    }
}