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
    private RundeFærdig _rundeFærdig;
    public RundeFærdig RundeFærdig { get { return _rundeFærdig; } }

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
    string spørgsmål;
    ListOfListsStruct myListOfLists;

    

    public TextMeshProUGUI _text;


    void Awake()
    {
        


        myListOfLists.valgtKategorier = new List<int>();
        // Opret en liste af lister
        myListOfLists.mainList = new List<List<string>>();
        myListOfLists.points = new List<List<int>>();

        //lister i listen
        myListOfLists.title = new List<string> { "Øer i Danmark", " Hajarter", "Kortspil", "Nobelfredspris vindere", "Wimbledon vindere", "VM i fodbold vindere", "Lande i kontinentet Asien", "Karakterer i Harry Potter", "Superhelte fra Marvel", "Sportsgrene der indgår boldspil", "Kræfttyper", "Haribo slik varianter", "Mandlige oscarvindere", "Superhelte fra DC", "Karakterer fra Batman universet", "Frugter / bær med ordet bær i", "Danske landsholdspillere i fodbold de sidste 5 år", "Rasmus Seebach sange", "Officielle sprog i Europa", "Danske kommuner der begynder med R" };

        // Øer i Danmark
        myListOfLists.mainList.Add(new List<string> { "Sjælland", "Fyn", "Lolland", "Falster", "Bornholm", "Thurø", "Jylland", "Bogø", "Rømø", "Læsø", "Femø","Samsø", "Tåsinge", "Christiansø", "Langeland" });
        myListOfLists.points.Add(new List<int> { 94, 85, 37, 45, 90, 0, 100, 27, 10, 24, 0, 18, 6, 2, 62 });

        // Hajarter
        myListOfLists.mainList.Add(new List<string> { "Hvidhaj", "Hammerhaj", "Rødhaj", "Pighaj","Tigerhaj","Hvalhaj","Megalodon", "Hajhval", "Savhaj","Cookiecutterhaj","Sorthaj","Afrohaj","Stjernehaj", "Grønlandshaj", "Blåhaj" });
        myListOfLists.points.Add(new List<int> { 97, 89, 4, 32, 71, 20, 15, 100, 6, 2, 0, 100, 0, 12, 44 });

        // Kortspil
        myListOfLists.mainList.Add(new List<string> { "Krig", "Fisk", "500", "100", "Røvhul","Poker","Blackjack","Kasino","Hjerterfri","Kabale","Uno","Vandfald","Whist","Bridge","Gammel Jomfru" });
        myListOfLists.points.Add(new List<int> { 92, 98, 52, 5, 57, 63, 76, 13, 21, 34, 100, 19, 3, 0, 0 });

        // Nobelfredspris vindere
        myListOfLists.mainList.Add(new List<string> { "Barack Obama", "Nelson Mandela", "Jimmy Carter","Malala Yousafzai","Kofi Annan","Moder Teresa","Al Gore","Albert Einstein","Rosa Parks","Niels Bohr","Denis Mukwege","Narges Mohammadi","Juan Manuel Santos","Dmitrij Muratov","Jody Williams", });
        myListOfLists.points.Add(new List<int> { 86, 98, 13, 23, 19, 35, 41, 100, 100, 100, 0, 0, 7, 0, 17 });

        // Wimbledon vindere
        myListOfLists.mainList.Add(new List<string> { "Novak Djokovic", "Roger Federer", "Carlos Alcaraz","Holger Rune","Andy Murray", "Bjorn Borg","Rafael Nadal","John Mcenroe","Lleyton Hewitt","Pete Sampras","Boris Becker","Fred Perry","Lawrence Doherty","Nick Kyrgios","Daniil Medvedev", });
        myListOfLists.points.Add(new List<int> { 96, 84, 56, 100, 78, 24, 92, 35, 0, 13, 0, 2, 0, 100, 100 });

        // VM i fodbold vindere
        myListOfLists.mainList.Add(new List<string> { "Italien", "Spanien", "Tyskland", "Argentina", "Frankrig", "England", "Danmark","Japan","Uruguay","Brasilien","Portugal","Holland","Belgien","Egypten","Kroatien" }); 
        myListOfLists.points.Add(new List<int> { 65, 72, 88, 92, 96, 77, 100, 100, 15, 56, 100, 100, 100, 100, 100 });

        // Lande i kontinentet Asien
        myListOfLists.mainList.Add(new List<string> { "Kina", "Indien", "Pakistan","Afghanistan","Albanien","Japan","Australien","Sri Lanka","Mongoliet","Vietnam","Thailand","Kazhakstan","Armenien","Singapore","Bhutan" });
        myListOfLists.points.Add(new List<int> { 95, 87, 40, 32, 100, 99, 100, 17, 78, 67, 72, 49, 34, 57, 0 });

        // Karakterer i Harry Potter
        myListOfLists.mainList.Add(new List<string> { "Ron Weasley", "Hermione Granger", "Harry Potter","Snape","Voldemort","Dumbledore","Malfoy","Hagrid","Dobby","Sirius Black","Neville Longbottom","Nymphadora Tonks","Mad-Eye","Gandalf","Schmiegel" });
        myListOfLists.points.Add(new List<int> { 86, 89, 99, 69, 81, 75, 56, 41, 34, 51, 20, 0, 12, 100, 100 });

        // Superhelte fra Marvel
        myListOfLists.mainList.Add(new List<string> { "Captain America", "Black Widow", "Star Lord", "Spiderman","Ironman","Hulk","Hawkeye","Thor","Vision","Falcon","Dr. Strange","Black Panther","Ultron","Thanos","Miles Morales" });
        myListOfLists.points.Add(new List<int> { 96, 82, 38, 93, 99, 88, 67, 91, 43, 31, 56, 49, 100, 100, 0 });

        // Sportsgrene der indgår boldspil
        myListOfLists.mainList.Add(new List<string> { "Fodbold", "Tennis", "Kroket", "Bordtennis","Golf","Rundbold","Håndbold","Badminton","Basketball","Padeltennis","Lacrosse","Vandpolo","Squash","Dart","Ishockey" });
        myListOfLists.points.Add(new List<int> { 99, 92, 43, 26, 42, 8, 78, 15, 87, 21, 0, 4, 0, 100, 100 });

        // Kræfttyper
        myListOfLists.mainList.Add(new List<string> { "Lungekræft", "Lymfekræft", "Strubekræft", "Testikelkræft", "Prostatakræft", "Blodkræft", "Hjernekræft", "Brystkræft", "Hudkræft", "Tarmkræft", "Rygsøjlekræft", "Modermærkekræft","Æggestokskræft","Fingerkræft","Tåkræft" }) ;
        myListOfLists.points.Add(new List<int> { 92, 68, 85, 93, 74, 47, 56, 79, 36, 24, 12, 0, 0, 100, 100 });

        // Haribo slik varianter
        myListOfLists.mainList.Add(new List<string> { "Stjernemix", "Labrelarver", "Matadormix","Piratos","Poletter","Clickmix","Vingummibamser","Matador darkmix","Flagermus","Pingviner","Top starmix","Softy mix","Skippermix","Familieguf","Bilar" });
        myListOfLists.points.Add(new List<int> { 97, 77, 94, 47, 35, 69, 57, 51, 32, 7, 23, 0, 0, 100, 100 });

        // Mandlige oscarvindere
        myListOfLists.mainList.Add(new List<string> { "Brad Pitt", "Leonardo Di Caprio", "Tom Cruise", "Tom Hanks", "Robert Downey Junior", "Christian Bale", "Matthew Mcconaughey", "Heath Ledger", "Will Smith", "Javier Bardem", "Joaquin Phoenix", "Bryan Cranston", "Anthony Hopkins", "Mads Mikkelsen", "Jim Carrey" }) ;
        myListOfLists.points.Add(new List<int> { 92, 95, 85, 89, 74, 69, 81, 46, 89, 9, 0, 12, 0, 100, 100 });

        // Superhelte fra DC
        myListOfLists.mainList.Add(new List<string> { "Batman", "Superman", "Green Lantern", "Robin", "The Flash", "Wonderwoman", "Shazam", "Black Adam", "Raven","Starfire","Beastboy","Joker","Deadpool","Arsenal","Red Hood" }) ;
        myListOfLists.points.Add(new List<int> { 98, 96, 76, 75, 60, 71, 83, 43, 24, 16, 35, 39, 100, 100, 0, 0 });

        // Karakterer fra Batman universet
        myListOfLists.mainList.Add(new List<string> { "Batman", "The Riddler", "Joker", "Bane","Mr. Freeze","Poison Ivy","Two Face","Catwoman","Harley Quinn","Jim Gordon","Alfred","Scarecrow","Thomas Wayne","Wolverine","Lucius Fox" });
        myListOfLists.points.Add(new List<int> { 100, 76, 99, 87, 82, 71, 92, 95, 89, 43, 56, 23, 5, 100, 0 });

        // Frugter / bær med ordet bær i
        myListOfLists.mainList.Add(new List<string> { "Hindbær", "Brombær", "Jordbær", "Ranglebær","Skovbær","Blåbær","Stikkelsbær","Tyttebær","Solbær","Kirsebær","Enebær","Tranebær","Multebær","Morbær","Boysenbær" });
        myListOfLists.points.Add(new List<int> { 99, 79, 98, 100, 100, 75, 62, 43, 33, 78, 7, 58, 0, 0, 23 });

        // Danske landsholdspillere i fodbold de sidste 5 år
        myListOfLists.mainList.Add(new List<string> { "Christian Eriksen", "Kasper Schmeichel", "Robert Skov","Elias Jelert","Thomas Delaney","Rasmus Højlund","John Faxe Jensen","Andreas Christensen","Mohammed Daramy","Christian Nørgaard","Pierre-Emil Højbjerg","Simon Kjær","Mathias Zanka","Mikkel Damsgaard","Lukas Lerager" });
        myListOfLists.points.Add(new List<int> { 98, 92, 42, 4, 85, 79, 100, 56, 0, 16, 67, 78, 0, 36, 100 });

        // Rasmus Seebach sange
        myListOfLists.mainList.Add(new List<string> { "Øde ø", "Natteravn", "Olivia", "Lidt i 5", "Millionær", "Tusind farver", "Livstegn", "Engel", "Zombie", "Farlig", "Falder", "Lovesong", "Du en ener", "Din forevigt", "Under Stjernerne på himlen" });
        myListOfLists.points.Add(new List<int> { 93, 89, 82, 76, 84, 53, 23, 64, 9, 18, 29, 0, 100, 100, 0 });

        // Officielle sprog i Europa
        myListOfLists.mainList.Add(new List<string> { "Engelsk", "Dansk", "Tysk", "Svensk","Norsk","Flamsk","Fransk","Polsk","Italiensk","Spansk","Arabisk","Persisk","Maltesisk","Slovakisk","Lettisk" });
        myListOfLists.points.Add(new List<int> { 96, 99, 89, 75, 72, 32, 67, 45, 82, 86, 100, 100, 0, 0, 8 });

        // Danske kommuner der begynder med R
        myListOfLists.mainList.Add(new List<string> { "Roskilde kommune", "Ringsted kommune", "Randers kommune", "Ringkøbing-Skjern kommune","Risskov kommune","Rebild kommune","Rudersdal kommune","Rødovre kommune","Rønne kommune","Rømø kommune","Rødby kommune","Rødekro kommune","Ringe kommune","Rungsted kommune","Ringkøbing kommune" });
        myListOfLists.points.Add(new List<int> { 95, 86, 91, 32 , 14, 0, 0, 46, 100, 100, 100, 100, 100, 100, 100  });

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
            photonView.RPC("CallRPCFunction", RpcTarget.AllBuffered, randomIndex);
            Debug.Log(randomIndex);
           

            for (int i = 0; i < myListOfLists.mainList[randomIndex].Count; i++)
            {
                Qlistings listing = Instantiate(button, _content);
                if (listing != null)
                {
                    _listings.Add(listing);
                    listing.GetOrAddComponent<Qlistings>().SetupBtn(myListOfLists.mainList[randomIndex][i], myListOfLists.points[randomIndex][i]);
                }

            }

            

        }
    }
   
    

    [PunRPC]
    public void CallRPCFunction(int i)
    {

        ChangeScreen(i);
        // Gør noget med det modtagne parameter
        Debug.Log("Modtaget parameter: " + i);
    }

    public void ChangeScreen(int index)
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            RundeFærdig.Hide();
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