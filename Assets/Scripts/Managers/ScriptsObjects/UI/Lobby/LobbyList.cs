using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class LobbyList : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;

    [SerializeField]
    private LobbyListing _lobbyListing;

    private List<LobbyListing> _listings = new List<LobbyListing>();

    private LobbyCanvases _lobbyCanvases;

    public void FirstInitialize(LobbyCanvases canvases)
    {
        _lobbyCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        _lobbyCanvases.NuværendeLobbyCanvas.Show();
        _content.DestroyChildren();
        _listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }


            else
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index != -1)
                {
                    LobbyListing listing = Instantiate(_lobbyListing, _content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        _listings.Add(listing);
                    }
                }
                
                    
            }
            
        }
    }

   

}
