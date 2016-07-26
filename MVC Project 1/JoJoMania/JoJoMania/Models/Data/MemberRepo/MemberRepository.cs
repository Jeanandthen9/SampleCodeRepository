using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoJoMania.Models.Data.JoJoRepo;
using JoJoMania.Models.Data.PartRepo;

namespace JoJoMania.Models.Data.MemberRepo
{
    public class MemberRepository
    {
        private static List<Member> _members;

        static MemberRepository()
        {
            _members = new List<Member>
            {
                new Member
                {
                    UserID = 1,
                    UserName = "xxDIO_iz_B3STxx",
                    Age = 21,
                    FavJoJo = JoJoRepository.Get(1),
                    FavPart = PartRepository.Get(1)
                },
                new Member
                {
                    UserID = 2,
                    UserName = "yareYareDaze",
                    Age = 19,
                    FavJoJo = JoJoRepository.Get(3),
                    FavPart = PartRepository.Get(3)
                },
                new Member
                {
                    UserID = 3,
                    UserName = "HadAKarsAccident",
                    Age = 65,
                    FavJoJo = JoJoRepository.Get(2),
                    FavPart = PartRepository.Get(4)
                }
            };
        }

        public static IEnumerable<Member> GetAll()
        {
            return _members;
        }

        public static Member Get(int memberID)
        {
            return _members.FirstOrDefault(m => m.UserID == memberID);
        }

        public static void Add(Member member)
        {
            if (_members.Count == 0)
            {
                member.UserID = 1;
            }
            else
            {
                member.UserID = _members.Max(n => n.UserID) + 1;
            }
            
            _members.Add(member);
        }

        public static void Edit(Member member)
        {
            var selectedMember = _members.First(m => m.UserID == member.UserID);

            selectedMember.UserID = member.UserID;
            selectedMember.Age = member.Age;
            selectedMember.UserName = member.UserName;
            selectedMember.FavPart = member.FavPart;
            selectedMember.FavJoJo = member.FavJoJo;
        }

        public static void Delete(int id)
        {
            _members.RemoveAll(m => m.UserID == id);
        }
    }
}