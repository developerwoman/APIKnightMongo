using APIKnightMongo.Business.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;
using System.Net;

namespace APIKnightMongo.Business
{
    public class KnightBusiness : IKnightBusiness
    {
        /// <summary>
        /// Um knight só começa seu treinamento a partir dos 7 anos de idade.Antes disso, sua experiência de combate é 0.
        /// A experiência é dada por:
        /// exp = Math.floor((age - 7) * Math.pow(22, 1.45))
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<int> GetExperienceAsync()
        {


            throw new NotImplementedException();
        }
    }
}
