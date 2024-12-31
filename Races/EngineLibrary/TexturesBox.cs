using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace EngineLibrary
{
    public class TexturesBox : IDisposable
    {
        public Texture2D Texture { get; private set; }

        private Dictionary<string, Texture2D> TextureDictionary;

        float delta = 0;

        float currTime = 0;

        public TexturesBox(Texture2D texture)
        {
            TextureDictionary = new Dictionary<string, Texture2D>();

            TextureDictionary.Add("default", texture);

            Texture = texture;
        }

        public TexturesBox()
        {
            TextureDictionary = new Dictionary<string, Texture2D>();
        }

        public void Add(string name, Texture2D texture2D)
        {
            TextureDictionary.Add(name, texture2D);
        }

        public void Del(string name)
        {
            TextureDictionary.Remove(name);
        }

        public void Edit(Texture2D texture2D, string name)
        {
            TextureDictionary[name] = texture2D;
        }

        public void Set(string name)
        {
            if (Time.CurrentTime - currTime >= delta)
            {
                Texture = TextureDictionary[name];

                currTime = Time.CurrentTime;

                delta = 0;
            }

            //changeTime -= 1;
        }

        public void Set(string name, float delta)
        {
            if (Time.CurrentTime - currTime >= this.delta)
            {
                Texture = TextureDictionary[name];

                this.delta = delta;
                currTime = Time.CurrentTime;
            }

            //changeTime -= 1;
        }

        public List<int> GetIdTextures()
        {
            List<int> result = new List<int>(10);

            foreach (var textur in TextureDictionary)
                result.Add(textur.Value.ID);

            return result;
        }

        public void PlayAnimation()
        {
            //changeTime -= 1; 

            //if (changeTime == 0) return;

            //Texture = animations[currentAnimation].GetSpriteFromAnimation();
        }

        public void Dispose()
        {
            ContentPipe.DeletTexture(GetIdTextures());
            TextureDictionary.Clear();
        }
    }
}
