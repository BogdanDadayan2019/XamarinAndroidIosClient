using System.Collections.Generic;


namespace SharedProject
{
    public class Clothes<T>
    {
        public string NameClothes { get; set; }
        public T bgImage { get; set; }
        public int id { get; set; }

        public Clothes(string NameClothes, T bgImage)
        {
            this.NameClothes = NameClothes;
            this.bgImage = bgImage;
           
        }

        public Clothes(string NameClothes)
        {
            this.NameClothes = NameClothes;
           
        }

        public Clothes()
        {

        }
        
            
    }
}