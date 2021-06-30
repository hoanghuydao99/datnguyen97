using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;

public class TutorialControl : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject dialog;
    public Vector3[] dialogTransform;
    public Vector3[] scaleDialog;
    public Transform btnContinue;
    int i = 0;
    public GameObject continueButton;
    bool done = false;

    private void Start()
    {
        dialog.transform.localPosition = dialogTransform[i];
        dialog.transform.localScale = scaleDialog[i];
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void Update()
    {
        if (done == true) { return; }
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            Debug.Log(index);
            textDisplay.text = "";
            StartCoroutine(Type());
            dialog.transform.localPosition = dialogTransform[i];
            dialog.transform.localScale = scaleDialog[i];
            textDisplay.transform.localScale = dialog.transform.localScale;
            btnContinue.localScale = dialog.transform.localScale;
            i++;
        }
        else
        {
            continueButton.SetActive(false);
            Destroy(dialog);
            done = true;
        }
    }
}
