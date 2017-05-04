using System;
using System.Collections.Generic;

namespace ShareYourself.Business.Dto
{
    public class UserPostCreationDto
    {
        public string Content { set; get; }
        public DateTime CreationDate { set; get; }
        public int CreatorId { set; get; }

        //public ICollection<TagDto> Tags { set; get; }
    }
}
