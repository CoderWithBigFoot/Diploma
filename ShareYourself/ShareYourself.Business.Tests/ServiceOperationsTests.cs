using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShareYourself.Business.Services;
using ShareYourself.Business.Dto;
using ShareYourself.Data;
using ShareYourself.Data.Entities;
using ShareYourself.Data.Contexts;
using ShareYourself.Business.Infrastructure.MapperProfiles;
using AutoMapper;

namespace ShareYourself.Business.Tests
{
    [TestClass]
    public class ServiceOperationsTests
    {
        [TestMethod]
        public void SplitTest()
        {
            char[] separators = new char[]
            {
               ',',' '
            };

            string testString = "Some_ , string _ ";

            var result = testString.Split(separators);
           
            

            Assert.AreEqual(result.Length, 6);
            CollectionAssert.Contains(result, "Some_");
            CollectionAssert.Contains(result, "string");
            CollectionAssert.Contains(result, "");
            CollectionAssert.Contains(result, "_");
        }

        [TestMethod]
        public void TakeTest()
        {
            List<int> collection = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            var result = collection
                .OrderByDescending(x=>x)
                .Skip(7)
                .Take(1)
                .FirstOrDefault();

            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TakeFresh_GetData_NotNull_NotZero()
        {
            Mapper.Initialize(cfg => 
            cfg.AddProfiles(
                typeof(UserPostMapperProfile),
                typeof(UserProfileMapperProfile)
            ));

            ShareYourselfContext context = new ShareYourselfContext("ShareYourself");
            IShareYourselfUow uow = new ShareYourselfUow(context);
            UserPostService service = new UserPostService(uow, null);

            var result = service.Take(PostFilters.Fresh, 2, 0, 5);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void TakeUpdates_GetData_NotNull_NotZero()
        {

        }         


    }
}
