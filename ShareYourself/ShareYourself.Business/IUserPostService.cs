﻿using System;
using System.Collections.Generic;
using ShareYourself.Business.Dto;

namespace ShareYourself.Business
{
    public interface IUserPostService : IBaseOperations
    {
        new void Create<TDto>(TDto dto) where TDto : UserPostCreationDto;
        IEnumerable<UserPostDto> Take(int userId, int skip, int count);
    }
}