using System.Collections.Generic;


namespace SharedProject
{
    public class Clothes<T>
    {
        public string Name { get; set; }
        public T bgImage { get; set; }

        public Clothes(string Name, T bgImage)
        {
            this.Name = Name;
            this.bgImage = bgImage;
        }
    }
}