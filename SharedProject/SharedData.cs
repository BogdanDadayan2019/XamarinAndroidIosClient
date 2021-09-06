﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject
{
    class SharedData<T>
    {
        public List<Clothes<T>> clothes = new List<Clothes<T>>();

        public void AddClothesForList(string Name, T bgImage)
        {
            clothes.Add(new Clothes<T>(Name, bgImage));
       
        }
    }
}
