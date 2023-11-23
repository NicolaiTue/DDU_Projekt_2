using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using Random = System.Random;
using Photon.Pun;
using System.Data.Common;

public class Kategorier : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Question _question;
    public Question Question { get { return _question; } }

    [SerializeField]
    private RundeF�rdig _rundeF�rdig;
    public RundeF�rdig RundeF�rdig { get { return _rundeF�rdig; } }

    public HostControls hostControls;
    public struct ListOfListsStruct
    {
        public List<string> title;
        public List<List<string>> mainList;
        public List<int> valgtKategorier;
    }

    string titel;
    string sp�rgsm�l;
    ListOfListsStruct myListOfLists;

    public TextMeshProUGUI _text;


    void Awake()
    {
        myListOfLists.valgtKategorier = new List<int>();

        // Opret en liste af lister
        myListOfLists.mainList = new List<List<string>>();

        //lister i listen
        myListOfLists.title = new List<string> { "�er i Danmark", " Hajarter", "Kortspil", "Nobelfredspris vindere", "Wimbledon vindere", "VM i fodbold vindere", "Lande i kontinentet Asien", "Karakterer i Harry Potter", "Superhelte fra Marvel", "Sportsgrene der indg�r boldspil", "Kr�fttyper", "Haribo slik varianter", "Mandlige oscarvindere", "Superhelte fra DC", "Karakterer fra Batman universet", "Frugter / b�r med ordet b�r i", "Danske landsholdspillere i fodbold de sidste 5 �r", "Rasmus Seebach sange", "Officielle sprog i Europa", "Danske kommuner der begynder med R" };

        // �er i Danmark
        myListOfLists.mainList.Add(new List<string> { "Sj�lland", "Fyn", "Lolland", "Falster" });

        // Hajarter
        myListOfLists.mainList.Add(new List<string> { "Hvidhaj", "Hammerhaj", "R�dhaj", "Pighaj" });

        // Kortspil
        myListOfLists.mainList.Add(new List<string> { "Krig", "Fisk", "500", "100", "R�vhul" });

        // Nobelfredspris vindere
        myListOfLists.mainList.Add(new List<string> { "Barack Obama", "Nelson Mandela", "Jimmy Carter" });

        // Wimbledon vindere
        myListOfLists.mainList.Add(new List<string> { "Novak Djokovic", "Roger Federer", "Carlos Alcaraz" });

        // VM i fodbold vindere
        myListOfLists.mainList.Add(new List<string> { "Italien", "Spanien", "Tyskland" });

        // Lande i kontinentet Asien
        myListOfLists.mainList.Add(new List<string> { "Kina", "Indien", "Pakistan" });

        // Karakterer i Harry Potter
        myListOfLists.mainList.Add(new List<string> { "Ron Weasley", "Hermione Granger", "Harry Potter" });

        // Superhelte fra Marvel
        myListOfLists.mainList.Add(new List<string> { "Captain America", "Black Widow", "Star Lord" });

        // Sportsgrene der indg�r boldspil
        myListOfLists.mainList.Add(new List<string> { "Fodbold", "Tennis", "Kroket" });

        // Kr�fttyper
        myListOfLists.mainList.Add(new List<string> { "Lungekr�ft", "Lymfekr�ft", "Strubekr�ft" });

        // Haribo slik varianter
        myListOfLists.mainList.Add(new List<string> { "Stjerne mix", "Labre larver" });

        // Mandlige oscarvindere
        myListOfLists.mainList.Add(new List<string> { "Brad Pitt", "Leonardo Di Caprio", "Tom Cruise" });

        // Superhelte fra DC
        myListOfLists.mainList.Add(new List<string> { "Batman", "Superman", "Green Lantern" });

        // Karakterer fra Batman universet
        myListOfLists.mainList.Add(new List<string> { "Batman", "The Riddler", "Joker" });

        // Frugter / b�r med ordet b�r i
        myListOfLists.mainList.Add(new List<string> { "Hindb�r", "Bromb�r", "Jordb�r" });

        // Danske landsholdspillere i fodbold de sidste 5 �r
        myListOfLists.mainList.Add(new List<string> { "Christian Eriksen", "Kasper Schmeichel", "Robert Skov" });

        // Rasmus Seebach sange
        myListOfLists.mainList.Add(new List<string> { "�de �", "Natteravn", "Olivia" });

        // Officielle sprog i Europa
        myListOfLists.mainList.Add(new List<string> { "Engelsk", "Dansk", "Tysk" });

        // Danske kommuner der begynder med R
        myListOfLists.mainList.Add(new List<string> { "Roskilde kommune", "Ringsted kommune", "Randers kommune" });


        // Udskriv indholdet af listen
        //PrintList(mainList);
    }


    private void OnEnable()
    {
        MasterChangeScene();
    }

    public void MasterChangeScene()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            var random = new Random();
            int randomIndex;
            do
            {
                randomIndex = random.Next(0, myListOfLists.title.Count - 1);
            } while (myListOfLists.valgtKategorier.Contains(randomIndex)); // Check for eksistens
            
            myListOfLists.valgtKategorier.Add(randomIndex);
            _text.text = myListOfLists.title[randomIndex];
//            hostControls.CallRPCFunction(randomIndex);
            photonView.RPC("CallRPCFunction", RpcTarget.AllBuffered, randomIndex);
            Debug.Log(randomIndex);
            //load sp�rgsm�l
        }
    }

    [PunRPC]
    public void CallRPCFunction(int i)
    {

        ChangeScreen(i);
        // G�r noget med det modtagne parameter
        Debug.Log("Modtaget parameter: " + i);
    }

    public void ChangeScreen(int index)
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            RundeF�rdig.Hide();
            Question.Show();
            _text.text = myListOfLists.title[index];
        }
        
    }



    void PrintList(List<List<string>> listOfLists)
    {
        foreach (List<string> subList in listOfLists)
        {
            foreach (string item in subList)
            {
                Debug.Log(item);
            }
            Debug.Log("----------");
        }
    }
}

