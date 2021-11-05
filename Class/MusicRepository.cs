using System;
using System.Collections.Generic;
using DIO.Music.Interfaces;

namespace DIO.Music
{
    public class MusicRepository : IRepository<Music>
    {
      private List<Music> ListMusic = new List<Music>();
      public void Update(int id, Music entity)
      {
        ListMusic[id] = entity;
      }

      public void Delete(int id)
      {
        ListMusic[id].Delete();
      }

      public void Insert(Music entity)
      {
        ListMusic.Add(entity);
      }

      public List<Music> List()
      {
        return ListMusic;
      }

      public int NextId()
      {
        return ListMusic.Count;
      }

      public Music ReturnById(int id)
      {
        return ListMusic[id];
      }
    }
}
