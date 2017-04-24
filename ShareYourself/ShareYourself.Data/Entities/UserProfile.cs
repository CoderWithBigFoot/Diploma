namespace ShareYourself.Data.Entities
{
    using System;
    using GenericRepository.Data.EntityFramework;

    public enum Gender { Male = 1, Female = 2 };

    public class UserProfile : Entity
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Email { set; get; }
        public Gender? Gender { set; get; }
        DateTime? BirthDate { set; get; }
    }
}
