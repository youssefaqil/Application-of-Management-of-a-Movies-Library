//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieNetWcfService
{
    using System;
    using System.Collections.Generic;
    
    public partial class NoteSet
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public int Movie_Id { get; set; }
        public int User_Id { get; set; }
    
        public virtual MovieSet MovieSet { get; set; }
        public virtual UserSet UserSet { get; set; }
    }
}