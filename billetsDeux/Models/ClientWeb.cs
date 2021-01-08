using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace billetsDeux.Models
{
    public class ClientWeb
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Sexe { get; set; }
        public string Adresse { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "les mots de passe ne sont pas identiques !!")]
        public string VerificationPswd { get; set; }
        public string Image { get; set; }
    }
    public enum Genre
    {
        M,
        F,
        X
    }
}
