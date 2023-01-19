using UnityEngine;
using UnityEngine.UI;
using Microsoft.CognitiveServices.Speech;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using TMPro;

public class SpeechManager : MonoBehaviour
{
    //public BotUI botUI;
    public TextMeshPro displayText;
    
    SpeechRecognizer recognizer;
    SpeechConfig config;
    
    private object threadLocker = new object();
    private string message;
    
    UnityEngine.Windows.Speech.KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keyWords = new Dictionary<string, System.Action>();

    private void RecognizingHandler(object sender, SpeechRecognitionEventArgs e)
    {
        lock (threadLocker)
        {
            message = e.Result.Text;
        }
    }
    
    void Start()
    {
        config = SpeechConfig.FromSubscription("75dc9c6def3a4cd6be093625e26e7953", "eastus");
        recognizer = new SpeechRecognizer(config);
        recognizer.Recognizing += RecognizingHandler;
        
        recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);
        
        //keywordRecognizer = new UnityEngine.Windows.Speech.KeywordRecognizer(keyWords.Keys.ToArray());
    }
    
    void Update()
    {
        lock (threadLocker)
        {
            displayText.text = message;
        }
    }
}
