using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace JoJoMania.Models.Data.JoJoRepo
{
    public static class JoJoRepository
    {
        private static List<JoJo> _jojo;

        static JoJoRepository()
        {
            _jojo = new List<JoJo>
            {
                new JoJo {ID = 0, PartDebut = new Part {PartNumber = 0}, FirstName = "Undecided", LastName = ""},
                new JoJo {ID = 1, PartDebut = new Part() {PartNumber = 1}, Story = "Dio is literally the worst and ruins Johnathan's life. What a huge jerk.", FirstName = "Johnathan", LastName = "Joestar", Age = 20, ImageURL = new Uri("http://i1351.photobucket.com/albums/p796/Nepeta_Quest/JonathanP2_zpsxacrsjh8.png")},
                new JoJo {ID = 2, PartDebut = new Part() { PartNumber = 2}, Story = "Joseph and his bff Ceaser fight three different Mister Universe type guys to stop them from ruling the world with their muscles.", FirstName = "Joseph", LastName = "Joestar", Age = 18, ImageURL = new Uri("http://i1351.photobucket.com/albums/p796/Nepeta_Quest/JosephJoestar123_zps8fvop15o.png")},
                new JoJo {ID = 3, PartDebut = new Part() {PartNumber = 3}, Story = "Dio's back and, incredibly, even worse than before because of his newly discovered imaginary friend, The World. Jotaro has to stop him using his imaginary friend, Star Platinum.", FirstName = "Jotaro", LastName = "Kujo", Age = 17, ImageURL = new Uri("http://i1351.photobucket.com/albums/p796/Nepeta_Quest/jotaro_kujo_19368_zpsdgccjozw.jpg")},
                new JoJo {ID = 4, PartDebut = new Part() {PartNumber = 4}, Story = "Josuke and his friends Koichi and Okuyasu are sweet, precious cinammon rolls that are too good for this world - too pure.", FirstName = "Josuke", LastName = "Higashikata", Age = 16, ImageURL = new Uri("http://i1351.photobucket.com/albums/p796/Nepeta_Quest/Josuke_Higashikata_zpsyv7ehx2u.png")},
                new JoJo {ID = 5, PartDebut = new Part() {PartNumber = 5}, Story = "Giorno's ability is way too overpowered - please nerf.", FirstName = "Giorno", LastName = "Giovanna", Age = 15, ImageURL = new Uri("http://i1351.photobucket.com/albums/p796/Nepeta_Quest/Giornocolorat1_zpsaeclfj0t.png")},
                new JoJo {ID = 6, PartDebut = new Part() {PartNumber = 6}, Story = "Jolyne will kick anyone's ass. She'll kick your ass. She'll kick my ass. She'll kick her own ass.", FirstName = "Jolyne", LastName = "Cujoh", Age = 19, ImageURL = new Uri("http://i1351.photobucket.com/albums/p796/Nepeta_Quest/JolyneKujoPro_zpsqr42llif.png")},
                new JoJo {ID = 7, PartDebut = new Part() {PartNumber = 7}, Story = "Johnny participates in a horse race. The race was planned by the president of the United States in order to find and collect the remains of Jesus Christ in order to gain infinite power for himself.", FirstName = "Johnny", LastName = "Joestar", Age = 19, ImageURL = new Uri("http://i1351.photobucket.com/albums/p796/Nepeta_Quest/Johnnypro_zpstv7dvqgl.png")},
                new JoJo {ID = 8, PartDebut = new Part() {PartNumber = 8}, Story = "Jo2uke is a fusion of two different people but can't remember anything about his past. He has 4 balls and 2 dicks. I am not making this up. This is actual canonical story material.", FirstName = "Josuke", LastName = "Higashikata", Age = 19, ImageURL = new Uri("http://i1351.photobucket.com/albums/p796/Nepeta_Quest/tumblr_monhe3eHXj1s1994eo1_500_zpsypluml7f.jpg")}
            };
        }

        public static IEnumerable<JoJo> GetAll()
        {
            return _jojo;
        }

        public static JoJo Get(int id)
        {
            return _jojo.FirstOrDefault(j => j.ID == id);
        }

        public static void Add(string joJoFirstName, string joJoLastName)
        {
            JoJo jojo = new JoJo();
            jojo.FirstName = joJoFirstName;
            jojo.LastName = joJoLastName;
            jojo.ID = _jojo.Max(j => j.ID) + 1;

            _jojo.Add(jojo);
        }

        public static void Edit(JoJo jojo)
        {
            var selectedJoJo = _jojo.FirstOrDefault(j => j.ID == jojo.ID);
            selectedJoJo.FirstName = jojo.FirstName;
            selectedJoJo.LastName = jojo.LastName;
            selectedJoJo.PartDebut = jojo.PartDebut;
            selectedJoJo.Age = jojo.Age;
        }

        public static void Delete(int id)
        {
            _jojo.RemoveAll(j => j.ID == id);
        }
    }
}