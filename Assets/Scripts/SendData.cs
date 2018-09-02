using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LiteNetLib;
using LiteNetLib.Utils;
using UnityEngine.Windows.Speech;

public class SendData : MonoBehaviour
{


    public ServerStart server;
    public string[] keywords = new string[] {"go", "stop" };
    public ConfidenceLevel confidence;
    public Text txtLabel;
    protected PhraseRecognizer recognizer;


    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += OnPhraseRecognized;
            recognizer.Start();
        }
    }


    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        txtLabel.text = args.text;
       SendDataRecogntionAsString(args.text);
        Debug.Log("result talking = " + args.text);
    }


    public void SendDataRecogntionAsString(string result)
    {
        NetPeer _ourPeer = server._ourPeer;
        server._dataWriter = new NetDataWriter();
        NetDataWriter _dataWriter = server._dataWriter;
        if (_ourPeer != null)
        {
            _dataWriter.Put(result);
            _ourPeer.Send(_dataWriter, DeliveryMethod.Sequenced);
            Debug.Log("Sent TO the APP :D ");
        }
    }


   
}
