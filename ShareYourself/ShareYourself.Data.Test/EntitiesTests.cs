using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShareYourself.Data.Contexts;
using ShareYourself.Data.Entities;

namespace ShareYourself.Data.Test
{
    [TestClass]
    public class EntitiesTests
    {
        [TestMethod]
        public void FullInfoPostCreatingDeleting_Successful()
        {
            ShareYourselfContext context = new ShareYourselfContext("ShareYourself");

            UserProfile profile_1 = new UserProfile
            {
                RegistrationDate = DateTime.Now,
                Name = "For test name",
                Surname = "For test surname"
            };

            UserPost post_1 = new UserPost
            {
                Content = "Some content",
                Creator = profile_1
            };

            Tag tag_1 = new Tag
            {
                Name = "Some test tag"
            };

            post_1.Tags.Add(tag_1);


            try
            {
                context.Set<UserPost>()
                    .Add(post_1);
                context.SaveChanges();

                context.Set<UserPost>()
                    .Remove(post_1);

                context.Set<Tag>()
                    .Remove(tag_1);

                context.Set<UserProfile>()
                    .Remove(profile_1);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TagsCreatingDeleting_Successful()
        {
            ShareYourselfContext context = new ShareYourselfContext("ShareYourself");

            Tag tag = new Tag
            {
                Name = "Some test tag"
            };

            try
            {
                var set = context.Set<Tag>();

                set.Add(tag);
                context.SaveChanges();

                set.Remove(tag);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
