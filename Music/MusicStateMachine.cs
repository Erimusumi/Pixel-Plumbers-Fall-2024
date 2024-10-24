using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Pixel_Plumbers_Fall_2024;


public class MusicStateMachine
{

    private List<Song> songList;
    private Song currentSong;

    public MusicStateMachine(ContentManager content)
    {
        songList = new List<Song>();
        currentSong = content.Load<Song>("Audio/Doom");
        songList.Add(currentSong);
        currentSong = content.Load<Song>("Audio/mario");
        songList.Add(currentSong);
        currentSong = content.Load<Song>("Audio/kirby");
        songList.Add(currentSong);
    }

    public Song current()
    {
        return songList[0];
    }

    public Song NextSong()
    {
        Song save = songList[0];
        songList.RemoveAt(0);
        songList.Add(save);
        return songList[0];
    }

}
