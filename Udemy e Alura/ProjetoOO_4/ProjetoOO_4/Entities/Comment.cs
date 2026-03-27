using System;
using System.Collections.Generic;


namespace ProjetoOO_4.Entities
{
    class Comment
    {
        public string Text { get; set; }
        
        //CONSTRUTORES
        public Comment()
        {

        }
        public Comment(string text)
        {
            Text = text;
        }


    }
}
