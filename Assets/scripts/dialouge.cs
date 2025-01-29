using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.Playables;

public class dialouge : MonoBehaviour
{
    
    [SerializeField] private float textSpeed;
    [SerializeField] private string[] lines;
    [SerializeField] private PlayableDirector fade;

    private TextMeshProUGUI textComponent;
    private int index;
    
    [SerializeField] private AudioSource ClipSource;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        lines[0] = textComponent.text;
        textComponent.text = string.Empty;
        StartDialouge();
        ClipSource.Play();
    }

    private void Update()
    {
        if (textComponent.text == lines[index])
        {
            ClipSource.Stop();
            StartCoroutine(playCutscene());
        }
    }

    private void StartDialouge()
    {
        index = 0;
        StartCoroutine(typeLine());
    }

    private IEnumerator typeLine()
    {

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private IEnumerator playCutscene()
    {
        yield return new WaitForSeconds(1.25f);
        fade.Play();
    }

}
