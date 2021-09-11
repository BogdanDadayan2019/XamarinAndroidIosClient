using System.Collections.Generic;


namespace SharedProject
{
    public class Clothes<T>
    {
        public int id { get; set; }
        public string NameClothes { get; set; }
        public T bgImage { get; set; }
        public int idType { get; set; }



        public Clothes(string NameClothes, T bgImage, int idType, int id)
        {
            this.NameClothes = NameClothes;
            this.bgImage = bgImage;
            this.idType = idType;
            this.id = id;

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