using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareYourself.Data.Entities;

namespace ShareYourself.Business.Dto
{
    public class UserProfileDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Email { set; get; }
        public Gender? Gender { set; get; }
        DateTime? BirthDate { set; get; }
    }
}
