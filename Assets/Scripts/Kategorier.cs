using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using Random = System.Random;
using Photon.Pun;
using System.Data.Common;
using System.Reflection;
using Unity.VisualScripting;

public class Kategorier : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Transform _content;

    [SerializeField]
    private Question _question;
    public Question Question { get { return _question; } }

    [SerializeField]
    private RundeF�rdig _rundeF�rdig;
    public RundeF�rdig RundeF�rdig { get { return _rundeF�rdig; } }

    public Qlistings button;

    private List<Qlistings> _listings = new List<Qlistings>();

    

    public struct ListOfListsStruct
    {
        public List<string> title;
        public List<List<string>> mainList;
        public List<int> valgtKategorier;
        public List<List<int>> points;

    }

    string titel;
    string sp�rgsm�l;
    ListOfListsStruct myListOfLists;

    

    public TextMeshProUGUI _text;

    //List<List<Answer>> answerList;
    void Awake()
    {
        //Answer n = new Answer("sj�lland", 90);
        //List<Answer> OerIDK = new List<Answer> { new Answer("Sj�lland", 90), new Answer("Fyn", 80), new Answer("Lolland", 70), new Answer("Falster", 68) };
        //answerList.Add(OerIDK);


        myListOfLists.valgtKategorier = new List<int>();
        // Opret en liste af lister
        myListOfLists.mainList = new List<List<string>>();
        myListOfLists.points = new List<List<int>>();

        //lister i listen
        myListOfLists.title = new List<string> { "�er i Danmark", " Hajarter", "Kortspil", "Nobelfredspris vindere", "Wimbledon vindere", "VM i fodbold vindere", "Lande i kontinentet Asien", "Karakterer i Harry Potter", "Superhelte fra Marvel", "Sportsgrene der indg�r boldspil", "Kr�fttyper", "Haribo slik varianter", "Mandlige oscarvindere", "Superhelte fra DC", "Karakterer fra Batman universet", "Frugter / b�r med ordet b�r i", "Danske landsholdspillere i fodbold de sidste 5 �r", "Rasmus Seebach sange", "Officielle sprog i Europa", "Danske kommuner der begynder med R" };

        // �er i Danmark
        myListOfLists.mainList.Add(new List<string> { "Sj�lland", "Fyn", "Lolland", "Falster" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Hajarter
        myListOfLists.mainList.Add(new List<string> { "Hvidhaj", "Hammerhaj", "R�dhaj", "Pighaj" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Kortspil
        myListOfLists.mainList.Add(new List<string> { "Krig", "Fisk", "500", "100", "R�vhul" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Nobelfredspris vindere
        myListOfLists.mainList.Add(new List<string> { "Barack Obama", "Nelson Mandela", "Jimmy Carter" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Wimbledon vindere
        myListOfLists.mainList.Add(new List<string> { "Novak Djokovic", "Roger Federer", "Carlos Alcaraz" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // VM i fodbold vindere
        myListOfLists.mainList.Add(new List<string> { "Italien", "Spanien", "Tyskland" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Lande i kontinentet Asien
        myListOfLists.mainList.Add(new List<string> { "Kina", "Indien", "Pakistan" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Karakterer i Harry Potter
        myListOfLists.mainList.Add(new List<string> { "Ron Weasley", "Hermione Granger", "Harry Potter" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Superhelte fra Marvel
        myListOfLists.mainList.Add(new List<string> { "Captain America", "Black Widow", "Star Lord" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Sportsgrene der indg�r boldspil
        myListOfLists.mainList.Add(new List<string> { "Fodbold", "Tennis", "Kroket" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Kr�fttyper
        myListOfLists.mainList.Add(new List<string> { "Lungekr�ft", "Lymfekr�ft", "Strubekr�ft" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Haribo slik varianter
        myListOfLists.mainList.Add(new List<string> { "Stjerne mix", "Labre larver" });
        myListOfLists.points.Add(new List<int> { 30, 25 });

        // Mandlige oscarvindere
        myListOfLists.mainList.Add(new List<string> { "Brad Pitt", "Leonardo Di Caprio", "Tom Cruise" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Superhelte fra DC
        myListOfLists.mainList.Add(new List<string> { "Batman", "Superman", "Green Lantern" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Karakterer fra Batman universet
        myListOfLists.mainList.Add(new List<string> { "Batman", "The Riddler", "Joker" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Frugter / b�r med ordet b�r i
        myListOfLists.mainList.Add(new List<string> { "Hindb�r", "Bromb�r", "Jordb�r" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Danske landsholdspillere i fodbold de sidste 5 �r
        myListOfLists.mainList.Add(new List<string> { "Christian Eriksen", "Kasper Schmeichel", "Robert Skov" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Rasmus Seebach sange
        myListOfLists.mainList.Add(new List<string> { "�de �", "Natteravn", "Olivia" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Officielle sprog i Europa
        myListOfLists.mainList.Add(new List<string> { "Engelsk", "Dansk", "Tysk" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });

        // Danske kommuner der begynder med R
        myListOfLists.mainList.Add(new List<string> { "Roskilde kommune", "Ringsted kommune", "Randers kommune" });
        myListOfLists.points.Add(new List<int> { 30, 25, 50, 75, 5 });


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

            foreach(Qlistings listing in _listings)
            {
                Destroy(listing.gameObject);
            }
            _listings.Clear();

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
            /*
             * 
             * 
             * 
             */

            for (int i = 0; i < myListOfLists.mainList[randomIndex].Count; i++)
            {
                Qlistings listing = Instantiate(button, _content);
                if (listing != null)
                {
                    _listings.Add(listing);
                    listing.GetOrAddComponent<Qlistings>().SetupBtn(myListOfLists.mainList[randomIndex][i], myListOfLists.points[randomIndex][i]);
                }

            }

            //foreach (string mulighed in myListOfLists.mainList[randomIndex])
            //{
            //    Qlistings listing = Instantiate(button, _content);
            //    if (listing != null)
            //    {
            //        _listings.Add(listing);
            //        listing.GetOrAddComponent<Qlistings>().answerTxt = mulighed;
            //    }


            //}

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

            foreach (Qlistings listing in _listings)
            {
                Destroy(listing.gameObject);
                
            }

            _listings.Clear();

            _text.text = myListOfLists.title[index];

            for (int i = 0; i < myListOfLists.mainList[index].Count; i++)
            {
                Qlistings listing = Instantiate(button, _content);
                if (listing != null)
                {
                    _listings.Add(listing);
                    listing.GetOrAddComponent<Qlistings>().SetupBtn(myListOfLists.mainList[index][i], myListOfLists.points[index][i]);
                }

            }

            //load
            //
            //foreach (string mulighed in myListOfLists.mainList[index])
            //{
            //    Qlistings listing = Instantiate(button, _content);
            //    if (listing != null)
            //    {
            //        _listings.Add(listing);
            //        listing.GetOrAddComponent<Qlistings>().answerTxt = mulighed;
            //    }


            //}

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

/*
public class Answer
{
    public Answer(string n, int v)
    {
        name = n;
        value = v;
    }
    public string name;
    public int value;

}
*/