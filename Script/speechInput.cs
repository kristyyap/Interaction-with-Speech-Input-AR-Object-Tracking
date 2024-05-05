using UnityEngine.Windows.Speech;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechInput : MonoBehaviour
{
    KeywordRecognizer KeywordRecognizerObj;
    public string[] Keywords_array;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        KeywordRecognizerObj = new KeywordRecognizer(Keywords_array);
        KeywordRecognizerObj.OnPhraseRecognized += OnKeywordsRecognized;
        KeywordRecognizerObj.Start();

        anim = GetComponent<Animator>();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("keyword " + args.text + "; Confidence " + args.confidence);

        charAnimation(args.text);
    }

    void charAnimation(string command)
    {
        if (command.Contains("dance"))
        {
            anim.Play("dance", -1, 0f);
        }
        if (command.Contains("rotate"))
        {
            anim.Play("rotate", -1, 0f);
        }
        if (command.Contains("jump"))
        {
            anim.Play("jump", -1, 0f);
        }
        if (command.Contains("fly"))
        {
            transform.Rotate(-90, 0, 0);
            anim.Play("fly", -1, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}