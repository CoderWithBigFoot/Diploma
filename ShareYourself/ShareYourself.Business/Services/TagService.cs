﻿using System.Linq;
using ShareYourself.Data;
using ShareYourself.Data.Entities;
using AutoMapper;

namespace ShareYourself.Business.Services
{
    public class TagService : BaseService, ITagService
    {
        public TagService(IShareYourselfUow uow) : base(uow) { }

        public void Create<TDto>(TDto dto)
            where TDto : class
        {
            var tag = Mapper.Map<Tag>(dto);
            uow.TagsRepository.Add(tag);
            uow.Commit();
        }

        public TDto Get<TDto>(int id)
            where TDto : class
        {
            var tagDto = uow
                .TagsRepository
                .Get<TDto>(x => x.Id == id)
                .FirstOrDefault();

            return tagDto;
        }

        public TDto Get<TDto>(string tagName)
            where TDto : class
        {
            var tagDto = uow
                .TagsRepository
                .Get<TDto>(x => x.Name == tagName)
                .FirstOrDefault();

            return tagDto;
        }

        public bool Contains(string tagName)
        {
            return uow.TagsRepository.Get().Any(x => x.Name == tagName);
        }
    }
}
